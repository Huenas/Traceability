using Fr.Emmanuel.TracabilityUI.Models;
using System.Collections.Generic;

namespace Fr.Emmanuel.TracabilityUI.ViewModels
{
    public class ControleurViewModel
    {
        public Controleur currentControleur { get; set; }
        public Controleur Controleur { get; set; }
        public List<Equipement> listEquipement { get; set; }
        public List<Controleur> listControleur { get; set; }
    }
}
