using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Words
    {
        private Dictionary<int, string> wordsDict;
        private Random r;

        public Words()
        {
            wordsDict = new Dictionary<int, string>();
            wordsDict.Add(1, "Apple");
            wordsDict.Add(2, "Chair");
            wordsDict.Add(3, "table");
            r = new Random();
        }
        public string GetWord()
        {
            int randomNum = r.Next(1, 3);
            string word = wordsDict[randomNum];
            return word;
        }
    }
}
