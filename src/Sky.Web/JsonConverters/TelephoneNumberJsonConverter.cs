using Newtonsoft.Json;
using System;

namespace Sky.Web.JsonConverters
{
    public class TelephoneNumberJsonConverter : JsonConverter<TelephoneNumber>
    {
        protected override TelephoneNumber ReadJson(JsonReader reader, Type objectType, TelephoneNumber existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
                return new TelephoneNumber((string)reader.Value);

            return null;
        }

        protected override void WriteJson(JsonWriter writer, TelephoneNumber value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.Value);
        }
    }
}
