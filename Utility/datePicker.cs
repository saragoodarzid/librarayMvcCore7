using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Globalization;

namespace librarySampleMVC.Utility
{
    public static class datePicker
    {
        public static String toshamsi(this DateTime dateTime)
        {
            PersianCalendar persian = new PersianCalendar();
            string d = $"{persian.GetYear(dateTime)}/{persian.GetMonth(dateTime)}/{persian.GetDayOfMonth(dateTime)}";
            return $"{persian.GetYear(dateTime)}/{persian.GetMonth(dateTime)}/{persian.GetDayOfMonth(dateTime)}";
        }
    }
}
