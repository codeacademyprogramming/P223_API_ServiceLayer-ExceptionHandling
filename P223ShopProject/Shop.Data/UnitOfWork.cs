using Shop.Core;
using Shop.Core.Repositories;
using Shop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        ICategoryRepository _categoryRepository;
        ISettingRepository _settingRepository;

        private readonly ShopDbContext _context;
        public UnitOfWork(ShopDbContext context)
        {
            _context = context;
        }
        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_context);

        public ISettingRepository SettingRepository => _settingRepository ?? new SettingRepository(_context);    

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
