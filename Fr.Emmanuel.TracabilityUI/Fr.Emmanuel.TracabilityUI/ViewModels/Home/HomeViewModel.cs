using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fr.Emmanuel.TracabilityUI.Models;

namespace Fr.Emmanuel.TracabilityUI.ViewModels
{
    public class HomeViewModel
    {
        public List<Affaire> Affaire { get; set; }    
        public List<AssocEqCont> AssocEqCont { get; set; }
        public List<Controleur> Controleur { get; set; }
        public List<Equipement> Equipement { get; set; }
        public List<Parametrage> Parametrage { get; set; }
        public List<RetourControleur> RetourControleur { get; set; }
        public List<RetourEquipement> RetourEquipement { get; set; }
        public List<TypeControleur> TypeControleur { get; set; }
        

        
        public int currentYear { get; set; }
        
    }
}
