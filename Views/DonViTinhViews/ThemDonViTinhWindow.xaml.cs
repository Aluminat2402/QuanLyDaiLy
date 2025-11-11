using QuanLyDaiLy.ViewModels.DonViTinhViewModels;
using System.Windows;

namespace QuanLyDaiLy.Views.DonViTinhViews
{
    /// <summary>
    /// Interaction logic for ThemDonViTinhWindow.xaml
    /// </summary>
    public partial class ThemDonViTinhWindow : Window
    {
        public ThemDonViTinhWindow(ThemDonViTinhViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
