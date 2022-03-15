using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Fr.Emmanuel.Tracability.Domain.Model;
using Fr.Emmanuel.Tracability.Domain.Services.IRepository;

namespace Fr.Emmanuel.Tracability.Entity.Services.Repository
{
    public class AffaireRepository : GenericRepository<Affaire>, IAffaireRepository
    {
        public AffaireRepository(DbContextFactory context) : base(context)
        {
        }

        public Affaire GetAffaireByNumber(string numeroAffaire)
        {
            var number = GetAll().Where(n => n.NumeroAffaire == numeroAffaire).FirstOrDefault();
            return number;
        }


  
    }
}
