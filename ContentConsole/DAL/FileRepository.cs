using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace ContentConsole.DAL
{
    public class FileRepository : IRepository
    {

        public string[] GetNegativeWords()
        {
            var negativeWords = new string[] { "swine", "bad", "nasty", "horrible" };
            return negativeWords;
        }

        public string GetContent()
        {
            return "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
        }
    }
}