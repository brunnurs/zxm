using Cirrious.MvvmCross.Plugins.Sqlite;

namespace Zxm.Core.Model
{
    public class UserSettings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
