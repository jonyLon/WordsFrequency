using System.Diagnostics.CodeAnalysis;

namespace WordsFrequency
{

    class Frequency
    {
        public string Text { get; set; }
        public int AllWords { get; set; }
        public int UniqueWords { get; set; }
        public string[] words { get; set; }
        Dictionary<string, int> dict = new Dictionary<string, int>();
        public Frequency(string text)
        {
            Text = String.IsNullOrEmpty(text)? throw new ArgumentNullException() : text;
            words = Text.Split(",.:\t\r\n ".ToCharArray());
        }
        public void CountWords()
        {
            int sum = 0;
            foreach (var word in words)
            {
                if (!String.IsNullOrWhiteSpace(word))
                {
                sum += 1;
                if (dict.ContainsKey(word))
                {
                    dict[word] += 1; 
                }
                else
                {
                    dict.Add(word, 1);
                }
                }
            }
            AllWords = sum;
        }
        public void CountUnique()
        {
            int sum = 0;
            foreach (var item in dict)
            {
                if (item.Value == 1)
                {
                    sum++;
                }
            }
            UniqueWords = sum;
        }

        public void Print()
        {
            CountWords();
            CountUnique();
            Console.WriteLine("\t\tWord:\t\t\tCount:");
            foreach (var item in dict)
            {
                Console.WriteLine($"\t\t{item.Key}\t\t\t{item.Value}");
            }
            Console.WriteLine($"All words: {AllWords}");
            Console.WriteLine($"Unique words: {UniqueWords}");
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Ось будинок,\r\nЯкий побудував Джек.\r\n\r\nА це пшениця,\r\nЯка в темній комірці зберігається\r\nУ будинку,\r\nЯкий побудував Джек.\r\n\r\nА це весела птиця-синиця,\r\nЯка часто краде пшеницю,\r\nЯка в темній комірці зберігається\r\nУ будинку,\r\nЯкий побудував Джек.";

            Frequency frequency = new Frequency(text);
            frequency.Print();
        }
    }
}