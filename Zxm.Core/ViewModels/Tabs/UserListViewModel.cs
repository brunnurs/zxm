using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Model;
using Zxm.Core.Services;

namespace Zxm.Core.ViewModels.Tabs
{
    public class UserListViewModel : MvxViewModel
    {
        private readonly IUserService _userService;

        public UserListViewModel(IUserService userService)
        {
            _userService = userService;
            LoadUsersCommand = new MvxCommand(LoadUsersCommandExecute);
        }

        private void LoadUsersCommandExecute()
        {
            Users = new ObservableCollection<User>(_userService.GetAllUser());
            Debug.WriteLine("Users loaded: " + Users.Count);
        }

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                RaisePropertyChanged(() => Users);
            }
        }

        public ICommand LoadUsersCommand { get; private set; }

		public override void Start() 
		{
			LoadUsersCommandExecute ();
		}
    }
}
