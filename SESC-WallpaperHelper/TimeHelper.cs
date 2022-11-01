using System;

namespace SESC_WallpaperHelper
{
    public static class TimeHelper
    {
        public static int GetHour()
        {
            var time = DateTime.Now.ToString("t");
            var hour = time.Split(':')[0];

            return HourToNumber(Convert.ToInt32(hour));
        }

        /// <summary>
        /// 24小时转为时辰
        /// </summary>
        /// <returns>第几时辰</returns>
        private static int HourToNumber(int hour)
        {
            switch (hour)
            {
                case 23:
                case 0:
                    return 1;
                
                case 1:
                case 2:
                    return 2;
                
                case 3:
                case 4:
                    return 3;
                
                case 5:
                case 6:
                    return 4;
                
                case 7:
                case 8:
                    return 5;
                
                case 9:
                case 10:
                    return 6;
                
                case 11:
                case 12:
                    return 7;
                
                case 13:
                case 14:
                    return 8;
                
                case 15:
                case 16:
                    return 9;
                
                case 17:
                case 18:
                    return 10;
                
                case 19:
                case 20:
                    return 11;
                
                case 21:
                case 22:
                    return 12;
            }

            return 0;
        }
    }
}