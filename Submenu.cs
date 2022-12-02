namespace ConsoleApp2
{
    internal class Submenu
    {
        public string name, submenuInput, orderHistoryInput, stringValue;
        public int price, intValue;
        public bool[] boolValue = new bool[4];

        private Submenu(string nameArg, string SubmenuInputArg, int priceArg)
        {
            name = nameArg;
            submenuInput = SubmenuInputArg;
            price = priceArg;
        }

        public static Submenu numberOfTiers = new Submenu("  Количество ярусов", "->Один\n  Два\n  Три\n  Четыре", 1000);
        public static Submenu filling = new Submenu("  Начинка", "->Трюфельная\n  Морковная с карамелью\n  Фирменная\n  Красный бархат\n  Шоколадная с ягодами", 0);
        public static Submenu shape = new Submenu("  Форма", "->Квадратная\n  Круглая\n  Треугольная\n  Другая", 0);
        public static Submenu productWeight = new Submenu("  Вес изделия", "->1 кг (5 порций)\n  3 кг (15 порций)\n  6 кг (30 порций)\n  9 кг (45 порций)\n  12 кг (60 порций)\n  15 кг (75 порций)\n  18 кг (90 порций)", 1300);
        public static Submenu cakeDecoration = new Submenu("  Оформление торта", "->Ягодное\n  Мастичное\n  Кремовое", 0);
        public static Submenu additionalInscription = new Submenu("  Дополнительная надпись  ", "Что написать на торте? Надпись на торте: ", 0);
        public static Submenu additionalDecorations = new Submenu("  Дополнительные украшения", "->Шоколадная табличка\n  Набор фейерверков\n  Свечи\n  Фигурки", 0);

        public static void Calculations()
        {
            // цена яруса и вес в зависимости от него
            if (numberOfTiers.intValue != 0)
            {
                if (numberOfTiers.intValue == 1)
                {
                    if (productWeight.intValue < 1)
                    {
                        productWeight.intValue = 1;
                    }
                }

                else if (numberOfTiers.intValue == 2)
                {
                    if (productWeight.intValue < 3)
                    {
                        productWeight.intValue = 3;
                    }
                }

                else if (numberOfTiers.intValue == 3)
                {
                    if (productWeight.intValue < 4)
                    {
                        productWeight.intValue = 4;
                    }
                }

                else if (numberOfTiers.intValue == 4)
                {
                    if (productWeight.intValue < 6)
                    {
                        productWeight.intValue = 6;
                    }
                }
            }

            // цена формы, оформления и надписи, если не пусты
            if (!string.IsNullOrEmpty(shape.stringValue))
            {
                shape.price = 100 * productWeight.intValue;
            }

            if (!string.IsNullOrEmpty(cakeDecoration.stringValue))
            {
               cakeDecoration.price = 500;
            }

            if (!string.IsNullOrEmpty(additionalInscription.stringValue))
            {
                additionalInscription.price = 150;
            }

            for (int i = 0; i < additionalDecorations.boolValue.LongLength; i++)
            {
                if (additionalDecorations.boolValue[i] == true)
                {
                    additionalDecorations.price += 200;
                }
            }
        }

        public static void ZeroingOut()
        {
            numberOfTiers.intValue = 0;
            filling.stringValue = string.Empty;
            shape.stringValue = string.Empty;
            productWeight.intValue = 0;
            cakeDecoration.stringValue = string.Empty;
            additionalInscription.stringValue = string.Empty;

            for (int i = 0; i < additionalDecorations.boolValue.LongLength; i++)
            {
                additionalDecorations.boolValue[i] = false;
            }
        }
    }
}
