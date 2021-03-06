﻿using System;
using System.Linq;
using eZet.Eve.EveLib.Model.EveMarketData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eZet.Eve.EveLib.Util.JsonConverter {
    public class RowConverter<T> : Newtonsoft.Json.JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) {
            var result = new RowCollection<T>();
            var json = JArray.Load(reader);
            foreach (var a in json.Select(item => serializer.Deserialize<T>(item["row"].CreateReader()))) {
                result.Add(a);
            }
            return result;
        }

        public override bool CanConvert(Type objectType) {
            return objectType == typeof(RowCollection<T>);
        }
    }
}