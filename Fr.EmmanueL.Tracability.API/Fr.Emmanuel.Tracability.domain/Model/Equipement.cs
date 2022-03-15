



using System;
using System.Collections.Generic;

#nullable disable

namespace Fr.Emmanuel.Tracability.Domain.Model
{
    public partial class Equipement
    {
        public Equipement()
        {
            AssocEqConts = new HashSet<AssocEqCont>();
            RetourEquipements = new HashSet<RetourEquipement>();
        }

        public int IdEquipement { get; set; }
        public int IdAffaire { get; set; }
        public string NomEquipement { get; set; }

        public virtual Affaire IdAffaireNavigation { get; set; }
        public virtual ICollection<AssocEqCont> AssocEqConts { get; set; }
        public virtual ICollection<RetourEquipement> RetourEquipements { get; set; }
    }
}
