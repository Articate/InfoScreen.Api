using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using InfoScreen.Service.Infrastructure;

namespace InfoScreen.WebApi.Formatter
{
    public class IocCustomCreationConverter<T> : CustomCreationConverter<T>
    {
        public override bool CanConvert(Type objectType)
        {
            try
            {
                return (typeof(T) == objectType) && ServiceInstaller.Container.Kernel.HasComponent(objectType);
            }
            catch
            {
                return false;
            }
        }

        public override T Create(Type objectType)
        {
            return (T)ServiceInstaller.Container.Resolve(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var obj = Create(objectType);
            serializer.Populate(reader, obj);
            return obj;
        }
    }
}