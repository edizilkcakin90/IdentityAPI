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
                "Server=localhost;Database=DbIdentityServerAPI;Trusted_Connection=True;"
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
           new User { ID = 2, Name = "Onur", LastName = "Uygur", Age = 31, Email = "onuruygur@gmail.com", IdentityNo = "12345678942", Sex = 'm', Password = "1234567" },
           new User { ID = 3, Name = "Coskun", LastName = "Parlar", Age = 30, Email = "coskunparlar@gmail.com", IdentityNo = "12345678943", Sex = 'm', Password = "12345678" },
           new User { ID = 4, Name = "Sezay", LastName = "Dogan", Age = 30, Email = "sezaydogan@gmail.com", IdentityNo = "12345678944", Sex = 'm', Password = "123456789" },
           new User { ID = 5, Name = "Esra", LastName = "Ergenc", Age = 21, Email = "esraergenc@gmail.com", IdentityNo = "12345678945", Sex = 'f', Password = "123456780" },
           new User { ID = 6, Name = "Senem", LastName = "Yildirim", Age = 29, Email = "senemyildirim@gmail.com", IdentityNo = "12345678946", Sex = 'f', Password = "123456781" },
           new User { ID = 7, Name = "Cem", LastName = "Parlar", Age = 25, Email = "cemparlar@gmail.com", IdentityNo = "12345678947", Sex = 'm', Password = "123456782" },
           new User { ID = 8, Name = "Yagmur", LastName = "Unal", Age = 27, Email = "yagmurunal@gmail.com", IdentityNo = "12345678948", Sex = 'f', Password = "123456783" });
        }
    }
}
