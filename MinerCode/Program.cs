using System;

namespace Miner
{
    class Program
    {
        //todo find friends
        //todo chage the color of mines
        public static string[] layer2a = {" ", " ", "M", "i", "n", "e", "r", " ", " ", " "};
        public static string[] layer1a = {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "};
        public static string[] layer0a = {"_", "_", "_", "_", "_", "_", "_", "_", "_", "_"};
        public static string[] layer0 = { "x", "0", "0", "0", "0", "0", "0", "0", "0", "0"};
        public static string[] layer1 = { "■", "▬", "▲", "0", "0", "0", "0", "0", "0", "0"};
        public static string[] layer2 = { "■", "▬", "▲", "0", "0", "0", "0", "0", "0", "0"};
        public static string[] layer3 = { "■", "▬", "▲", "*", "0", "0", "0", "0", "0", "0"};
        public static string[] layer4 = { "■", "▬", "▲", "0", "0", "0", "0", "0", "0", "0"};

        public static string[] layer5 = { "■", "▬", "▲", "*", "0", "0", "0", "0", "0", "0"};
        public static string[] layer6 = { "■", "▬", "▲", "■", "0", "0", "0", "0", "0", "0"};
        public static string[] layer7 = { "■", "▬", "▲", "*", "0", "0", "0", "0", "0", "0"};
        public static string[] layer8 = { "■", "▬", "▲", "■", "0", "0", "0", "0", "0", "0"};
        public static string[] layer9 = { "■", "▬", "▲", "▼", "*", "0", "0", "0", "0", "0"};

        public static string[] layer10 = { "■", "▬", "▲", "*", "0", "0", "0", "0", "0", "0"};
        public static string[] layer11 = { "■", "▬", "▲", "■", "0", "0", "0", "0", "0", "0"};
        public static string[] layer12 = { "■", "▬", "▲", "*", "0", "0", "0", "0", "0", "0"};
        public static string[] layer13 = { "■", "▬", "▲", "■", "0", "0", "0", "0", "0", "0"};
        public static string[] layer14 = { "■", "▬", "▲", "▼", "*", "0", "0", "0", "0", "0"};
        public static int highscore;
        public static int currentPosition = 0;
        public static bool AreYouDead;


        static void Main(string[] args)
        {
            Menu();
        }
        
        static void Start()
        {
            Console.CursorVisible = false;
            while (1<2)
            {
                Console.Clear();
                Coloring();
                Console.WriteLine("         Miner                HighScore:" + highscore);
                Console.WriteLine(" _____________________");
                Console.WriteLine("|" +" "+ "                    " +""+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer2a) +" "+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer1a) +" "+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer0a) +" "+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer0) +" "+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer1) +" "+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer2) +" "+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer3) +" "+ "|");
                Console.WriteLine("|" +" "+ Lib.Class1.WriteingLayers(layer4) +" "+ "|");
                Console.WriteLine("|_____________________|");
                Console.WriteLine("");
                IfYouAreDead();
                AcceptInput();       
            }
        }
        static void PointsGiving(string from_where)
        {
            switch(from_where)
            {
                case "left":
                    highscore = highscore + Lib.Class1.Points(layer0[currentPosition - 1]);
                break;
                case "right":
                    highscore = highscore + Lib.Class1.Points(layer0[currentPosition + 1]);
                break;
                case "down":
                    highscore = highscore + Lib.Class1.Points(layer1[currentPosition]);
                break;
            }
            return;
        }
        static void AcceptInput()
        {
            var key = Console.ReadKey();
            switch(key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if(currentPosition > 0)
                    {
                        PointsGiving("left");
                        layer0[currentPosition] = " ";
                        currentPosition--;
                        layer0[currentPosition] = "x";
                    }
                break;
                case ConsoleKey.RightArrow:
                    if(currentPosition < 9)
                    {
                        PointsGiving("right");
                        layer0[currentPosition] = " ";
                        currentPosition++;
                        layer0[currentPosition] = "x";
                    }
                break;
                case ConsoleKey.DownArrow:
                    PointsGiving("down");
                    layer0[currentPosition] = " ";
                    DownArrow();
                break;
            }
            return;
        }

        static void DownArrow()
        {
            Lib.Class1.ReplaceLayers(layer1a, layer2a);
            Lib.Class1.ReplaceLayers(layer0a, layer1a);
            Lib.Class1.ReplaceLayers(layer0, layer0a);
            Lib.Class1.ReplaceLayers(layer1, layer0);
            Lib.Class1.ReplaceLayers(layer2, layer1);
            Lib.Class1.ReplaceLayers(layer3, layer2);
            Lib.Class1.ReplaceLayers(layer4, layer3);
            Random r = new Random();
            int randIndex = r.Next(10);
            if (layer4[randIndex] == layer5[randIndex])
            {
                Lib.Class1.Randomize(layer10);
                Lib.Class1.Randomize(layer11);
                Lib.Class1.Randomize(layer12);
                Lib.Class1.Randomize(layer13);
                Lib.Class1.Randomize(layer14);
                Lib.Class1.ReplaceLayers(layer10, layer5);
                Lib.Class1.ReplaceLayers(layer11, layer6);
                Lib.Class1.ReplaceLayers(layer12, layer7);
                Lib.Class1.ReplaceLayers(layer13, layer8);
                Lib.Class1.ReplaceLayers(layer14, layer9);
            }
            Lib.Class1.ReplaceLayers(layer5, layer4);
            Lib.Class1.ReplaceLayers(layer6, layer5);
            Lib.Class1.ReplaceLayers(layer7, layer6);
            Lib.Class1.ReplaceLayers(layer8, layer7);
            Lib.Class1.ReplaceLayers(layer9, layer8);
            layer0[currentPosition] = "x";
            return;
        }

        static void IfYouAreDead()
        {
            for(var i = 0; i < layer0.Length; i++)
            {
                if(layer0[i] == "*")
                {
                    if(i != 0)
                    {
                        AreYouDead = Lib.Class1.IfLayerIsX(layer0[i-1]);
                        if(AreYouDead == true)
                        {OnEnd();}
                    }
                    if(i != 9)
                    {
                        AreYouDead = Lib.Class1.IfLayerIsX(layer0[i+1]);
                        if(AreYouDead == true)
                        {OnEnd();}
                    }
                }
                if(layer0a[i] == "*")
                {
                    AreYouDead = Lib.Class1.IfLayerIsX(layer0[i]);
                    if(AreYouDead == true)
                    {OnEnd();}
                }
                if(layer1[i] == "*")
                {
                    AreYouDead = Lib.Class1.IfLayerIsX(layer0[i]);
                    if(AreYouDead == true)
                    {OnEnd();}
                }
            }
            return;
        }
        static void OnEnd()
        {
            Console.WriteLine("You are dead");
            Console.ReadLine();
            Console.Clear();
            Environment.Exit(0);
        }
        static void Coloring()
        {
            for(var i = 0; i < layer0.Length; i++)
            {
                if(layer2a[i] == "*")
                {
                    
                }
                if(layer1a[i] == "*")
                {
                    
                }
                if(layer0a[i] == "*")
                {
                    
                }
                if(layer0[i] == "*")
                {

                }
                if(layer1[i] == "*")
                {
                    //Console.ForegroundColor = System.ConsoleColor.Red;
                    //layer1[1] = "*";
                    //Console.ResetColor();
                }
                if(layer2[i] == "*")
                {
                    
                }
                if(layer3[i] == "*")
                {
                    
                }
                if(layer4[i] == "*")
                {
                    
                }
            }
        }
        static void HowToPlay()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine("        Miner");
            Console.WriteLine(" _______________________ ");
            Console.WriteLine("|                       |");
            Console.WriteLine("| Move with the arrows  |");
            Console.WriteLine("|                       |");
            Console.WriteLine("| The objects give you  |");
            Console.WriteLine("| points                |");
            Console.WriteLine("|                       |");
            Console.WriteLine("|  Coal(■) - gives 50   |");
            Console.WriteLine("| points                |");
            Console.WriteLine("|                       |");
            Console.WriteLine("|  Iron(▲) - gives 100  |");  
            Console.WriteLine("| points                |");
            Console.WriteLine("|                       |");
            Console.WriteLine("|  Mercury(▬) - removes |");
            Console.WriteLine("| 10 points             |");
            Console.WriteLine("|                       |");
            Console.WriteLine("|  Diamonds(▼) - gives  |");
            Console.WriteLine("| 250 points            |");
            Console.WriteLine("|                       |");
            Console.WriteLine("|  Mines(*) - kills you |");
            Console.WriteLine("| when you are near it  |");
            Console.WriteLine("|                       |");
            Console.WriteLine("|  The Player(x) - you, |");
            Console.WriteLine("| the player            |");
            Console.WriteLine("|                       |");
            Console.WriteLine("|_______________________|");
            Console.ReadLine();
            Main(layer0);
            Console.WriteLine("");
            return;
        }
        static void Menu()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine("        Miner");
            Console.WriteLine(" _____________________ ");
            Console.WriteLine("|                     |");
            Console.WriteLine("| 1 - Start The Game  |");
            Console.WriteLine("| 2 - How to play     |");
            Console.WriteLine("|                     |");
            Console.WriteLine("|_____________________|");
            Console.WriteLine("");
            string input = Console.ReadLine();
            if (input == "1")
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
            else if(input == "2")
            {
                HowToPlay();
            }
        }
    }
}