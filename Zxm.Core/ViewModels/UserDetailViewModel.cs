using Cirrious.MvvmCross.ViewModels;

namespace Zxm.Core.ViewModels
{
    public class UserDetailViewModel : MvxViewModel
    {
        public void Init(string uri)
        {
            DetailUrl = uri;
        }

        private string _detailUrl;
        public string DetailUrl
        {
            get { return _detailUrl; }
            set
            {
                _detailUrl = value;
                RaisePropertyChanged(() => DetailUrl);
            }
        }
    }
}
