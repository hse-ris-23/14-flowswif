using System;
using System.Collections.Generic;
using ClassLibrary1;
using Laba10;
using ClassLibrary12_4;

namespace part2
{
    internal class Program
    {
        static ControlElement RandomElem()
        {
            Random rnd = new();
            int r = rnd.Next(4);
            if (r == 0)
            {
                ControlElement item = new();
                item.IRandomInit();
                return item;
            }
            else if (r == 1)
            {
                Button item = new();
                item.IRandomInit();
                return item;
            }
            else if (r == 2)
            {
                TextBox item = new();
                item.IRandomInit();
                return item;
            }
            else if (r == 3)
            {
                MultipleChoiceButton item = new();
                item.IRandomInit();
                return item;
            }
            return null;
        }

        static MyCollection<ControlElement> CreateCollection(int count)
        {
            MyCollection<ControlElement> col = new();
            for (int i = 0; i < count; i++)
            {
                try
                {
                    col.Add(RandomElem());
                }
                catch
                {
                    i--;
                }
            }
            return col;
        }

        static void Main(string[] args)
        {
            MyCollection<ControlElement> collection = CreateCollection(15);

            int menu = 0;
            do
            {
                try
                {
                    Console.WriteLine("\n   МЕНЮ");
                    Console.WriteLine("1. Вывод коллекции");
                    Console.WriteLine("2. Только кнопки");
                    Console.WriteLine("3. Поля ввода с текстом длиннее 5");
                    Console.WriteLine("4. Общая длина текста во всех полях ввода");
                    Console.WriteLine("5. Группировка по типу элемента");
                    Console.WriteLine("6. Выход");

                    menu = Utilities.IntInput("Выберите пункт меню > ");

                    switch (menu)
                    {
                        case 1:
                            foreach (var item in collection)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        case 2:
                            Analysis.WhereAnalys(collection);
                            break;
                        case 3:
                            Analysis.CountAnalys(collection);
                            break;
                        case 4:
                            Analysis.AggregateAnalys(collection);
                            break;
                        case 5:
                            Analysis.GroupAnalys(collection);
                            break;
                        case 6:
                            Console.WriteLine("\nДо свидания\n");
                            break;
                        default:
                            Console.WriteLine("\nНет такого пункта меню");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (menu != 6);
        }
    }
}


