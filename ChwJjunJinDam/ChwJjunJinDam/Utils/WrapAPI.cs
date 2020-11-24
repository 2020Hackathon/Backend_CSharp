using System;
using System.Runtime.InteropServices;

namespace ChwJjunJinDam.Utils
{
    public enum ConTextColor
    {
        LACK, BLUE, GREEN, JADE, RED,
        PURPLE, YELLOW, WHITE, GRAY,
        LIGHT_BLUE, LIGHT_GREEN, LIGHT_JADE,
        LIGHT_RED, LIGHT_PURPLE,
        LIGHT_YELLOW, LIGHT_WHITE
    }

    public static class WrapAPI
    {
        [DllImport("Kernel32.dll")]
        static extern int SetConsoleTextAttribute(IntPtr hConsoleOutput, short wAttributes);

        [DllImport("Kernel32.dll")]
        static extern IntPtr GetStdHandle(int nStdHandle);

        const int STD_OUTPUT_HANDLE = -11;
        public static void SetConsoleTextColor(ConTextColor color)
        {
            IntPtr handle = GetStdHandle(STD_OUTPUT_HANDLE);
            SetConsoleTextAttribute(handle, (short)color);
        }
    }
}
