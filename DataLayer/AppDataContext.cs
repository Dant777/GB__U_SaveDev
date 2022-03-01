using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }
        public DbSet<BankCard> BankCards { get; set; }
    }


}
