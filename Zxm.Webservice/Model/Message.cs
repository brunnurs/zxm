using System;
using System.Collections.Generic;

using ServiceStack.ServiceHost;

namespace Zxm.Webservice.Model
{
    [Route("/message", "GET")]
    [Route("/message/{Id}", "GET")]
    public class GetMessage : IReturn<List<Message>>
    {
        public int Id { get; set; }
    }
    
    [Route("/message", "POST")]
    public class CreateMessage : IReturn<Message>
    {
        public DateTime DateSent { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }
    }

    public class Message
    {
        public int Id { get; set; }
        public DateTime DateSent { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }

        public Message(int id)
        {
            Id = id;
        }

        public Message(CreateMessage messages)
        {
            DateSent = messages.DateSent;
            Sender = messages.Sender;
            Content = messages.Content;
        }
    }
}
