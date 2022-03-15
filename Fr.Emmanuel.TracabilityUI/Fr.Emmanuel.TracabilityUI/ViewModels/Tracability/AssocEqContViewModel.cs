
using Fr.Emmanuel.TracabilityUI.Models;
using System.Collections.Generic;

namespace Fr.Emmanuel.TracabilityUI.ViewModels
{
    public class AssocEqContViewModel
    {
        public AssocEqCont currentAssocEqCont { get; set; }


        public List<AssocEqCont> listAssocEqCont { get; set; }


        public List<Equipement> listEquipement { get; set; }
        public List<Controleur> listControleur { get; set; }

        public List<TypeControleur> listTypeControleur { get; set; }
    }
}
