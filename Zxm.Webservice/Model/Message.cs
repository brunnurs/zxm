using System;
using ServiceStack.ServiceHost;

namespace Zxm.Webservice.Model
{
    [Route("/message", "GET POST")]
    [Route("/message/{Id}", "GET")]
    public class Message
    {
        public int Id { get; set; }
        public DateTime DateSent { get; set; }
        public string Sender { get; set; }
        public byte[] Content { get; set; }

        public Message(int id)
        {
            Id = id;
        }
    }
}
