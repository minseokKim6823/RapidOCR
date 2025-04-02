using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using Emgu.CV.Structure;

namespace OcrLiteLib
{
    public class OcrLite
    {
        public bool isPartImg { get; set; }
        public bool isDebugImg { get; set; }

        private int padding = 0;
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

        public OcrResult DetectFilter(object img, int padding, int maxSideLen, float boxScoreThresh, float boxThresh, float unClipRatio, List<(float x, float y, float width, float height)> roiRatios)
        {

            Mat src;

            if(img is string path)
            {
                src = CvInvoke.Imread(path, ImreadModes.Color);
            }
            else if (img is Mat mat)
            {
                src = mat;
            }
            else
            {
                throw new ArgumentException("img는 string or Mat");
            }

            int originMaxSide = Math.Max(src.Cols, src.Rows);

            int resize = (maxSideLen <= 0 || maxSideLen > originMaxSide) ? originMaxSide : maxSideLen;
            resize += 2 * padding;

            Rectangle paddingRect = new Rectangle(padding, padding, src.Cols, src.Rows);
            Mat paddingSrc = OcrUtils.MakePadding(src, padding);

            ScaleParam scale = ScaleParam.GetScaleParam(paddingSrc, resize);

            return DetectOnce1(paddingSrc, paddingRect, scale, boxScoreThresh, boxThresh, unClipRatio, roiRatios);
        }
        
        public OcrResult DetectCrop(object img, int padding, int maxSideLen, float boxScoreThresh, float boxThresh, float unClipRatio, List<(float x, float y, float width, float height)> roiRatios)
        {
            Mat src;

            if (img is string path)
            {
                src = CvInvoke.Imread(path, ImreadModes.Color);
            }
            else if (img is Mat mat)
            {
                src = mat;
            }
            else
            {
                throw new ArgumentException("img는 string or Mat");
            }

            int originMaxSide = Math.Max(src.Cols, src.Rows);

            int resize = (maxSideLen <= 0 || maxSideLen > originMaxSide) ? originMaxSide : maxSideLen;
            resize += 2 * padding;

            Rectangle paddingRect = new Rectangle(padding, padding, src.Cols, src.Rows);
            Mat paddingSrc = OcrUtils.MakePadding(src, padding);

            ScaleParam scale = ScaleParam.GetScaleParam(paddingSrc, resize);

            return DetectOnce2(paddingSrc, paddingRect, scale, boxScoreThresh, boxThresh, unClipRatio, roiRatios);
        }

        public OcrResult DetectMask(object img, int padding, int maxSideLen, float boxScoreThresh, float boxThresh, float unClipRatio, List<(float x, float y, float width, float height)> roiRatios)
        {
            Mat src;

            if (img is string path)
            {
                src = CvInvoke.Imread(path, ImreadModes.Color);
            }
            else if (img is Mat mat)
            {
                src = mat;
            }
            else
            {
                throw new ArgumentException("img는 string or Mat");
            }
            int originMaxSide = Math.Max(src.Cols, src.Rows);

            Console.WriteLine(src.Width);
            int resize = (maxSideLen <= 0 || maxSideLen > originMaxSide) ? originMaxSide : maxSideLen;
            resize += 2 * padding;

            Rectangle paddingRect = new Rectangle(padding, padding, src.Cols, src.Rows);
            Mat paddingSrc = OcrUtils.MakePadding(src, padding);

            ScaleParam scale = ScaleParam.GetScaleParam(paddingSrc, resize);

            return DetectOnce3(paddingSrc, paddingRect, scale, boxScoreThresh, boxThresh, unClipRatio, roiRatios);
        }

        public OcrResult DetectNumber(object img, int padding, int maxSideLen, float boxScoreThresh, float boxThresh,float unClipRatio, List<(float x, float y, float width, float height)> roiRatios)
        {
            Mat src;

            
            if (img is string path)
            {
                src = CvInvoke.Imread(path, ImreadModes.Color);
            }
            else if (img is Mat mat)
            {
                src = mat;
            }
            else
            {
                throw new ArgumentException("img는 string or Mat");
            }
            int originMaxSide = Math.Max(src.Cols, src.Rows);

            int resize = (maxSideLen <= 0 || maxSideLen > originMaxSide) ? originMaxSide : maxSideLen;
            resize += 2 * padding;

            Rectangle paddingRect = new Rectangle(padding, padding, src.Cols, src.Rows);
            Mat paddingSrc = OcrUtils.MakePadding(src, padding);

            ScaleParam scale = ScaleParam.GetScaleParam(paddingSrc, resize);

            return DetectOnce4(paddingSrc, paddingRect, scale, boxScoreThresh, boxThresh, unClipRatio, roiRatios, false);
        }
        public OcrResult DetectMICR(object img, int padding, int maxSideLen, float boxScoreThresh, float boxThresh, float unClipRatio, List<(float x, float y, float width, float height)> roiRatios)
        {
            Mat src;

            if (img is string path)
            {
                src = CvInvoke.Imread(path, ImreadModes.Color);
            }
            else if (img is Mat mat)
            {
                src = mat;
            }
            else
            {
                throw new ArgumentException("img는 string or Mat");
            }

            int originMaxSide = Math.Max(src.Cols, src.Rows);

            int resize = (maxSideLen <= 0 || maxSideLen > originMaxSide) ? originMaxSide : maxSideLen;
            resize += 2 * padding;

            Rectangle paddingRect = new Rectangle(padding, padding, src.Cols, src.Rows);
            Mat paddingSrc = OcrUtils.MakePadding(src, padding);

            ScaleParam scale = ScaleParam.GetScaleParam(paddingSrc, resize);

            return DetectOnce4(paddingSrc, paddingRect, scale, boxScoreThresh, boxThresh, unClipRatio, roiRatios, true);
        }



        private OcrResult DetectOnce1(Mat src, Rectangle originRect, ScaleParam scale, float boxScoreThresh, float boxThresh,float unClipRatio, List<(float x, float y, float width, float height)> roiRatios){
            Mat textBoxPaddingImg = src.Clone();
            int thickness = OcrUtils.GetThickness(src);

            Console.WriteLine("=====Start detect=====");

            Stopwatch totalWatch = new Stopwatch();
            totalWatch.Start();

            var startTicks = DateTime.Now.Ticks;
            Console.WriteLine("---------- step: dbNet getTextBoxes ----------");

            var textBoxes = dbNet.GetTextBoxes(src, scale, boxScoreThresh, boxThresh, unClipRatio);
            var dbNetTime = (DateTime.Now.Ticks - startTicks) / 10000F; //탐색 속도

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
            };
            Rectangle micrRoi = roiRects.Count > 2 ? roiRects[2] : Rectangle.Empty;

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

            List<string> modelTypes = new List<string>();

            for (int i = 0; i < partImages.Count; i++)
            {
                Rectangle boxRect = OcrUtils.GetBoundingBox(filteredTextBoxes[i].Points);
                bool isMicrBox = micrRoi.IntersectsWith(boxRect);

                var textLine = isMicrBox
                    ? crnnNet2.GetTextLine(partImages[i])  // MICR 영역
                    : crnnNet1.GetTextLine(partImages[i]); // 일반 영역


                textLines.Add(textLine);
                modelTypes.Add(isMicrBox ? "MICR" : "NUM");
            }

            // 최종 결과 조합
            List<TextBlock> textBlocks = new List<TextBlock>();

            for (int i = 0; i < textLines.Count; ++i)
            {
                textBlocks.Add(new TextBlock
                {
                    BoxPoints = filteredTextBoxes[i].Points,
                    BoxScore = filteredTextBoxes[i].Score,
                    Text = textLines[i].Text,
                    CharScores = textLines[i].CharScores,
                    CrnnTime = textLines[i].Time,
                    ModelType = modelTypes[i]
                });
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
        private OcrResult DetectOnce2(Mat src, Rectangle originRect, ScaleParam scale, float boxScoreThresh, float boxThresh, float unClipRatio, List<(float x, float y, float width, float height)> roiRatios)
        {
            Mat textBoxPaddingImg = src.Clone();
            int thickness = OcrUtils.GetThickness(src);
            Stopwatch totalWatch = Stopwatch.StartNew();
            long startTicks = DateTime.Now.Ticks;

            int imgWidth = src.Width;
            int imgHeight = src.Height;

            // 2. 각 ROI 영역 및 대응 모델 설정
            var roiSettings = new List<(Rectangle roi, CrnnNet model)>();;
            for (int i = 0; i < roiRatios.Count; i++)
            {
                var (xRatio, yRatio, wRatio, hRatio) = roiRatios[i];

                int x = (int)(xRatio * imgWidth);
                int y = (int)(yRatio * imgHeight);
                int w = (int)(wRatio * imgWidth);
                int h = (int)(hRatio * imgHeight);

                Rectangle roi = Rectangle.Intersect(new Rectangle(x, y, w, h), new Rectangle(0, 0, imgWidth, imgHeight));

                CrnnNet model = (i >= 2) ? crnnNet2 : crnnNet1; // 세 번째(MICR)만 모델2 사용

                roiSettings.Add((roi, model));
            }

            // 3. ROI 기반 탐지 및 인식
            var filteredTextBoxes = new List<TextBox>();
            var recogModels = new List<CrnnNet>();

            foreach (var (roi, model) in roiSettings)
            {
                Mat cropped = new Mat(src, roi);
                ScaleParam roiScale = ScaleParam.GetScaleParam(cropped, Math.Max(roi.Width, roi.Height));

                var boxes = dbNet.GetTextBoxes(cropped, roiScale, boxScoreThresh, boxThresh, unClipRatio);

                foreach (var box in boxes)
                {
                    var newPoints = new List<Point>();
                    foreach (var pt in box.Points)
                    {
                        newPoints.Add(new Point(pt.X + roi.X, pt.Y + roi.Y));
                    }
                    box.Points = newPoints;

                    filteredTextBoxes.Add(box);
                    recogModels.Add(model);
                }
            }

            // 4. 텍스트 인식
            var partImages = OcrUtils.GetPartImages(src, filteredTextBoxes);
            if (isPartImg)
            {
                for (int i = 0; i < partImages.Count; i++)
                {
                    CvInvoke.Imshow($"PartImg({i})", partImages[i]);
                }
            }

            var textLines = new List<TextLine>();
            for (int i = 0; i < partImages.Count; i++)
            {
                textLines.Add(recogModels[i].GetTextLine(partImages[i]));
            }

            // 5. 결과 조합
            var textBlocks = new List<TextBlock>();
            for (int i = 0; i < textLines.Count; i++)
            {
                textBlocks.Add(new TextBlock
                {
                    BoxPoints = filteredTextBoxes[i].Points,
                    BoxScore = filteredTextBoxes[i].Score,
                    Text = textLines[i].Text,
                    CharScores = textLines[i].CharScores,
                    CrnnTime = textLines[i].Time,
                    ModelType = recogModels[i] == crnnNet2 ? "MICR" : "NUM"
                });
            }

            OcrUtils.DrawTextBoxes(textBoxPaddingImg, filteredTextBoxes, thickness);
            totalWatch.Stop();

            return new OcrResult
            {
                TextBlocks = textBlocks,
                DbNetTime = (DateTime.Now.Ticks - startTicks) / 10000F,
                BoxImg = new Mat(textBoxPaddingImg, originRect),
                StrRes = string.Join(Environment.NewLine, textBlocks.ConvertAll(tb => tb.Text)),
                DetectTime = totalWatch.ElapsedMilliseconds
            };
        }

        private OcrResult DetectOnce3(Mat src, Rectangle originRect, ScaleParam scale, float boxScoreThresh, float boxThresh, float unClipRatio, List<(float x, float y, float width, float height)> roiRatios)
        {
            Mat textBoxPaddingImg = src.Clone();
            int thickness = OcrUtils.GetThickness(src);
            Stopwatch totalWatch = Stopwatch.StartNew();
            long startTicks = DateTime.Now.Ticks;

            int imgWidth = src.Width;
            int imgHeight = src.Height;

            // 1. ROI 영역 비율 정의
            //var roiRatios = new List<(float x, float y, float width, float height)>
            //{
            //    (0.58f, 0.21f, 0.2f, 0.08f), // 일련번호
            //    (0.28f, 0.29f, 0.4f, 0.12f),  // 금액
            //    (0f, 0.695f, 1f, 0f)          // MICR
            //};

            // 2. 마스킹을 위한 mask 생성
            var roiSettings = new List<(Rectangle roi, CrnnNet model)>();
            Mat mask = new Mat(src.Size, DepthType.Cv8U, 1);
            mask.SetTo(new MCvScalar(0)); // 전체 영역을 검정으로 막아두고

            for (int i = 0; i < roiRatios.Count; i++)
            {
                var (xRatio, yRatio, wRatio, hRatio) = roiRatios[i];

                Console.WriteLine("==================================");
                Console.WriteLine(imgHeight);
                Console.WriteLine(hRatio);
                int x = (int)(xRatio * imgWidth);
                int y = (int)(yRatio * imgHeight);
                int w = (int)(wRatio * imgWidth);
                int h = (int)(hRatio  * imgHeight);
                Console.WriteLine(h);
                Rectangle roi = Rectangle.Intersect(new Rectangle(x, y, w, h), new Rectangle(0, 0, imgWidth, imgHeight));

                // 마스크에서 ROI 영역만 흰색으로
                CvInvoke.Rectangle(mask, roi, new MCvScalar(255), -1);

                CrnnNet model = (i >= 2) ? crnnNet2 : crnnNet1;
                roiSettings.Add((roi, model));
            }

            // 3. 마스킹 적용
            Mat maskedSrc = new Mat();
            CvInvoke.BitwiseAnd(src, src, maskedSrc, mask);

            if (!isDebugImg)
            {
                CvInvoke.Imshow("Masked ROI Image", maskedSrc);
                CvInvoke.WaitKey(1); // 바로 사라지지 않도록
            }

            // 4. ROI 기반 탐지 및 인식
            var filteredTextBoxes = new List<TextBox>();
            var recogModels = new List<CrnnNet>();

            foreach (var (roi, model) in roiSettings)
            {
                Mat cropped = new Mat(maskedSrc, roi);
                ScaleParam roiScale = ScaleParam.GetScaleParam(cropped, Math.Max(roi.Width, roi.Height));

                var boxes = dbNet.GetTextBoxes(cropped, roiScale, boxScoreThresh, boxThresh, unClipRatio);

                foreach (var box in boxes)
                {
                    var newPoints = new List<Point>();
                    foreach (var pt in box.Points)
                    {
                        newPoints.Add(new Point(pt.X + roi.X, pt.Y + roi.Y));
                    }
                    box.Points = newPoints;

                    filteredTextBoxes.Add(box);
                    recogModels.Add(model);
                }
            }

            // 5. 텍스트 인식
            var partImages = OcrUtils.GetPartImages(src, filteredTextBoxes);
            if (isPartImg)
            {
                for (int i = 0; i < partImages.Count; i++)
                {
                    CvInvoke.Imshow($"PartImg({i})", partImages[i]);
                }
            }

            var textLines = new List<TextLine>();
            for (int i = 0; i < partImages.Count; i++)
            {
                textLines.Add(recogModels[i].GetTextLine(partImages[i]));
            }

            // 6. 결과 조합
            var textBlocks = new List<TextBlock>();
            for (int i = 0; i < textLines.Count; i++)
            {
              
                textBlocks.Add(new TextBlock
                {
                    BoxPoints = filteredTextBoxes[i].Points,
                    BoxScore = filteredTextBoxes[i].Score,
                    Text = textLines[i].Text,
                    CharScores = textLines[i].CharScores,
                    CrnnTime = textLines[i].Time,
                    ModelType = recogModels[i] == crnnNet2 ? "MICR" : "NUM"
                });
            }

            OcrUtils.DrawTextBoxes(textBoxPaddingImg, filteredTextBoxes, thickness);
            totalWatch.Stop();

            return new OcrResult
            {
                TextBlocks = textBlocks,
                DbNetTime = (DateTime.Now.Ticks - startTicks) / 10000F,
                BoxImg = new Mat(textBoxPaddingImg, originRect),
                StrRes = string.Join(Environment.NewLine, textBlocks.ConvertAll(tb => tb.Text)),
                DetectTime = totalWatch.ElapsedMilliseconds
            };
        }

        private OcrResult DetectOnce4(Mat src, Rectangle originRect, ScaleParam scale, float boxScoreThresh, float boxThresh, float unClipRatio,  List<(float x, float y, float width, float height)> roiRatios, bool useCrnnNet2 = false)
        {
            Mat textBoxPaddingImg = src.Clone();
            int thickness = OcrUtils.GetThickness(src);
            Stopwatch totalWatch = Stopwatch.StartNew();
            long startTicks = DateTime.Now.Ticks;

            Console.WriteLine("===== Start detect (full image) =====");

            // 1. 전체 이미지에서 텍스트 박스 탐지
            var textBoxes = dbNet.GetTextBoxes(src, scale, boxScoreThresh, boxThresh, unClipRatio);
            var dbNetTime = (DateTime.Now.Ticks - startTicks) / 10000F;

            // 2. 박스 유효성 검사 및 필터링 (사이즈 유효성만 확인)
            var filteredTextBoxes = new List<TextBox>();
            var recogModels = new List<CrnnNet>();
            foreach (var box in textBoxes)
            {
                if (box.Points == null || box.Points.Count == 0) continue;

                Rectangle boxRect = OcrUtils.GetBoundingBox(box.Points);
                if (boxRect.Width <= 0 || boxRect.Height <= 0) continue;

                filteredTextBoxes.Add(box);
            }

            // 3. 박스 기준 이미지 잘라내기
            List<Mat> partImages = OcrUtils.GetPartImages(src, filteredTextBoxes);

            if (isPartImg)
            {
                for (int i = 0; i < partImages.Count; i++)
                {
                    CvInvoke.Imshow($"PartImg({i})", partImages[i]);
                }
            }

            // 4. 텍스트 인식 (모두 crnnNet1 사용)
            List<TextLine> textLines = new List<TextLine>();
            foreach (var part in partImages)
            {
                if (useCrnnNet2)
                    textLines.Add(crnnNet2.GetTextLine(part)); // MICR 모드
                else
                    textLines.Add(crnnNet1.GetTextLine(part)); // 기본

            }


            // 5. 결과 조합
            var textBlocks = new List<TextBlock>();
            for (int i = 0; i < textLines.Count; i++)
            {
                textBlocks.Add(new TextBlock
                {
                    BoxPoints = filteredTextBoxes[i].Points,
                    BoxScore = filteredTextBoxes[i].Score,
                    Text = textLines[i].Text,
                    CharScores = textLines[i].CharScores,
                    CrnnTime = textLines[i].Time,
                    ModelType = recogModels[i] == crnnNet2 ? "MICR" : "NUM"
                });
            }

            // 6. 박스 시각화
            OcrUtils.DrawTextBoxes(textBoxPaddingImg, filteredTextBoxes, thickness);
            totalWatch.Stop();

            // 7. 결과 반환
            return new OcrResult
            {
                TextBlocks = textBlocks,
                DbNetTime = dbNetTime,
                BoxImg = new Mat(textBoxPaddingImg, originRect),
                StrRes = string.Join(Environment.NewLine, textBlocks.ConvertAll(tb => tb.Text)),
                DetectTime = totalWatch.ElapsedMilliseconds
            };
        }
    }
}