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
                        var line = i;

                        #region replaces
                        while (line.Contains(","))
                            line = line.Replace(",", "");
                        while (line.Contains("."))
                            line = line.Replace(".", "");
                        while (line.Contains(":"))
                            line = line.Replace(":", "");
                        while (line.Contains(";"))
                            line = line.Replace(";", "");
                        while (line.Contains("\""))
                            line = line.Replace("\"", "");
                        while (line.Contains("("))
                            line = line.Replace("(", "");
                        while (line.Contains(")"))
                            line = line.Replace(")", "");
                        while (line.Contains("!"))
                            line = line.Replace("!", "");
                        while (line.Contains("?"))
                            line = line.Replace("?", "");
                        #endregion

                        if (line.Length < 6 && line.Length > 2)
                        {
                            easyDict.Add(line);
                            Console.WriteLine(line + " in easy");
                        }
                        else if (line.Length < 10 && line.Length > 2)
                        {
                            medDict.Add(line);
                            Console.WriteLine(i + " in medium");
                        }
                        else if (line.Length < 15 && line.Length > 2)
                        {
                            hardDict.Add(line);
                            Console.WriteLine(line + " in hard");
                        }
                        else Console.WriteLine("Error adding the word");
                    }
                }
            }
            Console.WriteLine("Name for sorted dictionaries: ");
            string sortedPath = Console.ReadLine();
            if (!sortedPath.Contains(".txt")) sortedPath += ".txt";
            using (var sw = new StreamWriter(sortedPath.Replace(".txt", "_easy.txt"), false, Encoding.Default))
            {
                foreach (var i in easyDict)
                {
                    sw.Write(i + " ");
                }
            }
            using (var sw = new StreamWriter(sortedPath.Replace(".txt", "_med.txt"), false, Encoding.Default))
            {
                foreach (var i in medDict)
                {
                    sw.Write(i + " ");
                }
            }
            using (var sw = new StreamWriter(sortedPath.Replace(".txt", "_hard.txt"), false, Encoding.Default))
            {
                foreach (var i in hardDict)
                {
                    sw.Write(i + " ");
                }
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"{easyDict.Count} words in easy dictionary");
            Console.WriteLine($"{medDict.Count} words in medium dictionary");
            Console.WriteLine($"{hardDict.Count} words in hard dictionary");
            Console.WriteLine("Completed.");
            Console.ReadKey();
        }
    }
}
