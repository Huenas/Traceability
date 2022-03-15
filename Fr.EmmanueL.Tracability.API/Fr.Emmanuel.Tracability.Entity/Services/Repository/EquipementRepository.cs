using Fr.Emmanuel.Tracability.Domain.Model;
using Fr.Emmanuel.Tracability.Domain.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Fr.Emmanuel.Tracability.Entity.Services.Repository
{
    public class EquipementRepository : GenericRepository<Equipement>, IEquipementRepository
    {
        public EquipementRepository(DbContextFactory context) : base(context)
        {
        }

        public async Task<Equipement> GetByIdIncludingEquipement(int equipementId)
        {
            var query = await GetAllIncluding(x => x.IdAffaireNavigation
                                             
                                             ).AsNoTracking().ToListAsync();
            return query.Where(c =>c.IdEquipement ==equipementId).FirstOrDefault();
        }

        public Equipement GetEquipementByProperties(string nomEquipement)
        {
            var equipProp = GetAll().Where(c => c.NomEquipement == nomEquipement).FirstOrDefault();
            return equipProp;
        }

        public async Task<IEnumerable<Equipement>> GetEquipementIncluding()
        {
            var equipementIncluding = await GetAllIncluding(
                                                            x => x.IdAffaireNavigation ).AsNoTracking().ToListAsync();
            return equipementIncluding;
        }
    }

}