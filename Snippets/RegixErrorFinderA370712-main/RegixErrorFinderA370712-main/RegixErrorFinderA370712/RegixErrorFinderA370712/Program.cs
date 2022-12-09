using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RegixErrorFinderA370712
{
    class Program
    {
        static void Main(string[] args)
        {                    
            string[] lines = File.ReadAllLines(@".\tekstfiler\A370712.txt");

            // den originale regex før    (@"^$|^(?=.{1,20}$)[a-zA-ZæøåÆØÅ]+(-| |)?[a-zA-ZæøåÆØÅ]*$");
            Regex kommvejRegex = new Regex(@"^$|^(?=.{1,20}$)[a-zA-ZæøåÆØÅ'èéüäóöëÜÿ/.,\d]+((-| |)?[a-zA-ZæøåÆØÅ'èéüäóöëÜÿ/.,\d\-]*){0,4}$");                              
           
            for (int i = 1; i < lines.Length - 1; i++)
            {
                int startIndex = 31;
                int endIndex = 20;

                string vejnavn = lines[i].Substring(startIndex, endIndex);               
                Match match = kommvejRegex.Match(vejnavn.Trim());
                if (!match.Success)
                {
                    Console.WriteLine($"false, {vejnavn}");
                }              
            }
        }
    }
}
