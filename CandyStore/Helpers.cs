using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyStore
{
    internal static class Helpers
    {
        //changed from int to internal static so this can be accessed throughout the app
        internal static int GetDaysSinceOpening()
        {
            var openingDate = new DateTime(2023, 1, 1);
            TimeSpan timeDifference = DateTime.Now - openingDate;

            return timeDifference.Days;
        }

    } // end class Helpers
}
