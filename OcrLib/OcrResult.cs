using Emgu.CV;
using OcrLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OcrLiteLib
{
    public sealed class TextBox
    {
        public List<Point> Points { get; set; }
        public float Score { get; set; }
        public override string ToString()
        {
            return $"TextBox[score({Score}),[x: {Points[0].X}, y: {Points[0].Y}], [x: {Points[1].X}, y: {Points[1].Y}], [x: {Points[2].X}, y: {Points[2].Y}], [x: {Points[3].X}, y: {Points[3].Y}]]";
        }
    }

    public sealed class Angle
    {
        public int Index { get; set; }
        public float Score { get; set; }
        public float Time { get; set; }
        public override string ToString()
        {
            string header = Index >= 0 ? "Angle" : "AngleDisabled";
            return $"{header}[Index({Index}), Score({Score}), Time({Time}ms)]";
        }
    }
    public sealed class TextLine
    {
        public string Text { get; set; }
        public List<float> CharScores { get; set; }
        public float Time { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            CharScores.ForEach(x => sb.Append($"{x},"));
            return $"TextLine[Text({Text}),CharScores({sb.ToString()}),Time({Time}ms)]";
        }
    }
    public sealed class TextBlock
    {
        public List<Point> BoxPoints { get; set; }
        public float BoxScore { get; set; }
        public int AngleIndex { get; set; }
        public float AngleScore { get; set; }
        public float AngleTime { get; set; }
        public string Text { get; set; }
        public List<float> CharScores { get; set; }
        public float CrnnTime { get; set; }
        public float BlockTime { get; set; }
        public string ModelType { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("├─TextBlock");
            string textBox = $"│   ├──TextBox[score({BoxScore}),[x: {BoxPoints[0].X}, y: {BoxPoints[0].Y}], [x: {BoxPoints[1].X}, y: {BoxPoints[1].Y}], [x: {BoxPoints[2].X}, y: {BoxPoints[2].Y}], [x: {BoxPoints[3].X}, y: {BoxPoints[3].Y}]]";
            sb.AppendLine(textBox);
            StringBuilder sbScores = new StringBuilder();
            CharScores.ForEach(x => sbScores.Append($"{x},"));
            string textLine = $"│   ├──TextLine[Text({Text}),CharScores({sbScores.ToString()}),Time({CrnnTime}ms)]";
            sb.AppendLine(textLine);
            return sb.ToString();
        }
    }
    public sealed class OcrResult
    {
        public List<TextBlock> TextBlocks { get; set; }
        public float DbNetTime { get; set; }
        public Mat BoxImg { get; set; }
        public float DetectTime { get; set; }
        public string StrRes { get; set; }
        public Dictionary<string, string> StrResMap { get; internal set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("OcrResult");

            // 1. 모델별 블록 분리
            var serialBlocks = TextBlocks.FindAll(tb => tb.ModelType == "SERIAL");
            var amountBlocks = TextBlocks.FindAll(tb => tb.ModelType == "AMOUNT");
            var micrBlocks = TextBlocks.FindAll(tb => tb.ModelType == "MICR");

            if (serialBlocks.Count > 0)
            {
                sb.AppendLine("├─[SERIAL 번호 인식 결과]");
                serialBlocks.ForEach(x => sb.Append(x));
            } 
            if (amountBlocks.Count > 0)
            {
                sb.AppendLine("├─[AMOUNT 인식 결과]");
                amountBlocks.ForEach(x => sb.Append(x));
            }

            if (micrBlocks.Count > 0)
            {
                sb.AppendLine("├─[MICR 코드 결과]");
                micrBlocks.ForEach(x => sb.Append(x));
            }

            // 2. 타이밍 정보
            sb.AppendLine($"├─DbNetTime({DbNetTime}ms)");
            sb.AppendLine($"├─DetectTime({DetectTime}ms)");

            // 3. 최종 문자열 결과
            sb.AppendLine("└─StrRes(");
            sb.AppendLine(StrRes);
            sb.AppendLine(")");

            return sb.ToString();
        }

        public static implicit operator OcrResult(ResultFilter v)
        {
            throw new NotImplementedException();
        }
    }
}

