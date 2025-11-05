using QuanLyDaiLy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyDaiLy.Services
{
    public interface IQuanService
    {
        Task<Quan> GetQuanById(int id);
        Task<IEnumerable<Quan>> GetAllQuan();
        Task<IEnumerable<Quan>> GetQuanPage(int offset, int size = 12);
        Task<int> GetTotalPages(int size = 12);
        Task AddQuan(Quan quan);
        Task<int> GenerateAvailableId();
    }
}