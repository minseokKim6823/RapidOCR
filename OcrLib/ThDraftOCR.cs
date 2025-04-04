using System;
using System.Collections.Generic;
using System.Linq;
using Emgu.CV;
using OcrLiteLib;

namespace OcrLib
{
    public class ThDraftOCR
    {
        private OcrLite ocr;
        private SimpleConfig config;
        private string imgPath;
        private int maxSideLen;
        private List<(float x, float y, float width, float height)> roiRatios;
        private int padding;
            
        public ThDraftOCR()
        {
            ocr = new OcrLite();
            config = new SimpleConfig("config.ini");

            maxSideLen = config.GetInt("maxSideLen");
            int numThread = config.GetInt("numThread");
            padding = config.GetInt("padding");
            string detPath = config.Get("detPath");
            string rec1Path = config.Get("num_rec_path");
            string rec2Path = config.Get("micr_rec_path");
            string keys1Path = config.Get("num_keys_path");
            string keys2Path = config.Get("micr_keys_path");
            roiRatios = config.GetRoiList();
            ocr.InitModels(detPath, rec1Path, rec2Path, keys1Path, keys2Path, numThread,padding);
        }
        public OcrResult DetectFilter(object imgPath)
        {
            var result = ocr.DetectFilter(
                img: imgPath,
                padding:padding,
                maxSideLen: maxSideLen,
                boxScoreThresh: 0.6f,
                boxThresh: 0.3f,
                unClipRatio: 1.6f,
                roiRatios: roiRatios
            );

            var textBlocks = result.TextBlocks;

            ResultFilter resultFilter =new ResultFilter(textBlocks);
            result.StrRes = resultFilter.Result.StrRes;
            result.StrResMap = resultFilter.Result.StrResMap;

            // 결과 확인용 출력
            Console.WriteLine("===== OCR 문자열 결과 =====");
            Console.WriteLine(result.StrRes);

            Console.WriteLine("\n===== OCR Map 결과 =====");
            foreach (var kv in result.StrResMap)
            {
                Console.WriteLine($"[{kv.Key}] : {kv.Value}");
            }

            return result;
        }

        public OcrResult DetectCrop(object imgPath)
        {

            return ocr.DetectCrop(
                img: imgPath,
                padding: 0,
                maxSideLen: maxSideLen,
                boxScoreThresh: 0.6f,
                boxThresh: 0.3f,
                unClipRatio: 1.6f,
                roiRatios: roiRatios
                );
        }

        public OcrResult DetectMask(object imgPath)
        {

            return ocr.DetectMask(
                img: imgPath,
                padding: 0,
                maxSideLen: maxSideLen,
                boxScoreThresh: 0.6f,
                boxThresh: 0.3f,
                unClipRatio: 1.6f,
                roiRatios: roiRatios
                );
        }

        public OcrResult DetectNumber(object imgPath)
        {

            return ocr.DetectNumber(
                img: imgPath,
                padding: 0,
                maxSideLen: maxSideLen,
                boxScoreThresh: 0.6f,
                boxThresh: 0.3f,
                unClipRatio: 1.6f,
                roiRatios: roiRatios
                );
        }
        public OcrResult DetectMICR(object imgPath)
        {

            return ocr.DetectMICR(
                img: imgPath,
                padding: 0,
                maxSideLen: maxSideLen,
                boxScoreThresh: 0.6f,
                boxThresh: 0.3f,
                unClipRatio: 1.6f,
                roiRatios: roiRatios
                );
        }
    }
    
}
