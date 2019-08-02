using System.Linq;
using System.Security.Principal;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options)
            : base(options)
        {
        }

        public ProjectContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=DbApiOrnek;Trusted_Connection=True;"
                );
        }

        public DbSet<User> Users { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProjectContext>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { ID = 1, Name = "Ediz", LastName = "Ilkcakin", Age = 29, Email = "edizilkcakin@gmail.com", IdentityNo = "12345678941", Sex = 'm', Password = "123456" },
           new User { ID = 2, Name = "Onur", LastName = "Uygur", Age = 33, Email = "onuruygur@gmail.com", IdentityNo = "12345678942", Sex = 'm', Password = "1234567" },
           new User { ID = 3, Name = "Ahmet", LastName = "Asd", Age = 30, Email = "ahmetasd@gmail.com", IdentityNo = "12345678943", Sex = 'm', Password = "12345678" },
           new User { ID = 4, Name = "Mehmet", LastName = "Dsa", Age = 27, Email = "mehmetdsa@gmail.com", IdentityNo = "12345678944", Sex = 'm', Password = "123456789" });
        }
    }
}
