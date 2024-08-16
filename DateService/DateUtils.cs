using System;
using System.Globalization;
namespace DateService
{
    public class DateUtils
    {
        public static int  GetYearsGap(String dateString)
        {
            // Parse the string to a DateTime object
            DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            // Get today's date
            DateTime today = DateTime.Today;

            // Calculate the age
            int res = today.Year - date.Year;

            // If the birthday hasn't occurred yet this year, subtract one year from the age
            if (date > today.AddYears(-res))
            {
                res--;
            }
            return res;
        }
    }
}
