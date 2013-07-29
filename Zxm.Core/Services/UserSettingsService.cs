using System.Linq;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public class UserSettingsService 
    {
        private readonly DatabaseService _databaseService;

        public UserSettingsService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        private UserSettings _userSettings;
        public UserSettings UserSettings
        {
            get
            {
                if (_userSettings == null)
                {
                    LoadUserSettings();
                }
                return _userSettings;
            }
            set
            {
                _userSettings = value;
                UpdateUserSettings();
            }
        }

        private void UpdateUserSettings()
        {
            _databaseService.Update(_userSettings);
        }

        private void LoadUserSettings()
        {
            _userSettings = _databaseService.GetAll<UserSettings>().FirstOrDefault();
            if (_userSettings == null)
            {
                _userSettings = new UserSettings();
                _databaseService.Insert(_userSettings);
            }
        }
    }
}
