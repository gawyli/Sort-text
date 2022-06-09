using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = "content.txt";
            string[] lines = File.ReadAllLines(source);     //read all lines to string array

            DataObject infoText = new DataObject(lines);    //instance of object DataObject
 
            List<string> sortedLines;

            //Execute program which sort content by last letter of the last word
            sortedLines = infoText.SortContentByTheLastLetterOfLastWord();

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine();

            foreach (string line in sortedLines)
            {
                Console.WriteLine(line);
            }

            Console.ReadLine();
        }
    }
}
