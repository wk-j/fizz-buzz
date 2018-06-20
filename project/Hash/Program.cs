using System;

namespace Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            var h = "Hello";
            Console.WriteLine(h.GetHashCode());
            Console.WriteLine(100.GetHashCode());
        }
    }
}
