using Laba10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1
{
    public static class Utilities
    {
        public static int IntInput(string prompt)
        {
            int result;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Invalid input. Please enter an integer: ");
            }
            return result;
        }
    }

    public static class Analysis
    {
        public static void AverageButtonCountAnalys(Stack<Dictionary<string, ControlElement>> stack)
        {
            Console.WriteLine("\nСРЕДНЕЕ КОЛИЧЕСТВО КНОПОК\n");
            int buttonCount = stack.SelectMany(dict => dict.Values).OfType<Button>().Count();
            int totalCount = stack.SelectMany(dict => dict.Values).Count();
            double average = totalCount > 0 ? (double)buttonCount / totalCount : 0;
            Console.WriteLine($"Среднее количество кнопок: {average}");
        }

        public static void GroupByElementTypeAnalys(Stack<Dictionary<string, ControlElement>> stack)
        {
            Console.WriteLine("\nГРУППИРОВКА ПО ТИПУ ЭЛЕМЕНТА\n");
            var result = stack.SelectMany(dict => dict.Values)
                              .GroupBy(e => e.GetType().Name)
                              .Select(g => new { ElementType = g.Key, Count = g.Count() });
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ElementType}: {item.Count}");
            }
        }

        public static void SortByKeyNameAnalys(Stack<Dictionary<string, ControlElement>> stack)
        {
            Console.WriteLine("\nСОРТИРОВКА ПО ИМЕНИ КЛЮЧА\n");
            var result = stack.SelectMany(dict => dict)
                              .OrderBy(kvp => kvp.Key);
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        public static void JoinWidgetManufacturerAnalys(Stack<Dictionary<string, ControlElement>> stack, List<WidgetManufacturer> factories)
        {
            Console.WriteLine("\nСОЕДИНЕНИЕ С МАССИВОМ\n");
            var result = from dict in stack
                         from kvp in dict
                         join f in factories on kvp.Value.GetType().Name equals f.WidgetType
                         select new { Key = kvp.Key, Element = kvp.Value, f.WidgetType, f.Location };
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Element} - {item.WidgetType}, {item.Location}");
            }
        }

        public static void TextToKeyLengthRatioAnalys(Stack<Dictionary<string, ControlElement>> stack)
        {
            Console.WriteLine("\nОТНОШЕНИЕ ТЕКСТА К ДЛИНЕ ИМЕНИ КЛЮЧА\n");
            var result = from dict in stack
                         from kvp in dict
                         where kvp.Value is TextBox
                         let textLength = ((TextBox)kvp.Value).Internaltext.Length
                         let keyLength = kvp.Key.Length
                         let ratio = (double)textLength / keyLength
                         select new { kvp.Key, TextLength = textLength, KeyLength = keyLength, Ratio = ratio };
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: TextLength = {item.TextLength}, KeyLength = {item.KeyLength}, Ratio = {item.Ratio}");
            }
        }
    }
}
