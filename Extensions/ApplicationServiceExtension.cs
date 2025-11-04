using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;
using QuanLyDaiLy.Configs;
using QuanLyDaiLy.Helpers;
using QuanLyDaiLy.Repositories;
using QuanLyDaiLy.Services;
using QuanLyDaiLy.ViewModels;
using QuanLyDaiLy.Views;
using System.Windows.Navigation;

namespace QuanLyDaiLy.Extensions;

public static class ApplicationServiceExtensions
{
  public static IServiceCollection ConfigureServices(this IServiceCollection services)
  {
      // Register database
      services.AddSingleton<DatabaseConfig>();

      // Register repositories and services
      services.AddScoped<IDaiLyService, DaiLyRepository>();
      services.AddScoped<ILoaiDaiLyService, LoaiDaiLyRepository>();
      services.AddScoped<IQuanService, QuanRepository>();
      services.AddScoped<IThamSoService, ThamSoRepository>();
  
      // Register helpers
      services.AddSingleton<ComboBoxItemConverter>();

      // Register ViewModels
      services.AddTransient<MainWindowViewModel>();
      services.AddTransient<HoSoDaiLyViewModel>();
      services.AddTransient<ChinhSuaDaiLyViewModel>();
      services.AddTransient<TraCuuDaiLyViewModel>();

      services.AddTransient<ViewModels.LoaiDaiLyViewModels.LoaiDaiLyPageViewModel>();
      services.AddTransient<ViewModels.LoaiDaiLyViewModels.ThemLoaiDaiLyViewModel>();
      services.AddTransient<ViewModels.LoaiDaiLyViewModels.CapNhatLoaiDaiLyViewModel>();
      services.AddTransient<ViewModels.LoaiDaiLyViewModels.TraCuuLoaiDaiLyWindowViewModel>();

      services.AddSingleton<Views.MainWindow>();

      // Register Views
      services.AddTransient<MainWindow>();
      services.AddTransient<HoSoDaiLyWinDow>();
      services.AddTransient<ChinhSuaDaiLyWindow>();
      services.AddTransient<TraCuuDaiLyWindow>();

      services.AddTransient<Views.LoaiDaiLyViews.LoaiDaiLyPage>();
      services.AddTransient<Views.LoaiDaiLyViews.ThemLoaiDaiLyWindow>();
      services.AddTransient<Views.LoaiDaiLyViews.CapNhatLoaiDaiLyWindow>();
      services.AddTransient<Views.LoaiDaiLyViews.TraCuuLoaiDaiLyWindow>();
      return services;
  }
}
