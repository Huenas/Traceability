using System.Collections.Generic;
using Fr.Emmanuel.Tracability.Domain.Model;
using System.Threading.Tasks;

namespace Fr.Emmanuel.Tracability.Domain.Services.IRepository
{
    public interface IParametrageRepository : IGenericRepository<Parametrage>

    {
        Parametrage GetParametrageByProperties(int controleurId, string fichiers, string versionSoft);

        public Task<IEnumerable<Parametrage>> GetParametrageIncluding();
    }
}
