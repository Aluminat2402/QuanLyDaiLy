using System.Windows;
using QuanLyDaiLy.ViewModels.PhieuXuatViewModels;

namespace QuanLyDaiLy.Views.PhieuXuatViews
{
    /// <summary>
    /// Interaction logic for CapNhatPhieuXuatWindow.xaml
    /// </summary>
    public partial class CapNhatPhieuXuatWindow : Window
    {
        public CapNhatPhieuXuatWindow(CapNhatPhieuXuatViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
