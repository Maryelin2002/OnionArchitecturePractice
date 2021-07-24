using Microsoft.EntityFrameworkCore;
using SolvexWorkshop.Model.Entities;

namespace SolvexWorkshop.Model.Contexts
{
    public class WorkShopContext : BaseDbContext
    {
        public WorkShopContext(DbContextOptions<WorkShopContext> options) : base(options)
        {
        }
        public DbSet<Document> Documents { get; set; }
        public DbSet<WorkShop> WorkShops { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkShopMember> WorkShopMembers { get; set; }
        public DbSet<WorkShopDay> WorkShopDays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
