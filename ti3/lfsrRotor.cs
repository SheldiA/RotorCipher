﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ti3
{
    class lfsrRotor
    {
        private byte[] rightRotor = { 0, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 1, 2, 3, 4, 5, 29, 30, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 69, 70, 71, 72, 73, 74, 75, 76, 77, 217, 218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 253, 254, 255 };
        private byte[] middleRotor = { 0, 242, 243, 222, 223, 224, 225, 104, 105, 106, 107, 108, 109, 110, 226, 227, 228, 229, 230, 244, 245, 246, 247, 248, 249, 250, 251, 252, 1, 2, 3, 4, 5, 29, 30, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 69, 70, 71, 72, 73, 74, 75, 76, 77, 217, 218, 219, 220, 221, 231, 232, 167, 168, 169, 170, 171, 172, 173, 174, 175, 233, 234, 235, 236, 237, 238, 239, 240, 241, 253, 254, 255 };
        private byte[] leftRotor = { 0, 242, 243, 244, 245, 246, 247, 29, 30, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 112, 113, 248, 249, 250, 251, 252, 1, 2, 3, 4, 5, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 105, 106, 107, 108, 109, 110, 111, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 69, 70, 71, 72, 73, 74, 75, 76, 77, 217, 218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 253, 254, 255 };
        
        private byte rcbRight = 0, rcbMiddle = 0, rcbLeft = 0,rsRight = 0,rsMiddle = 0,rsLeft = 0;
        private TI2.LFSR lfsr;
        private byte previousResult;

        public lfsrRotor(string password,byte[] key)
        {
            GenerateRotor(key);
            lfsr = new TI2.LFSR(password);
            previousResult = 0;
        }

        private void GenerateRotor(byte[] key)
        {
            if (key.Length > 3)
            {
                rcbRight = (byte)(key[0] % 8);
                rcbMiddle = (byte)(key[1] % 8);
                rcbLeft = (byte)(key[2] % 8);
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
