using Newtonsoft.Json;
using System;

namespace Sky.Web.JsonConverters
{
    public class MoneyJsonConverter : JsonConverter<Money>
    {
        protected override Money ReadJson(JsonReader reader, Type objectType, Money existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Float)
                return new Money(Convert.ToDecimal(reader.Value));

            return null;
        }

        protected override void WriteJson(JsonWriter writer, Money value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.Value);
        }
    }
}
