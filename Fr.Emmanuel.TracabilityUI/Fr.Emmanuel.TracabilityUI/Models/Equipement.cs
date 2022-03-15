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
    public class Equipement
    {
        [JsonProperty("idEquipement")]
        public int IdEquipement { get; set; }

        [JsonProperty("idAffaire")]
        public int IdAffaire { get; set; }

        [JsonProperty("nomEquipement")]
        public string NomEquipement { get; set; }

        [JsonProperty("numeroAffaire")]
        public string NumeroAffaire { get; set; }

        [JsonProperty("assocEqConts")]
        public string AssocEqConts { get; set; }


        [JsonProperty("retourEquipements")]
        public string RetourEquipements { get; set; }


    }
}