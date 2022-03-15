using System;
using System.Collections.Generic;

#nullable disable

namespace Fr.Emmanuel.Tracability.Domain.Model
{
    public partial class RetourEquipement
    {
        public int IdRetourEquipement { get; set; }
        public int IdEquipement { get; set; }
        public DateTime DateRetour { get; set; }
        public string LibelleRetour { get; set; }

        public virtual Equipement IdEquipementNavigation { get; set; }
    }
}
