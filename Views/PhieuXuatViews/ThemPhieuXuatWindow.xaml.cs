using QuanLyDaiLy.ViewModels.PhieuXuatViewModels;   
using System.Windows;

namespace QuanLyDaiLy.Views.PhieuXuatViews
{
    /// <summary>
    /// Interaction logic for ThemPhieuXuatWindow.xaml
    /// </summary>
    public partial class ThemPhieuXuatWindow : Window
    {
        public ThemPhieuXuatWindow(ThemPhieuXuatViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
