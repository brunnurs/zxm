using System.Collections.ObjectModel;
using Cirrious.MvvmCross.ViewModels;

namespace Zxm.Core.ViewModels.Tabs
{
    public class UserListViewModel : MvxViewModel
    {
        public UserListViewModel()
        {
            
        }

        private ObservableCollection<User> _users = new ObservableCollection<User>{new User{Name = "Hans"}, new User{Name = "Peter"}};
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                RaisePropertyChanged(() => Users);
            }
        }
    }

    public class User
    {
        public string Name { get; set; }
    }
}
