using System;
using System.Collections.ObjectModel;
using System.Text;
using static System.Collections.Generic.SortedDictionary<char, int>;



/*
            Дан входной файл из символов (латинские буквы) необходимо опредилить символ, который встречается чаще всего,
            кол-во уникальных символов, выдать список символов, с помощью которых составлена последовательность в файле (в алф порядке)
            Ограничения: данные считывать в массивы, списки и др. элементы коллекций (нельзя для хранения исходных данных, для обработки можно)
            Строк может быть несколько, в строку считывать можно
  */
namespace Yuckylot
{
    class Program
    {
        static void Main()
        {
            string path = @".\..\..\..\Letters.txt";
            StreamReader reader = new StreamReader(path);

            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();

            char letter = (char)reader.Read();
            int maxCount = 0;
            char maxLetter = '.';
            while(true)
            {
                if (dict.ContainsKey(letter))
                {
                    dict[letter] += 1;
                }
                else
                {
                    dict.Add(letter, 1);
                }
                if (reader.EndOfStream)
                {
                    break;
                }
                if (maxCount < dict[letter])
                {
                    maxCount = dict[letter];
                    maxLetter = letter;
                }
                letter = (char)reader.Read();
            }

            var used = dict.Keys.OrderBy( x => x);
            
            StringBuilder sb = new StringBuilder();
            StringBuilder sub = new StringBuilder();

            sb.Append($"Символ, который встречается чаще всего : {maxLetter} ({maxCount} раз)\n\n");

            sb.Append($"Кол-во уникальных символов {used.Count()}\n\n");

            sb.Append($"Использованны: ");
            foreach(char x in used)
            {
                sub.Append($"{x} ");
            }
            sb.Append(sub.ToString());
            sb.Append("\n\n");
            Console.WriteLine(sb.ToString());
            File.WriteAllText(@".\..\..\..\Answer.txt", sb.ToString());
        }
    }
}