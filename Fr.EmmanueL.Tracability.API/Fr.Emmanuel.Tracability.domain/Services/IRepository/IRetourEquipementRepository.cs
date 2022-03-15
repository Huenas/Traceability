using System.Collections.Generic;
using Fr.Emmanuel.Tracability.Domain.Model;
using System.Threading.Tasks;

namespace Fr.Emmanuel.Tracability.Domain.Services.IRepository
{
    public interface IRetourEquipementRepository : IGenericRepository<RetourEquipement>
    {
        List<RetourEquipement> GetRetourEquipementByDate(string annee, string mois, string jour);
        public Task<IEnumerable<RetourEquipement>> GetRetourEquipementIncluding();
        
    }



}
