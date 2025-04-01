//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Emgu.CV.CvEnum;
//using Emgu.CV;
//using OcrLiteLib;

//namespace OcrLib
//{
//    class OcrLite2
//    {
//        public bool isPartImg { get; set; }
//        public bool isDebugImg { get; set; }

//        private DbNet dbNet;
//        private CrnnNet crnnNet1;
//        private CrnnNet crnnNet2;
//        1
//        public OcrLite2()
//        {
//            dbNet = new DbNet();
//            crnnNet1 = new CrnnNet();
//            crnnNet2 = new CrnnNet();
//        }

//        public void InitModels(string detPath, string rec1Path, string rec2Path, string keys1Path, string keys2Path, int numThread)
//        {
//            try
//            {
//                dbNet.InitModel(detPath, numThread);
//                crnnNet1.InitModel(rec1Path, keys1Path, numThread);
//                crnnNet2.InitModel(rec2Path, keys2Path, numThread);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message + ex.StackTrace);
//                throw ex;
//            }
//        }

//        public OcrResult Detect(string img, int padding, int maxSideLen, float boxScoreThresh, float boxThresh,
//                              float unClipRatio)
//        {
//            Mat originSrc = CvInvoke.Imread(img, ImreadModes.Color);//default : BGR
//            int originMaxSide = Math.Max(originSrc.Cols, originSrc.Rows);

//            int resize = (maxSideLen <= 0 || maxSideLen > originMaxSide) ? originMaxSide : maxSideLen;
//            resize += 2 * padding;

//            Rectangle paddingRect = new Rectangle(padding, padding, originSrc.Cols, originSrc.Rows);
//            Mat paddingSrc = OcrUtils.MakePadding(originSrc, padding);

//            ScaleParam scale = ScaleParam.GetScaleParam(paddingSrc, resize);

//            return DetectOnce(paddingSrc, paddingRect, scale, boxScoreThresh, boxThresh, unClipRatio);
//        }

//        private OcrResult DetectOnce(Mat src, Rectangle originRect, ScaleParam scale, float boxScoreThresh, float boxThresh,
//                      float unClipRatio)
//        {
//            Mat textBoxPaddingImg = src.Clone();
//            int thickness = OcrUtils.GetThickness(src);
//            Stopwatch totalWatch = Stopwatch.StartNew();
//            long startTicks = DateTime.Now.Ticks;

//            int imgWidth = src.Width;
//            int imgHeight = src.Height;

//            // 1. ROI 영역 비율 정의
//            var roiRatios = new List<(float x, float y, float width, float height)>
//            {
//                //x, y ,width ,height
//                //(0.56f, 0.21f, 0.27f, 0.08f), // 일련번호
//                (0.26f, 0.27f, 0.4f, 0.17f),       // 금액
//                //(0f, 0.8f, 1f, 0.5f)       // MICR
//            };

//            // 2. 각 ROI 영역 및 대응 모델 설정
//            var roiSettings = new List<(Rectangle roi, CrnnNet model)>();
//            var last = roiRatios.Count;
//            for (int i = 0; i < roiRatios.Count; i++)
//            {
//                var (xRatio, yRatio, wRatio, hRatio) = roiRatios[i];

//                int x = (int)(xRatio * imgWidth);
//                int y = (int)(yRatio * imgHeight);
//                int w = (int)((wRatio > 0 ? wRatio : 1 - xRatio) * imgWidth);
//                int h = (int)((hRatio > 0 ? hRatio : 1 - yRatio) * imgHeight);

//                Rectangle roi = Rectangle.Intersect(new Rectangle(x, y, w, h), new Rectangle(0, 0, imgWidth, imgHeight));

//                CrnnNet model = (i == last) ? crnnNet2 : crnnNet1; // 세 번째(MICR)만 모델2 사용

//                roiSettings.Add((roi, model));
//            }

//            // 3. ROI 기반 탐지 및 인식
//            var filteredTextBoxes = new List<TextBox>();
//            var recogModels = new List<CrnnNet>();

//            foreach (var (roi, model) in roiSettings)
//            {
//                Mat cropped = new Mat(src, roi);
//                ScaleParam roiScale = ScaleParam.GetScaleParam(cropped, Math.Max(roi.Width, roi.Height));

//                var boxes = dbNet.GetTextBoxes(cropped, roiScale, boxScoreThresh, boxThresh, unClipRatio);

//                foreach (var box in boxes)
//                {
//                    var newPoints = new List<Point>();
//                    foreach (var pt in box.Points)
//                    {
//                        newPoints.Add(new Point(pt.X + roi.X, pt.Y + roi.Y));
//                    }
//                    box.Points = newPoints;

//                    filteredTextBoxes.Add(box);
//                    recogModels.Add(model);
//                }
//            }

//            // 4. 텍스트 인식
//            var partImages = OcrUtils.GetPartImages(src, filteredTextBoxes);
//            if (isPartImg)
//            {
//                for (int i = 0; i < partImages.Count; i++)
//                {
//                    CvInvoke.Imshow($"PartImg({i})", partImages[i]);
//                }
//            }

//            var textLines = new List<TextLine>();
//            for (int i = 0; i < partImages.Count; i++)
//            {
//                textLines.Add(recogModels[i].GetTextLine(partImages[i]));
//            }

//            // 5. 결과 조합
//            var textBlocks = new List<TextBlock>();
//            for (int i = 0; i < textLines.Count; i++)
//            {
//                textBlocks.Add(new TextBlock
//                {
//                    BoxPoints = filteredTextBoxes[i].Points,
//                    BoxScore = filteredTextBoxes[i].Score,
//                    Text = textLines[i].Text,
//                    CharScores = textLines[i].CharScores,
//                    CrnnTime = textLines[i].Time
//                });
//            }

//            OcrUtils.DrawTextBoxes(textBoxPaddingImg, filteredTextBoxes, thickness);
//            totalWatch.Stop();

//            return new OcrResult
//            {
//                TextBlocks = textBlocks,
//                DbNetTime = (DateTime.Now.Ticks - startTicks) / 10000F,
//                BoxImg = new Mat(textBoxPaddingImg, originRect),
//                StrRes = string.Join(Environment.NewLine, textBlocks.ConvertAll(tb => tb.Text)),
//                DetectTime = totalWatch.ElapsedMilliseconds
//            };
//        }
//    }
//}
