﻿using System;

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

        public string Content { get; set; }
        public string Sender { get; set; }
        public DateTime DateSent { get; set; }
    }
}
