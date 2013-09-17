using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Model;
using Zxm.Core.Services;

namespace Zxm.Core.ViewModels.Tabs
{
    public class SettingsViewModel : MvxViewModel
    {
        private readonly UserSettingsService _userSettingsService;
        private readonly UserSettings _userSettings;

        public SettingsViewModel(UserSettingsService userSettingsService)
        {
            _userSettingsService = userSettingsService;

            _userSettings = _userSettingsService.UserSettings;
        }

        public string UserName
        {
            get { return _userSettings.UserName; }
            set
            {
                _userSettings.UserName = value;
                RaisePropertyChanged(() => UserName);
                _userSettingsService.UserSettings = _userSettings;
            }
        }

        public string Password
        {
            get { return _userSettings.Password; }
            set
            {
                _userSettings.Password = value;
                RaisePropertyChanged(() => Password);
                _userSettingsService.UserSettings = _userSettings;
            }
        }
    }
}
