using Fr.Emmanuel.TracabilityUI.Models;
using System.Collections.Generic;

namespace Fr.Emmanuel.TracabilityUI.ViewModels
{
    public class RetourEquipementViewModel
    {
        public RetourEquipement RetourEquipement { get; set; }
        public List<Equipement> listEquipement { get; set; }
        public List<RetourEquipement> listRetourEquipement { get; set; }

    }
}
