using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Services;

namespace Zxm.Core.ViewModels.Tabs
{
    public class SettingsViewModel : MvxViewModel
    {
        private readonly ISettingsService _settingsService;
        public SettingsViewModel(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
                Save();
            }
        }

        private void Save()
        {
            //var setting = _settingsService.GetUserSettings();
            //setting.UserName = UserName;
            //_settingsService.SaveUserSettings(setting);
        }
    }
}
