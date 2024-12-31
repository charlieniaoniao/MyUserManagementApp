using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MyUserManagementApp.Models;
using MyUserManagementApp.Data;
using MyUserManagementApp.Commands;

namespace MyUserManagementApp.ViewModels
{
    public class UserManagementViewModel : BaseViewModel
    {
        private UserManagementContext _context;
        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser { get; set; }
        public User NewUser { get; set; }

        public ICommand AddUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }

        public UserManagementViewModel()
        {
            _context = new UserManagementContext();
            Users = new ObservableCollection<User>(_context.Users.ToList());
            NewUser = new User();

            AddUserCommand = new RelayCommand(AddUser);
            UpdateUserCommand = new RelayCommand(UpdateUser);
            DeleteUserCommand = new RelayCommand(DeleteUser);
        }

        private void AddUser()
        {
            if (NewUser != null)
            {
                _context.Users.Add(NewUser);
                _context.SaveChanges();
                Users.Add(NewUser);
                NewUser = new User();
                OnPropertyChanged(nameof(NewUser));
            }
        }

        private void UpdateUser()
        {
            if (SelectedUser != null)
            {
                _context.Entry(SelectedUser).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                OnPropertyChanged(nameof(Users));
            }
        }

        private void DeleteUser()
        {
            if (SelectedUser != null)
            {
                _context.Users.Remove(SelectedUser);
                _context.SaveChanges();
                Users.Remove(SelectedUser);
            }
        }
    }
}