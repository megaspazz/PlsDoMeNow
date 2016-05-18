using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace PlsDoMeNow.Models
{
    public class JsonString
    {
        public string Value { get; set; }

        public static JsonString FromObject(object obj)
        {
            return new JsonString()
            {
                Value = JsonConvert.SerializeObject(obj)
            };
        }
    }
}