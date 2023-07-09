
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Models.Task;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        #region DbSet
        public DbSet<Task> Task { get; set; }
        public DbSet<UserStory> UserStory { get; set; }
        #endregion
        #region Setting
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Settings: set Primary keys
            modelBuilder.Entity<Task>().HasKey(t => t.Id);
            modelBuilder.Entity<UserStory>().HasKey(s => s.Id);
            #endregion
            #region settings: set auto generated unique identifier
            modelBuilder.Entity<Task>().Property<Guid>(t => t.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<UserStory>().Property<Guid>(s => s.Id).ValueGeneratedOnAdd();
            #endregion
            #region Settings: set one to many relations
            modelBuilder.Entity<Task>().HasOne(t => t.UserStory)
                .WithMany(s => s.Tasks)
                .HasForeignKey(t => t.userStoryId);
            #endregion
        }
        #endregion
    }
}
