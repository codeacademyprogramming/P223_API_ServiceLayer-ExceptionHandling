using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;
using Shop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public class SettingRepository:Repository<Setting>,ISettingRepository
    {
        private readonly ShopDbContext _context;

        public SettingRepository(ShopDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<string> GetValue(string key)
        {
            Setting setting = await _context.Settings.FirstOrDefaultAsync(x => x.Key == key);

            return setting.Value;
        }
    }
}
