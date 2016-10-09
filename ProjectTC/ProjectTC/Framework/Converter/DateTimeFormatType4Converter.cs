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
    public class DateTimeFormatType4Converter : IValueConverter
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

                    return string.Format("{0}", a.ToString("D"));
                }
                else if (value is string)
                {
                    string a = (string)value;
                    if (a.Length >= 7)
                    {
                        int nYear = 0;
                        int nMonth = 0;
                        int nDay = 0;

                        int.TryParse(a.Substring(0, 2), out nYear);
                        int.TryParse(a.Substring(2, 2), out nMonth);
                        int.TryParse(a.Substring(4, 2), out nDay);

                        string code = a.Substring(6, 1);
                        if (code.Equals("1") || code.Equals("2"))
                        {
                            nYear += 1900;

                            DateTime obj = new DateTime(nYear, nMonth, nDay);

                            return string.Format("{0}", obj.ToString("D"));
                        }
                        else if (code.Equals("3") || code.Equals("4"))
                        {
                            nYear += 2000;

                            DateTime obj1 = new DateTime(nYear, nMonth, nDay);

                            return string.Format("{0}", obj1.ToString("D"));
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
