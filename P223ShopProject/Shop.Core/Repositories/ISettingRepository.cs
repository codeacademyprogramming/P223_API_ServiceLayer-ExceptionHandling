using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Repositories
{
    public interface ISettingRepository:IRepository<Setting>
    {
        Task<string> GetValue(string key);
    }
}
