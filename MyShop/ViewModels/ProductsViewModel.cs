using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using MyShop.Models;
using MyShop.Repositories;
using MyShop.Service;
using MyShop.Views;
using MyShop.Views.Dialog;
using MyShop.Views.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Networking.Sockets;
using static MyShop.Views.Dialog.CommonDialog;

namespace MyShop.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; } = new();
        
        private Product? selectedProduct = null;
        public Product? SelectedProduct 
        { 
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                UpdateSelectedProductCommand.RaiseCanExecuteChanged();
                DeleteSelectedProductCommand.RaiseCanExecuteChanged();
            }
        }
        public bool HasSelection => SelectedProduct != null;
        public bool NoSelection => SelectedProduct == null;
        // Service
        public ProductService _productService = new ProductService();
        
        // Pagination properties
        public PagingMetadata Pagination { get; set; } = new();

        // Commands
        public RelayCommand AddNewProductCommand {  get; }
        public RelayCommand UpdateSelectedProductCommand { get; }
        public RelayCommand DeleteSelectedProductCommand { get; }
        public RelayCommand ChangePageCommand { get; set; }

        // InfoBar properties
        public bool ShowInfoBar { get; set; } = false;
        public string InfoBarMessage { get; set; } = string.Empty;
        public string InfoBarType { get; set; } = string.Empty;

        public ProductsViewModel()
        {
            AddNewProductCommand = new RelayCommand(
                async _ => await _addNewProductAsync());

            UpdateSelectedProductCommand = new RelayCommand(
                async _ => await _updateSelectedProductAsync(), 
                _ => HasSelection);

            DeleteSelectedProductCommand = new RelayCommand(
                async _ => await _deleteSelectedProductAsync(), 
                _ => HasSelection);
            ChangePageCommand = new RelayCommand(
                page => _changePage((int?)page));

            _ = _loadProducts();
        }

        private async Task _loadProducts()
        {
            var result = await _productService.GetAllProducts(new PagingRequest()
            {
                PageSize = Pagination.PageSize,
                PageNumber = Pagination.PageNumber
            });
            Pagination = result.Pagination;
            Products.Clear();
            foreach (var item in result.Items!)
            {
                Products.Add(item);
            }
            SelectedProduct = Products[0];
        }

        private async Task _addNewProductAsync()
        {
            var dialog = new AddProductForm()
            {
                XamlRoot = App.ActiveWindow!.Content.XamlRoot,
                Title = "Thêm sản phẩm mới",
                PrimaryButtonText = "Thêm",
                CloseButtonText = "Hủy",
                DefaultButton = ContentDialogButton.Primary
            };

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                await _productService.AddProductAsync(dialog.NewItem);
                
                int newPage = (int)Math.Ceiling((double)(Pagination.TotalItems + 1) / Pagination.PageSize);
                InfoBarMessage = $"Sản phẩm '{dialog.NewItem.Name}' đã được thêm thành công.";
                _showInfoBar(InfoBarMessage, "Success");
                //_ = new SuccessDialog(InfoBarMessage).ShowAsync();

                _changePage(newPage);
            }
        }

        private async Task _updateSelectedProductAsync()
        {
            if (SelectedProduct == null) return;

            var dialog = new EditProductForm(SelectedProduct)
            {
                XamlRoot = App.ActiveWindow!.Content.XamlRoot,
                Title = "Cập nhật thông tin sản phẩm",
                PrimaryButtonText = "Cập nhật",
                CloseButtonText = "Hủy",
                DefaultButton = ContentDialogButton.Primary
            };

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                var item = await _productService.UpdateProductAsync(dialog.EditItem);
                InfoBarMessage = $"Sản phẩm '{dialog.EditItem.Name}' đã được cập nhật thành công.";
                _showInfoBar(InfoBarMessage, "Success");
                _ = _loadProducts();
            }
        }

        private async Task _deleteSelectedProductAsync()
        {
            if (SelectedProduct == null) return;
            var name = SelectedProduct.Name;
            var result = await new ConfirmationDialog($"Bạn có chắc muốn xóa sản phẩm '{SelectedProduct.Name}' không?").ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                _productService.DeleteProductAsync(SelectedProduct.Id);

                Products.Remove(SelectedProduct);
                SelectedProduct = null;

                
                InfoBarMessage = $"Sản phẩm '{name}' đã được xóa thành công.";
                _showInfoBar(InfoBarMessage, "Success");
                if (Pagination.PageNumber < Pagination.TotalPages)
                {
                    _ = _loadProducts();
                }
                else
                {
                    int newPage = (int)Math.Ceiling((double)(Pagination.TotalItems - 1) / Pagination.PageSize);
                    _changePage(newPage);
                }
                
            }
        }


        private void _changePage(int? pageNumber)
        {
            Pagination.PageNumber = pageNumber ?? 1;

            _ = _loadProducts();
        }

        private void _showInfoBar(string message, string type)
        {
            InfoBarMessage = message;
            InfoBarType = type;
            ShowInfoBar = true;
        }

        public void CloseProductCommand()
        {
            SelectedProduct = null;
        }
    }
}
