using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public enum WeekDay
    {
        Maandag = 1,
        Dinsdag = 2,
        Woensdag = 3,
        Donderdag = 4,
        Vrijdag = 5,
        Zaterdag = 6,
        Zondag = 7
    }
    public static class WeekHelper
    {
        public static string GetDagByWeekday(int day)
        {
            switch (day)
            {
                case 1:
                    return WeekDay.Maandag.ToString();
                case 2:
                    return WeekDay.Dinsdag.ToString();
                case 3:
                    return WeekDay.Woensdag.ToString();
                case 4:
                    return WeekDay.Donderdag.ToString();
                case 5:
                    return WeekDay.Vrijdag.ToString();
                case 6:
                    return WeekDay.Zaterdag.ToString();
                case 7:
                    return WeekDay.Zondag.ToString();
                default:
                    return string.Empty;
            }
        }
    }

}
