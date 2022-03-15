using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Fr.Emmanuel.Tracability.Entity
{
    public class DbContextFactory : IDesignTimeDbContextFactory<TracabilityDbContext>
    {
        public TracabilityDbContext CreateDbContext(string[] args = null)
        {
            var builder = new DbContextOptionsBuilder<TracabilityDbContext>();
            var connectionString = "Data Source=XXXXXXX\\SQLEXPRESS;Initial Catalog=Tracability;Persist Security Info=True;Integrated Security=XXXX";

            builder.UseSqlServer(connectionString);

            var dbContext = (TracabilityDbContext)Activator.CreateInstance(
                typeof(TracabilityDbContext),
                builder.Options);

            return dbContext;
        }
    }
}
