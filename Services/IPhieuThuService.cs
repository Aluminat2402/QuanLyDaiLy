using QuanLyDaiLy.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace QuanLyDaiLy.Services
{
    public interface IPhieuThuService
    {
        
        Task<IEnumerable<PhieuThu>> GetAllPhieuThu();
        Task<IEnumerable<PhieuThu>> GetPhieuThuPage(int offset, int size = 20);
        Task<int> GetTotalPages(int size = 20);
        Task AddPhieuThu(PhieuThu phieuThu);
        Task<int> GenerateAvailableId();

    }
}