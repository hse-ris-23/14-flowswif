using ClassLibrary12_4;
using Laba10;
using System;
using System.Collections.Generic;
using System.Linq;

namespace part2
{

    public static class Utilities
    {
        public static int IntInput(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                    break;
                Console.WriteLine("Неверный ввод, пожалуйста введите целое число.");
            }
            return result;
        }
    }
    public class Analysis
    {
        public static void WhereAnalys(MyCollection<ControlElement> collection)
        {
            Console.WriteLine("\nТОЛЬКО КНОПКИ\n");
            var result = collection.Where(x => x is Button);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void CountAnalys(MyCollection<ControlElement> collection)
        {
            Console.WriteLine("\nКОЛИЧЕСТВО ПОЛЕЙ ВВОДА С ТЕКСТОМ ДЛИННЕЕ 5\n");
            var result = collection.Count(x => x is TextBox && ((TextBox)x).Internaltext.Length > 5);

            Console.WriteLine($"Количество полей ввода с текстом длиннее 5: {result}");
        }

        public static void AggregateAnalys(MyCollection<ControlElement> collection)
        {
            Console.WriteLine("\nОБЩАЯ ДЛИНА ТЕКСТА ВО ВСЕХ ПОЛЯХ ВВОДА\n");
            var result = collection.Where(x => x is TextBox).Sum(x => ((TextBox)x).Internaltext.Length);

            Console.WriteLine($"Общая длина текста во всех полях ввода: {result}");
        }

        public static void GroupAnalys(MyCollection<ControlElement> collection)
        {
            Console.WriteLine("\nГРУППИРОВКА ПО ТИПУ ЭЛЕМЕНТА\n");
            var result = collection.GroupBy(x => x.GetType().Name)
                                    .Select(gr => new { Type = gr.Key, Count = gr.Count() });

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Type} : {item.Count}");
            }
        }
    }
}


