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
    public class RetourControleur
    {
        [JsonProperty("idRetourControleur")]
        public int IdRetourControleur { get; set; }

        [JsonProperty("idControleur")]
        public int IdControleur { get; set; }

        [JsonProperty("dateRetour")]
        public DateTime DateRetour { get; set; }

        [JsonProperty("serial")]
        public string Serial { get; set; }

        [JsonProperty("adresseDansArmoire")]
        public string AdresseDansArmoire { get; set; }


        [JsonProperty("lotProd")]
        public string LotProd { get; set; }

        [JsonProperty("libelleRetour")]
        public string LibelleRetour { get; set; }       
        
        [JsonProperty("idControleurNavigation")]
        public string IdControleurNavigation { get; set; }

        [JsonProperty("idTypeControleurNavigation")]
        public string IdTypeControleurNavigation { get; set; }

        [JsonProperty("idTypeControleur")]
        public string IdTypeControleur { get; set; }



        [JsonProperty("libelleType")]
        public string LibelleType { get; set; }






    }
}