using System.Collections.Generic;
using Fr.Emmanuel.Tracability.Domain.Model;
using System.Threading.Tasks;

namespace Fr.Emmanuel.Tracability.Domain.Services.IRepository
{
    public interface IControleurRepository : IGenericRepository<Controleur>

    {
        Controleur GetControleurByProperties(int serial, string lotProd, int adresseDansArmoire, string detail, int retourCtrleurId);
        int GetControleurIncludingAEC(int controleurId);
        int GetControleurIncludingParam(int controleurId);

        public Task<IEnumerable<Controleur>> GetControleurIncluding();
        int GetControleurIncludingRC(int controleurId);
    }
}
