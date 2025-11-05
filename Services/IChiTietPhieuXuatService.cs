using QuanLyDaiLy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyDaiLy.Services
{
    public interface IChiTietPhieuXuatService
    {
        Task<ChiTietPhieuXuat> GetChiTietPhieuXuatById(int id);
        Task<IEnumerable<ChiTietPhieuXuat>> GetAllChiTietPhieuXuat();

        Task AddChiTietPhieuXuat(ChiTietPhieuXuat chiTietPhieuXuat);
        Task DeleteChiTietPhieuXuat(int id);

        Task<IEnumerable<ChiTietPhieuXuat>> GetChiTietPhieuXuatByPhieuXuatId(int maPhieuXuat);
    }
}
