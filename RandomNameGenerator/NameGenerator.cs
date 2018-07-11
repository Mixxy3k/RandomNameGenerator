using System;

namespace RandomNameGenerator
{
    class NameGenerator
    {
        private readonly Random random = new Random();

        String lastLetter = String.Empty;
        String newLetter = String.Empty;

        private enum CharType { VOWEL = 1, COSONANTS = 2, UNKNOW = 0 };

        char[] vowel = { 'a', 'e', 'i', 'o', 'u', 'y' };
        char[] consonants = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };

        private String GenerateLetter() { return ((char)random.Next(97, 123)).ToString(); }

        public string GenerateNewWord(int lenght = 0)
        { 
            string GeneratedWord = String.Empty;

            if (lenght == 0)
            {
                lenght = random.Next(3, 8);
            }

            for (int i = 0; i < lenght; i++)
            {
                if (i == 0)
                {
                    lastLetter = GenerateLetter();
                    GeneratedWord += lastLetter;
                    continue;
                }
                if (GetLetterType(lastLetter) == (int)CharType.VOWEL)
                    DrawLetter(57);
   
                else if (GetLetterType(lastLetter) == (int)CharType.COSONANTS)
                    DrawLetter(48);
   
                GeneratedWord += newLetter;
                lastLetter = newLetter;
            }
            return GeneratedWord;
        }

        private void DrawLetter(int vowelProbability)
        {
            int rand = random.Next(0, 100);
            newLetter = String.Empty;
            if (rand < vowelProbability)
            {
                while (GetLetterType(newLetter) != (int)CharType.VOWEL || newLetter == lastLetter)
                {
                    newLetter = GenerateLetter();
                };
                return;
            }
            
            newLetter = GenerateLetter();
            
        }
    
        private int GetLetterType(String letter)
        {
            foreach (char c in vowel)
            {
                if (c.ToString() == letter.ToLower())
                    return 1;
            }
            foreach (char c in consonants)
            {
                if (c.ToString() == letter.ToLower())
                    return 2;
            }
            return 0;
        }
    }
}