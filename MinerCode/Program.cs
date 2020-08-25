using System;
using System.Drawing;
using Console = Colorful.Console;

namespace Miner
{
    class Program
    {
        //todo find friends

        /*tonotdo
            chage the color of mines using Colorful Console package,
            chage the color of mines when writing to the screen,
            add with "dotnet add package Colorful.Console --version 1.2.11",
            site of package "http://colorfulconsole.com/"
            nuget site "https://www.nuget.org/packages/Colorful.Console"
        */

        //todo make starting animation, change ascii Miner, in site http://patorjk.com/software/taag/#p=display&f=Big&t=Miner
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
                Console.WriteAscii("         Miner");
                Console.WriteLine("");
                Lib.Class1.CenteringText("HighScore:" + highscore);
                Lib.Class1.CenteringText("┌─────────────────────┐");
                Lib.Class1.CenteringText("│" +" "+ Lib.Class1.WriteingLayers(layer2a) +" "+ "│");
                Lib.Class1.CenteringText("│" +" "+ Lib.Class1.WriteingLayers(layer1a) +" "+ "│");
                Lib.Class1.CenteringText("│" +" "+ Lib.Class1.WriteingLayers(layer0a) +" "+ "│");
                Lib.Class1.CenteringText("│" +" "+ Lib.Class1.WriteingLayers(layer0) +" "+ "│");
                Lib.Class1.CenteringText("│" +" "+ Lib.Class1.WriteingLayers(layer1) +" "+ "│");
                Lib.Class1.CenteringText("│" +" "+ Lib.Class1.WriteingLayers(layer2) +" "+ "│");
                Lib.Class1.CenteringText("│" +" "+ Lib.Class1.WriteingLayers(layer3) +" "+ "│");
                Lib.Class1.CenteringText("│" +" "+ Lib.Class1.WriteingLayers(layer4) +" "+ "│");
                Lib.Class1.CenteringText("└─────────────────────┘");
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
            Lib.Class1.CenteringText("You are dead");
            Console.ReadLine();
            Console.Clear();
            Environment.Exit(0);
        }
        static void HowToPlay()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteAscii("         Miner");
            Lib.Class1.CenteringText("┌───────────────────────┐");
            Lib.Class1.CenteringText("│                       │");
            Lib.Class1.CenteringText("│ Move with the arrows  │");
            Lib.Class1.CenteringText("│                       │");
            Lib.Class1.CenteringText("│ The objects give you  │");
            Lib.Class1.CenteringText("│ points                │");
            Lib.Class1.CenteringText("│                       │");
            Lib.Class1.CenteringText("│  Coal(■) - gives 50   │");
            Lib.Class1.CenteringText("│ points                │");
            Lib.Class1.CenteringText("│                       │");
            Lib.Class1.CenteringText("│  Iron(▲) - gives 100  │");  
            Lib.Class1.CenteringText("│ points                │");
            Lib.Class1.CenteringText("│                       │");
            Lib.Class1.CenteringText("│  Mercury(▬) - removes │");
            Lib.Class1.CenteringText("│ 30 points             │");
            Lib.Class1.CenteringText("│                       │");
            Lib.Class1.CenteringText("│  Diamonds(▼) - gives  │");
            Lib.Class1.CenteringText("│ 250 points            │");
            Lib.Class1.CenteringText("│                       │");
            Lib.Class1.CenteringText("│  Mines(*) - kills you │");
            Lib.Class1.CenteringText("│ when you are near it  │");
            Lib.Class1.CenteringText("│                       │");
            Lib.Class1.CenteringText("│  The Player(x) - you, │");
            Lib.Class1.CenteringText("│ the player            │");
            Lib.Class1.CenteringText("│                       │");
            Lib.Class1.CenteringText("└───────────────────────┘");
            Console.ReadLine();
            Menu();
            return;
        }
        static void Menu()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteAscii("         Miner");
            Lib.Class1.CenteringText("┌────────────────────┐");
            Lib.Class1.CenteringText("│                    │");
            Lib.Class1.CenteringText("│ 1 - Start The Game │");
            Lib.Class1.CenteringText("│ 2 - How to play    │");
            Lib.Class1.CenteringText("│                    │");
            Lib.Class1.CenteringText("└────────────────────┘");
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