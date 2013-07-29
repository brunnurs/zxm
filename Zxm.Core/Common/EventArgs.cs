using System;

namespace Zxm.Core.Common
{
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}