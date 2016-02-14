﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseraConsole
{
    class Program
    {
        static string ReverseComplement(string pattern)
        {
            char[] array = new char[pattern.Length];
            for (int i = 0; i < pattern.Length; i++)
            {
                switch (pattern[i])
                {
                    case 'A':
                        array[i] = 'T';
                        break;
                    case 'C':
                        array[i] = 'G';
                        break;
                    case 'G':
                        array[i] = 'C';
                        break;
                    case 'T':
                        array[i] = 'A';
                        break;
                    default:
                        break;
                }
            }

            return new string(array.Reverse().ToArray());
        }

        static int PatternCount(string text, string pattern)
        {
            int count = 0;
            for (int i = 0; i <= text.Length - pattern.Length; i++)
            {
                if (text.Substring(i, pattern.Length) == pattern)
                {
                    count++;
                }
            }            
            return count;
        }

        static IEnumerable<string> FrequentWords(string text, int k)
        {
            List<string> frequentPatterns = new List<string>();
            List<int> counts = new List<int>();
            for (int i = 0; i <= text.Length - k; i++)
            {
                string pattern = text.Substring(i, k);
                counts.Add(PatternCount(text, pattern));
            }

            var maxCount = counts.Max();
            for (int i = 0; i <= text.Length - k; i++)
            {
                if (counts[i] == maxCount && !frequentPatterns.Contains(text.Substring(i, k)))
                {
                    frequentPatterns.Add(text.Substring(i, k));
                    yield return text.Substring(i, k);
                }
            }
            //return frequentPatterns.ToString();
        }

        static IEnumerable<int> PatternAppearIndex(string pattern, string text)
        {
            for (int i = 0; i <= text.Length - pattern.Length; i++)
            {
                if (text.Substring(i, pattern.Length) == pattern)
                {
                    yield return i;
                }
            }
        }

        static void Main(string[] args)
        {
            int count = PatternCount("CGCGATACGTTACATACATGATAGACCGCGCGCGATCATATCGCGATTATC", "CGCG");
            Console.WriteLine(count);

            Console.WriteLine(ReverseComplement("GATTACA"));

            foreach (var item in FrequentWords("CGCCTAAATAGCCTCGCGGAGCCTTATGTCATACTCGTCCT", 3))
            {
                Console.Write(item + " ");
            }
            
            Console.ReadKey();
        }
    }
}
