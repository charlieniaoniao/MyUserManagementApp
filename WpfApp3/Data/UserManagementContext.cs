using System.Data.Entity;
using MyUserManagementApp.Migrations;
using MyUserManagementApp.Models;

namespace MyUserManagementApp.Data
{
    public class UserManagementContext : DbContext
    {
        public UserManagementContext() : base("UserManagementContext")
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserManagementContext,Configuration>());
            base.OnModelCreating(modelBuilder);
        }
    }
}