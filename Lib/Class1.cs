using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Lib
{
    public class Class1
    {
        public static string WriteingLayers(string[] layer)
        {
            string a = layer[0] +" "+ layer[1] +" "+ layer[2] +" "+ layer[3] +" "+ layer[4] +" "+ layer[5] +" "+ layer[6] +" "+ layer[7] +" "+ layer[8] +" "+ layer[9];
            return a;
        }
    

        public static void Randomize<T>(T[] items)
        {
            Random rand = new Random();

        // For each spot in the array, pick
        // a random item to swap into that spot.
            for (int i = 0; i < items.Length - 1; i++)
            {
            int j = rand.Next(i, items.Length);
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

    	[DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadConsoleOutputCharacter(
        IntPtr hConsoleOutput, 
        [Out] StringBuilder lpCharacter, 
        uint length, 
        COORD bufferCoord, 
        out uint lpNumberOfCharactersRead);

        [StructLayout(LayoutKind.Sequential)]
        public struct COORD
        {
            public short X;
            public short Y;
        }

        public static char ReadCharacterAt(int x, int y)
        {
            IntPtr consoleHandle = GetStdHandle(-11);
            if (consoleHandle == IntPtr.Zero)
            {
                return '\0';
            }
            COORD position = new COORD
            {
                X = (short)x,
                Y = (short)y
            };
            StringBuilder result = new StringBuilder(1);
            uint read = 0;
            if (ReadConsoleOutputCharacter(consoleHandle, result, 1, position, out read))
            {
                return result[0];
            }
            else
            {
                return '\0';
            }
        }
        public static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
    }
}
