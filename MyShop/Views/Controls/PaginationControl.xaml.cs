using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MyShop.Repositories;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MyShop.Views.Controls
{
    public class PageItem
    {
        public int Page { get; set; }
        public int Total { get; set; }
        public string Display => $"Page {Page}/{Total}";
    }
    public sealed partial class PaginationControl : UserControl, INotifyPropertyChanged
    {
        public event Action<int>? PageChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        public PagingMetadata Pagination
        {
            get => (PagingMetadata)GetValue(PaginationProperty);
            set
            {
                SetValue(PaginationProperty, value);
                _generatePageOptions();
            }
            
        }

        private void _generatePageOptions()
        {
            if (Pagination == null) return;

            PageOptions.Clear();
            for (int i = 1; i <= Pagination.TotalPages; i++)
            {
                PageOptions.Add(new PageItem { Page = i, Total = Pagination.TotalPages });
            }
        }

        public static readonly DependencyProperty PaginationProperty =
            DependencyProperty.Register(
                nameof(Pagination),
                typeof(PagingMetadata),
                typeof(PaginationControl),
                new PropertyMetadata(null));

        public ObservableCollection<PageItem> PageOptions { get; } = new();
        public PageItem? SelectedPage => PageOptions.FirstOrDefault(p => p.Page == Pagination.PageNumber);

        public string PageInfo => $"Page {Pagination.PageNumber} / {Pagination.TotalPages}";

        public string ItemsInfo
        {
            get
            {
                int start = (Pagination.PageNumber - 1) * Pagination.PageSize + 1;
                int end = Math.Min(Pagination.PageNumber * Pagination.PageSize, Pagination.TotalItems);
                return $"Showing {start}-{end} of {Pagination.TotalItems}";
            }
        }

        public PaginationControl()
        {
            InitializeComponent();
        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            Pagination.PageNumber = 1;
            PageChanged?.Invoke(Pagination.PageNumber);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PageInfo)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ItemsInfo)));
        }

        private void PrevPage_Click(object sender, RoutedEventArgs e)
        {
            if (Pagination.PageNumber > 1)
            {
                Pagination.PageNumber--;
                PageChanged?.Invoke(Pagination.PageNumber);
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (Pagination.PageNumber < Pagination.TotalPages)
            {
                Pagination.PageNumber++;
                PageChanged?.Invoke(Pagination.PageNumber);
            }
        }

        private void LastPage_Click(object sender, RoutedEventArgs e)
        {
            Pagination.PageNumber = Pagination.TotalPages;
            PageChanged?.Invoke(Pagination.PageNumber);
        }

        private void PageSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var control = (ComboBox)sender;
            if (control.SelectedValue == null) return;
            int newPage = (int)control.SelectedValue;
            if (newPage != Pagination.PageNumber)
            {
                PageChanged?.Invoke(newPage);
            }
        }
    }
}
