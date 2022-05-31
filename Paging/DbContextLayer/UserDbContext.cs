using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Paging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.DbContextLayer
{
    public class UserDbContext : IdentityDbContext<AppUser>
    {
        public IConfiguration Configuration { get; }

        public UserDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ContextConnection"));

        }

        public  DbSet<Product> products { get; set; }

        public DbSet<Item> items { get; set; }

        public DbSet<UserAlbum> userAlbums { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var item in builder.Model.GetEntityTypes())
            {
                var tableName = item.GetTableName();

                if (tableName.StartsWith("AspNet"))
                {
                    item.SetTableName(tableName.Substring(6));
                }

            }
            builder.Entity<Item>().HasMany<Product>(p => p.Products).WithOne(i => i.Item).HasForeignKey(id => id.ItemId);

        }
    }
}
