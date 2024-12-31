using System.Data.Entity;
using MyUserManagementApp.Models;

namespace MyUserManagementApp.Data
{
    public class UserManagementContext : DbContext
    {
        public UserManagementContext() : base("name=UserManagementContext")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}