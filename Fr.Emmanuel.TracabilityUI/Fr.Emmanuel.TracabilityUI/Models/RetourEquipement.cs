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
    public class RetourEquipement
    {
        [JsonProperty("idRetourEquipement")]
        public int IdRetourEquipement { get; set; }

        [JsonProperty("idEquipement")]
        public int IdEquipement { get; set; }

        [JsonProperty("dateRetour")]
        public string DateRetour { get; set; }

        [JsonProperty("idAffaire")]
        public int IdAffaire { get; set; }

        [JsonProperty("idAffaireNavigation")]
        public string IdAffaireNavigation { get; set; }

        [JsonProperty("libelleRetour")]
        public string LibelleRetour { get; set; }

        [JsonProperty("nomEquipement")]
        public string nomEquipement { get; set; }

        [JsonProperty("idControleurNavigation")]
        public string IdControleurNavigation { get; set; }

        [JsonProperty("idEquipementNavigation")]
        public string IdEquipementNavigation { get; set; }

        [JsonProperty("retourEquipements")]
        public string retourEquipements { get; set; }






    }
}