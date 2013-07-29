using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Plugins.Sqlite;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public class DatabaseService : IDatabaseService
    {
        public const string DatabaseName = "ZxmDatabase";

        private readonly ISQLiteConnectionFactory _sqLiteConnectionFactory;

        public DatabaseService(ISQLiteConnectionFactory sqLiteConnectionFactory)
        {
            _sqLiteConnectionFactory = sqLiteConnectionFactory;
            using (var connection = _sqLiteConnectionFactory.Create(DatabaseName))
            {
                connection.CreateTable<UserSettings>();
            }
        }

        public List<T> GetAll<T>() where T:new()
        {
            using (var connection = _sqLiteConnectionFactory.Create(DatabaseName))
            {
                return connection.Table<T>().ToList();
            }
        }

        public void Update(object value)
        {
            using (var connection = _sqLiteConnectionFactory.Create(DatabaseName))
            {
                connection.Update(value);
            } 
        }

        public void Insert(object value)
        {
            using (var connection = _sqLiteConnectionFactory.Create(DatabaseName))
            {
                connection.Insert(value);
            } 
        }
    }
}