using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlaniT.Models;

namespace PlaniT.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<TodayTemplateItem> TodayTemplateItems { get; set; }
        public DbSet<DayCard> DayCards { get; set; }
        public DbSet<DayTask> DayTasks { get; set; }
        public DbSet<FutureVisionItem> FutureVisionItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }

}
