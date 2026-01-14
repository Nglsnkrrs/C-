using System;

namespace Task_1
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "child")
            {
                return Child.Run();
            }
            else
            {
                Parent.Run();
                return 0;
            }
        }
    }
}
