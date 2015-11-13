using Newtonsoft.Json;
using System;

namespace Sky.Web.JsonConverters
{
    public abstract class JsonConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return ReadJson(reader, objectType, (T)existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            WriteJson(writer, (T)value, serializer);
        }

        protected abstract T ReadJson(JsonReader reader, Type objectType, T existingValue, JsonSerializer serializer);
        protected abstract void WriteJson(JsonWriter writer, T value, JsonSerializer serializer);
    }
}
