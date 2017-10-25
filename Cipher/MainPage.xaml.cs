using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Cipher
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int seed;
            string temp = seedTextBox.Text;
            string plainText;
            string cipherText;
            Cipher encrypt;
            Cipher decrypt;

            try
            {
                if (!temp.Trim().Equals(""))
                {
                    if ((bool)encryptRadioButton.IsChecked)
                    {
                        seed = int.Parse(seedTextBox.Text);
                        plainText = plainTextBox.Text;
                        encrypt = new Cipher(seed, plainText, 'e');
                        cipheredTextBox.Text = encrypt.getEncryptedPhrase();
                    }
                    else if ((bool)decryptRadioButton.IsChecked)
                    {
                        seed = int.Parse(seedTextBox.Text);
                        cipherText = cipheredTextBox.Text;
                        decrypt = new Cipher(seed, cipherText, 'd');
                        plainTextBox.Text = decrypt.getDecryptedPhrase();
                    } 
                } else
                {
                    throwEmptySeedError();
                }
            } catch(Exception ex)
            {
                throwInvalidSeedError(ex);
            }
        }

        private async void throwInvalidSeedError(Exception e)
        {

            ContentDialog testDialog = new ContentDialog
            {
                Title = "INVALID SEED",
                Content = "Invalid seed was entered in to the seed textbox!",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await testDialog.ShowAsync();

        }

        private async void throwEmptySeedError()
        {

            ContentDialog testDialog = new ContentDialog
            {
                Title = "EMPTY SEED",
                Content = "The seed textbox was left empty!",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await testDialog.ShowAsync();

        }
    }
}
