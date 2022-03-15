using System.Collections.Generic;
using Fr.Emmanuel.Tracability.Domain.Model;
using System.Threading.Tasks;

namespace Fr.Emmanuel.Tracability.Domain.Services.IRepository
{
    public interface IEquipementRepository : IGenericRepository<Equipement>

    {
        Equipement GetEquipementByProperties(string nomEquipement);
        public Task<IEnumerable<Equipement>> GetEquipementIncluding();
        Task<Equipement> GetByIdIncludingEquipement(int equipementId);
    }
}
