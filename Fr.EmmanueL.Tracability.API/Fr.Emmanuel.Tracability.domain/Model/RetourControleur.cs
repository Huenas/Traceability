using System;
using System.Collections.Generic;

#nullable disable

namespace Fr.Emmanuel.Tracability.Domain.Model
{
    public partial class RetourControleur
    {
        public int IdRetourControleur { get; set; }
        public int IdControleur { get; set; }
        public DateTime DateRetour { get; set; }
        public string LibelleRetour { get; set; }


        public virtual Controleur IdControleurNavigation { get; set; }
    }
}
