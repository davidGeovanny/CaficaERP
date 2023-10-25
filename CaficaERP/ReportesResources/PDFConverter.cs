using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CaficaERP.ReportesResources
{
    public class PDFConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                MemoryStream ms = new MemoryStream((byte[])value);
                return ms;
            }
            else
                return null;


        }
        
        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            FileStream filestream = new FileStream((string)value, FileMode.Open, FileAccess.Read);
            byte[] doc = new byte[filestream.Length];
            BinaryReader binaryreader = new BinaryReader(filestream);
            binaryreader.Read(doc, (Int32)0, (Int32)filestream.Length);
            binaryreader.Close();


            return doc;
        }
    }

}
