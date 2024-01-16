using Hook.Core.Entities;
using Hook.Data.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Data.DAL
{
    public class HookDbContext : IdentityDbContext
    {
        public HookDbContext(DbContextOptions<HookDbContext> options) : base(options)
        {

        }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            base.OnModelCreating(builder);
        }
    }

}
