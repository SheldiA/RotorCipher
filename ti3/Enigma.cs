using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ti3
{
    class Enigma
    {
        private readonly string alphabet = "abcdefghijklmnopqrstuvwxyz";
        private const int alphabetQuantity = 26;
        private readonly string rightRotor = "bdfhjlcprtxvznyeiwgakmusqo";
        private readonly string middleRotor = "ajdksiruxblhwtmcqgznpyfvoe";
        private readonly string leftRotor = "ekmflgdqvzntowyhxuspaibrcj";
        private readonly string reflector = "yruhqsldpxngokmiebfzcwvjat";
        private int rightOffset;
        private int middleOffset;
        private int leftOffset;

        public Enigma()
        {
            rightOffset = 0;
            middleOffset = 0;
            leftOffset = 0;
        }

        public char Encrypt(char message)
        {
            char result = message;
            bool isUpper = false;

            if (result >= 65 && result <= 90)
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
