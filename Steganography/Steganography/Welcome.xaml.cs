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
using System.Windows.Shapes;

namespace Steganography
{
	/// <summary>
	/// Логика взаимодействия для Welcome.xaml
	/// </summary>
	public partial class Welcome : Window
	{
		public Welcome()
		{
			InitializeComponent();
		}
		/// <summary>
		/// By pressing the button the window is closed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
