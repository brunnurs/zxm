using Cirrious.MvvmCross.Plugins.Sqlite;

namespace Zxm.Core.Model
{
    public class UserSettings
    {
		public const string DEFAULT_PASSWORD = "abcd1234abcd1234";

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }

		private string password = DEFAULT_PASSWORD;

        public string Password {
			get {
				return password;
			}
			set {
				password = value;
			}
		}
    }
}
