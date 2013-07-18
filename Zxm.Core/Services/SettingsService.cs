using Cirrious.MvvmCross.Plugins.Sqlite;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISQLiteConnectionFactory _sqLiteConnectionFactory;
        private const string DatabaseName = "ZxmDatabase";

        public SettingsService(ISQLiteConnectionFactory sqLiteConnectionFactory)
        {
            _sqLiteConnectionFactory = sqLiteConnectionFactory;
        }

        public UserSettings GetUserSettings()
        {
            using (var sqliteConnection = _sqLiteConnectionFactory.Create(DatabaseName))
            {
                //TODO: First maybe wrong when multiple users but works for now
                return sqliteConnection.Table<UserSettings>().FirstOrDefault();
            }
        }

        public void SaveUserSettings(UserSettings userSettings)
        {
            using (var sqliteConnection = _sqLiteConnectionFactory.Create(DatabaseName))
            {
                sqliteConnection.Update(userSettings);
            }
        }
    }
}