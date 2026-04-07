using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Automation.Peers;
using Microsoft.UI.Xaml.Automation.Provider;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Helpers
{
    public static class EnterKeyHelper
    {
        // Khai báo Attached Property
        public static readonly DependencyProperty DefaultButtonProperty =
            DependencyProperty.RegisterAttached(
                "DefaultButton",
                typeof(Button),
                typeof(EnterKeyHelper),
                new PropertyMetadata(null, OnDefaultButtonChanged));

        public static void SetDefaultButton(DependencyObject element, Button value) => element.SetValue(DefaultButtonProperty, value);
        public static Button GetDefaultButton(DependencyObject element) => (Button)element.GetValue(DefaultButtonProperty);

        private static void OnDefaultButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element)
            {
                element.KeyDown -= Element_KeyDown;
                if (e.NewValue != null)
                {
                    element.KeyDown += Element_KeyDown;
                }
            }
        }

        private static void Element_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                var button = GetDefaultButton(sender as DependencyObject);
                if (button != null && button.IsEnabled)
                {
                    e.Handled = true;
                    var peer = new ButtonAutomationPeer(button);
                    var invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                    invokeProv?.Invoke();
                }
            }
        }
    }
}
