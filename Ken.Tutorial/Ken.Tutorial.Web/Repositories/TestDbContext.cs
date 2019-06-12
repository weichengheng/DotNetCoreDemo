using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ken.Tutorial.Web.Models.Entity;

namespace Ken.Tutorial.Web.Repositories
{
    public class TestDbContext:DbContext
    {
         private IConfiguration Configuration { get; }

         public TestDbContext(IConfiguration cfg)
         {
             this.Configuration=cfg;
         }

         protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseMySql(Configuration.GetConnectionString("gwtestDb"));
         }

         public DbSet<BillDetailSync2SapLogEntity> BillDetailSync2SapLog { get; set; }
    }
}
