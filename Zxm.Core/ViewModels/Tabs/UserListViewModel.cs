using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Common;
using Zxm.Core.Model;
using Zxm.Core.Services;

namespace Zxm.Core.ViewModels.Tabs
{
    public class UserListViewModel : MvxViewModel
    {
        private readonly UserService _userService;

        public UserListViewModel(UserService userService)
        {
            _userService = userService;
            Users = new ObservableCollection<User>();

            LoadUsersCommand = new MvxCommand(LoadUsersCommandExecute);
        }

        private void LoadUsersCommandExecute()
        {
            _userService.RequestAllUser(RequestUserCallback);
        }

        private void RequestUserCallback(List<User> newUserList)
        {
            if (newUserList != null)
            {
                Users = new ObservableCollection<User>(newUserList);
            }
        }

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                RaisePropertyChanged(() => Users);
            }
        }

        public ICommand LoadUsersCommand { get; private set; }

        public ICommand ShowUserDetailsCommand { get; private set; }

        public override void Start()
        {
            LoadUsersCommandExecute();
        }
    }
}
