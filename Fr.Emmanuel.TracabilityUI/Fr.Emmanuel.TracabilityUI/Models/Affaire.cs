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
    public class Affaire
    {
        [JsonProperty("idAffaire")]
        public int IdAffaire { get; set; }

        [JsonProperty("numeroAffaire")]
        public string NumeroAffaire { get; set; }
        [JsonProperty("idAffaireNavigation")]
        public string IdAffaireNavigation { get; set; }
    }
}