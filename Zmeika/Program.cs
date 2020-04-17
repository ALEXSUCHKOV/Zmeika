
using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Выберите уровень слодности и введите его номер:");
            Console.WriteLine("1. Лёгкий уровень [поле10х10, скорость медленная]");
            Console.WriteLine("2. Средний уровень [поле15х15, скорость нормальная]");
            Console.WriteLine("3. Сложный уровень [поле20х20, скорость быстрая]");
            int V = Convert.ToInt32(Console.ReadLine());
            switch (V)
            {
                case 1:
                    Console.Clear();
                    Class1 class1 = new Class1();
                    class1.Setup(class1.proigrish);
                    while (!class1.proigrish)
                    {
                        class1.karta_and_pers();
                        class1.Input_Logic();
                        class1.dvigenie();
                        class1.itog();
                        Thread.Sleep(200);
                    }
                    break;
                case 2:
                    Console.Clear();
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
                    break;
                case 3:
                    Console.Clear();
                    Class3 class3 = new Class3();
                    class3.Setup(class3.proigrish);
                    while (!class3.proigrish)
                    {
                        class3.karta_and_pers();
                        class3.Input_Logic();
                        class3.dvigenie();
                        class3.itog();
                        Thread.Sleep(100);
                    }
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }
            Console.ReadKey();
        }
    }
}
