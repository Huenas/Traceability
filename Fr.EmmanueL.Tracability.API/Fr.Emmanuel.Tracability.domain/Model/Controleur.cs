using System;
using System.Collections.Generic;

#nullable disable

namespace Fr.Emmanuel.Tracability.Domain.Model
{
    public partial class Controleur
    {
        public Controleur()
        {
            AssocEqConts = new HashSet<AssocEqCont>();
            Parametrages = new HashSet<Parametrage>();
            RetourControleurs = new HashSet<RetourControleur>();
        }

        public int IdControleur { get; set; }
        public int IdTypeControleur { get; set; }
        public string Serial { get; set; }
        public string AdresseDansArmoire { get; set; }
        public string LotProd { get; set; }

        public virtual TypeControleur IdTypeControleurNavigation { get; set; }
        public virtual ICollection<AssocEqCont> AssocEqConts { get; set; }
        public virtual ICollection<Parametrage> Parametrages { get; set; }
        public virtual ICollection<RetourControleur> RetourControleurs { get; set; }
    }
}
