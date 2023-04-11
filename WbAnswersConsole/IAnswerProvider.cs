using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbAnswersConsole
{
    internal interface IAnswerProvider
    {
        string GetAnswer(string question);
    }
}
