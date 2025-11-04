using Microsoft.EntityFrameworkCore;
using QuanLyDaiLy.Configs;
using QuanLyDaiLy.Data;
using QuanLyDaiLy.Models;
using QuanLyDaiLy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyDaiLy.Repositories
{
    public class PhieuXuatRepository : IPhieuXuatService
    {
        private readonly DataContext _context;

        public PhieuXuatRepository(DatabaseConfig databaseConfig)
        {
            _context = databaseConfig.DataContext;
            if (_context == null)
            {
                throw new ArgumentNullException(nameof(databaseConfig), "Database not initialized!");
            }
        }

        public async Task<PhieuXuat> GetPhieuXuatById(int id)
        {
            PhieuXuat? phieuXuat = await _context.DsPhieuXuat
                .Include(p => p.DaiLy)
                .Include(p => p.DsChiTietPhieuXuat)
                    .ThenInclude(c => c.MatHang)
                        .ThenInclude(m => m.DonViTinh)
                .FirstOrDefaultAsync(p => p.MaPhieuXuat == id);
            return phieuXuat ?? throw new Exception("PhieuXuat not found!");
        }

        public async Task<IEnumerable<PhieuXuat>> GetAllPhieuXuat()
        {
            return await _context.DsPhieuXuat
                .Include(p => p.DaiLy)
                .Include(p => p.DsChiTietPhieuXuat)
                    .ThenInclude(c => c.MatHang)
                        .ThenInclude(m => m.DonViTinh)
                .ToListAsync();
        }

        public async Task<IEnumerable<PhieuXuat>> GetPhieuXuatPage(int offset, int size = 20)
        {
            return await _context.DsPhieuXuat
                .Include(m => m.DaiLy)
                .Skip(offset * size)
                .Take(size)
                .ToListAsync();
        }

        public async Task<int> GetTotalPages(int size = 20)
        {
            int leftover = await _context.DsPhieuXuat.CountAsync() % size;
            int totalPages = await _context.DsPhieuXuat.CountAsync() / size;
            if (leftover > 0)
            {
                totalPages++;
            }
            return totalPages;
        }

        public async Task AddPhieuXuat(PhieuXuat phieuXuat)
        {
            _context.DsPhieuXuat.Add(phieuXuat);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GenerateAvailableId()
        {
            int maxId = await _context.DsPhieuXuat.MaxAsync(d => d.MaPhieuXuat);
            return maxId + 1;
        }
    }
}
