using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyGame.Models.ExceptionHandling
{
    public class Error
    {
        public void BasicException()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error! Please try again!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
