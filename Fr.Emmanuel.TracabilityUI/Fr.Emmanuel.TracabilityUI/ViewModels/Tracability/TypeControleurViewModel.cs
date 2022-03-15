using Fr.Emmanuel.TracabilityUI.Models;
using System.Collections.Generic;

namespace Fr.Emmanuel.TracabilityUI.ViewModels
{
    public class TypeControleurViewModel
    {
        public TypeControleur currentTypeControleur { get; set; }
        public List<TypeControleur> listTypeControleur { get; set; }
        public List<Controleur> listControleur { get; set; }
    }
}
