using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using QuanLyDaiLy.Messages;
using QuanLyDaiLy.Models;
using QuanLyDaiLy.Services;
using QuanLyDaiLy.Views.QuanViews;

namespace QuanLyDaiLy.ViewModels.QuanViewModels
{
    public partial class QuanPageViewModel :
        ObservableObject
    {
        private readonly IQuanService _quanService;
        private readonly IServiceProvider _serviceProvider;

        private int TotalPages = 0;
        private const int VisibleButtons = 5;
        private const int ItemsPerPage = 12;

        private record struct PaginationButton(string Content, string Parameter, Style Style);

        public QuanPageViewModel(
            IQuanService quanService,
            IServiceProvider serviceProvider
        ) {
            _quanService = quanService;
            _serviceProvider = serviceProvider;

            WeakReferenceMessenger.Default.RegisterAll(this);
        }
    }
}