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
    public class Controleur
    {
        [JsonProperty("idControleur")]
        public int IdControleur { get; set; }

        [JsonProperty("idTypeControleur")]
        public int IdTypeControleur { get; set; }

        [JsonProperty("serial")]
        public string Serial { get; set; }

        [JsonProperty("adresseDansArmoire")]
        public string AdresseDansArmoire { get; set; }

        [JsonProperty("lotProd")]
        public string LotProd { get; set; }

        [JsonProperty("libelleType")]
        public string LibelleType { get; set; }


    }
}