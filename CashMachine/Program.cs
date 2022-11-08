using System;

namespace CashMachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sachMachine = new CashMachine();
            sachMachine.Insert(new int[] {20, 50 } );
            Console.WriteLine(sachMachine.WithDraw(40));
        } 
    }
}