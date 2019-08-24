using System;
using System.Collections.Generic;
using System.Linq;

namespace VMS.Utils
{
    public class DatesService
    {
        public static List<DateTime> GetSelectedDaysInPeriod(DateTime startDate, DateTime endDate, List<DayOfWeek> daysToCheck)
        {
            var selectedDates = new List<DateTime>();

            if (startDate >= endDate)
            {
                return selectedDates; //No days to return
            }

            if (daysToCheck == null || daysToCheck.Count == 0)
            {
                return selectedDates; //No days to select
            }

            try
            {
                //Get the total number of days between the two dates
                var totalDays = (int)endDate.Subtract(startDate).TotalDays + 1;

                //So.. we're creating a list of all dates between the two dates:
                var allDatesQry = from d in Enumerable.Range(0, totalDays)
                                  select new DateTime(
                                                       startDate.AddDays(d).Year,
                                                       startDate.AddDays(d).Month,
                                                       startDate.AddDays(d).Day);

                //And extracting those weekdays we explicitly wanted to return
                var selectedDatesQry = from d in allDatesQry
                                       where daysToCheck.Contains(d.DayOfWeek)
                                       select d;

                //Copying the IEnumerable to a List
                selectedDates = selectedDatesQry.ToList();
            }
            catch (Exception)
            {
                //Log error
                //...

                //And re-throw
                throw;
            }
            return selectedDates;
        }

        public static List<DateTime> GetDatesFromCheckBoxes(DateTime beginDate, DateTime endDate, string days)
        {
            List<DayOfWeek> daysToCheck = new List<DayOfWeek>();
            //var days = daysList.Split(',');

            if (days.Contains("mon"))
            {
                daysToCheck.Add(DayOfWeek.Monday);
            }

            if (days.Contains("tue"))
            {
                daysToCheck.Add(DayOfWeek.Tuesday);
            }

            if (days.Contains("wed"))
            {
                daysToCheck.Add(DayOfWeek.Wednesday);
            }

            if (days.Contains("thu"))
            {
                daysToCheck.Add(DayOfWeek.Thursday);
            }

            if (days.Contains("fri"))
            {
                daysToCheck.Add(DayOfWeek.Friday);
            }

            if (days.Contains("sat"))
            {
                daysToCheck.Add(DayOfWeek.Saturday);
            }

            if (days.Contains("sun"))
            {
                daysToCheck.Add(DayOfWeek.Sunday);
            }

            return GetSelectedDaysInPeriod(beginDate, endDate, daysToCheck);
        }
    }
}
