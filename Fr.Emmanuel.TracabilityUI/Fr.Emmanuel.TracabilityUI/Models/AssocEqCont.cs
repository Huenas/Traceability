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
    public class AssocEqCont
    {
        [JsonProperty("idAssocEqCont")]
        public int IdAssocEqCont { get; set; }
        

        [JsonProperty("idTypeControleur")]
        public int IdTypeControleur { get; set; }



        [JsonProperty("adresseDansArmoire")]
        public string AdresseDansArmoire { get; set; }
        
        [JsonProperty("lotProd")]
        public string LotProd { get; set; }

        [JsonProperty("idTypeControleurNavigation")]
        public string IdTypeControleurNavigation { get; set; }

        [JsonProperty("idControleurNavigation")]
        public string IdControleurNavigation { get; set; }

        [JsonProperty("idEquipementNavigation")]
        public string IdEquipementNavigation { get; set; }


        [JsonProperty("libelleType")]
        public string LibelleType { get; set; }

        [JsonProperty("idAffaireNavigation")]
        public string IdAffaireNavigation { get; set; }

        [JsonProperty("idAffaire")]
        public int idAffaire { get; set; }



        [JsonProperty("controleurs")]
        public string Controleurs { get; set; }

        [JsonProperty("idEquipement")]
        public int IdEquipement { get; set; }
        
        [JsonProperty("idControleur")]
        public int IdControleur { get; set; }

        [JsonProperty("dateAssoc")]
        public DateTime DateAssoc { get; set; }

        [JsonProperty("serial")]
        public string Serial { get; set; }

        [JsonProperty("nomEquipement")]
        public string NomEquipement { get; set; }

    }
}