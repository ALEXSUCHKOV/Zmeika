using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake
{
    class Class2
    {
        public bool proigrish = false;
        int kolvo_syedaniy = 0;
        int snakex;
        int snakey;
        int fruitX, fruitY;
        const int shirina = 17;
        const int visota = 17;
        int[] hvostX = new int[100];
        int[] hvostY = new int[100];
        int nomerhv;
        Random R = new Random();
        ConsoleKeyInfo knopki;
        public bool Setup(bool proigrish)
        {
            proigrish = false;
            snakex = shirina / 2 - 1;
            snakey = visota / 2 - 1;
            fruitX = R.Next(1, 10);
            fruitY = R.Next(1, 10);
            Console.WriteLine();
            return proigrish;
        }
        public void karta_and_pers()
        {
            Console.WriteLine();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < visota + 1; i++)
                Console.Write((char)35);
            Console.WriteLine();

            for (int i = 0; i < shirina; i++)
            {
                for (int j = 0; j < shirina; j++)
                {
                    if (j == 0 || j == shirina - 1)
                        Console.Write((char)35);
                    if (i == snakey && j == snakex)
                        Console.Write((char)64);
                    else if (i == fruitY && j == fruitX)
                        Console.Write((char)111);
                    else
                    {
                        bool print = false;

                        for (int k = 0; k < nomerhv; k++)
                        {
                            if (hvostX[k] == j && hvostY[k] == i)
                            {
                                print = true;
                                Console.Write((char)97);
                            }
                        }
                        if (!print)
                            Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            for (int j = 0; j < shirina + 1; j++)
                Console.Write((char)35);
            Console.WriteLine();
            Console.WriteLine("Длина хвоста " + kolvo_syedaniy);
        }
        public void Input_Logic()
        {
            int predznX = hvostX[0];
            int predznY = hvostY[0];
            int pred2X;
            int pred2Y;
            hvostX[0] = snakex;
            hvostY[0] = snakey;
            for (int i = 1; i < nomerhv; i++)
            {
                pred2X = hvostX[i];
                pred2Y = hvostY[i];
                hvostX[i] = predznX;
                hvostY[i] = predznY;
                predznX = pred2X;
                predznY = pred2Y;
            }
        }
        public void dvigenie()
        {
            if (Console.KeyAvailable == true)
            {
                knopki = Console.ReadKey(true);
            }
            switch (knopki.Key)
            {
                case ConsoleKey.UpArrow:
                    snakey--;
                    break;
                case ConsoleKey.DownArrow:
                    snakey++;
                    break;
                case ConsoleKey.RightArrow:
                    snakex++;
                    break;
                case ConsoleKey.LeftArrow:
                    snakex--;
                    break;
            }
        }
        public void itog()
        {
            if (snakex > shirina)
                snakex = 0;
            else if (snakex < 0)
                snakex = shirina - 1;
            if (snakey > visota)
                snakey = 0;
            else if (snakey < 0)
                snakey = visota - 1;
            for (int g = 0; g < nomerhv; g++)
            {
                if (hvostX[g] == snakex && hvostY[g] == snakey)
                {
                    proigrish = true;
                    Console.WriteLine("GAME OVER");
                    Console.WriteLine("RESTART 'R'");
                }
            }
            if (proigrish != false)
            {
                char RESTART = Convert.ToChar(Console.ReadLine());
                if (RESTART == 'R')
                {
                    Class2 class2 = new Class2();
                    class2.Setup(class2.proigrish);
                    while (!class2.proigrish)
                    {
                        class2.karta_and_pers();
                        class2.Input_Logic();
                        class2.dvigenie();
                        class2.itog();
                        Thread.Sleep(150);
                    }
                    Console.ReadKey();
                }
            }
            if (snakex == fruitX && snakey == fruitY)
            {
                kolvo_syedaniy++;
                fruitX = R.Next(1, visota - 2);
                fruitY = R.Next(1, shirina - 2);
                nomerhv++;
            }
        }
    }
}
