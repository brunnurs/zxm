using System;
using Zxm.Core.Model;

namespace Zxm.Core.Services
{
    public class MessageEventArgs : EventArgs
    {
        public Message Message { get; set; }
    }
}