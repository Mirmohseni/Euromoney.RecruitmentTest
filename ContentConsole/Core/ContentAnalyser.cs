using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Core
{
    public class ContentAnalyser : IContentAnalyser
    {
        private readonly string _content;
        private readonly string[] _negativeWords;
        private readonly char[] _delimiters = new char[] { ' ', ',', '.', ';', '\'' };
        public ContentAnalyser(string content, IEnumerable<string> negativeWords)
        {
            _content = content;
            _negativeWords = negativeWords.ToArray();
        }
        public int CountNegativeWords()
        {
            string[] contentWords = _content.Split(_delimiters, StringSplitOptions.RemoveEmptyEntries);

            int negativeWords = 0;

            foreach (var item in _negativeWords)
            {
                if (contentWords.Any(w => w.Equals(item, StringComparison.InvariantCultureIgnoreCase)))
                {
                    negativeWords++;
                }
            }

            return negativeWords;
        }

        public int CountAllNegativeWords()
        {
            string[] contentWords = _content.Split(_delimiters, StringSplitOptions.RemoveEmptyEntries);

            int negativeWords = 0;

            foreach (var item in _negativeWords)
            {
                negativeWords = negativeWords + contentWords.Count(w => w.Equals(item, StringComparison.InvariantCultureIgnoreCase));
            }

            return negativeWords;
        }

        public string FilterContent()
        {
            var filteredContent = _content;
            foreach (var item in _negativeWords)
            {
                var hashedNegativeWord = item.Substring(0, 1) + string.Empty.PadRight(item.Length - 2, '#') + item.Substring(item.Length - 1, 1);
                filteredContent = filteredContent.Replace(item, hashedNegativeWord);
            }

            return filteredContent;
        }
    }
}
