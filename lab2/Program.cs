using System;
using MyArray;
using System.Diagnostics;

namespace lab2
{
    class Program
    {
        
        static void DrawMenu()
        {
            Console.Clear(); //очистка экрана перед выводом меню
            Console.WriteLine("1 - Заполнить массив");
            Console.WriteLine("2 - Вывести массив");
            Console.WriteLine("3 - Отсортировать массив методом вставки");
            Console.WriteLine("4 - Отсортировать массив методом слияния");
            Console.WriteLine("5 - Вывод отсортированного массива");
            Console.WriteLine("C - Отчистка консоли");
            Console.WriteLine("6 - Esc. Выход из программы");
            for (int i = 0; i < 20; i++)
                Console.Write("----");
            Console.WriteLine();

        }
        static void Menu()
        {
            DrawMenu();

            int[] A = new int[0]; //инициализация массива
            int[] Sorted = new int[0]; //инициализация отсортированного массива
            bool f = false; // флаг ввода массива
            int N = 0;
            Stopwatch time = new Stopwatch();
            

            ConsoleKeyInfo K;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Введите команду > ");
                Console.ForegroundColor = ConsoleColor.White;
                K = Console.ReadKey();
                Console.WriteLine();
                try
                {
                    switch (K.Key)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine("Введите размер массива:");
                            N = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите диапазон значений массива через запятую:");
                            string[] ab = Console.ReadLine().Split(",");
                            int a = int.Parse(ab[0]);
                            int b = int.Parse(ab[1]);
                            A = Arr.RandomArr(N, a, b);
                            f = true;
                            Console.WriteLine("Массив успешно сгенерирован!");
                            break;
                        case ConsoleKey.D2:
                            if (f)
                            {
                                
                                Arr.PrintArr(A);
                            }
                            break;
                        case ConsoleKey.D3:
                            if (f)
                            {
                                Sorted = new int[N];
                                A.CopyTo(Sorted, 0);
                                time = new Stopwatch();
                                time.Start();
                                ArrSort.InsertSort(Sorted);
                                time.Stop();
                                TimeSpan ts = time.Elapsed;
                                Console.WriteLine("Массив отсортирован методом вставки. Затраченное время: {0}", ts);
                            }
                            break;
                        case ConsoleKey.D4:
                            if (f)
                            {
                                Sorted = new int[N];
                                A.CopyTo(Sorted, 0);
                                time = new Stopwatch();
                                time.Start();
                                ArrSort.MergeSort(Sorted);
                                time.Stop();
                                TimeSpan ts = time.Elapsed;
                                Console.WriteLine("Массив отсортирован методом слиянием. Затраченное время: {0}", ts);
                            }
                            break;
                        case ConsoleKey.D5:
                            if (f)
                            {
                                MyArray.Arr.PrintArr(Sorted);
                            }
                            break;
                        case ConsoleKey.C:
                            DrawMenu();
                            break;
                        default:
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Не корректный ввод!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Argument null!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Слишком большое число!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (K.Key != ConsoleKey.Escape);
        }
        static void Main(string[] args)
        {
            try
            {
                Menu();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
