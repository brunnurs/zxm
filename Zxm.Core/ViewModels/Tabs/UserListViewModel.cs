using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Model;

namespace Zxm.Core.ViewModels.Tabs
{
    public class UserListViewModel : MvxViewModel
    {
        public UserListViewModel()
        {
            //TODO Pos5: Get UserService
            LoadUsersCommand = new MvxCommand(LoadUsersCommandExecute);
            Users = new List<User>();
        }

        private void LoadUsersCommandExecute()
        {
            //TODO Pos5: Request Users
        }

        private void RequestUserCallback(List<User> newUserList)
        {
            if (newUserList != null)
            {
                Users = newUserList;
            }
        }

        private List<User> _users;
        public List<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                RaisePropertyChanged(() => Users);
            }
        }

        public ICommand LoadUsersCommand { get; private set; }

        public override void Start()
        {
            LoadUsersCommandExecute();
        }
    }
}
