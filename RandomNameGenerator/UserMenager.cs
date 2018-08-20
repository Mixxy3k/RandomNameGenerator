using System;

namespace NameGenerator
{
    class UserMenager
    {
        Random random;
        FileMenager fileMenager;
        Generator generator;

        enum State { Unknow = 0,Settings, Menu, GenerateWord, GenerateSentence};

        public string version = "1.6";

        private State state;
        public bool saveToBuffor { get; set; }
        public bool displayGeneratedWords { get; set; }
        public bool exit { get; set; }

        public UserMenager()
        {
            exit = false;
            Console.ForegroundColor = ConsoleColor.White;
            generator = new Generator();
            state = State.Menu;
            saveToBuffor = false;
            displayGeneratedWords = true;
            random = new Random();
        }

        public void useFileMenager(FileMenager fileMenager)
        {
            this.fileMenager = fileMenager;
        }

        public uint Input(uint options = 4294967295)
        {
            for (; ; )
            {
                Console.Write("> ");
                var x = Console.ReadLine();
                if (uint.TryParse(x, out uint number) && number >= 0 && number <= options )
                    return number;
                else 
                    ConsoleLog($"Baka \"{x}\" is not an option", "ERROR");
            }
        }

        public void ConsoleLog(string message, string type = null, ConsoleColor color = ConsoleColor.White)
        {
            Console.Write("> ");
            if (type == null)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(message);
            }
            else
            {
                Console.ForegroundColor = color;

                if (type == "ERROR")
                    Console.ForegroundColor = ConsoleColor.Red;
                if (type == "LOG")
                    Console.ForegroundColor = ConsoleColor.Green;
                if (type == "IMPORTANT MESSAGE")
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                if (type == "GENERATED")
                    Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine(type + ": " + message);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Loop()
        {
            switch (Input(5))
            {
                case 0:
                    state = State.Settings;
                    DisplaySettings();
                    Console.Clear();
                    break;
                case 1:
                    state = State.GenerateWord;
                    Generate();
                    break;
                case 2:
                    state = State.GenerateSentence;
                    Generate();
                    break;
                case 3:
                    String fileName = saveMenager();
                    if (fileName == "0")
                    {
                        state = State.Menu;
                        break;
                    }
                    if (fileName != null)
                    {
                        fileMenager.WriteToFile(fileName);
                        fileMenager.outputData.Clear();
                    }
                    else
                        Console.ReadKey();
                    break;
                case 4:
                    exit = true;
                    break;
            }
            ExitMenager();
            Console.Clear();
            return;
        }

        private void ExitMenager()
        {
            if (state == State.Menu)
                return;
            if (exit == true)
            {
                ConsoleLog("Are you sure to exit program? All bufer data gonna be destroy!", "IMPORTANT MESSAGE");
                ConsoleLog("Press 0 to back or any other to Exit!");
                var x = Console.ReadLine();
                exit = true;
                if (x == "0")
                    exit = false;
            }
            Console.ReadKey();
        }

        private String saveMenager()
        {
            for (; ; )
            {
                if (fileMenager.outputData.Count == 0)
                {
                    ConsoleLog("You dont have any things in buffer! Save not possible!", "ERROR");
                    ConsoleLog("You can enable saving to buffer in settings!");
                    return null;
                }
                String name = String.Empty;
                ConsoleLog("0. Back");
                Console.Write("> Write filename without \".txt\": ");
                var x = Console.ReadLine();
                if (x == "0")
                    return "0";
                if(x == null || x == "" || x == String.Empty)
                {
                    ConsoleLog("You dont write any name!", "ERROR");
                    ConsoleLog("");
                    continue;
                }
                name = x + ".txt";
                if (fileMenager.AreFileExistChecker(name))
                {
                    ConsoleLog($"File \"{name} \" exist! Do you want to overwrite the file?", "IMPORTANT MESSAGE");
                    ConsoleLog("0. NO!");
                    ConsoleLog("1. YES!");
                    uint i = Input(1);
                    if (i == 1)
                        return name;
                }
                else
                    return name;
            }
        }

        private void DisplaySettings()
        { 
            while(state == State.Settings)
            {
                Console.Clear();
                ConsoleLog($"----- Name Generator v {version} -----");
                ConsoleLog("0. Back to menu");
                if (saveToBuffor)
                    ConsoleLog("Saving to buffor is ENABLED, press 1 to change it!", null, ConsoleColor.Green);
                else
                    ConsoleLog("Saving to buffor is DISABLED, press 1 to change it!", null, ConsoleColor.Red);

                if (displayGeneratedWords)
                    ConsoleLog("Displaying generated words is ENABLED, press 2 to change it!", null, ConsoleColor.Green);
                else
                    ConsoleLog("Displaying generated words  DISABLED, press 2 to change it!", null, ConsoleColor.Red);
                switch (Input(2))
                {
                    case 0:
                        Console.Clear();
                        state = State.Menu;
                        break;
                    case 1:
                        saveToBuffor = !saveToBuffor;
                        break;
                    case 2:
                        displayGeneratedWords = !displayGeneratedWords;
                        break;
                }
            }
        }

        private void Generate()
        {
            ConsoleLog("How much words you want to generate?");
            uint quantity = Input();
            for(int i = 0; i < quantity; i++)
            {
                String s = String.Empty;

                switch (state)
                {
                    case State.Unknow:
                        ConsoleLog("BAD OPTION", "ERROR");
                        break;
                    case State.GenerateWord:
                        s = generator.GenerateNewWord();
                        break;
                    case State.GenerateSentence:
                        s = generator.GenerateNewSentence();
                        break;
                }
                if (saveToBuffor)
                    fileMenager.AddToOutputBuffer(s);
                if (displayGeneratedWords)
                    ConsoleLog($"{s}", "GENERATED");
            }
            ConsoleLog("Genearate complete!, press ANY KEY to continue", "LOG");
        }
    }
}