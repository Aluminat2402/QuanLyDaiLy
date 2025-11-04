using System.Collections.Generic;
using System.Threading.Tasks;
using QuanLyDaiLy.Models;

namespace QuanLyDaiLy.Services
{
    public interface IPhieuXuatService
    {
        Task<PhieuXuat> GetPhieuXuatById(int id);
        Task<IEnumerable<PhieuXuat>> GetAllPhieuXuat();
        Task<IEnumerable<PhieuXuat>> GetPhieuXuatPage(int offset, int size = 20);
        Task<int> GetTotalPages(int size = 20);

        Task AddPhieuXuat(PhieuXuat phieuXuat);
        Task<int> GenerateAvailableId();
    }
}
