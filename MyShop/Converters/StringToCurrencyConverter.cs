using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyShop.Converters
{
    public class StringToCurrencyConverter : IValueConverter
    {
        public string Culture { get; set; } = "vi-VN";
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return "";

            int currency = int.Parse(value.ToString() ?? "0");
            CultureInfo culture = CultureInfo.GetCultureInfo(Culture);
            var formatted = string.Format(culture, "{0:C}", currency);
            return formatted;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
