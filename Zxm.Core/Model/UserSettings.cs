using Cirrious.MvvmCross.Plugins.Sqlite;

namespace Zxm.Core.Model
{
    public class UserSettings
    {
        public const string DefaultPassword = "abcd1234abcd1234";
        private const string DefaultUserName = "Anonymous";

        public UserSettings()
        {
            Password = DefaultPassword;
            UserName = DefaultUserName;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
