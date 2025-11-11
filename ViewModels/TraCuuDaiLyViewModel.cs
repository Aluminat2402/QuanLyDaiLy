using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using QuanLyDaiLy.Messages;
using QuanLyDaiLy.Models;
using QuanLyDaiLy.Services;
using QuanLyDaiLy.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace QuanLyDaiLy.ViewModels
{
    public partial class TraCuuDaiLyViewModel : ObservableObject
    {
        // Services
        private readonly IDaiLyService _daiLyService;
        private readonly ILoaiDaiLyService _loaiDaiLyService;
        private readonly IQuanService _quanService;
     
        public TraCuuDaiLyViewModel(
            ILoaiDaiLyService loaiDaiLyService,
            IQuanService quanService,
            IDaiLyService daiLyService
        )
        {
            _loaiDaiLyService = loaiDaiLyService;
            _quanService = quanService;
            _daiLyService = daiLyService;

            _ = LoadDataAsync();
        }

        #region Binding Properties
        [ObservableProperty]
        private string _maDaiLy = string.Empty;
        [ObservableProperty]
        private string _tenDaiLy = string.Empty;
        [ObservableProperty]
        private string _dienThoai = string.Empty;
        [ObservableProperty]
        private string _diaChi = string.Empty;
        [ObservableProperty]
        private string _email = string.Empty;
        [ObservableProperty]
        private ObservableCollection<LoaiDaiLy> _loaiDaiLies = [];
        [ObservableProperty]
        private LoaiDaiLy _selectedLoaiDaiLy = new();
        [ObservableProperty]
        private ObservableCollection<Quan> _quans = [];
        [ObservableProperty]
        private Quan _selectedQuan = new();
        [ObservableProperty]
        private DateTime _ngayTiepNhanFrom = DateTime.MinValue;
        [ObservableProperty]
        private DateTime _ngayTiepNhanTo = DateTime.Now;
        [ObservableProperty]
        private long _noDaiLyFrom = 0;
        [ObservableProperty]
        private long _noDaiLyTo = long.MaxValue;
        [ObservableProperty]
        private int _noTheoToiDaLoaiDaiLyFrom = 0;
        [ObservableProperty]
        private int _noTheoToiDaLoaiDaiLyTo = int.MaxValue;
        [ObservableProperty]
        private int _maPhieuXuatFrom = 0;
        [ObservableProperty]
        private int _maPhieuXuatTo = int.MaxValue;
        [ObservableProperty]
        private DateTime _ngayLapPhieuXuatFrom = DateTime.MinValue;
        [ObservableProperty]
        private DateTime _ngayLapPhieuXuatTo = DateTime.Now;
        [ObservableProperty]
        private long _tongGiaTriPhieuXuatFrom = 0;
        [ObservableProperty]
        private long _tongGiaTriPhieuXuatTo = long.MaxValue;
        [ObservableProperty]
        private string _tenDonViTinh = string.Empty;
        [ObservableProperty]
        private int _soLuongXuatCuaMatHangXuatFrom = 0;
        [ObservableProperty]
        private int _soLuongXuatCuaMatHangXuatTo = int.MaxValue;
        [ObservableProperty]
        private long _donGiaXuatCuaMatHangXuatFrom = 0;
        [ObservableProperty]
        private long _donGiaXuatCuaMatHangXuatTo = long.MaxValue;
        [ObservableProperty]
        private long _thanhTienCuaMatHangXuatFrom = 0;
        [ObservableProperty]
        private long _thanhTienCuaMatHangXuatTo = long.MaxValue;
        [ObservableProperty]
        private int _soLuongTonCuaMatHangXuatFrom = 0;
        [ObservableProperty]
        private int _soLuongTonCuaMatHangXuatTo = int.MaxValue;
        // Search Results
        public ObservableCollection<DaiLy> SearchResults = [];
        #endregion

        private async Task LoadDataAsync()
        {
            try
            {
                var listLoaiDaiLy = await _loaiDaiLyService.GetAllLoaiDaiLy();
                var listQuan = await _quanService.GetAllQuan();
                LoaiDaiLies.Clear();
                Quans.Clear();

                LoaiDaiLies = [.. listLoaiDaiLy];
                Quans = [.. listQuan];
        
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #region RelayCommands
        [RelayCommand]
        private void CloseWindow()
        {
            Application.Current.Windows.OfType<TraCuuDaiLyWindow>().FirstOrDefault()?.Close();
        }

        [RelayCommand]
        private async Task SearchDaiLy()
        {
            try
            {
                var daiLies = await _daiLyService.GetAllDaiLy();
                ObservableCollection<DaiLy> filteredResults = [.. daiLies];

                if (!string.IsNullOrEmpty(MaDaiLy))
                {
                    filteredResults = [.. filteredResults.Where(d => d.MaDaiLy.ToString().Contains(MaDaiLy))];
                }
                if (!string.IsNullOrEmpty(TenDaiLy))
                {
                    filteredResults = [.. filteredResults.Where(d => d.TenDaiLy.Contains(TenDaiLy))];
                }
                if (!string.IsNullOrEmpty(DienThoai))
                {
                    filteredResults = [.. filteredResults.Where(d => d.DienThoai.Contains(DienThoai))];
                }
                if (!string.IsNullOrEmpty(DiaChi))
                {
                    filteredResults = [.. filteredResults.Where(d => d.DiaChi.Contains(DiaChi))];
                }
                if (!string.IsNullOrEmpty(Email))
                {
                    filteredResults = [.. filteredResults.Where(d => d.Email.Contains(Email))];
                }
                if (!string.IsNullOrEmpty(SelectedLoaiDaiLy.TenLoaiDaiLy))
                {
                    filteredResults = [.. filteredResults.Where(d => d.MaLoaiDaiLy == SelectedLoaiDaiLy.MaLoaiDaiLy)];
                }
                if (!string.IsNullOrEmpty(SelectedQuan.TenQuan))
                {
                    filteredResults = [.. filteredResults.Where(d => d.MaQuan == SelectedQuan.MaQuan)];
                }
                // Tìm kiếm theo ngày tiếp nhận (từ - đến)
                if (NgayTiepNhanFrom != DateTime.MinValue && NgayTiepNhanTo != DateTime.MinValue)
                {
                    filteredResults = [.. filteredResults.Where(d => d.NgayTiepNhan >= NgayTiepNhanFrom && d.NgayTiepNhan <= NgayTiepNhanTo)];
                }
                // Tìm kiếm theo tiền nợ (từ - đến)
                if (NoDaiLyFrom != 0 || NoDaiLyTo != long.MaxValue)
                {
                    filteredResults = [.. filteredResults.Where(d => d.TienNo >= NoDaiLyFrom && d.TienNo <= NoDaiLyTo)];
                }
                // Tìm kiếm theo nợ tối đa (từ - đến)
                if (NoTheoToiDaLoaiDaiLyFrom != 0 || NoTheoToiDaLoaiDaiLyTo != int.MaxValue)
                {
                    filteredResults = [.. filteredResults.Where(d => d.LoaiDaiLy.NoToiDa >= NoTheoToiDaLoaiDaiLyFrom && d.LoaiDaiLy.NoToiDa <= NoTheoToiDaLoaiDaiLyTo)];
                }
               
                SearchResults = [.. filteredResults];

                ApplySearchResults();

                if (SearchResults.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào phù hợp!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ApplySearchResults()
        {
            WeakReferenceMessenger.Default.Send(new SearchCompletedMessage<DaiLy>(SearchResults));
            CloseWindow();
        }
        #endregion
    }
}
