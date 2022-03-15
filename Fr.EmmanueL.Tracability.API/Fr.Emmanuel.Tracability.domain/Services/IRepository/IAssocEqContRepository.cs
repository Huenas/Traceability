


using Fr.Emmanuel.Tracability.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fr.Emmanuel.Tracability.Domain.Services.IRepository
{
    public interface IAssocEqContRepository : IGenericRepository<AssocEqCont>

    {
        AssocEqCont GetAssocEqContByPropreties(int equipementId, int controleurId);
        List<AssocEqCont> GetDateLivraisonByDate(string annee, string mois, string jour);
        Task<AssocEqCont> GetByIdIncludingAssocEqCont(int IdAssocEqCont);
        public Task<IEnumerable<AssocEqCont>> GetAssocEqContIncluding();
        Task<IEnumerable<AssocEqCont>> GetAllIncludingAssocEQC();
   
    }
}
