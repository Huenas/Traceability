using Fr.Emmanuel.TracabilityUI.Models;
using System.Collections.Generic;

namespace Fr.Emmanuel.TracabilityUI.ViewModels
{
    public class ParametrageViewModel
    {
        public Parametrage parametrage { get; set; }
        public Parametrage currentParametrage { get; set; }
        public List<Parametrage> listEquipement { get; set; }
    
        public List<Parametrage> listParametrage { get; set; }
    }
}
