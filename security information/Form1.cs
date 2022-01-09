using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace security_information
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(2048);

        public string Encrypt(string data, RSAParameters key)
        {

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(key);
                var byteData = Encoding.UTF8.GetBytes(data);
                var encryptData = rsa.Encrypt(byteData, false);
                return Convert.ToBase64String(encryptData);
            }
        }

        public string Decrypt(string cipherText, RSAParameters key)
        {

            using (var rsa = new RSACryptoServiceProvider())
            {
                var cipherByteData = Convert.FromBase64String(cipherText);
                rsa.ImportParameters(key);

                var encryptData = rsa.Decrypt(cipherByteData, false);
                return Encoding.UTF8.GetString(encryptData);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text); 
            string message = textBox2.Text ;   
            textBox3.Text = ceasercipher.encrypt(message,x); //pass the data to output text 
            
        }

         private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        
        //**********   clear all data ****************************
        private void clear_Click(object sender, EventArgs e)
        {         
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox11.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox4.Text;
            textBox6.Text = Encrypt(text, rsaCryptoServiceProvider.ExportParameters(false));

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            int x = Convert.ToInt32(textBox1.Text);
            string message = textBox11.Text;
            textBox8.Text = ceasercipher.decrypt(message, x); //pass the data to output text 
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string text = textBox9.Text;
            textBox7.Text = Decrypt(text, rsaCryptoServiceProvider.ExportParameters(true));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox11.Clear();
        }
    }
}

public class ceasercipher
{
    public static string encrypt(string text ,int key)
    {
        string result = " ";
        
        for (int i=0;i<text.Length;i++)
        {
            if(char.IsUpper(text[i]))
            {
                 
                result +=Convert.ToChar(Convert.ToInt32(text[i]+key-65) %26 +65);
            }
            else
            {
                result += Convert.ToChar(Convert.ToInt32(text[i] + key - 97) % 26 + 97);
            }

        } return result;
    }

    public static string decrypt(string text, int key)
    {
        return encrypt(text, 26 - key); 
    }
}


