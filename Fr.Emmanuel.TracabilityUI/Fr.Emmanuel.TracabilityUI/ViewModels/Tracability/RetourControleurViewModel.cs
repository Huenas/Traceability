using Fr.Emmanuel.TracabilityUI.Models;
using System.Collections.Generic;

namespace Fr.Emmanuel.TracabilityUI.ViewModels
{
    public class RetourControleurViewModel
    {
        public RetourControleur retourControleur { get; set; }
        public RetourControleur currentRetourControleur { get; set; }
        public List<Equipement> listEquipement { get; set; }
        public List<RetourControleur> listRetourControleur { get; set; }
        
        public List<Controleur> listControleur { get; set; }

        
        public List<TypeControleur> listTypeControleur { get; set; }
    }
}
