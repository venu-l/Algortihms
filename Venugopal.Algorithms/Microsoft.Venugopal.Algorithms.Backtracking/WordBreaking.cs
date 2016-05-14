using Microsoft.Venugopal.Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Venugopal.Algorithms.Backtracking
{
    public class WordBreaking : IAlgoDriver
    {
        private string _input = "iamgodboy";
        private HashSet<string> _wordDictionary = new HashSet<string>();
        public WordBreaking()
        {
            _wordDictionary.Add("i");
            _wordDictionary.Add("am");
            _wordDictionary.Add("the");
            _wordDictionary.Add("very");
            _wordDictionary.Add("good");
            _wordDictionary.Add("boy");
            _wordDictionary.Add("hyderabad");
            _wordDictionary.Add("vizag");
            _wordDictionary.Add("venugopal");
            _wordDictionary.Add("name");
            _wordDictionary.Add("my");
            _wordDictionary.Add("is");
        }

        public void Execute()
        {
            var result = this.StringInDictionary(_input);

            if(result)
                Console.WriteLine("String can be broken in to valid dictionary strings");
            else
                Console.WriteLine("String can't be broken in to valid dictionary strings");
        }

        private bool StringInDictionary(string word)
        {
            if (_wordDictionary.Contains(word))
                return true;

            int i = 1;
            bool result = false;
            while (i < word.Length)
            {
                result = this.StringInDictionary(word.Substring(0, i))
                      && this.StringInDictionary(word.Substring(i));

                if (result)
                    break;
                i++;
            }

            return result;
        }
    }
}
