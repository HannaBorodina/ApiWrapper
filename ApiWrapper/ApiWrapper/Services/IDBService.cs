using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWrapper.Services
{
    public interface IDBService
    {
        Task AddDataToDB<T>(string data);
    }
}
