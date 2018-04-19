using System;

namespace TitleCapitalizationTool
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] exceptions = { "a", "an", "the", "and", "but", "for", "nor", "so", "yet", "at", "by", "in", "of", "on", "or", "out", "to", "up" };

            string[] punctuations = { ",", ":", ";", "-", ".", "!", "?" };

            if (args == null)
            {
                Console.Write("Enter title to capitalize: ");

                Console.ForegroundColor = ConsoleColor.DarkRed;

                string title = Console.ReadLine();

                string result = TitleCapitalization(title, exceptions, punctuations);

                Console.ResetColor();

                Console.Write("Capitalized title: ");

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.WriteLine(result);

                Console.ResetColor();
            }
            else
            {
                foreach (string arg in args)
                {
                    Console.Write("Original title: ");

                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    string title = arg;

                    string result = TitleCapitalization(title, exceptions, punctuations);

                    Console.ResetColor();

                    Console.Write("Capitalized title: ");

                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                    Console.WriteLine(result);

                    Console.ResetColor();
                }
            }
        }

        private static string TitleCapitalization(string title, string[] exceptions, string[] punctuations)
        {
            foreach (string punctuation in punctuations)
            {
                title = title.Replace(punctuation, " " + punctuation + " ");
            }

            title = title.Trim();

            string[] words = title.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();

                bool isEquals = false;

                for (int j = 0; j < exceptions.Length; ++j)
                {
                    if (words[i].Equals(exceptions[j]) == true)
                    {
                        isEquals = true;
                    }
                }

                if (isEquals == false || i == 0 || i == words.Length - 1)
                {
                    words[i] = Char.ToUpper(words[i][0]) + (words[i].Length > 1 ? words[i].Substring(1, words[i].Length - 1) : "");
                }
            }

            string result = words[0];

            for (int i = 1; i < words.Length; ++i)
            {
                if (words[i][0] >= 'a' && words[i][0] <= 'z' || words[i][0] >= 'A' && words[i][0] <= 'Z' || words[i][0] == '-')
                {
                    result = result + " " + words[i];
                }
                else
                {
                    result += words[i];
                }
            }

            return result;
        }
    }
}
