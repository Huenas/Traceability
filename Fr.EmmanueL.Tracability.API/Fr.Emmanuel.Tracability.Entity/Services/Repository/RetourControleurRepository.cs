using Fr.Emmanuel.Tracability.Domain.Model;
using Fr.Emmanuel.Tracability.Domain.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Fr.Emmanuel.Tracability.Entity.Services.Repository
{
    public class RetourControleurRepository : GenericRepository<RetourControleur>, IRetourControleurRepository
    {
        public RetourControleurRepository(DbContextFactory context) : base(context)
        {
        }

        public async Task<IEnumerable<RetourControleur>> GetAllIncludingControleur()
        {
            var query = await GetAllIncluding(x => x.IdControleur,
                                              y => y.IdRetourControleur).AsNoTracking().ToListAsync();/*Maybe del this one out*/
            return query;
        }

        public List<RetourControleur> GetRetourControleurByDate(string annee, string mois, string jour)
        {
            int day = 1;
            int month = int.Parse(mois);
            int year = int.Parse(annee);
            DateTime date = new DateTime(year, month, day);

            var res = GetAll().Where(t => t.DateRetour == date).ToList();
            return res;
        }


        public async Task<IEnumerable<RetourControleur>> GetRetourControleurIncluding()
        {
            var retourcontroleurIncluding = await GetAllIncluding(
                                                            x => x.IdControleurNavigation).AsNoTracking().ToListAsync();
            return retourcontroleurIncluding;
        }
    }
}