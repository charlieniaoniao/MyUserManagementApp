namespace MyUserManagementApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SQLite.EF6.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyUserManagementApp.Data.UserManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }

        protected override void Seed(MyUserManagementApp.Data.UserManagementContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Users.Add(new Models.User
            {
                Username = "admin",
                Password = "admin123",
                Name = "Administrator",
                Email = "admin@example.com",
                Role = "Admin"
            });
        }
    }
}
