using System;
using System.Diagnostics.Tracing;
using System.Security.Cryptography;

namespace Hello
{
    class Program
    {
        public static bool IsAnagram(List<string> rez, string word)
        {
            bool isInRezult = true;

            for (int i = 0; i < rez.Count; i++)
            {
                isInRezult = true;

                if (rez[i].Length == word.Length)
                {
                    for (int j = 0; j < rez[i].Length; j++)
                    {
                        if (CountChars(rez[i], rez[i][j]) != CountChars(word, rez[i][j]))
                        {
                            isInRezult = false;
                            break;
                        }
                    }
                }
                else
                {
                    isInRezult = false;
                }

                if (isInRezult)
                {
                    return true;
                }
            }

            return isInRezult;
        }

        public static int CountChars(string word, char c)
        {
            int count = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == c)
                {
                    count++;
                }
            }

            return count;
        }


        public static void Main()
        {
            string[] array = new string[5] { "code", "doce", "ecod", "framer", "frame" };
            List<string> list = array.ToList();

            List<string> rezult = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                rezult.Add(list[i]);

                for (int j = i + 1; j < list.Count; j++)
                {
                    if (IsAnagram(rezult, list[j]))
                    {
                        list.Remove(list[j]);
                        j--;
                    }
                }
            }

            rezult.Sort();

            foreach (var e in rezult)
                Console.WriteLine(e);
        }
    }
}