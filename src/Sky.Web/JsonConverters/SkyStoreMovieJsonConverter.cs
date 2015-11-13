using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sky.Web.JsonConverters
{
    public class SkyStoreMovieJsonConverter : JsonConverter<SkyStoreMovie>
    {
        protected override SkyStoreMovie ReadJson(JsonReader reader, Type objectType, SkyStoreMovie existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
                return new SkyStoreMovie((string)reader.Value);

            return null;
        }

        protected override void WriteJson(JsonWriter writer, SkyStoreMovie value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.Title);
        }
    }
}
