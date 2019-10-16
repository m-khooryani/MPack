using Newtonsoft.Json;
using System;
using System.Linq;

namespace MPack
{
    public class NumericStringJsonConverter : JsonConverter
    {
        private readonly Type[] _types;

        public NumericStringJsonConverter()
        {

        }

        public NumericStringJsonConverter(params Type[] types)
        {
            _types = types;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var mj = value as NumericString;
            writer.WriteValue(mj.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string s = reader?.Value?.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            return NumericString.Parse(s);
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanConvert(Type objectType)
        {
            return _types.Any(t => t == objectType);
        }
    }
}
