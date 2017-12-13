using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steganography
{
	/// <summary>
	/// Class for check of a welcome window what it would open only at start of the program
	/// </summary>
	static class CheckedWindow
    {
		/// <summary>
		/// Whether the property the accepting or returning window has been opened
		/// </summary>
		public static bool IsChecked
        { set; get; }
		/// <summary>
		/// if the window was октрыто IsChecked to become true
		/// </summary>
		static CheckedWindow()
        {
            IsChecked = false;
        }
    }
}
