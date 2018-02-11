using System;

namespace MentoringProgramTask5IoC.Logg
{
    internal class Logger : ILogger
    {
        private readonly string _debug;
        private readonly string _info;

        public Logger(string debug, string info)
        {
            _debug = debug;
            _info = info;
        }
        public void Debug(string message)
        {
            Console.WriteLine(_debug + message);
        }

        public void Info(string message)
        {
            Console.WriteLine(_info + message);
        }
    }
}
