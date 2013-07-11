using System.Collections.ObjectModel;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Model;

namespace Zxm.Core.ViewModels.Tabs
{
    public class UserListViewModel : MvxViewModel
    {
        public UserListViewModel()
        {

        }

        private ObservableCollection<User> _users = new ObservableCollection<User> { new User { Name = "Hans" }, new User { Name = "Peter" } };
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
}
