using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace SESC_WallpaperHelper
{
    public static class WallpaperHelper
    {
        private static readonly string _directoryPath = @"C:\Users\Admin\Desktop\";
        
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        /// <summary>
        /// 获得指定路径下指定文件路径
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="number">指定文件序号</param>
        private static string GetFilePath(string filePath, int number)
        {
            var root = new DirectoryInfo(filePath);
            return _directoryPath + root.GetFiles()[number].Name;
        }
        
        /// <summary>
        /// 根据当前时辰切换壁纸
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool ChangeWallPaperWithHour(int number)
        {
            var filePath = GetFilePath(_directoryPath, number);
            Console.WriteLine(filePath);
            var nResult = SystemParametersInfo(20, 1, filePath, 0x1 | 0x2);
            if (nResult == 0)
            {
                return false;
            }
            else
            {
                var currentUser = Registry.CurrentUser;
                var subKey = currentUser.CreateSubKey(@"Control Panel\Desktop\");
                subKey?.SetValue("Wallpaper", filePath);
            
                return true;
            }
        }
    }
}