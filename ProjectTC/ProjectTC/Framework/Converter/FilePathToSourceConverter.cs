using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace Framework
{
    public class FilePathToSourceConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (null == value || true == String.IsNullOrEmpty(value.ToString()) || false == File.Exists(value.ToString()))
                return null;

            BitmapImage bitmapImage = null;

            try
            {
                string fileTemp = value.ToString() + "_tmp";
                File.Copy(value.ToString(), fileTemp, true);

                using (var stream = new FileStream(fileTemp, FileMode.Open))
                {
                    bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = stream;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();
                }

                if (File.Exists(fileTemp))
                    File.Delete(fileTemp);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bitmapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
