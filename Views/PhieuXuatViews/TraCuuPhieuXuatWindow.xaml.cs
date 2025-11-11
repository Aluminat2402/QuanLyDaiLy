using System.Windows;
using QuanLyDaiLy.ViewModels.PhieuXuatViewModels;

namespace QuanLyDaiLy.Views.PhieuXuatViews
{
    /// <summary>
    /// Interaction logic for TraCuuPhieuXuatWindow.xaml
    /// </summary>
    public partial class TraCuuPhieuXuatWindow : Window
    {
        public TraCuuPhieuXuatWindow(TraCuuPhieuXuatViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
