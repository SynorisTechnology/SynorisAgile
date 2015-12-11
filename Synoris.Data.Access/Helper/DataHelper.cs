using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synoris.Data.Access.Helper
{
    public class DataHelper
    {
        public static DateTimeFormatInfo IndianDateFormat()
        {
            DateTimeFormatInfo dtinfo = new DateTimeFormatInfo();
            dtinfo.ShortDatePattern = "dd/MM/yyyy";
            dtinfo.DateSeparator = "/";
            return dtinfo;
        }
    }
}

