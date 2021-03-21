using Microsoft.EntityFrameworkCore;

namespace NeoGrowth.Entity
{
    public class NeoGrowthContext : DbContext
    {
        public DbSet<LeadInformation> LeadInformations { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }

        public DbSet<CommunicationLog> CommunicationLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=NeoGrowth;User Id=sa;Password=Aurigo@123;");
        }
    }
}
