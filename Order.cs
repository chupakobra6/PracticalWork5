using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    internal class Order
    {
        // объявление переменных
        static int numberOfTiers, productWeight, numberOfTiersPrice, shapePrice, cakeDecorationPrice, additionalInscriptionPrice, additionalDecorationsPrice;
        static string filling, shape, cakeDecoration, additionalInscription;
        static bool[] additionalDecorations = new bool[4];
        public static int price;
        public static string yourCake;

        public static void OrderMenu(int position)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите Escape\nВыберите пункт из меню:\n-----------------------");
            Console.SetCursorPosition(0, 3);

            OrderSubmenu(position);

            // цена яруса и вес в зависимости от него
            if (numberOfTiers != 0)
            {
                numberOfTiersPrice = 1000;

                if (numberOfTiers == 1)
                {
                    if (productWeight == 0)
                    {
                        productWeight = 1;
                    }
                }

                else if (numberOfTiers == 2)
                {
                    if (productWeight == 0)
                    {
                        productWeight = 3;
                    }

                    if (productWeight < 3)
                    {
                        productWeight = 3;
                    }
                }

                else if (numberOfTiers == 3)
                {
                    if (productWeight == 0)
                    {
                        productWeight = 4;
                    }

                    if (productWeight < 4)
                    {
                        productWeight = 4;
                    }
                }

                else if (numberOfTiers == 4)
                {
                    if (productWeight == 0)
                    {
                        productWeight = 6;
                    }

                    if (productWeight < 6)
                    {
                        productWeight = 6;
                    }
                }
            }

            // цена формы, оформления и надписи, если не пусты
            if (!string.IsNullOrEmpty(shape))
            {
                shapePrice = 100 * productWeight;
            }

            if (!string.IsNullOrEmpty(cakeDecoration))
            {
                cakeDecorationPrice = 500;
            }

            if (!string.IsNullOrEmpty(additionalInscription))
            {
                additionalInscriptionPrice = 150;
            }

            for (int i = 0; i < additionalDecorations.LongLength; i++)
            {
                if (additionalDecorations[i] == true)
                {
                    additionalDecorationsPrice += 1;
                }
            }

            // формула цены, если выбраны ярусы (п.с. маркетинг)
            if (numberOfTiers != 0)
            {
                price = numberOfTiersPrice + shapePrice + productWeight * 1300 + cakeDecorationPrice + additionalInscriptionPrice + 200 * additionalDecorationsPrice;
            }

            // сборка строчки заказа
            if (numberOfTiers != 0)
            {
                yourCake = $"кол-во ярусов: {numberOfTiers};";

                if (filling != null)
                {
                    yourCake += $" начинка: {filling};";
                }

                if (!string.IsNullOrEmpty(shape))
                {
                    yourCake += $" форма: {shape};";
                }

                if (productWeight != 0)
                {
                    yourCake += $" вес: {productWeight} кг;";
                }

                if (cakeDecoration != null)
                {
                    yourCake += $" оформление: {cakeDecoration};";
                }

                if (!string.IsNullOrEmpty(additionalInscription))
                {
                    yourCake += $" надпись: \"{additionalInscription}\";";
                }

                if (additionalDecorations[0] == true || additionalDecorations[1] == true || additionalDecorations[2] == true || additionalDecorations[3] == true)
                {
                    yourCake += " доп. оформление:";

                    if (additionalDecorations[0] == true)
                    {
                        yourCake += " шоколадная табличка;";
                    }

                    if (additionalDecorations[1] == true)
                    {
                        yourCake += " набор фейерверков;";
                    }

                    if (additionalDecorations[2] == true)
                    {
                        yourCake += " cвечи;";
                    }

                    if (additionalDecorations[3] == true)
                    {
                        yourCake += " фигурки;";
                    }
                }
            }

            Console.SetCursorPosition(2, 3);
        }

        static void OrderSubmenu(int position)
        {
            // выбор подпунктов
            if (position == 3)
            {
                position = 3;

                Console.WriteLine("->Один\n  Два\n  Три\n  Четыре");

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W) || (key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
                    {
                        position = Program.Arrows(key, position, 3, 6);
                    }

                    else if (key.Key == ConsoleKey.Enter)
                    {
                        numberOfTiers = position - 2;
                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }

                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }
                }
                while (true);
            }

            else if (position == 4)
            {
                position = 3;

                Console.WriteLine("->Трюфельная\n  Морковная с карамелью\n  Фирменная\n  Красный бархат\n  Шоколадная с ягодами");

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W) || (key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
                    {
                        position = Program.Arrows(key, position, 3, 7);
                    }

                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (position == 3)
                        {
                            filling = "Трюфельная";
                        }

                        else if (position == 4)
                        {
                            filling = "Морковная с карамелью";
                        }

                        else if (position == 5)
                        {
                            filling = "Фирменная";
                        }

                        else if (position == 6)
                        {
                            filling = "Красный бархат";
                        }

                        else if (position == 7)
                        {
                            filling = "Шоколадная с ягодами";
                        }

                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }

                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }
                }
                while (true);
            }

            else if (position == 5)
            {
                position = 3;

                Console.WriteLine("->Квадратная\n  Круглая\n  Треугольная\n  Другая");

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W) || (key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
                    {
                        position = Program.Arrows(key, position, 3, 6);
                    }

                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (position == 3)
                        {
                            shape = "Квадратная";
                        }

                        else if (position == 4)
                        {
                            shape = "Круглая";
                        }

                        else if (position == 5)
                        {
                            shape = "Треугольная";
                        }

                        else if (position == 6)
                        {
                            Console.Write("Форма торта: ");
                            shape = Console.ReadLine();
                        }

                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }

                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }
                }
                while (true);
            }

            else if (position == 6)
            {
                position = 3;

                Console.WriteLine("->1 кг (5 порций)\n  3 кг (15 порций)\n  6 кг (30 порций)\n  9 кг (45 порций)\n  12 кг (60 порций)\n  15 кг (75 порций)\n  18 кг (90 порций)");

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W) || (key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
                    {
                        position = Program.Arrows(key, position, 3, 9);
                    }

                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (position - 2 == 1)
                        {
                            productWeight = 1;
                        }

                        else
                        {
                            productWeight = (position - 3) * 3;
                        }

                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }

                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }
                }
                while (true);
            }

            else if (position == 7)
            {
                position = 3;

                Console.WriteLine("->Ягодное\n  Мастичное\n  Кремовое");

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W) || (key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
                    {
                        position = Program.Arrows(key, position, 3, 5);
                    }

                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (position == 3)
                        {
                            cakeDecoration = "Ягодное";
                        }

                        else if (position == 4)
                        {
                            cakeDecoration = "Мастичное";
                        }

                        else if (position == 5)
                        {
                            cakeDecoration = "Кремовое";
                        }

                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }

                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }
                }
                while (true);
            }

            else if (position == 8)
            {
                position = 3;

                Console.WriteLine("Что написать на торте?");
                Console.CursorVisible = true;

                Console.Write("Надпись на торте: ");
                additionalInscription = Console.ReadLine();

                Console.Clear();
                Program.menuCheck = 0;

                Console.CursorVisible = false;
            }

            else if (position == 9)
            {
                position = 3;

                Console.WriteLine("->Шоколадная табличка\n  Набор фейерверков\n  Свечи\n  Фигурки");

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W) || (key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
                    {
                        position = Program.Arrows(key, position, 3, 6);
                    }

                    else if (key.Key == ConsoleKey.Enter)
                    {
                        if (position == 3)
                        {
                            if (additionalDecorations[0] == true)
                            {
                                additionalDecorations[0] = false;
                                Console.SetCursorPosition(22, 3);
                                Console.WriteLine("         ");
                            }

                            else
                            {
                                additionalDecorations[0] = true;
                                Console.SetCursorPosition(22, 3);
                                Console.WriteLine("- выбрано");
                            }
                        }

                        else if (position == 4)
                        {
                            if (additionalDecorations[1] == true)
                            {
                                additionalDecorations[1] = false;
                                Console.SetCursorPosition(20, 4);
                                Console.WriteLine("         ");
                            }

                            else
                            {
                                additionalDecorations[1] = true;
                                Console.SetCursorPosition(20, 4);
                                Console.WriteLine("- выбрано");
                            }
                        }

                        else if (position == 5)
                        {
                            if (additionalDecorations[2] == true)
                            {
                                additionalDecorations[2] = false;
                                Console.SetCursorPosition(8, 5);
                                Console.WriteLine("         ");
                            }

                            else
                            {
                                additionalDecorations[2] = true;
                                Console.SetCursorPosition(8, 5);
                                Console.WriteLine("- выбрано");
                            }
                        }

                        else if (position == 6)
                        {
                            if (additionalDecorations[3] == true)
                            {
                                additionalDecorations[3] = false;
                                Console.SetCursorPosition(10, 6);
                                Console.WriteLine("         ");
                            }

                            else
                            {
                                additionalDecorations[3] = true;
                                Console.SetCursorPosition(10, 6);
                                Console.WriteLine("- выбрано");
                            }
                        }
                    }

                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }
                }
                while (true);
            }

            // конец заказа
            else if (position == 10)
            {
                position = 3;
                Console.WriteLine("Заказ оформлен! Спасибо за покупку торта \"У Полифема\", обращайтесь ещё!");

                Saving();

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        // обнуление
                        numberOfTiers = 0; productWeight = 0; numberOfTiersPrice = 0; shapePrice = 0; cakeDecorationPrice = 0; additionalInscriptionPrice = 0; additionalDecorationsPrice = 0;
                        filling = null; shape = null; cakeDecoration = null; additionalInscription = null;

                        for (int i = 0; i < additionalDecorations.LongLength; i++)
                        {
                            additionalDecorations[i] = false;
                        }

                        price = 0;
                        yourCake = null;

                        Console.Clear();
                        Program.menuCheck = 0;
                        break;
                    }

                }
                while (true);
            }
        }

        static void Saving()
        {
            string path = "OrderHistory.txt";
            string newOrder = $"Заказ от {DateTime.Now}\n\tЗаказ: {yourCake}\n\tЦена: {price}\n\n";

            if (price != 0 || !string.IsNullOrEmpty(yourCake))
            {
                File.AppendAllText(path, newOrder);
            }

            Program.position = 3;
        }

    }
}
