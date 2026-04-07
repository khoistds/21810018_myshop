using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using MyShop.Models;
using MyShop.Repositories;
using MyShop.Service;
using MyShop.Views.Auth;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MyShop
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        private Window? _window;
        public static Window? ActiveWindow { get; set;  }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
            Services.Register<IRepo<Product, int>, MockProductRepository>();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            _window = new LoginWindow();
            _window.Activate();
        }

        public static void SwitchWindow(Window newWindow)
        {
            // Lấy instance hiện tại của App
            var currentApp = (App)Application.Current;

            // Lưu lại cửa sổ cũ để đóng sau
            var oldWindow = currentApp._window;

            // Cập nhật cả biến instance và biến static sang cửa sổ mới
            currentApp._window = newWindow;
            ActiveWindow = newWindow;

            // Hiển thị cửa sổ mới
            currentApp._window.Activate();

            // Đóng cửa sổ cũ (nếu có)
            oldWindow?.Close();
        }

    }
}
