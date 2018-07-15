using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    class UserMenager
    {
        public int GetInput()
        {
            for(; ; )
            {
                Console.Write("> ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                    return number;
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"> So, you wrote \"{input}\", but you know its not a number!");
                    Console.WriteLine("> Try again");
                    Console.BackgroundColor = ConsoleColor.Black;
                } 
            }
        }
    }
}
