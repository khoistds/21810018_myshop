using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Views.Dialog
{
    public enum DialogType
    {
        Success,
        Error,
        Warning,
        Infomation,
        Confirmation
    }
    public class CommonDialog : ContentDialog
    {
        public static string ToImageText(DialogType type)
        {
            return type switch
            {
                DialogType.Success => "success.png",
                DialogType.Error => "error.png",
                DialogType.Warning => "warning.png",
                DialogType.Infomation => "infomation.png",
                DialogType.Confirmation => "confirmation.png",
                _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected dialog type value: {type}"),
            };
        }

        public CommonDialog(DialogType type, string message, string title)
        {
            string image = ToImageText(type);

            XamlRoot = App.ActiveWindow!.Content.XamlRoot;
            Title = title;
            Content = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                    new Image() {
                        Source = new BitmapImage(new Uri($"ms-appx:///Assets/Actions/{image}")),
                        Width = 64, Height = 64, Margin = new Thickness(0, 0, 20, 0)
                    },
                    new TextBlock() {
                        Text = message,
                        Width = 300, TextWrapping = TextWrapping.Wrap,
                        VerticalAlignment = VerticalAlignment.Center
                    }
                }
            };
            CloseButtonText = "Đóng";
        }

        public class SuccessDialog : CommonDialog
        {
            public SuccessDialog(string message, string title = "Thành công !") : base(DialogType.Success, message, title)
            {
            }
        }

        public class ErrorDialog : CommonDialog
        {
            public ErrorDialog(string message, string title = "Lỗi !") : base(DialogType.Error, message, title)
            {
            }
        }

        public class WarningDialog : CommonDialog
        {
            public WarningDialog(string message, string title = "Cảnh báo !") : base(DialogType.Warning, message, title)
            {
            }
        }

        public class InfomationDialog : CommonDialog
        {
            public InfomationDialog(string message, string title = "Thông tin !") : base(DialogType.Infomation, message, title)
            {
            }
        }

        public class ConfirmationDialog : CommonDialog
        {
            public ConfirmationDialog(string message, string title = "Xác nhận !") : base(DialogType.Confirmation, message, title)
            {
                PrimaryButtonText = "Đồng ý";
                CloseButtonText = "Hủy";
                DefaultButton = ContentDialogButton.Primary;
            }

        }
    }
}
