using System;
using System.Collections.Generic;

#nullable disable

namespace Fr.Emmanuel.Tracability.Domain.Model
{
    public partial class Parametrage
    {
        public int IdParametrage { get; set; }
        public int IdControleur { get; set; }
        public string Version { get; set; }
        public string Fichier { get; set; }

        public virtual Controleur IdControleurNavigation { get; set; }
    }
}
