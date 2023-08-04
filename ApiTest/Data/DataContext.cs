using ApiTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ApiTest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=LEAN\\SQLEXPRESS;Database=testdb;Trusted_Connection=True;TrustServerCertificate=True;")
                  .ConfigureWarnings(w => w
#if DEBUG
        // throw on all EF query diagnostics in debug builds (eg query should be split)
        .Default(WarningBehavior.Throw)
#endif
        .Log(CoreEventId.RowLimitingOperationWithoutOrderByWarning)
    );
        }

        public DbSet<Items> Items { get; set; }
    }

}
