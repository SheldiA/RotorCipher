using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ti3
{
    class lfsrRotor
    {
        private byte[] rightRotor; 
        private byte[] middleRotor;
        private byte[] leftRotor;
        
        private byte rcbRight = 0, rcbMiddle = 0, rcbLeft = 0,rsRight = 0,rsMiddle = 0,rsLeft = 0;
        private TI2.LFSR lfsr;
        private byte previousResult;

        public lfsrRotor(string password,byte[] key)
        {
            GenerateRotor(key,ref rightRotor,2);
            GenerateRotor(key, ref middleRotor, 3);
            GenerateRotor(key, ref leftRotor, 4);
            lfsr = new TI2.LFSR(password);
            previousResult = 0;
            if (key.Length > 3)
            {
                rcbRight = (byte)((key[0] % 10) + 1);
                rcbMiddle = (byte)((key[1] % 10) + 1);
                rcbLeft = (byte)((key[2] % 10) + 1);
            }
        }

        private void GenerateRotor(byte[] key,ref byte[] rotor,int number)
        {
            rotor = new byte[256];
            byte temp;
            for (int i = 0; i < 256; ++i)
                rotor[i] = (byte)i;
            for (int i = 0; i < key.Length - number; ++i)
            {
                temp = rotor[key[i]];
                rotor[key[i]] = rotor[key[i + number]];
                rotor[key[i + number]] = temp;
            }
        }

        public byte EncryptByte(byte message)
        {
            byte result = message;
            result = UseRotor(rightRotor, rcbRight, ref rsRight, result);
            result = UseRotor(middleRotor, rcbMiddle, ref rsMiddle, result);
            result = UseRotor(leftRotor, rcbLeft, ref rsLeft, result);
            previousResult = result;
            lfsr.MakeOffset();
            return result;
        }

        public byte DecryptByte(byte message)
        {
            byte result = message;

            result = UseRotorDecrypt(leftRotor, rcbLeft, ref rsLeft, result);
            result = UseRotorDecrypt(middleRotor, rcbMiddle, ref rsMiddle, result);
            result = UseRotorDecrypt(rightRotor, rcbRight, ref rsRight, result);

            previousResult = message;
            lfsr.MakeOffset();
            return result;
        }

        private byte UseRotor(byte[] currRotor, byte currRotorRcb, ref byte rsCurrRotor, byte message)
        {
            byte rcb = lfsr.GetByte(currRotorRcb);
            rsCurrRotor = (byte)((rsCurrRotor + previousResult + rcb) % 256);
            return currRotor[(message + rsCurrRotor) % 256];
          
        }

        private byte UseRotorDecrypt(byte[] currRotor, byte currRotorRcb,ref byte rsCurrRotor, byte message)
        {
            byte result = 0;
           
            for (int i = 0; i < 256; ++i)
            {
                if (currRotor[i] == message)
                {
                    result = (byte)i;
                    break;
                }
            }

            byte rcb = lfsr.GetByte(currRotorRcb);
            rsCurrRotor = (byte)((rsCurrRotor + previousResult + rcb) % 256);
            return (byte)(result - rsCurrRotor);
        }
    }
}
