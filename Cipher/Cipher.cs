using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Cipher
{
    class Cipher
    {

        private String alphabet = "abcdefghijklmnopqrstuvwxyz";
        private String cipher = "";
        private String phrase = "";
        private String endPhrase = "";

        public Cipher(int seed, string phrase, char type)
        {
            Random rand = new Random(seed);

            this.phrase = phrase;
            int count = 0;
            int temp;

            while (count < alphabet.Length)
            {
                temp = rand.Next(0, alphabet.Length);

                if (cipher.IndexOf(alphabet[temp]) < 0)
                {
                    cipher += alphabet[temp];
                    count++;
                }
            }

            if (type == 'e')
            {
                encrypt();
            } else if (type == 'd')
            {
                decrypt();
            }

        }

        private void encrypt()
        {
            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase[i] != ' ' || !Char.IsDigit(phrase[i]))
                {
                    if (Char.IsUpper(phrase[i]))
                    {
                        endPhrase += cipher.ToUpper()[alphabet.ToUpper().IndexOf(phrase[i])];
                    }
                    else if (Char.IsLower(phrase[i]))
                    {
                        endPhrase += cipher[alphabet.IndexOf(phrase[i])];
                    }
                    else
                    {
                        endPhrase += phrase[i];
                    } 
                }
            }
        }

        private void decrypt()
        {
            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase[i] != ' ' || !Char.IsDigit(phrase[i]))
                {
                    if (Char.IsUpper(phrase[i]))
                    {
                        endPhrase += alphabet.ToUpper()[cipher.ToUpper().IndexOf(phrase[i])];
                    }
                    else if (Char.IsLower(phrase[i]))
                    {
                        endPhrase += alphabet[cipher.IndexOf(phrase[i])];
                    }
                    else
                    {
                        endPhrase += phrase[i];
                    }
                }
            }
        }

        public String getEncryptedPhrase()
        {
            return endPhrase;
        }

        public String getDecryptedPhrase()
        {
            return endPhrase;
        }

    }
}
