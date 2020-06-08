using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Data;
using System.Globalization;
using System.Data;
using System.Windows.Media.Imaging;

namespace FilterWPF
{
    public class BoolToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DataRowView)
            {
                DataRowView row = value as DataRowView;

                if (row != null)
                {
                    if (row.DataView.Table.Columns.Contains("Status"))
                    {
                        Type type = row["Status"].GetType();
                        string status = (string)row["Status"];
                        if (status == "Null")
                        {
                            Uri uri = new Uri("pack://application:,,,/Images/yellow.jpg");
                            BitmapImage source = new BitmapImage(uri);
                            return source;
                        }
                        if (status == "True")
                        {
                            Uri uri = new Uri("pack://application:,,,/Images/green.jpg");
                            BitmapImage source = new BitmapImage(uri);
                            return source;
                        }
                        if (status == "False")
                        {
                            Uri uri = new Uri("pack://application:,,,/Images/red.jpg");
                            BitmapImage source = new BitmapImage(uri);
                            return source;
                        }
                    }
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
