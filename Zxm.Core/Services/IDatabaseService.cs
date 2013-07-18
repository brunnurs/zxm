using System.Collections.Generic;

namespace Zxm.Core.Services
{
    public interface IDatabaseService
    {
        List<T> GetAll<T>() where T : new();
        void Update(object value);
        void Insert(object value);
    }
}
