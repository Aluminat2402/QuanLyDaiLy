using QuanLyDaiLy.ViewModels.DonViTinhViewModels;
using System.Windows.Controls;


namespace QuanLyDaiLy.Views.DonViTinhViews
{
    /// <summary>
    /// Interaction logic for DonViTinhPage.xaml
    /// </summary>
    public partial class DonViTinhPage : Page
    {
        public DonViTinhPage(DonViTinhPageViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
