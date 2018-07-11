using System;
using System.IO;
using System.Collections.Generic;

namespace RandomNameGenerator
{
    class FileMenager
    {
        private List<String> inputData = new List<string>();
        public List<String> outputData = new List<string>();
        public void AddToOutputBuffer(String text)
        {
            outputData.Add(text);
        }
        public void WriteToFile(String fileLocation)
        {
            TextWriter textWriter = new StreamWriter(fileLocation);
            foreach(String word in outputData)
            {
                textWriter.WriteLine(word);
            }
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
        private bool CheckFile(String fileLocation)
        {
            if (File.Exists(fileLocation))
                return true;
            Console.WriteLine($"> Cannot load file: {fileLocation}");
            return false;
        }
    }
}
