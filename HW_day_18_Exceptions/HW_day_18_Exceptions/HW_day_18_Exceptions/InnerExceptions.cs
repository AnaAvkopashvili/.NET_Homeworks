using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_18_Exceptions
{
    public class InnerExceptions
    {
        public static string AllInnerExceptions(Exception ex)
        {
            if (ex == null)
            {
                return "";
            }
            string exceptions = "Exception Message: " + ex.Message + Environment.NewLine;
            exceptions += AllInnerExceptions(ex.InnerException);
            return exceptions;
        }

        public static  string LastInnerException(Exception ex)
        {
            if (ex == null)
            {
                return "No inner exceptions.";
            }

            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            return "Last Inner Exception: " + ex.Message;
        }
    }
}
