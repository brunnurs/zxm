using Cirrious.MvvmCross.Plugins.Sqlite;
using Zxm.Core.Common;
using Zxm.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Zxm.Core.Services
{
    public class MessageDatabaseService
    {
        private readonly ISQLiteConnectionFactory _sqLiteConnectionFactory;

        public MessageDatabaseService(ISQLiteConnectionFactory sqLiteConnectionFactory)
        {
            _sqLiteConnectionFactory = sqLiteConnectionFactory;
            using (var connection = _sqLiteConnectionFactory.Create(Config.DatabaseName))
            {
                connection.CreateTable<Message>();
            }
        }

        public List<Message> GetAllMessages()
        {
            using (var connection = _sqLiteConnectionFactory.Create(Config.DatabaseName))
            {
                return connection.Table<Message>().ToList();
            }
        }

        public Message GetMessage(Message message)
        {
            using (var connection = _sqLiteConnectionFactory.Create(Config.DatabaseName))
            {
                return  (   
                            from m in connection.Table<Message>()
                            where m.Sender.Equals(message.Sender)
                            where m.Content.Equals(message.Content)
                            where m.DateSent.Equals(message.DateSent)
                            select m
                         ).FirstOrDefault();                                              
            }
        }

        public void InsertMessage(Message message)
        {
            using (var connection = _sqLiteConnectionFactory.Create(Config.DatabaseName))
            {
                connection.Insert(message);
            }
        }

        public void DeleteMessage(Message message)
        {
            using (var connection = _sqLiteConnectionFactory.Create(Config.DatabaseName))
            {
                connection.Delete(message);
            }
        }
    }
}

