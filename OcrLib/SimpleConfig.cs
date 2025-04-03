using System.Collections.Generic;
using System.IO;


namespace OcrLib
{
    class SimpleConfig
    {
        private Dictionary<string, string> config = new Dictionary<string, string>();

        public SimpleConfig(string path)
        {
            foreach (var line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#")) continue;

                var parts = line.Split('=');
                if (parts.Length == 2)
                {
                    config[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }

        public string Get(string key) => config.ContainsKey(key) ? config[key] : null;
        public int GetInt(string key) => int.Parse(Get(key));
        public float GetFloat(string key) => float.Parse(Get(key));
        public List<(float, float, float, float)> GetRoiList()
        {
            var rois = new List<(float, float, float, float)>();
            foreach (var kv in config)
            {
                if (kv.Key.EndsWith("roi"))
                {
                    var parts = kv.Value.Split(',');
                    if (parts.Length == 4 &&
                        float.TryParse(parts[0], out float x) &&
                        float.TryParse(parts[1], out float y) &&
                        float.TryParse(parts[2], out float w) &&
                        float.TryParse(parts[3], out float h))
                    {
                        rois.Add((x, y, w, h));
                    }
                }
            }
            return rois;
        }
    }
}
