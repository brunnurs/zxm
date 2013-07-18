using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public interface ISettingsService
    {
        UserSettings GetUserSettings();
        void SaveUserSettings(UserSettings userSettings);
    }
}
