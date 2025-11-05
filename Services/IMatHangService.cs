using QuanLyDaiLy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyDaiLy.Services
{
    public interface IMatHangService
    {
        Task<MatHang> GetMatHangById(int id);
        Task<IEnumerable<MatHang>> GetAllMatHang();
        Task<IEnumerable<MatHang>> GetMatHangPage(int offset, int size = 20);
        Task<int> GetTotalPages(int size = 20);

        Task UpdateMatHang(MatHang matHang);

        Task<MatHang> GetMatHangByTenMatHang(string tenMatHang);
        Task<int> GenerateAvailableId();
    }
}
