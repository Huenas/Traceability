using System.Collections.Generic;
using Fr.Emmanuel.Tracability.Domain.Model;
using System.Threading.Tasks;

namespace Fr.Emmanuel.Tracability.Domain.Services.IRepository
{
    public interface IRetourControleurRepository : IGenericRepository<RetourControleur>
    {
        List<RetourControleur> GetRetourControleurByDate(string annee, string mois, string jour);
        Task<IEnumerable<RetourControleur>> GetAllIncludingControleur();

        public Task<IEnumerable<RetourControleur>> GetRetourControleurIncluding();
    }
}
