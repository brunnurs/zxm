using System.Diagnostics;
using System.Linq;
using Cirrious.MvvmCross.ViewModels;
using Zxm.Core.Model;
using Zxm.Core.Services;

namespace Zxm.Core.ViewModels.Tabs
{
    //TODO: Binding of settings to gui and save logic is kind of not nice
    public class SettingsViewModel : MvxViewModel
    {
        private readonly IDatabaseService _databaseService;
        private readonly UserSettings _userSettings;

        public SettingsViewModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;

            _userSettings = _databaseService.GetAll<UserSettings>().FirstOrDefault();
            if (_userSettings == null)
            {
                _userSettings = new UserSettings();
                _databaseService.Insert(_userSettings);
            }
        }

        public string UserName
        {
            get { return _userSettings.UserName; }
            set
            {
                _userSettings.UserName = value;
                RaisePropertyChanged(() => UserName);
                _databaseService.Update(_userSettings);
            }
        }
    }
}
