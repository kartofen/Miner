using System;

namespace Miner
{
    class Program
    {
        public static string[] layer1 = { "■", "▬", "▲", "0", "0", "0", "0", "0", "0", "0"};
        public static string[] layer2 = { "■", "▬", "▲", "0", "0", "0", "0", "0", "0", "0"};
        public static string[] layer3 = { "■", "▬", "▲", "0", "0", "0", "0", "0", "0", "0"};
        public static string[] layer4 = { "■", "▬", "▲", "0", "0", "0", "0", "0", "0", "0"};
        public static string[] layer5 = { "■", "▬", "▲", "0", "0", "0", "0", "0", "0", "0"};
        public static string[] layer6 = { "■", "▬", "▲", "0", "0", "0", "0", "0", "0", "0"};
        public static string[] layer7 = { "■", "▬", "▲", "0", "0", "0", "0", "0", "0", "0"};
        public static string[] layer8 = { "■", "▬", "▲", "0", "0", "0", "0", "0", "0", "0"};
        public static string[] layer9 = { "■", "▬", "▲", "▼", "0", "0", "0", "0", "0", "0"};

        public static int left = 2;
        public static int top = 2;
        public static int highscore;

        static void Main(string[] args)
        {
            Lib.Class1.Randomize(layer1);
            Lib.Class1.Randomize(layer2);
            Lib.Class1.Randomize(layer3);
            Lib.Class1.Randomize(layer4);
            Lib.Class1.Randomize(layer5);
            Lib.Class1.Randomize(layer6);
            Lib.Class1.Randomize(layer7);
            Lib.Class1.Randomize(layer8);
            Lib.Class1.Randomize(layer9);
            Start();
        }
        
        static void Start()
        {
            Console.CursorVisible = false;
            while (1<2)
            {
                Console.Clear();
                
                Console.WriteLine("         Miner                    HighScore:" + highscore);
                Console.WriteLine(" _____________________");
                Console.WriteLine("|" +" "+ "                    " +""+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer1) +" "+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer2) +" "+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer3) +" "+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer4) +" "+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer5) +" "+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer6) +" "+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer7) +" "+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer8) +" "+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer9) +" "+ "|"); 
                PointsGiving();                          
                DrawScreen();
                AcceptInput();
            }
        }
        static void DrawScreen()
        {
            Console.SetCursorPosition(left, top);
            Console.Write('*');
            return;
        }

        static void AcceptInput()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if(left != 2)
                    { left-= 2;}
                break;
                case ConsoleKey.RightArrow:
                    if(left != 20)
                    { left+= 2;}
                break;
                /*case ConsoleKey.UpArrow:
                    if(top != 2)
                    { top--; }
                break;*/
                case ConsoleKey.DownArrow:
                    top++; 
                break;
                default:
                break;
            }
            return;
        }
        static void PointsGiving()
        {
            char current_char = Lib.Class1.ReadCharacterAt(left, top);
            if(current_char == '■')
            {
                highscore =+ 1;
            }
            if(current_char == '▬')
            {
                highscore =- 1;
            }
            if(current_char == '▲')
            {
                highscore =+ 2;
            }
            Console.SetCursorPosition(left, top);
            Console.WriteLine(' ');
            return;
            
        }        
    }
}
