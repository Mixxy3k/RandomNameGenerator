using System;

namespace NameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            UserMenager userMenager = new UserMenager();
            FileMenager fileMenager = new FileMenager(userMenager);
            userMenager.useFileMenager(fileMenager);

            while (!userMenager.exit)
            {
                userMenager.ConsoleLog($"----- Name Generator v {userMenager.version}  -----");

                userMenager.ConsoleLog("Write number next to the to an option and press Enter to accept");
                userMenager.ConsoleLog($"Writing to buffor {userMenager.saveToBuffor}! Things waiting in buffor: {fileMenager.outputData.Count}!");
                userMenager.ConsoleLog("0. Settings");
                userMenager.ConsoleLog("1. Generate Word - Generate a word from ASCI table");
                userMenager.ConsoleLog("2. Generate Sentence - Generate a sentence created by random generated word");
                userMenager.ConsoleLog("3. Save to file");
                userMenager.ConsoleLog("4. Exit", null, ConsoleColor.Red);

                userMenager.Loop();
            }
        }
    }
}
