using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public class UserSettingsService 
    {
        private UserSettings _userSettings;
        public virtual UserSettings UserSettings
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
           //TODO Pos9: Update User Settings
        }

        private void LoadUserSettings()
        {
            //TODO Pos9: GetUserSettings
            //TODO Pos9: Create new Setting when no available

        }
    }
}
