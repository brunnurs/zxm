using System;

namespace Zxm.Core.Model
{
    public class Message
    {
        public string Content { get; set; }
        public string Sender { get; set; }
        
        //TODO: This should be DateTime but Newtonsoft json.NET does not like it
        public string DateTime { get; set; }
    }
}
