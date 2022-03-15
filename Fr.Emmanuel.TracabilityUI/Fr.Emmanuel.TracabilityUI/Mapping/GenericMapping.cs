using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Fr.Emmanuel.TracabilityUI.Mapping
{
    public class GenericMapping : JsonConverter
    {
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetTypeInfo().IsClass;           
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object instance = Activator.CreateInstance(objectType);
            var props = objectType.GetTypeInfo().DeclaredProperties.ToList();

            JObject jo = JObject.Load(reader);
            foreach (JToken token in jo.Children())
            {
                PopulateObject(token, props, instance, serializer);
            }
            return instance;
        }

        private void PopulateObject (JToken token, List<PropertyInfo> props, object instance, JsonSerializer serializer)
        {
            if (token is JProperty)
            {
                if (token.First is JValue)
                {
                    var name = ((JProperty)token).Name;

                    PropertyInfo prop = props.FirstOrDefault(pi => pi.CanWrite && pi.GetCustomAttribute<JsonPropertyAttribute>().PropertyName == name);
                    prop.SetValue(instance, ((JProperty)token).Value.ToObject(prop.PropertyType, serializer));

                }
            }
            foreach (JToken token2 in token.Children())
                PopulateObject(token2, props, instance, serializer);
                    } 
    }
}