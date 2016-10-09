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
    public class DateTimeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // 1. 컬쳐
            if (culture.Name.Equals("en"))
            {

            }
            else
            {
                // ko-KR 기본값

                if (value is DateTime)
                {
                    DateTime a = (DateTime)value;
                    if (a.Equals(DateTime.MinValue)) return "";
                    if (a.Equals(new DateTime(1900, 1, 1))) return "";
                    return string.Format("{0:D4}.{1:D2}.{2:D2}", a.Year, a.Month, a.Day);
                }
                else if (value is string)
                {
                    string a = (string)value;
                    if (a.Length >= 7)
                    {
                        string code = a.Substring(6, 1);
                        if (code.Equals("1") || code.Equals("2"))
                        {
                            return string.Format("19{0}.{1}.{2}", a.Substring(0, 2), a.Substring(2, 2), a.Substring(4, 2));
                        }
                        else if (code.Equals("3") || code.Equals("4"))
                        {
                            return string.Format("20{0}.{1}.{2}", a.Substring(0, 2), a.Substring(2, 2), a.Substring(4, 2));
                        }
                    }
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
