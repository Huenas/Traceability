using Fr.Emmanuel.Tracability.Domain.Model;
using Fr.Emmanuel.Tracability.Domain.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Fr.Emmanuel.Tracability.Entity.Services.Repository
{
    public class ParametrageRepository : GenericRepository<Parametrage>, IParametrageRepository
    {
        public ParametrageRepository(DbContextFactory context) : base(context)
        {
        }

        public Parametrage GetParametrageByProperties(int controleurId, string fichiers, string versionSoft)
        {
            var paramProp = GetAll().Where(c => c.IdControleur == controleurId && c.Fichier == fichiers && c.Version == versionSoft).FirstOrDefault();
            return paramProp;
        }

        public async Task<IEnumerable<Parametrage>> GetParametrageIncluding()
        {
            var equipementIncluding = await GetAllIncluding(
                                                            x => x.IdControleurNavigation).AsNoTracking().ToListAsync();
            return equipementIncluding;
        }

    }
}
