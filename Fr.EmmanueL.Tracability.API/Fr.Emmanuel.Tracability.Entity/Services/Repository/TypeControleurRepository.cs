using Fr.Emmanuel.Tracability.Domain.Model;
using Fr.Emmanuel.Tracability.Domain.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.Emmanuel.Tracability.Entity.Services.Repository
{
    public class TypeControleurRepository : GenericRepository<TypeControleur>, ITypeControleurRepository
    {
        public TypeControleurRepository(DbContextFactory context) : base(context)
        {

        }

        public TypeControleur GetTypeControleurByName(string libelleType)
        {
            var typeName = GetAll().Where(n => n.LibelleType == libelleType).FirstOrDefault();
            return typeName;
        }
        
    }
}
