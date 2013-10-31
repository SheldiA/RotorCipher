using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace ti3
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private static byte[] save = new byte[10000];
        private void bt_do_Click(object sender, EventArgs e)
        {
            if (cb_Algorithm.SelectedIndex == 0)
            {
                Enigma.languages language;
                if ((rtb_message.Text[0] >= 1040) && (rtb_message.Text[0] <= 1103))
                    language = Enigma.languages.russian;
                else
                    language = Enigma.languages.english;

                Enigma enigma = new Enigma(GetBytePassword(tb_key.Text),language);
                rtb_cipher.Text = "";
                for (int i = 0; i < rtb_message.Text.Length; ++i)
                    rtb_cipher.Text += enigma.Encrypt(rtb_message.Text[i]);
            }
            else
            {
                lfsrRotor rotor = new lfsrRotor(GetBinaryPassword(tb_key.Text), GetBytePassword(tb_key.Text));
                rtb_cipher.Text = "";

                byte[] incomingBytes = Encoding.Default.GetBytes(rtb_message.Text);
                byte[] resultBytes = new byte[incomingBytes.Length];

                for (int i = 0; i < incomingBytes.Length; ++i)
                {
                    if (cb_EncrDecr.SelectedIndex == 0)
                        resultBytes[i] = rotor.EncryptByte(incomingBytes[i]);
                    else
                        resultBytes[i] = rotor.DecryptByte(save[i]);
                }

                if (cb_EncrDecr.SelectedIndex == 0)
                {
                    for (int i = 0; i < resultBytes.Length; ++i)
                        save[i] = resultBytes[i];
                }
                    string str = Encoding.Default.GetString(resultBytes);
                    for (int i = 0; i < str.Length; ++i)
                        rtb_cipher.Text += str[i];
            }
        }

        private string GetBinaryPassword(string initial_string)
        {
            byte[] data = GetBytePassword(initial_string);
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; ++i)
                sBuilder.Append(Convert.ToString(data[i], 2));
            return sBuilder.ToString();
        }

        private byte[] GetBytePassword(string initial_string)
        {
            //MD5 md5hash = MD5.Create();
            SHA512 sha512 = new SHA512Managed();
            byte[] data = sha512.ComputeHash(Encoding.UTF8.GetBytes(initial_string));
            return data;
        }

        private void bt_change_Click(object sender, EventArgs e)
        {
            rtb_message.Text = rtb_cipher.Text;
            rtb_cipher.Text = "";
            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            cb_EncrDecr.SelectedIndex = 0;
            cb_Algorithm.SelectedIndex = 0;
        }

        private void bt_openFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "*.txt";
            openFileDialog1.Filter = "TXT Files|*.txt";
            if ((openFileDialog1.ShowDialog() == DialogResult.OK) && (openFileDialog1.FileName.Length > 0))
            {
                rtb_message.LoadFile(openFileDialog1.FileName,RichTextBoxStreamType.PlainText);
            }
        }
    }
}
