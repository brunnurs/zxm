using System;
using Cirrious.MvvmCross.Plugins.Sqlite;
using Newtonsoft.Json;

namespace Zxm.Core.Model
{
    public class Message
    {
        public Message(Message newMessage)
        {
            Content = newMessage.Content;
            Sender = newMessage.Sender;
            DateSent = newMessage.DateSent;
        }

        public Message()
        {

        }

        [PrimaryKey]
        public DateTime DateSent { get; set; }

        public bool ShouldSerializeDateSent()
        {
            // JSON.net crashes on android when serializing a DateTime-Property
            // This is why we do not serialize it as it is set again on the webservice
            return false;
        }


        public string Content { get; set; }
        public string Sender { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(Message))
                return false;
            Message other = (Message)obj;
            return Content == other.Content && Sender == other.Sender && DateSent == other.DateSent;
        }


        public override int GetHashCode()
        {
            unchecked
            {
                return (Content != null ? Content.GetHashCode() : 0) ^ (Sender != null ? Sender.GetHashCode() : 0) ^ (DateSent != null ? DateSent.GetHashCode() : 0);
            }
        }
        public override string ToString()
        {
            return string.Format("[Message: DateSent={0}, Sender={1}]", DateSent, Sender);
        }
    }
}
