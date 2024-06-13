using System;
using System.Collections.Generic;
using System.Linq;
using Laba10;

namespace part1
{
    public class Program
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

        static Stack<Dictionary<string, ControlElement>> CreateApp(int count)
        {
            Stack<Dictionary<string, ControlElement>> stack = new();
            for (int i = 0; i < count; i++)
            {
                Dictionary<string, ControlElement> dict = new();
                for (int j = 0; j < count; j++)
                {
                    ControlElement element = RandomElem();
                    dict[$"Element {j}"] = element;
                }
                stack.Push(dict);
            }
            return stack;
        }

        static void ShowStack(Stack<Dictionary<string, ControlElement>> stack)
        {
            int i = 1;
            foreach (var dict in stack)
            {
                Console.WriteLine($"\nDictionary {i++}\n");
                foreach (var kvp in dict)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
        }

        static void Main(string[] args)
        {
            Stack<Dictionary<string, ControlElement>> stack = CreateApp(3);

            List<WidgetManufacturer> factories = new List<WidgetManufacturer>
            {
                new WidgetManufacturer("Button", "Location1", 100),
                new WidgetManufacturer("TextBox", "Location2", 150),
                new WidgetManufacturer("MultipleChoiceButton", "Location3", 200),
                new WidgetManufacturer("ControlElement", "Location4", 250)
            };

            int menu = 0;
            do
            {
                try
                {
                    Console.WriteLine("\n   МЕНЮ");
                    Console.WriteLine("1. Вывод списка");
                    Console.WriteLine("2. Среднее количество кнопок");
                    Console.WriteLine("3. Группировка по типу элемента");
                    Console.WriteLine("4. Сортировка по имени ключа");
                    Console.WriteLine("5. Соединение с массивом анализ");
                    Console.WriteLine("6. Отношение текста к длине имени ключа");
                    Console.WriteLine("7. Выход");
                    menu = Utilities.IntInput("Выберите пункт меню > ");

                    switch (menu)
                    {
                        case 1:
                            {
                                ShowStack(stack);
                                break;
                            }
                        case 2:
                            {
                                Analysis.AverageButtonCountAnalys(stack);
                                break;
                            }
                        case 3:
                            {
                                Analysis.GroupByElementTypeAnalys(stack);
                                break;
                            }
                        case 4:
                            {
                                Analysis.SortByKeyNameAnalys(stack);
                                break;
                            }
                        case 5:
                            {
                                Analysis.JoinWidgetManufacturerAnalys(stack, factories);
                                break;
                            }
                        case 6:
                            {
                                Analysis.TextToKeyLengthRatioAnalys(stack);
                                break;
                            }
                        case 7:
                            {
                                Console.WriteLine("\nДо свидания\n");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (menu != 7);
        }
    }
}
