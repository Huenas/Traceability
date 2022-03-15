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
    public class Parametrage
    {
        [JsonProperty("idParametrage")]
        public int IdParametrage { get; set; }

        [JsonProperty("idControleur")]
        public int IdControleur { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("fichier")]
        public string Fichier { get; set; }
        
        [JsonProperty("idControleurNavigation")]
        public string IdControleurNavigation { get; set; }

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

        [JsonProperty("idTypeControleurNavigation")]
        public string IdTypeControleurNavigation { get; set; }


    }
}