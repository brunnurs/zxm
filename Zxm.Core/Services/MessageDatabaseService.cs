using Cirrious.MvvmCross.Plugins.Sqlite;
using Zxm.Core.Common;
using Zxm.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Zxm.Core.Services
{
    public class MessageDatabaseService : DatabaseService
    {
        public MessageDatabaseService(ISQLiteConnectionFactory sqLiteConnectionFactory) : base(sqLiteConnectionFactory) {}

        public Message GetMessage(Message message)
        {
            using (var connection = SqLiteConnectionFactory.Create(Config.DatabaseName))
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
    }
}

