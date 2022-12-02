namespace ConsoleApp2
{
    internal class Order
    {
        // объявление переменных
        public static int price = 0;
        public static string yourCake = "";

        public static void OrderMenu(int position)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите Escape\nВыберите пункт из меню:\n-----------------------");
            Console.SetCursorPosition(0, 3);

            OrderSubmenu(position);
            Submenu.Calculations();

            // формула цены, если выбраны ярусы (п.с. маркетинг)
            if (Submenu.numberOfTiers.intValue != 0)
            {
                price = Submenu.numberOfTiers.price + Submenu.shape.price + Submenu.productWeight.intValue * Submenu.productWeight.price + Submenu.cakeDecoration.price + Submenu.additionalInscription.price + Submenu.additionalDecorations.price;
            }

            // сборка строчки заказа
            if (Submenu.numberOfTiers.intValue != 0)
            {
                yourCake = $"кол-во ярусов: {Submenu.numberOfTiers.intValue};";

                if (!string.IsNullOrEmpty(Submenu.filling.stringValue))
                {
                    yourCake += $" начинка: {Submenu.filling.stringValue};";
                }

                if (!string.IsNullOrEmpty(Submenu.shape.stringValue))
                {
                    yourCake += $" форма: {Submenu.shape.stringValue};";
                }

                if (Submenu.productWeight.intValue != 0)
                {
                    yourCake += $" вес: {Submenu.productWeight.intValue} кг;";
                }

                if (!string.IsNullOrEmpty(Submenu.cakeDecoration.stringValue))
                {
                    yourCake += $" оформление: {Submenu.cakeDecoration.stringValue};";
                }

                if (!string.IsNullOrEmpty(Submenu.additionalInscription.stringValue))
                {
                    yourCake += $" надпись: \"{Submenu.additionalInscription.stringValue}\";";
                }

                if (Submenu.additionalDecorations.boolValue[0] == true || Submenu.additionalDecorations.boolValue[1] == true || Submenu.additionalDecorations.boolValue[2] == true || Submenu.additionalDecorations.boolValue[3] == true)
                {
                    yourCake += " доп. оформление:";

                    if (Submenu.additionalDecorations.boolValue[0] == true)
                    {
                        yourCake += " шоколадная табличка;";
                    }

                    if (Submenu.additionalDecorations.boolValue[1] == true)
                    {
                        yourCake += " набор фейерверков;";
                    }

                    if (Submenu.additionalDecorations.boolValue[2] == true)
                    {
                        yourCake += " cвечи;";
                    }

                    if (Submenu.additionalDecorations.boolValue[3] == true)
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

                Console.WriteLine(Submenu.numberOfTiers.submenuInput);

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if ((key.Key == ConsoleKey.UpArrow) || (key.Key == ConsoleKey.W) || (key.Key == ConsoleKey.DownArrow) || (key.Key == ConsoleKey.S))
                    {
                        position = Program.Arrows(key, position, 3, 6);
                    }

                    else if (key.Key == ConsoleKey.Enter)
                    {
                        Submenu.numberOfTiers.intValue = position - 2;
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

                Console.WriteLine(Submenu.filling.submenuInput);

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
                            Submenu.filling.stringValue = "Трюфельная";
                        }

                        else if (position == 4)
                        {
                            Submenu.filling.stringValue = "Морковная с карамелью";
                        }

                        else if (position == 5)
                        {
                            Submenu.filling.stringValue = "Фирменная";
                        }

                        else if (position == 6)
                        {
                            Submenu.filling.stringValue = "Красный бархат";
                        }

                        else if (position == 7)
                        {
                            Submenu.filling.stringValue = "Шоколадная с ягодами";
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

                Console.WriteLine(Submenu.shape.submenuInput);

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
                            Submenu.shape.stringValue = "Квадратная";
                        }

                        else if (position == 4)
                        {
                            Submenu.shape.stringValue = "Круглая";
                        }

                        else if (position == 5)
                        {
                            Submenu.shape.stringValue = "Треугольная";
                        }

                        else if (position == 6)
                        {
                            Console.Write("Форма торта: ");
                            Submenu.shape.stringValue = Console.ReadLine();
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

                Console.WriteLine(Submenu.productWeight.submenuInput);

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
                            Submenu.productWeight.intValue = 1;
                        }

                        else
                        {
                            Submenu.productWeight.intValue = (position - 3) * 3;
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

                Console.WriteLine(Submenu.cakeDecoration.submenuInput);

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
                            Submenu.cakeDecoration.stringValue = "Ягодное";
                        }

                        else if (position == 4)
                        {
                            Submenu.cakeDecoration.stringValue = "Мастичное";
                        }

                        else if (position == 5)
                        {
                            Submenu.cakeDecoration.stringValue = "Кремовое";
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
                Console.WriteLine(Submenu.additionalInscription.submenuInput);
                Console.CursorVisible = true;

                Submenu.additionalInscription.stringValue = Console.ReadLine();

                Console.Clear();
                Program.menuCheck = 0;

                Console.CursorVisible = false;
            }

            else if (position == 9)
            {
                position = 3;

                Console.WriteLine(Submenu.additionalDecorations.submenuInput);

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
                            if (Submenu.additionalDecorations.boolValue[0] == true)
                            {
                                Submenu.additionalDecorations.boolValue[0] = false;
                                Console.SetCursorPosition(22, 3);
                                Console.WriteLine("         ");
                            }

                            else
                            {
                                Submenu.additionalDecorations.boolValue[0] = true;
                                Console.SetCursorPosition(22, 3);
                                Console.WriteLine("- выбрано");
                            }
                        }

                        else if (position == 4)
                        {
                            if (Submenu.additionalDecorations.boolValue[1] == true)
                            {
                                Submenu.additionalDecorations.boolValue[1] = false;
                                Console.SetCursorPosition(20, 4);
                                Console.WriteLine("         ");
                            }

                            else
                            {
                                Submenu.additionalDecorations.boolValue[1] = true;
                                Console.SetCursorPosition(20, 4);
                                Console.WriteLine("- выбрано");
                            }
                        }

                        else if (position == 5)
                        {
                            if (Submenu.additionalDecorations.boolValue[2] == true)
                            {
                                Submenu.additionalDecorations.boolValue[2] = false;
                                Console.SetCursorPosition(8, 5);
                                Console.WriteLine("         ");
                            }

                            else
                            {
                                Submenu.additionalDecorations.boolValue[2] = true;
                                Console.SetCursorPosition(8, 5);
                                Console.WriteLine("- выбрано");
                            }
                        }

                        else if (position == 6)
                        {
                            if (Submenu.additionalDecorations.boolValue[3] == true)
                            {
                                Submenu.additionalDecorations.boolValue[3] = false;
                                Console.SetCursorPosition(10, 6);
                                Console.WriteLine("         ");
                            }

                            else
                            {
                                Submenu.additionalDecorations.boolValue[3] = true;
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
                Console.WriteLine("Заказ оформлен! Спасибо за покупку торта \"У Полифема\", обращайтесь ещё!");

                Saving();

                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        // обнуление
                        price = 0;
                        yourCake = "";

                        Submenu.ZeroingOut();
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
