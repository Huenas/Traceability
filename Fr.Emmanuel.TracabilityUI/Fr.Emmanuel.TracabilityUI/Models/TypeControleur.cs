using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fr.Emmanuel.TracabilityUI;
using Fr.Emmanuel.TracabilityUI.Mapping;
using Newtonsoft.Json;

namespace Fr.Emmanuel.TracabilityUI.Models
{
    [JsonConverter(typeof(GenericMapping))]
    public class TypeControleur
    {
        [JsonProperty("idTypeControleur")]
        public int IdTypeControleur { get; set; }

        [JsonProperty("libelleType")]
        public string LibelleType { get; set; }

        [JsonProperty("controleurs")]
        public string Controleurs { get; set; }


    }
}