using System;
using OcrLiteLib;
using System.Linq;
using System.Collections.Generic;


namespace OcrLib
{
    public class ResultFilter
    {
        public OcrResult Result { get; private set; }
        public ResultFilter(List<TextBlock> textBlocks)
        {
            var sortedSerialStr = string.Join(" ",
                    textBlocks
                        .Where(tb => tb.ModelType == "SERIAL")
                        .Where(tb => tb.CharScores.Average() >= 0.8f)
                        .Select(tb => tb.Text.Length > 8
                        ? tb.Text.Substring(tb.Text.Length - 8) // 뒤에서 8글자
                        : tb.Text));

            // AMOUNT
            var sortedAmountStr = string.Join(" ",
                textBlocks
                    .Where(tb => tb.ModelType == "AMOUNT")
                    .Where(tb => tb.CharScores.Average() >= 0.8f)
                    .OrderBy(tb => tb.BoxPoints.Min(p => p.X))
                    .Select(tb =>
                    {
                        var text = tb.Text;
                        int cutIndex = text.LastIndexOfAny(new[] { '.', '*' });
                        return cutIndex >= 0 ? text.Substring(0, cutIndex) : text;
                    }));

            // MICR
            var sortedMicrStr = string.Join(" ",
                textBlocks
                    .Where(tb => tb.ModelType == "MICR")
                    .OrderBy(tb => tb.BoxPoints.Min(p => p.X))
                    .Select(tb =>
                    {
                        var text = tb.Text;
                        if (string.IsNullOrEmpty(text)) return text;

                        return text
                            .Replace("A", ":")
                            .Replace("B", ";")
                            .Replace("C", "<")
                            .Replace("D", "=");
                    }));

            Result = new OcrResult
            {
                TextBlocks = textBlocks,
                StrResMap = new Dictionary<string, string>
                {
                    { "SERIAL", sortedSerialStr },
                    { "AMOUNT", sortedAmountStr },
                    { "MICR", sortedMicrStr }
                }
            };
        }
    }
}
