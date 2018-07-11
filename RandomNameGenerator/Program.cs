using System;

namespace RandomNameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            NameGenerator nameGenerator = new NameGenerator();
            FileMenager fileMenager = new FileMenager();

            int number = 0;
            bool complete = false;
            Console.WriteLine("---------- Name Geneartor ----------");
            Console.WriteLine("> Press any key to generate a Name");
            while (complete == false)
            {
                Console.WriteLine("> How much word you need? ");
                Console.Write("> ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int number1))
                {
                    number = number1;
                    complete = true;
                }
                else
                    Console.WriteLine($"> Seriosly?! \"{input}\" is not a number!");
            }
            for (int i = 1; i <= number; i++)
            {
                fileMenager.AddToOutputBuffer(nameGenerator.GenerateNewWord(0));
            }
            fileMenager.WriteToFile("ListNames.txt");
            Console.WriteLine("> Generated, check file!");
            Console.ReadKey();
        }
    }
}
