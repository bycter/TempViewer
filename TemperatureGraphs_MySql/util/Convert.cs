using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TempViewer.util
{
    public class Convert
    {
        
        public String[] ConvertDateToHour(DateTime[] date)
        {            
            string hour;
            int k = 0;
            String[] hourArray = new String[date.Length];
            foreach (DateTime i in date)
            {
                hour = i.Hour.ToString();
                
                if (i.Hour < 10)
                {
                    hour = "0" + hour;
                }
                
                hourArray[k] = hour;
                k++;
            }
            return hourArray;
        }

        private String[] ConvertDateToMinute(DateTime[] date)
        {
            string minute;
            int k = 0;
            String[] minuteArray = new String[date.Length];
            foreach (DateTime i in date)
            {
                minute = i.Hour.ToString();

                if (i.Hour < 10)
                {
                    minute = "0" + minute;
                }

                minuteArray[k] = minute;
                k++;
            }
            return minuteArray;
        }
    }
}
