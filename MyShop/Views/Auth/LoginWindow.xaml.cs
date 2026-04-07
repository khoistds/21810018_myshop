using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MyShop.Views.Auth
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginWindow : Window
    {
        private AppWindow m_AppWindow;

        public LoginWindow()
        {
            InitializeComponent();

            IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);

            WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);

            m_AppWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);

            m_AppWindow.SetIcon("Assets/Logo/stds.ico");

            this.Title = "Login";
        }

        private void Window_Activated(object sender, WindowActivatedEventArgs args)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localSettings.Values.ContainsKey("Username") && localSettings.Values.ContainsKey("Password") && localSettings.Values.ContainsKey("Entropy"))
            {
                string username = (string)localSettings.Values["Username"];
                string encryptedPassword = (string)localSettings.Values["Password"];
                string entropy = (string)localSettings.Values["Entropy"];
                string rawPassword = Password.Decrypt(encryptedPassword, entropy);

                tb_Username.Text = username;
                pb_Password.Password = rawPassword;
            }

        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = tb_Username.Text;
            string password = pb_Password.Password;

            if (username == "admin" && password == "1")
            {
                if (chb_RememberMe.IsChecked == true)
                {
                    var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                    var (encryptedPassword, entropy) = Password.Encrypt(password);
                    localSettings.Values["Username"] = username;
                    localSettings.Values["Password"] = encryptedPassword;
                    localSettings.Values["Entropy"] = entropy;
                }
                // Tạo instance của cửa sổ chính
                MainWindow mainWindow = new MainWindow();

                // Sử dụng hàm điều hướng đã viết trong App để chuyển cửa sổ
                App.SwitchWindow(mainWindow);

            }
            else
            {
                var dialog = new ContentDialog()
                {
                    XamlRoot = this.Content.XamlRoot,
                    Content = "Invalid username or password.",
                    CloseButtonText = "OK"
                };
                var _ = await dialog.ShowAsync();
            }
        }
    }
}
