using System;
using Lib;

namespace MinerGame
{
    class Program
    {
        //todo find friends
        
        //!! dockerizing not working

        static string[] layer2a = {" ", " ", "M", "i", "n", "e", "r", " ", " ", " "};
        static string[] layer1a = {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "};
        static string[] layer0a = {"_", "_", "_", "_", "_", "_", "_", "_", "_", "_"};
        static string[] layer0 = { "x", "0", "0", "0", "0", "0", "0", "0", "0", "0"};
        static string[] layer1 = { "■", "▬", "▲", "0", "0", "0", "0", "0", "0", "0"};
        static string[] layer2 = { "■", "▬", "▲", "0", "0", "0", "0", "0", "0", "0"};
        static string[] layer3 = { "■", "▬", "▲", "*", "0", "0", "0", "0", "0", "0"};
        static string[] layer4 = { "■", "▬", "▲", "0", "0", "0", "0", "0", "0", "0"};

        static string[] layer5 = { "■", "▬", "▲", "*", "0", "0", "0", "0", "0", "0"};
        static string[] layer6 = { "■", "▬", "▲", "■", "0", "0", "0", "0", "0", "0"};
        static string[] layer7 = { "■", "▬", "▲", "*", "0", "0", "0", "0", "0", "0"};
        static string[] layer8 = { "■", "▬", "▲", "■", "0", "0", "0", "0", "0", "0"};
        static string[] layer9 = { "■", "▬", "▲", "▼", "*", "0", "0", "0", "0", "0"};

        static string[] layer10 = { "■", "▬", "▲", "*", "0", "0", "0", "0", "0", "0"};
        static string[] layer11 = { "■", "▬", "▲", "■", "0", "0", "0", "0", "0", "0"};
        static string[] layer12 = { "■", "▬", "▲", "*", "0", "0", "0", "0", "0", "0"};
        static string[] layer13 = { "■", "▬", "▲", "■", "0", "0", "0", "0", "0", "0"};
        static string[] layer14 = { "■", "▬", "▲", "▼", "*", "0", "0", "0", "0", "0"};
        static int highscore;
        static int currentPosition = 0;
        static bool AreYouDead_;


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Menu();

            Miner.Randomize(layer1);
            Miner.Randomize(layer2);
            Miner.Randomize(layer3);
            Miner.Randomize(layer4);
            Miner.Randomize(layer5);
            Miner.Randomize(layer6);
            Miner.Randomize(layer7);
            Miner.Randomize(layer8);
            Miner.Randomize(layer9);
            Start();
        }
        
        static void Start()
        {
            while (1<2)
            {
                Console.Clear();
                Colorful.Console.WriteAscii("         Miner");
                Console.WriteLine("");
                Miner.CenterText("HighScore:" + highscore);
                Miner.CenterText("┌─────────────────────┐");
                Miner.CenterText(Miner.WriteLayers(layer2a));
                Miner.CenterText(Miner.WriteLayers(layer1a));
                Miner.CenterText(Miner.WriteLayers(layer0a));
                Miner.CenterText(Miner.WriteLayers(layer0));
                Miner.CenterText(Miner.WriteLayers(layer1));
                Miner.CenterText(Miner.WriteLayers(layer2));
                Miner.CenterText(Miner.WriteLayers(layer3));
                Miner.CenterText(Miner.WriteLayers(layer4));
                Miner.CenterText("└─────────────────────┘");
                Console.WriteLine("");

                AreYouDead();
                AcceptInput();    
            }
        }
        
        static void AreYouDead()
        {
            for(var i = 0; i < layer0.Length; i++)
            {
                if(layer0a[i] == "*")
                {
                    AreYouDead_= Miner.IfLayerIsX(layer0[i]);
                    if(AreYouDead_== true)
                    {OnEnd();}
                }
                if(layer0[i] == "*")
                {
                    if(i != 0)
                    {
                        AreYouDead_= Miner.IfLayerIsX(layer0[i-1]);
                        if(AreYouDead_== true)
                        {OnEnd();}
                    }
                    if(i != 9)
                    {
                        AreYouDead_= Miner.IfLayerIsX(layer0[i+1]);
                        if(AreYouDead_== true)
                        {OnEnd();}
                    }
                }
                if(layer1[i] == "*")
                {
                    AreYouDead_= Miner.IfLayerIsX(layer0[i]);
                    if(AreYouDead_== true)
                    {OnEnd();}
                }
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
                        AddPoints("left");
                        layer0[currentPosition] = " ";
                        currentPosition--;
                        layer0[currentPosition] = "x";
                    }
                break;
                case ConsoleKey.RightArrow:
                    if(currentPosition < 9)
                    {
                        AddPoints("right");
                        layer0[currentPosition] = " ";
                        currentPosition++;
                        layer0[currentPosition] = "x";
                    }
                break;
                case ConsoleKey.DownArrow:
                    AddPoints("down");
                    layer0[currentPosition] = " ";
                    DownArrow();
                break;
            }
            return;
        }
        
        

        static void DownArrow()
        {
            Miner.ReplaceLayers(layer1a, layer2a);
            Miner.ReplaceLayers(layer0a, layer1a);
            Miner.ReplaceLayers(layer0, layer0a);
            Miner.ReplaceLayers(layer1, layer0);
            Miner.ReplaceLayers(layer2, layer1);
            Miner.ReplaceLayers(layer3, layer2);
            Miner.ReplaceLayers(layer4, layer3);

            Miner.RandomizeLayers(layer4, layer5, layer6, layer7, layer8, layer9, layer10, layer11, layer12, layer13, layer14);

            Miner.ReplaceLayers(layer5, layer4);
            Miner.ReplaceLayers(layer6, layer5);
            Miner.ReplaceLayers(layer7, layer6);
            Miner.ReplaceLayers(layer8, layer7);
            Miner.ReplaceLayers(layer9, layer8);

            layer0[currentPosition] = "x";
            return;
        }

        static void AddPoints(string from_where)
        {
            switch(from_where)
            {
                case "left":
                    highscore = highscore + Miner.GivePoints(layer0[currentPosition - 1]);
                break;
                case "right":
                    highscore = highscore + Miner.GivePoints(layer0[currentPosition + 1]);
                break;
                case "down":
                    highscore = highscore + Miner.GivePoints(layer1[currentPosition]);
                break;
            }
            return;
        }

        static void OnEnd()
        {
            Miner.CenterText("You are dead");
            Console.ReadLine();

            Console.Clear();
            Environment.Exit(0);
        }

        static void Menu()
        {
            Console.Clear();
            Colorful.Console.WriteAscii("         Miner");
            Miner.CenterText("┌────────────────────┐");
            Miner.CenterText("│ 1 - Start The Game │");
            Miner.CenterText("│ 2 - How to play    │");
            Miner.CenterText("│                    │");
            Miner.CenterText("└────────────────────┘");
            Console.WriteLine("");

            string input = Console.ReadLine();
            if (input == "1")
            {
                return;
            }
            else if(input== "2")
            {
                Miner.HowToPlay();
            }
        }
    }
}