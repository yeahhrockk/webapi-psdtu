using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicatonDBContext : DbContext
    {
        // координация EFCore в базе данных
        public ApplicatonDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions) { }
        public DbSet<User> UseR { get; set; }
        public DbSet<Role> RoleS { get; set; } 
        public DbSet<Permission> Permissions { get; set; } 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // связь User - Role через прокси-таблицу UserRoles (many-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.RoleU_R)
                .WithMany(r => r.UserR_U)
                .UsingEntity(j => j.ToTable("UserRoles"));

            // связь Role - Permission через прокси-таблицу RolePermissions (many-to-many)
            modelBuilder.Entity<Role>()
                .HasMany(r => r.PermissionR_P)
                .WithMany(p => p.RoleP_R)
                .UsingEntity(j => j.ToTable("RolePermissions"));
        }
        
    }
}