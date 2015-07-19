using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole.Core
{
    public interface IContentAnalyser
    {
        int CountNegativeWords();

        int CountAllNegativeWords();

        string FilterContent();
    }
}
