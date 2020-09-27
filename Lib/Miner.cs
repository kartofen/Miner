using System;

namespace Lib
{
    public class Miner
    {
        public static string WriteLayers(string[] layer)
        {
            string a = "│" +" "+ layer[0] +" "+ layer[1] +" "+ layer[2] +" "+ layer[3] +" "+ layer[4] +" "+ layer[5] +" "+ layer[6] +" "+ layer[7] +" "+ layer[8] +" "+ layer[9]+" "+ "│";
            return a;
        }
    

        public static void Randomize<T>(T[] items)
        {
            Random rand = new Random();
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

        public static int GivePoints(string where)
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

        public static void CenterText(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        public static void RandomizeLayers(string[] layer4, string[] layer5, string[] layer6, string[] layer7, string[] layer8, string[] layer9, string[] layer10, string[] layer11, string[] layer12, string[] layer13, string[] layer14)
        {
            Random r = new Random();
            int randIndex = r.Next(10);

            if (layer4[randIndex] == layer5[randIndex])
            {
                Randomize(layer10);
                Randomize(layer11);
                Randomize(layer12);
                Randomize(layer13);
                Randomize(layer14);
                ReplaceLayers(layer10, layer5);
                ReplaceLayers(layer11, layer6);
                ReplaceLayers(layer12, layer7);
                ReplaceLayers(layer13, layer8);
                ReplaceLayers(layer14, layer9);
            }

            return;
        }

        public static void HowToPlay()
        {
            Console.Clear();
            Colorful.Console.WriteAscii("         Miner");
            CenterText("┌───────────────────────┐");
            CenterText("│                       │");
            CenterText("│ Move with the arrows  │");
            CenterText("│                       │");
            CenterText("│ The objects give you  │");
            CenterText("│ Points                │");
            CenterText("│                       │");
            CenterText("│  Coal(■) - gives 50   │");
            CenterText("│ Points                │");
            CenterText("│                       │");
            CenterText("│  Iron(▲) - gives 100  │");  
            CenterText("│ Points                │");
            CenterText("│                       │");
            CenterText("│  Mercury(▬) - removes │");
            CenterText("│ 30 Points             │");
            CenterText("│                       │");
            CenterText("│  Diamonds(▼) - gives  │");
            CenterText("│ 250 Points            │");
            CenterText("│                       │");
            CenterText("│  Mines(*) - kills you │");
            CenterText("│ when you are near it  │");
            CenterText("│                       │");
            CenterText("│  The Player(x) - you, │");
            CenterText("│ the player            │");
            CenterText("│                       │");
            CenterText("└───────────────────────┘");
            Console.ReadLine();
            return;
        }
    }
}
