using System;
using Zxm.Core.Model;

namespace Zxm.Core.Common
{
    public class MessageEventArgs : EventArgs
    {
        public Message Message { get; set; }
    }
}