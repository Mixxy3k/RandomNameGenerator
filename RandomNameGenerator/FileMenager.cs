using System;
using System.IO;
using System.Collections.Generic;
using User;

namespace Files
{
    class FileMenager
    {
        private List<String> inputData = new List<string>();
        public List<String> outputData = new List<string>();
        public void AddToOutputBuffer(String text)
        {
            outputData.Add(text);
        }
        public void WriteToFile(String fileLocation, UserMenager um)
        {
            TextWriter textWriter = new StreamWriter(fileLocation);
            foreach(String word in outputData)
            {
                textWriter.WriteLine(word);
            }
            um.Message("Saved to file!",ConsoleColor.Green,"LOG");
            textWriter.Close();
        }
        public bool LoadFromFile(String fileLocation)
        {
            if (CheckFile(fileLocation))
            {
                inputData.Add(File.OpenText(fileLocation).ReadToEnd());
                return true;
            }
            return false;
        }
        private bool CheckFile(String fileLocation, UserMenager um)
        {
            if (File.Exists(fileLocation))
                return true;
            um.Message($"> Cannot load file: {fileLocation}", ConsoleColor.DarkRed, "ERROR");
            return false;
            if
        }
    }
}
