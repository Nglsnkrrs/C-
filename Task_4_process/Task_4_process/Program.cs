using System;

namespace Task_4_process
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "child")
            {
                return Child.Run(args);
            }
            else
            {
                Parent.Run();
                return 0;
            }
        }
    }
}
