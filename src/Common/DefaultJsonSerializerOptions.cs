using System.Text.Json;
using System.Text.Json.Serialization;

namespace Common
{
    public static class DefaultJsonSerializerOptions
    {
        public static readonly JsonSerializerOptions Options;

        static DefaultJsonSerializerOptions()
        {
            Options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Options.Converters.Add(new JsonStringEnumConverter());
        }

        public static void FromTradesmanDefaults(this JsonSerializerOptions o)
        {
            o.PropertyNameCaseInsensitive = Options.PropertyNameCaseInsensitive;

            o.Converters.Clear();
            foreach (var c in Options.Converters)
                o.Converters.Add(c);
        }
    }
}
