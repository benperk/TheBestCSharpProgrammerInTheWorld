using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TreeView
{
    [ValueConversion(typeof(string), typeof(bool))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TreeViewModel)
            {
                TreeViewModel tvm = (TreeViewModel)value;

                if (tvm.IsRoot)
                {
                    Uri uri = new Uri("pack://application:,,,/green.png");
                    BitmapImage source = new BitmapImage(uri);
                    return source;
                }
                else
                {
                    Uri uri = new Uri("pack://application:,,,/blue.png");
                    BitmapImage source = new BitmapImage(uri);
                    return source;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
