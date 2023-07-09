using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        #region DbSet
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }
        #endregion
        #region Setting
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Settings: set Primary keys
            modelBuilder.Entity<Team>().HasKey(t => t.Id);
            modelBuilder.Entity<TeamUser>().HasKey(tu => new { tu.TeamId, tu.UserId });
            #endregion
            #region settings: set auto generated unique identifier
            modelBuilder.Entity<Team>().Property<Guid>(t => t.Id).ValueGeneratedOnAdd();
            #endregion
            #region Settings: set many to many relations
            modelBuilder.Entity<TeamUser>()
            .HasOne(tu => tu.Team)
             .WithMany(u => u.TeamUsers)
             .HasForeignKey(tu => tu.TeamId);
            #endregion
        }
        #endregion
    }
}
