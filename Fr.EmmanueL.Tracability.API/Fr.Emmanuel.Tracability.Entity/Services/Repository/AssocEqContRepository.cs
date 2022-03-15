using Fr.Emmanuel.Tracability.Domain.Model;
using Fr.Emmanuel.Tracability.Domain.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.Emmanuel.Tracability.Entity.Services.Repository
{
    public class AssocEqContRepository : GenericRepository<AssocEqCont>, IAssocEqContRepository
    {
        public AssocEqContRepository(DbContextFactory context) : base(context)
        {
        }

        public async Task<IEnumerable<AssocEqCont>> GetAllIncludingAssocEQC()
        {
            var query = await GetAllIncluding(x => x.IdEquipement,
                                              y => y.IdControleur,
                                              z => z.DateAssoc).AsNoTracking().ToListAsync();
            return query;
        }

        public AssocEqCont GetAssocEqContByPropreties(int IdEquipement, int IdControleur)
        {
            var assoc = GetAll().Where(c => c.IdEquipement == IdEquipement && c.IdControleur == IdControleur).FirstOrDefault();
            return assoc;
        }

        public async Task<AssocEqCont> GetByIdIncludingAssocEqCont(int idAssocEqCont)
        {
            var assocProp = await GetAllIncluding(x => x.IdEquipement,
                                              y => y.IdControleur,
                                              z => z.DateAssoc).AsNoTracking().ToListAsync();

            return assocProp.Where(a => a.IdAssocEqCont == idAssocEqCont).FirstOrDefault();
        }
        public async Task<IEnumerable<AssocEqCont>> GetAssocEqContIncluding()
        {
            var assocEqContIncluding = await GetAllIncluding(x => x.IdControleurNavigation.IdTypeControleurNavigation,
                                                            y => y.IdEquipementNavigation
                                                            
                                                            ).AsNoTracking().ToListAsync();
            return assocEqContIncluding;
        }


        public List<AssocEqCont> GetDateLivraisonByDate(string annee, string mois, string jour)
        {
            int day = 1;
            int month = int.Parse(mois);
            int year = int.Parse(annee);
            DateTime date = new DateTime(year, month, day);

            var res = GetAll().Where(t => t.DateAssoc == date).ToList();
            return res;
        }


    }
}
