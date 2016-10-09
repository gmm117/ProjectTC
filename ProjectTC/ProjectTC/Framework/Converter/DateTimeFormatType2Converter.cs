using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;


namespace Framework
{
    public class DateTimeFormatType2Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is DateTime)
            {
                var dt = (DateTime)value;
                return string.Format("{0:D4}년 {1:D2}월 {2:D2}일", dt.Year, dt.Month, dt.Day);
            }
            else if (value is string)
            {
                var dt = (string)value;
                return string.Format("{0:D4}년 {1:D2}월 {2:D2}일", dt.Substring(0, 4), dt.Substring(4, 2), dt.Substring(6, 2));
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
