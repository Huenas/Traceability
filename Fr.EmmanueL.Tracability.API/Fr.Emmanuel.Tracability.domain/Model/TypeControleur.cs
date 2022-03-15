using System;
using System.Collections.Generic;

#nullable disable

namespace Fr.Emmanuel.Tracability.Domain.Model
{
    public partial class TypeControleur
    {
        public TypeControleur()
        {
            Controleurs = new HashSet<Controleur>();
        }

        public int IdTypeControleur { get; set; }
        public string LibelleType { get; set; }

        public virtual ICollection<Controleur> Controleurs { get; set; }
    }
}
