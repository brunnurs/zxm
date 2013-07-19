using System;
using System.Collections.Generic;

namespace Zxm.Core.Common
{
    public static class ListExtensions
    {
        public static List<T> ForEachReturnList<T>(this List<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }

            return enumeration;
        }
    }
}                                                                                                                                                         