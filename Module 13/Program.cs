using System;
using System.ComponentModel.Design;
using System.IO;
namespace TextAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            // читаем весь файл в строку текста
            string text = File.ReadAllText("C:/Users/iveal/Downloads/Text1.txt");
            
            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            // Убираем символы пунктуации
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            // считаем сколько раз используется каждое слово
            Dictionary<string,int> wordCounts = new Dictionary<string,int>();

            foreach ( string word in words ) 
            {
                if ( wordCounts.ContainsKey(word) ) 
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }
            //сортируем в порядок
            var sortedWordsCount = wordCounts.OrderByDescending(kv => kv.Value);

            //выводим в консоль
            Console.WriteLine("Десять самых встречаемых слов:");
            int count = 0;
            foreach (var kv in sortedWordsCount)
            {
                Console.WriteLine($"{kv.Key}: встречается {kv.Value} раз");
                count++;
                if (count >=10 )
                {
                    break;
                }
            }           
        }
    }
}


