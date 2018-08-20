using System;

namespace NameGenerator
{
    class Generator
    {
        private readonly Random random = new Random();

        String lastLetter = String.Empty;
        String newLetter = String.Empty;

        private enum CharType { VOWEL = 1, COSONANTS = 2, UNKNOW = 0 };

        readonly char[] vowel = { 'a', 'e', 'i', 'o', 'u', 'y' };
        readonly char[] consonants = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };

        private String GenerateLetter() { return ((char)random.Next(97, 123)).ToString(); }

        public String GenerateNewWord(int lenght = 0)
        {
            string GeneratedWord = String.Empty;

            if (lenght == 0)
                lenght = random.Next(3, 8);
            //Console.WriteLine($"> LENGHT: {lenght}");
            

            for (int i = 0; i < lenght; i++)
            {
                if (i == 0)
                {
                    lastLetter = GenerateLetter().ToUpper();
                    GeneratedWord += lastLetter;
                    continue;
                }
                if (GetLetterType(lastLetter) == (int)CharType.VOWEL)
                    DrawLetter(30);

                else if (GetLetterType(lastLetter) == (int)CharType.COSONANTS)
                    DrawLetter(40);

                GeneratedWord += newLetter;
                lastLetter = newLetter;
            }
            return GeneratedWord;
        }

        public string GenerateNewSentence()
        {
            String sentence = String.Empty;
            int lenght = random.Next(3, 12);
            sentence += GenerateNewWord();
            for (int i = 0; i < lenght; i++)
            {
                sentence += (GenerateNewWord().ToLower() + " ");
            }
            return sentence + ".";
        }

        private void DrawLetter(int vowelProbability)
        {
            int rand = random.Next(0, 100);
            newLetter = String.Empty;
            if (rand < vowelProbability)
            {
                while (GetLetterType(newLetter) != (int)CharType.VOWEL || newLetter == lastLetter)
                    newLetter = GenerateLetter();
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
