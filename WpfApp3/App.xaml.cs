using System;
using System.Windows;
using System.Data.Entity;

namespace MyUserManagementApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 初始化数据库
            Database.SetInitializer(new Data.UserManagementInitializer());
            using (var context = new Data.UserManagementContext())
            {
                context.Database.Initialize(false);
            }
        }
    }
}