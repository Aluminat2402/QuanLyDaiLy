using QuanLyDaiLy.ViewModels.PhieuXuatViewModels;
using System.Windows.Controls;

namespace QuanLyDaiLy.Views.PhieuXuatViews
{
    /// <summary>
    /// Interaction logic for PhieuXuatPage.xaml
    /// </summary>
    public partial class PhieuXuatPage : Page
    {
        public PhieuXuatPage(PhieuXuatPageViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
