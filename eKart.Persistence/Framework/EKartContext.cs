using Microsoft.EntityFrameworkCore;


namespace eKart.Persistence.Framework
{
    public sealed class EKartContext : DbContext
    {
        public EKartContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EKartContext).Assembly);
        }
    }
}
