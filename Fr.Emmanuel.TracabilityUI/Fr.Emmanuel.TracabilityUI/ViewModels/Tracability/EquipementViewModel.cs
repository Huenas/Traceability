using Fr.Emmanuel.TracabilityUI.Models;
using System.Collections.Generic;

namespace Fr.Emmanuel.TracabilityUI.ViewModels
{
    public class EquipementViewModel
    {
        public Equipement Equipement { get; set; }
        public List<Affaire> listAffaire { get; set; }
        public List<Equipement> listEquipement { get; set; }
    }
}
