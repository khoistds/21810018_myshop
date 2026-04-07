using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Helpers
{
    public static class ListViewBehavior
    {
        public static bool GetRightClickSelect(DependencyObject obj)
            => (bool)obj.GetValue(RightClickSelectProperty);

        public static void SetRightClickSelect(DependencyObject obj, bool value)
            => obj.SetValue(RightClickSelectProperty, value);

        public static readonly DependencyProperty RightClickSelectProperty =
            DependencyProperty.RegisterAttached(
                "RightClickSelect",
                typeof(bool),
                typeof(ListViewBehavior),
                new PropertyMetadata(false, OnChanged));

        private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ListView listView && (bool)e.NewValue)
            {
                listView.PointerPressed += OnPointerPressed;
            }
            else if (d is ListView lv)
            {
                lv.PointerPressed -= OnPointerPressed;
            }
        }

        private static void OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var control = sender as ListView;
            if (control == null) return;

            if (e.GetCurrentPoint(control).Properties.IsRightButtonPressed)
            {
                ListViewItem? item = FindParent<ListViewItem>((DependencyObject)e.OriginalSource);
                if (item != null)
                {
                    item.IsSelected = true;
                    var flyout = FlyoutBase.GetAttachedFlyout(item);
                    flyout?.ShowAt(item);
                }
            }
        }

        // Hàm bổ trợ để tìm thẻ cha (ListViewItem)
        private static T? FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            if (child == null) return null;
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null) return null;
            if (parentObject is T parent) return parent;
            return FindParent<T>(parentObject);
        }
    }
}
