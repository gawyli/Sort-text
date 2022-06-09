using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DataObject
    {
        private string[] Lines { get; set; }

        public List<string> lastWords = new List<string>();     //list of last words from each line
        public List<int> elementsInLine = new List<int>();      //list of amount of elements in each line
        public List<string> wordsToBeSort;
        public List<string> sortedLines;

        public DataObject(string[] lines)
        {
            Lines = lines;
        }
        
        //function for sort the proven content
        public List<string> SortContentByTheLastLetterOfLastWord()
        {
            List<string[]> eachLineSplitWords = new List<string[]>();   //list of each line with string array which storing each word after split

            for (int i = 0; i < Lines.Length; i++)
            {
                eachLineSplitWords.Add(Lines[i].Replace(".", "").Split(" "));

                elementsInLine.Add(eachLineSplitWords[i].Length);

                lastWords.Add(eachLineSplitWords[i][elementsInLine[i] - 1]);   //adding last word using last index from two dimensional list 
            }

            wordsToBeSort = ReverseWords(lastWords);    //reverse each word, so that program can sort words by the last letter
            wordsToBeSort.Sort();                       //sort by last letter (reversed words)
            lastWords = ReverseWords(wordsToBeSort);    // after sorted reverse words, foreach revers words to the orginal way in sorted order 


            return SortingLines(lastWords, eachLineSplitWords);
        }

        //Function for reverse words
        private List<string> ReverseWords(List<string> words)
        {
            List<string> listWords = new List<string>();

            foreach (string word in words)
            {
                char[] charWord = word.ToCharArray();
                Array.Reverse(charWord);
                listWords.Add(new string(charWord));
            }

            return listWords;
        }

        //Function for setting up lines in correct order
        private List<string> SortingLines(List<string> words, List<string[]> eachLineSplitWords)
        {
            sortedLines = new List<string>();

            //for loop which add in correct order the lines to the list - sortedLines
            for (int i = 0; i < Lines.Length; i++)
            {
                for (int j = 0; j < lastWords.Count; j++)
                {
                    if (eachLineSplitWords[j][elementsInLine[j] - 1] == lastWords[i])    //if statements check if word is in the line, if yes then add current line to the sortedList, if not then move forward
                    {
                        sortedLines.Add(Lines[j]);
                        break;
                    }
                }
            }

            return sortedLines;
        }
    }
}
