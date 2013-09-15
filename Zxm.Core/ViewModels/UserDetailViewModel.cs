using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Model;
using Zxm.Core.Common;

namespace Zxm.Core.ViewModels
{
    public class UserDetailViewModel : MvxViewModel
    {
        public void Init(string userId, string username)
        {
            DetailUrl = CreateURLById(userId);
            UserName = username;
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

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        string CreateURLById(string userId)
        {

            return string.Format("{0}user/details?userId={1}", Config.WebserviceUrl, userId);
        }
    }
}
