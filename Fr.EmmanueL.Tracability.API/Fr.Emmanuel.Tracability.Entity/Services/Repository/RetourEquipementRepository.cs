using Fr.Emmanuel.Tracability.Domain.Model;
using Fr.Emmanuel.Tracability.Domain.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Fr.Emmanuel.Tracability.Entity.Services.Repository
{
    public class RetourEquipementRepository : GenericRepository<RetourEquipement>, IRetourEquipementRepository
    {
        public RetourEquipementRepository(DbContextFactory context) : base(context)
        {
        }

        public async Task<IEnumerable<RetourEquipement>> GetRetourEquipementIncluding()
        {
            var retourEquipementIncluding = await GetAllIncluding(
                                                                x => x.IdEquipementNavigation).AsNoTracking().ToListAsync();
            return retourEquipementIncluding;
        }


        public List<RetourEquipement> GetRetourEquipementByDate(string annee, string mois, string jour)
        {
            int day = 1;
            int month = int.Parse(mois);
            int year = int.Parse(annee);
            DateTime date = new DateTime(year, month, day);

            var res = GetAll().Where(t => t.DateRetour == date).ToList();
            return res;
        }
    }
}