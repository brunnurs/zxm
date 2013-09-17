using Cirrious.MvvmCross.Plugins.Sqlite;
using Zxm.Core.Common;

namespace Zxm.Core.Model
{
    public class UserSettings
    {
        public UserSettings()
        {
            Password = Config.DefaultUserPassword;
            UserName = Config.DefaultUserName;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
