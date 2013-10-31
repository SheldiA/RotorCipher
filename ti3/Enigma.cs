using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ti3
{
    class Enigma
    {
        public enum languages { russian,english};
        
        private readonly string alphabet;
        private readonly int alphabetQuantity;
        private readonly string reflector;
        private readonly int highUpperBorder;
        private readonly int lowUpperBorder;

        private const string alphabetRus = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private const int alphabetQuantityRus = 33;
        private const string reflectorRus = "пеуцсбшоэрщтюхыжаидквямгьёйънчзлф";

        private const string alphabetEng = "abcdefghijklmnopqrstuvwxyz";
        private const int alphabetQuantityEng = 26;
        private const string reflectorEng = "yruhqsldpxngokmiebfzcwvjat";

        private string rightRotor;
        private string middleRotor;
        private string leftRotor;
        
        private int rightOffset;
        private int middleOffset;
        private int leftOffset;

        public Enigma(byte[] key,languages lang)
        {
            if (lang == languages.russian)
            {
                alphabet = alphabetRus;
                alphabetQuantity = alphabetQuantityRus;
                reflector = reflectorRus;
                highUpperBorder = 1071;
                lowUpperBorder = 1040;
            }
            else
            {
                alphabet = alphabetEng;
                alphabetQuantity = alphabetQuantityEng;
                reflector = reflectorEng;
                highUpperBorder = 90;
                lowUpperBorder = 65;
            }

            rightOffset = 0;
            middleOffset = 0;
            leftOffset = 0;
            rightRotor = new string(GenerateRotor(key, 0, alphabet));
            middleRotor = new string(GenerateRotor(key, 1, alphabet));
            leftRotor = new string(GenerateRotor(key, 2, alphabet));
        }

        private char[] GenerateRotor(byte[] key,int number,string alphabet)
        {
            char[] result = alphabet.ToCharArray();
            char temp;

            for (int i = 0; i < alphabetQuantity - 1; i += 2)
            {
                temp = result[key[(i + number * alphabetQuantity) % key.Length] % alphabetQuantity];
                result[key[(i + number * alphabetQuantity) % key.Length] % alphabetQuantity] = result[key[(i + 1 + number * alphabetQuantity) % key.Length] % alphabetQuantity];
                result[key[(i + 1 + number * alphabetQuantity) % key.Length] % alphabetQuantity] = temp;
            }

            return result;
        }


        public char Encrypt(char message)
        {
            char result = message;
            bool isUpper = false;

            if ( result >= lowUpperBorder && result <= highUpperBorder)
            {
                isUpper = true;
                result = (char)(result + 32);
            }

            if (alphabet.IndexOf(result) > -1)
            {
                result = rightRotor[(alphabet.IndexOf(result) + rightOffset) % alphabetQuantity];
                result = middleRotor[(alphabet.IndexOf(result) + middleOffset) % alphabetQuantity];
                result = leftRotor[(alphabet.IndexOf(result) + leftOffset) % alphabetQuantity];

                result = reflector[alphabet.IndexOf(result)];

                result = alphabet[(leftRotor.IndexOf(result) + alphabetQuantity - leftOffset) % alphabetQuantity];
                result = alphabet[(middleRotor.IndexOf(result) + alphabetQuantity - middleOffset) % alphabetQuantity];
                result = alphabet[(rightRotor.IndexOf(result) + alphabetQuantity - rightOffset) % alphabetQuantity];

                ++rightOffset;
                if (rightOffset == alphabetQuantity)
                {
                    rightOffset = 0;
                    ++middleOffset;
                }
                if (middleOffset == alphabetQuantity)
                {
                    middleOffset = 0;
                    ++leftOffset;
                }
                if (leftOffset == alphabetQuantity)
                    leftOffset = 0;
            }

            if(isUpper)
                result = (char)(result - 32);

            return result;
        }
    }
}
