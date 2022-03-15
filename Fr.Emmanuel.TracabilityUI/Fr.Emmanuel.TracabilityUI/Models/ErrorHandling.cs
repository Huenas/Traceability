
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fr.Emmanuel.TracabilityUI.Mapping;
using Newtonsoft.Json;

namespace Fr.Emmanuel.TracabilityUI.Models
{
    [JsonConverter(typeof(GenericMapping))]
    public class ErrorHandling
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("didError")]
        public string DidError { get; set; }
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
    }
}
