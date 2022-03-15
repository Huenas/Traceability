using System;
using System.Collections.Generic;

#nullable disable

namespace Fr.Emmanuel.Tracability.Domain.Model
{
    public partial class Affaire
    {
        public Affaire()
        {
            Equipements = new HashSet<Equipement>();
        }

        public int IdAffaire { get; set; }
        public string NumeroAffaire { get; set; }

        public virtual ICollection<Equipement> Equipements { get; set; }
    }
}
