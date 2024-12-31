using System.Data.Entity;

namespace MyUserManagementApp.Data
{
    public class UserManagementInitializer : CreateDatabaseIfNotExists<UserManagementContext>
    {
        protected override void Seed(UserManagementContext context)
        {
            context.Users.Add(new Models.User
            {
                Username = "admin",
                Password = "admin123",
                Name = "Administrator",
                Email = "admin@example.com",
                Role = "Admin"
            });
            base.Seed(context);
        }
    }
}