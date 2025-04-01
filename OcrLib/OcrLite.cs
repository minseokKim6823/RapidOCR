using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;

namespace OcrLiteLib
{
    public class OcrLite
    {
        public bool isPartImg { get; set; }
        public bool isDebugImg { get; set; }

        private DbNet dbNet;
        private CrnnNet crnnNet1;
        private CrnnNet crnnNet2;

        public OcrLite()
        {
            dbNet = new DbNet();
            crnnNet1 = new CrnnNet();
            crnnNet2 = new CrnnNet();
        }

        public void InitModels(string detPath, string rec1Path, string rec2Path, string keys1Path, string keys2Path, int numThread)
        {
            try
            {
                dbNet.InitModel(detPath, numThread);
                crnnNet1.InitModel(rec1Path, keys1Path, numThread);
                crnnNet2.InitModel(rec2Path, keys2Path, numThread);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                throw ex;
            }
        }

        public OcrResult Detect(string img, int padding, int maxSideLen, float boxScoreThresh, float boxThresh,
                              float unClipRatio, bool doAngle, bool mostAngle)
        {
            Mat originSrc = CvInvoke.Imread(img, ImreadModes.Color);//default : BGR
            int originMaxSide = Math.Max(originSrc.Cols, originSrc.Rows);

            int resize = (maxSideLen <= 0 || maxSideLen > originMaxSide) ? originMaxSide : maxSideLen;
            resize += 2 * padding;

            Rectangle paddingRect = new Rectangle(padding, padding, originSrc.Cols, originSrc.Rows);
            Mat paddingSrc = OcrUtils.MakePadding(originSrc, padding);

            ScaleParam scale = ScaleParam.GetScaleParam(paddingSrc, resize);

            return DetectOnce(paddingSrc, paddingRect, scale, boxScoreThresh, boxThresh, unClipRatio);
        }

        private OcrResult DetectOnce(Mat src, Rectangle originRect, ScaleParam scale, float boxScoreThresh, float boxThresh,
                      float unClipRatio)
        {
            Mat textBoxPaddingImg = src.Clone();
            int thickness = OcrUtils.GetThickness(src);

            Console.WriteLine("=====Start detect=====");

            Stopwatch totalWatch = new Stopwatch();
            totalWatch.Start();

            var startTicks = DateTime.Now.Ticks;
            Console.WriteLine("---------- step: dbNet getTextBoxes ----------");

            var textBoxes = dbNet.GetTextBoxes(src, scale, boxScoreThresh, boxThresh, unClipRatio);
            var dbNetTime = (DateTime.Now.Ticks - startTicks) / 10000F; //탐색 속도

            // 1. ROI 영역 비율 정의
            List<(float x, float y, float width, float height)> roiRatios = new List<(float, float, float, float)>
            {
                (0.76f, 0.25f, 0, 0.03f), // 일련번호 인식
                (0, 0.35f, 1, 0),//금액 인식
                (0, 0.8f, 1, 0.5f )//아래
            };

            // 2. 비율을 기준으로 실제 Rectangle 생성
            List<Rectangle> roiRects = new List<Rectangle>();
            int imgWidth = src.Width;
            int imgHeight = src.Height;
            Console.WriteLine($"imgWidth : {imgWidth}");
            Console.WriteLine($"imgHeight : {imgHeight}");
            Console.WriteLine($"src : {src}");


            foreach (var ratio in roiRatios)
            {
                int rectX = (int)(ratio.x * imgWidth);
                int rectY = (int)(ratio.y * imgHeight);
                int rectWidth = (int)(ratio.width * imgWidth);
                int rectHeight = (int)(ratio.height * imgHeight);

                roiRects.Add(new Rectangle(rectX, rectY, rectWidth, rectHeight));
            }
            ;

            // 이후 기존 로직 유지
            List<TextBox> filteredTextBoxes = new List<TextBox>();

            foreach (var box in textBoxes)
            {
                if (box.Points == null || box.Points.Count == 0)
                {
                    Console.WriteLine("Skipping box: no points.");
                    continue;
                }

                Rectangle boxRect = OcrUtils.GetBoundingBox(box.Points);
                if (boxRect.Width <= 0 || boxRect.Height <= 0)
                {
                    Console.WriteLine("Skipping box: invalid bounding box.");
                    continue;
                }

                bool intersectsAnyROI = roiRects.Exists(roi => roi.IntersectsWith(Rectangle.Round(boxRect)));

                if (intersectsAnyROI)
                {
                    filteredTextBoxes.Add(box);
                    Console.WriteLine($"Box added: {boxRect}");
                }
                else
                {
                    Console.WriteLine($"Box skipped (no ROI match): {boxRect}");
                }
            }

            // 3. 이후 과정은 필터링된 박스 기준으로만 수행!
            List<Mat> partImages = OcrUtils.GetPartImages(src, filteredTextBoxes);

            if (isPartImg)
            {
                for (int i = 0; i < partImages.Count; i++)
                {
                    CvInvoke.Imshow($"PartImg({i})", partImages[i]);
                }
            }

            List<TextLine> textLines = new List<TextLine>();

            Rectangle micrRoi = roiRects[2];

            for (int i = 0; i < partImages.Count; i++)
            {
                Rectangle boxRect = OcrUtils.GetBoundingBox(filteredTextBoxes[i].Points);
                bool isMicrBox = micrRoi.IntersectsWith(boxRect);

                var textLine = isMicrBox
                    ? crnnNet2.GetTextLine(partImages[i])  // MICR 영역
                    : crnnNet1.GetTextLine(partImages[i]); // 일반 영역


                textLines.Add(textLine);
            }

            // 최종 결과 조합
            List<TextBlock> textBlocks = new List<TextBlock>();

            for (int i = 0; i < textLines.Count; ++i)
            {
                TextBlock textBlock = new TextBlock
                {

                    BoxPoints = filteredTextBoxes[i].Points,
                    BoxScore = filteredTextBoxes[i].Score,
                    Text = textLines[i].Text,
                    CharScores = textLines[i].CharScores,
                    CrnnTime = textLines[i].Time,
                };

                textBlocks.Add(textBlock);
            }

            // 박스 시각화도 ROI 필터링된 것만 그린다!
            OcrUtils.DrawTextBoxes(textBoxPaddingImg, filteredTextBoxes, thickness);

            totalWatch.Stop();
            float totalTimeMs = totalWatch.ElapsedMilliseconds;

            Console.WriteLine($"===== 전체 인식 시간 : {totalTimeMs} ms =====");

            // 결과 반환
            return new OcrResult
            {
                TextBlocks = textBlocks,
                DbNetTime = dbNetTime,
                BoxImg = new Mat(textBoxPaddingImg, originRect),
                StrRes = string.Join(Environment.NewLine, textBlocks.ConvertAll(tb => tb.Text)),
                DetectTime = totalTimeMs
            };
        }

    }
}







//using Emgu.CV;
//using Emgu.CV.CvEnum;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Diagnostics;


//namespace OcrLiteLib
//{
//    public class OcrLite
//    {
//        public bool isPartImg { get; set; }
//        public bool isDebugImg { get; set; }
//        private DbNet dbNet;
//        private CrnnNet crnnNet1;
//        private CrnnNet crnnNet1;

//        public OcrLite()
//        {
//            dbNet = new DbNet();
//            crnnNet = new CrnnNet();
//        }

//        public void InitModels(string detPath, string rec1Path, string rec2Path, string keys1Path, string keys2Path, int numThread)
//        {
//            try
//            {
//                dbNet.InitModel(detPath, numThread);
//                crnnNet.InitModel(rec1Path, keys1Path, numThread);
//                crnnNet.InitModel(rec2Path, keys2Path, numThread);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message + ex.StackTrace);
//                throw ex;
//            }
//        }

//        public OcrResult Detect(string img, int padding, int maxSideLen, float boxScoreThresh, float boxThresh,
//                              float unClipRatio, bool doAngle, bool mostAngle)
//        {
//            Mat originSrc = CvInvoke.Imread(img, ImreadModes.Color);//default : BGR
//            int originMaxSide = Math.Max(originSrc.Cols, originSrc.Rows);

//            int resize;
//            if (maxSideLen <= 0 || maxSideLen > originMaxSide)
//            {
//                resize = originMaxSide;
//            }
//            else
//            {
//                resize = maxSideLen;
//            }
//            resize += 2 * padding;
//            Rectangle paddingRect = new Rectangle(padding, padding, originSrc.Cols, originSrc.Rows);
//            Mat paddingSrc = OcrUtils.MakePadding(originSrc, padding);

//            ScaleParam scale = ScaleParam.GetScaleParam(paddingSrc, resize);

//            return DetectOnce(paddingSrc, paddingRect, scale, boxScoreThresh, boxThresh, unClipRatio, doAngle, mostAngle);
//        }

//        private OcrResult DetectOnce(Mat src, Rectangle originRect, ScaleParam scale, float boxScoreThresh, float boxThresh,
//                              float unClipRatio, bool doAngle, bool mostAngle)
//        {
//            Mat textBoxPaddingImg = src.Clone();
//            int thickness = OcrUtils.GetThickness(src);
//            Console.WriteLine("=====Start detect=====");
//            Stopwatch totalWatch = new Stopwatch();
//            totalWatch.Start();

//            var startTicks = DateTime.Now.Ticks;

//            Console.WriteLine("---------- step: dbNet getTextBoxes ----------");
//            var textBoxes = dbNet.GetTextBoxes(src, scale, boxScoreThresh, boxThresh, unClipRatio);
//            var dbNetTime = (DateTime.Now.Ticks - startTicks) / 10000F;


//            List<Rectangle> roiRects = new List<Rectangle>
//            {
//                //x, y, width, height
//                new Rectangle(300, 150, 150, 10),
//                new Rectangle(600, 50, 50, 50),
//                new Rectangle(0, 350, 800, 100)
//            };


//            //List<TextBlock> filteredBlocks = new List<TextBlock>();
//            List<TextBox> filteredTextBoxes = new List<TextBox>();

//            foreach (var box in textBoxes)
//            {
//                if (box.Points == null || box.Points.Count == 0)
//                {
//                    Console.WriteLine("Skipping box: no points.");
//                    continue;
//                }

//                Rectangle boxRect = OcrUtils.GetBoundingBox(box.Points);

//                if (boxRect.Width <= 0 || boxRect.Height <= 0)
//                {
//                    Console.WriteLine("Skipping box: invalid bounding box.");
//                    continue;
//                }

//                bool intersectsAnyROI = roiRects.Exists(roi => roi.IntersectsWith(Rectangle.Round(boxRect)));

//                if (intersectsAnyROI)
//                {
//                    filteredTextBoxes.Add(box);
//                    Console.WriteLine($"Box added: {boxRect}");
//                }
//                else
//                {
//                    Console.WriteLine($"Box skipped (no ROI match): {boxRect}");
//                }
//            }

//            // 3. 이후 과정은 필터링된 박스 기준으로만 수행!
//            List<Mat> partImages = OcrUtils.GetPartImages(src, filteredTextBoxes);

//            if (isPartImg)
//            {
//                for (int i = 0; i < partImages.Count; i++)
//                {
//                    CvInvoke.Imshow($"PartImg({i})", partImages[i]);
//                }
//            }


//            List<TextLine> textLines = new List<TextLine>();

//            for (int i = 0; i < partImages.Count; i++)
//            {
//                Rectangle boxRect = OcrUtils.GetBoundingBox(filteredTextBoxes[i].Points);
//                float centerY = boxRect.Top + boxRect.Height / 2.0f;

//                float roiThresholdY = src.Height * 0.8f;

//                if (centerY >= roiThresholdY)
//                {
//                    textLines.Add(crnnNet2.GetTextLine(partImages[i])); // 아래쪽은 모델2
//                }
//                else
//                {
//                    textLines.Add(crnnNet1.GetTextLine(partImages[i])); // 나머지는 모델1
//                }
//            }

//            // 박스 시각화도 ROI 필터링된 것만 그린다!
//            OcrUtils.DrawTextBoxes(textBoxPaddingImg, filteredTextBoxes, thickness);

//            totalWatch.Stop();
//            float totalTimeMs = totalWatch.ElapsedMilliseconds;

//            Console.WriteLine($"===== 전체 인식 시간 : {totalTimeMs} ms =====");

//            // 결과 반환
//            OcrResult ocrResult = new OcrResult
//            {
//                TextBlocks = textBlocks,
//                DbNetTime = dbNetTime,
//                BoxImg = new Mat(textBoxPaddingImg, originRect),
//                StrRes = string.Join(Environment.NewLine, textBlocks.ConvertAll(tb => tb.Text)),
//                DetectTime = totalTimeMs
//            };

//            Console.WriteLine(ocrResult);
//            return ocrResult;
//        }

//    }
//}