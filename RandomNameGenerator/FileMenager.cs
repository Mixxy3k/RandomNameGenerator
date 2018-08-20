using System;
using System.Collections.Generic;
using System.IO;

namespace NameGenerator
{
    class FileMenager
    {
        public List<String> outputData;
        UserMenager userMenager;

        public FileMenager(UserMenager userMenager)
        {
            this.userMenager = userMenager;
            outputData = new List<string>();
        }

        public void AddToOutputBuffer(String text)
        {
            outputData.Add(text);
        }

        public void WriteToFile(String fileLocation)
        {
            TextWriter textWriter = new StreamWriter(fileLocation);
            foreach (String word in outputData)
                textWriter.WriteLine(word);
            
            userMenager.ConsoleLog($"Saved to file! \"CurrentLocation/{fileLocation}\"", "LOG");
            textWriter.Close();
        }

        public bool AreFileExistChecker(String fileLocation)
        {
            if (File.Exists(fileLocation))
                return true;
            return false;
        }
    }
}
