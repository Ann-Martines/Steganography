using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Diagnostics;
//using System.Drawing;

namespace Steganography
{
	enum Nums : byte { Zero = 0, One}
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		/// <summary>
		/// Class for work with bytes and bits of the image
		/// </summary>
		BMP bmp = null;
		/// <summary>
		/// Loading and filling of a form
		/// </summary>
		public MainWindow()
        {
            InitializeComponent();
            
        }
		/// <summary>
		/// In an event of Load OpenFileDialog for the choice of the image opens
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Im1.Source = null;
                this.Im2.Source = null;
                this.Txt.Clear();
                this.lbBefore.Opacity = 50;
                this.lbAfter.Opacity = 50;
                OpenFileDialog ofd = new OpenFileDialog();

                ofd.Filter = "(*.bmp) | *.bmp";
                if (ofd.ShowDialog() == true)
                {
                    this.Im1.Source = new BitmapImage(new Uri(ofd.FileName));
                    
                    var im = System.Drawing.Image.FromFile(ofd.FileName);
                    bmp = new BMP(im, ofd.FileName);
                    this.lbTxt.Content = String.Format("Maximum quantity of symbols: {0}", bmp.MaxSizeTxt.ToString());
                }
                this.lbBefore.Opacity = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
		/// <summary>
		/// By clicking on the Encrypt button the text begins to be ciphered
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
				MyException mex = new MyException();
                if (this.Im1.Source == null)
                {
                    System.Windows.Forms.MessageBox.Show(mex.NotImage(), "Wrong!!!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return;
                }
                if (this.Txt.Text == "")
                {
                    System.Windows.Forms.MessageBox.Show(mex.NotText(), "Wrong!!!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return;
                }
                if (this.Txt.Text.Count() > bmp.MaxSizeTxt)
                {
                    System.Windows.Forms.MessageBox.Show(mex.MaxSimbol(), "Info", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return;
                }

                bmp.WriteToPicture(this.Txt.Text);
                this.lbAfter.Opacity = (int)Nums.Zero;
                this.Im2.Source = new BitmapImage(new Uri(bmp.NameFile));
                System.Windows.Forms.MessageBox.Show(String.Format("The text is ciphered! Name of the new file: {0}", bmp.NameFile), "Finish", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
		/// <summary>
		/// By clicking on the Decrypt button the text is deciphered from the image
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
				MyException mex = new MyException();
				if (this.Im1.Source == null)
                {
                    System.Windows.Forms.MessageBox.Show(mex.NotImage(), "Wrong!!!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return;
                }
                bmp.ReadFromPictire();
				if (bmp.SizeTxt == 0)
					return;
				this.lbAfter.Opacity = (int)Nums.Zero;
				this.Im2.Source = new BitmapImage(new Uri(bmp.NameFile));
                System.Windows.Forms.MessageBox.Show("The text is deciphered", "Finish", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                this.Txt.Text = bmp.ReadTxt;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
		/// <summary>
		/// At change of the text shows the number of the entered images
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.lbSimbol.Content = String.Format("Count simol: {0}", this.Txt.Text.Count());
        }
		/// <summary>
		/// The window is closed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
		/// <summary>
		/// Before closing of a form closes the using resources and we close the program
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.Im1.Source = null;
                this.Im2.Source = null;
                bmp.Dispose();

                Process.GetCurrentProcess().Kill();

            }
            catch { }
        }
		/// <summary>
		///When loading a window we check whether the welcome window has been already open
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (CheckedWindow.IsChecked)
                return;

            Welcome wel = new Welcome();
            wel.ShowDialog();
            CheckedWindow.IsChecked = true;
        }
		/// <summary>
		/// About the program
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MenuItem_Click_2(object sender, RoutedEventArgs e)
		{
			AboutProgram ap = new AboutProgram();
			ap.Show();
		}
		/// <summary>
		/// Help
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MenuItem_Click_3(object sender, RoutedEventArgs e)
		{
			WindowHelp winH = new WindowHelp();
			winH.Show();
		}
	}
}
