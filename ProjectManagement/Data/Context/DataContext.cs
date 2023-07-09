using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        #region DbSets
        public DbSet<Project> Projects { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Service> Services { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region primary keys
            modelBuilder.Entity<Project>().HasKey(c => c.Id);
            modelBuilder.Entity<Sprint>().HasKey(c => c.Id);
            modelBuilder.Entity<Service>().HasKey(c => c.Id);
            #endregion

            #region OneToMany Relationships
            modelBuilder.Entity<Sprint>()
                .HasOne(p => p.Project)
                .WithMany(u => u.Sprints)
                .HasForeignKey(fk => fk.projectId);


            modelBuilder.Entity<Project>()
                .HasOne(p => p.Service)
                .WithMany(u => u.Projects)
                .HasForeignKey(fk => fk.Fk_ServiceId);
            #endregion
            #region Setting Auto Generated Unique Identifier
            modelBuilder.Entity<Project>().Property<Guid>(t => t.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Sprint>().Property<Guid>(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Service>().Property<Guid>(t => t.Id).ValueGeneratedOnAdd();
            #endregion

        }
    }
}
