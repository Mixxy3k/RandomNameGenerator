using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    class UserMenager
    {
        public int Input()
        {
            for(; ; )
            {
                Console.Write("> ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                    return number;
                else
                {
                    Message($"So, you wrote \"{input}\", but you know its not a number!", ConsoleColor.DarkGreen,"ERROR");
                    Message("> Try again");
                } 
            }
        }
        public void Message(string text, ConsoleColor color = ConsoleColor.Black, string type = String.Empty){
            Console.BackgroundColor = color;
            
            if(type == String.Empty)
                Console.WriteLine("> " + text);
            else 
                Console.WriteLine("> " + type +": " + text);
            Consloe.BackgroundColor = ConsoleColor.Black;

        }
        public void Clear() { Console.Clear(); }
    }
}

