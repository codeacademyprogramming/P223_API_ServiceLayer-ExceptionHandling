using Shop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ISettingRepository SettingRepository { get; }

        int Commit();
        Task<int> CommitAsync();

    }
}
