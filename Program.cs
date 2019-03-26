using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DictionaryDifficultySplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> easyDict = new List<string>();
            List<string> medDict = new List<string>();
            List<string> hardDict = new List<string>();
            Console.WriteLine("Path to source file:");
            string sourcePath = Console.ReadLine();
            using (var sr = new StreamReader(sourcePath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var words = sr.ReadLine().Split();
                    foreach (string i in words)
                    {
                        if (i.Length < 6)
                        {
                            easyDict.Add(i);
                            Console.WriteLine(i + " in easy");
                        }
                        else if (i.Length < 10)
                        {
                            medDict.Add(i);
                            Console.WriteLine(i + " in medium");
                        }
                        else if (i.Length < 15)
                        {
                            hardDict.Add(i);
                            Console.WriteLine(i + " in hard");
                        }
                        else Console.WriteLine("Error adding the word");
                    }
                }
            }
            //Console.WriteLine("Name for sorted dictionaries: ");
            //string sortedPath = Console.ReadLine();
            using (var sw = new StreamWriter("sorted_easy.txt", false, Encoding.Default))
            {
                foreach (var i in easyDict)
                {
                    sw.Write(i + " ");
                }
            }
            using (var sw = new StreamWriter("sorted_med.txt", false, Encoding.Default))
            {
                foreach (var i in medDict)
                {
                    sw.Write(i + " ");
                }
            }
            using (var sw = new StreamWriter("sorted_hard.txt", false, Encoding.Default))
            {
                foreach (var i in hardDict)
                {
                    sw.Write(i + " ");
                }
            }
            Console.ReadKey();
        }
    }
}
