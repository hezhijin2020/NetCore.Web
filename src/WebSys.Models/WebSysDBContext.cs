using Microsoft.EntityFrameworkCore;

namespace WebSys.Models
{
    public class WebSysDBContext : DbContext
    {
        public WebSysDBContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=.;database=RightingSys;uid=sa;pwd=147258");
        }

        public DbSet<Models.ACL_Department> ACL_Department { get; set; }
        public DbSet<Models.ACL_User> ACL_User { get; set; }
        public DbSet<Models.ys_OrderMeal> ys_OrderMeal { get; set; }
    }
}