using System;
using User;
using Files;

namespace RandomNameAndSentenceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            NameAndSentenceGenerator nameGenerator = new NameAndSentenceGenerator();
            FileMenager fileMenager = new FileMenager();
            UserMenager userMenager = new UserMenager();
            
            bool saveToFile = true;
            for (; ; )
            {
                Console.Clear();
                Console.WriteLine("------- Random word and sentence Geneartor -------");
                Console.WriteLine("> 1 Generate random word");
                Console.WriteLine("> 2 Generate random sentence");
                Console.WriteLine("> 3 Generate random document");
                Console.WriteLine("> 4 Generate super strong password");
                Console.WriteLine("> Any Other number to exit");
                Console.WriteLine($"> Saving to file: {saveToFile}, if you want change it press 0");
                switch (userMenager.Input())
                {
                    case 0:
                        saveToFile = !saveToFile;
                        break;
                    case 1:
                        nameGenerator.GenerateNewWord();
                        break;
                    case 2:
                        nameGenerator.GenerateNewSentence();
                        break;
                    case 3:
                        //GenerateRandomDocument();
                        break;
                    case 4:
                        //GeneratePassword();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
