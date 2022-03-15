using Fr.Emmanuel.TracabilityUI.Models;
using System.Collections.Generic;

namespace Fr.Emmanuel.TracabilityUI.ViewModels
{
    public class AffaireViewModel
    {
        public Affaire currentAffaire { get; set; }
        public List<Affaire> numeroAffaire { get; set; }
        public List<Affaire> listAffaire { get; set; }
        
    }
}
