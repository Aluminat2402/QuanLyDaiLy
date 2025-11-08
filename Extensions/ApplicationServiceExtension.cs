using Microsoft.Extensions.DependencyInjection;
using QuanLyDaiLy.Configs;
using QuanLyDaiLy.Helpers;
using QuanLyDaiLy.Repositories;
using QuanLyDaiLy.Services;
using QuanLyDaiLy.ViewModels;
using QuanLyDaiLy.ViewModels.PhieuXuatViewModels;
using QuanLyDaiLy.ViewModels.DonViTinhViewModels;
using QuanLyDaiLy.Views;
using QuanLyDaiLy.Views.PhieuXuatViews;
using QuanLyDaiLy.Views.DonViTinhViews;
using System;

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
        services.AddScoped<IPhieuXuatService, PhieuXuatRepository>();
        services.AddScoped<IMatHangService, MatHangRepository>();
        services.AddScoped<IChiTietPhieuXuatService, ChiTietPhieuXuatRepository>();
        services.AddScoped<IDonViTinhService, DonViTinhRepository>();

        // Register helpers
        services.AddSingleton<ComboBoxItemConverter>();

        // Register ViewModels
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<HoSoDaiLyViewModel>();
        services.AddTransient<ChinhSuaDaiLyViewModel>();
        services.AddTransient<TraCuuDaiLyViewModel>();

        services.AddTransient<PhieuXuatPageViewModel>();
        services.AddTransient<ThemPhieuXuatViewModel>();
        services.AddTransient<CapNhatPhieuXuatViewModel>();
        services.AddTransient<TraCuuPhieuXuatWindow>();

        services.AddTransient<ViewModels.LoaiDaiLyViewModels.LoaiDaiLyPageViewModel>();
        services.AddTransient<ViewModels.LoaiDaiLyViewModels.ThemLoaiDaiLyViewModel>();
        services.AddTransient<ViewModels.LoaiDaiLyViewModels.CapNhatLoaiDaiLyViewModel>();
        services.AddTransient<ViewModels.LoaiDaiLyViewModels.TraCuuLoaiDaiLyWindowViewModel>();

        services.AddTransient<ViewModels.MatHangViewModels.MatHangPageViewModel>();
        services.AddTransient<ViewModels.MatHangViewModels.ThemMatHangWindowViewModel>();
        services.AddTransient<ViewModels.MatHangViewModels.CapNhatMatHangWindowViewModel>();
        services.AddTransient<ViewModels.MatHangViewModels.TraCuuMatHangWindowViewModel>();

        services.AddTransient<ViewModels.QuanViewModels.QuanPageViewModel>();
        services.AddTransient<ViewModels.QuanViewModels.ThemQuanViewModel>();
        services.AddTransient<ViewModels.QuanViewModels.ChinhSuaQuanViewModel>();

        services.AddTransient<DonViTinhPageViewModel>();
        services.AddTransient<ThemDonViTinhViewModel>();
        services.AddTransient<CapNhatDonViTinhViewModel>();

        services.AddSingleton<Views.MainWindow>();

        // Register Views
        services.AddTransient<MainWindow>();
        services.AddTransient<HoSoDaiLyWinDow>();
        services.AddTransient<ChinhSuaDaiLyWindow>();
        services.AddTransient<TraCuuDaiLyWindow>();

        services.AddTransient<PhieuXuatPage>();
        services.AddTransient<ThemPhieuXuatWindow>();
        services.AddTransient<Func<int, CapNhatPhieuXuatViewModel>>(px => phieuXuatId =>
            new CapNhatPhieuXuatViewModel(
                px.GetRequiredService<IPhieuXuatService>(),
                px.GetRequiredService<IChiTietPhieuXuatService>(),
                px.GetRequiredService<IDaiLyService>(),
                px.GetRequiredService<IMatHangService>(),
                px.GetRequiredService<ILoaiDaiLyService>()
            )
        );
        services.AddTransient<TraCuuPhieuXuatViewModel>();

        services.AddTransient<Views.LoaiDaiLyViews.LoaiDaiLyPage>();
        services.AddTransient<Views.LoaiDaiLyViews.ThemLoaiDaiLyWindow>();
        services.AddTransient<Views.LoaiDaiLyViews.CapNhatLoaiDaiLyWindow>();
        services.AddTransient<Views.LoaiDaiLyViews.TraCuuLoaiDaiLyWindow>();

        services.AddTransient<Views.MatHangViews.MatHangPage>();
        services.AddTransient<Views.MatHangViews.ThemMatHangWindow>();
        services.AddTransient<Views.MatHangViews.CapNhatMatHangWindow>();
        services.AddTransient<Views.MatHangViews.TraCuuMatHangWindow>();

        services.AddTransient<Views.QuanViews.QuanPage>();
        services.AddTransient<Views.QuanViews.ThemQuanWindow>();
        services.AddTransient<Views.QuanViews.CapNhatQuanWindow>();

        services.AddTransient<DonViTinhPage>();
        services.AddTransient<ThemDonViTinhWindow>();
        services.AddTransient<CapNhatDonViTinhWindow>();

        return services;
    }
}
