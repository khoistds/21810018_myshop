using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MyShop.Views.Categories;
using MyShop.Views.Customers;
using MyShop.Views.Dashboard;
using MyShop.Views.Employees;
using MyShop.Views.Exports;
using MyShop.Views.Imports;
using MyShop.Views.Products;
using MyShop.Views.Settings;
using MyShop.Views.Stock;
using MyShop.Views.Suppliers;
using MyShop.Views.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MyShop.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            root.Navigate(typeof(DashboardPage));
        }

        private async void navigator_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                root.Navigate(typeof(SettingsPage));
                return;
            }
            var selectedItem = args.InvokedItemContainer;
            var selectedTag = selectedItem?.Tag?.ToString();

            if (selectedTag == "Exit")
            {
                ContentDialog exitDialog = new ContentDialog
                {
                    Title = "Confirm Exit",
                    Content = "Are you sure you want to exit the application?",
                    PrimaryButtonText = "Yes",
                    CloseButtonText = "No",
                    XamlRoot = this.Content.XamlRoot,
                };
                var result = await exitDialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    App.Current.Exit();
                }
                return;
            }

            root.Navigate(selectedTag switch
            {
                "DashBoardPage" => typeof(DashboardPage),
                "CategoryListPage" => typeof(CategoryListPage),
                "ProductListPage" => typeof(ProductListPage),
                "SupplierListPage" => typeof(SupplierListPage),
                "CustomerListPage" => typeof(CustomerListPage),
                "EmployeeListPage" => typeof(EmployeeListPage),
                "ImportListPage" => typeof(ImportListPage),
                "ExportListPage" => typeof(ExportListPage),
                "StockListPage" => typeof(StockListPage),
                "UserListPage" => typeof(UserListPage),
                "SettingsPage" => typeof(SettingsPage),
                _ => typeof(DashboardPage)
            });
        }
    }
}
