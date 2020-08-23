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
        public static void ReplaceLayers(string[] source, string[] destination)
        {
            Array.Copy(source, 0, destination, 0, 10);
        }

        public static int Points(string where)
        {
            switch(where)
            {
                case "■":
                    return 50;
                case "▬":
                    return -30;
                case "▲":
                    return 100;
                case "▼":
                    return 250;
                default:
                    return 0;
            }
        }
        public static bool IfLayerIsX(string layer)
        {
            if (layer == "x")
            {
                return true;
            }
            else{return false;}
        }
    }
}
