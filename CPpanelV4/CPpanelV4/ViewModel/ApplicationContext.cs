using System.Data.Entity;

namespace CPpanelV4
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
            
            
        }
        public DbSet<Coin> Coins { get; set; }
    }
}