using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Plugins.Sqlite;
using Zxm.Core.Common;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public class DatabaseService
    {
        private readonly ISQLiteConnectionFactory _sqLiteConnectionFactory;

        public DatabaseService(ISQLiteConnectionFactory sqLiteConnectionFactory)
        {
            _sqLiteConnectionFactory = sqLiteConnectionFactory;
            using (var connection = _sqLiteConnectionFactory.Create(Config.DatabaseName))
            {
                connection.CreateTable<UserSettings>();
            }
        }

        public List<T> GetAll<T>() where T:new()
        {
            using (var connection = _sqLiteConnectionFactory.Create(Config.DatabaseName))
            {
                return connection.Table<T>().ToList();
            }
        }

        public void Update(object value)
        {
            using (var connection = _sqLiteConnectionFactory.Create(Config.DatabaseName))
            {
                connection.Update(value);
            } 
        }

        public void Insert(object value)
        {
            using (var connection = _sqLiteConnectionFactory.Create(Config.DatabaseName))
            {
                connection.Insert(value);
            } 
        }

        public void Delete(object value)
        {
            using (var connection = _sqLiteConnectionFactory.Create(Config.DatabaseName))
            {
                connection.Delete(value);
            } 
        }

    }
}