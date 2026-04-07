using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MyShop.Views.Products
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductListPage : Page
    {
        public ProductsViewModel ViewModel { get; set; } = new ProductsViewModel();
        public ProductListPage()
        {
            InitializeComponent();
        }

        private void closeSelectedProductButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CloseProductCommand();
        }

        private void listViewButton_Click(object sender, RoutedEventArgs e)
        {
            var newTemplate = (DataTemplate)productListPage.Resources["ListTemplate"];
            ProductsList.ItemTemplate = newTemplate;
        }

        private void thumbnailViewButton_Click(object sender, RoutedEventArgs e)
        {
            var newTemplate = (DataTemplate)productListPage.Resources["ThumbnailTemplate"];
            ProductsList.ItemTemplate = newTemplate;
        }

        private void PaginationControl_PageChanged(int newPage)
        {
            ViewModel.ChangePageCommand.Execute(newPage);
        }
    }
}
