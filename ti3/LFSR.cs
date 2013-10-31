using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TI2
{
    class LFSR
    {
        private readonly byte[] polinomial = { 42, 43, 79, 80 };
        private readonly byte polinomial_degree = 80;
        public char[] key;

        public LFSR(string password)
        {
            key = password.ToCharArray(0, polinomial_degree);
        }

        public void MakeOffset()
        {
            char first_symbol;
            first_symbol = Xor(key, polinomial);
            Shl(key);
            key[key.Length - 1] = first_symbol;

        }

        public byte GetByte(byte number)
        {
            byte result;
            string resultStr = "";
            byte numberBytes = (byte)(polinomial_degree / 8);
            if (number > numberBytes)
                number = (byte)(number % numberBytes);

            for (int i = (number - 1) * 8 ; i < number * 8; ++i)
                resultStr += key[i];
            result = Convert.ToByte(resultStr, 2);
 
            return result;
        }

        protected void Shl(char[] changed_password)
        {
            for (int i = 0; i < changed_password.Length - 1; ++i)
                changed_password[i] = changed_password[i + 1];

        }

        protected char Xor(char[] changed_password, byte[] polinomial)
        {
            char xor_result;
            xor_result = changed_password[changed_password.Length - polinomial[0]];
            for (int i = 1; i < polinomial.Length; ++i)
            {
                if (xor_result == changed_password[changed_password.Length - polinomial[i]])
                    xor_result = '0';
                else
                    xor_result = '1';
            }
            return xor_result;
        }
    }
}
