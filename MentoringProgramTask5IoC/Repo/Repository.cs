using System;

namespace MentoringProgramTask5IoC.Repo
{
    internal class Repository : IRepository
    {
        public void TestRepository1()
        {
            Console.WriteLine("Hello from repo!");
        }

        public int TestRepository2()
        {
            return 25;
        }
    }
}
