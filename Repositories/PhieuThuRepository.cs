using Microsoft.EntityFrameworkCore;
using QuanLyDaiLy.Configs;
using QuanLyDaiLy.Data;
using QuanLyDaiLy.Models;
using QuanLyDaiLy.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyDaiLy.Repositories
{
    public class PhieuThuRepository : IPhieuThuService
    {
        private readonly DataContext _context;

        public PhieuThuRepository(DatabaseConfig databaseConfig)
        {
            _context = databaseConfig.DataContext;
            if (_context == null)
            {
                throw new ArgumentNullException(nameof(databaseConfig), "Database not initialized!");
            }
        }

        public async Task<IEnumerable<PhieuThu>> GetAllPhieuThu()
        {
            return await _context.DsPhieuThu
                .Include(p => p.DaiLy)
                .ToListAsync();
        }

        public async Task<IEnumerable<PhieuThu>> GetPhieuThuPage(int offset, int size = 20)
        {
            return await _context.DsPhieuThu
                .Include(m => m.DaiLy)
                .Skip(offset * size)
                .Take(size)
                .ToListAsync();
        }
        public async Task<int> GetTotalPages(int size = 20)
        {
            int leftover = await _context.DsPhieuThu.CountAsync() % size;
            int totalPages = await _context.DsPhieuThu.CountAsync() / size;
            if (leftover > 0)
            {
                totalPages++;
            }
            return totalPages;
        }
    }
}