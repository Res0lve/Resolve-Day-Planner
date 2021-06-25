using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResolveDayPlanner.Services
{
    public interface IDataStore<T>
    {
        Task<T> GetErrandAsync(string id);
    }
}