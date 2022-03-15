using System;
using System.Collections.Generic;

#nullable disable

namespace Fr.Emmanuel.Tracability.Domain.Model
{
    public partial class AssocEqCont
    {
        public int IdAssocEqCont { get; set; }
        public int IdEquipement { get; set; }
        public int IdControleur { get; set; }
        public DateTime DateAssoc { get; set; }

        public virtual Controleur IdControleurNavigation { get; set; }
        public virtual Equipement IdEquipementNavigation { get; set; }
    }
}
