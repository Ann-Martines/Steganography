using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.IO;

namespace Steganography
{
	/// <summary>
	/// Класс для зашифровки bmp изображений
	/// </summary>
	class BMP : MainWindow
	{
		/// <summary>
		/// Image
		/// </summary>
		Image im = null;
		/// <summary>
		/// For obtaining some data from the image
		/// </summary>
		Bitmap bm = null;
		/// <summary>
		///	Variable for storage of a full name of the image
		/// </summary>
		string name = null;
		/// <summary>
		/// Variable in which to be stored the text, only a few from the image
		/// </summary>
		string readTxt = null;
		/// <summary>
		/// Leaf in which the deciphered symbols are stored in bytes
		/// </summary>
		List<int> lstRead = null;
		/// <summary>
		/// Quantity of symbols which need to be considered
		/// </summary>
		int sizeTxt = 0;
		/// <summary>
		/// The index for work with bits
		/// </summary>
		int ind = 0;
		/// <summary>
		/// The index for work with bits
		/// </summary>
		int index = 0;
		/// <summary>
		/// Default constructor
		/// </summary>
		public BMP() { }
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="im">Image</param>
		/// <param name="name">Full name of the image</param>
		public BMP(Image im, string name)
		{
			this.im = im;
			this.bm = new Bitmap(this.im);
			this.name = name;
		}
		/// <summary>
		/// Property which returns a full name of the file
		/// </summary>
		public string NameFile
		{
			get
			{
				return this.name;
			}
		}
		/// <summary>
		/// Property which returns the maximum size of the text
		/// </summary>
		public int MaxSizeTxt
		{
			get
			{
				int size = (this.im.Width * this.im.Height) / 8;
				return size;
			}
		}
		/// <summary>
		/// Property which returns the only a few text
		/// </summary>
		public string ReadTxt
		{
			get
			{
				return this.readTxt;
			}
		}
		/// <summary>
		/// Size text
		/// </summary>
		public int SizeTxt
		{
			get
			{
				return this.sizeTxt;
			}
		}
		/// <summary>
		/// Method in which there is an enciphering of the text in the image
		/// </summary>
		/// <param name="str">Текст который необходимо зашифровать</param>
		public void WriteToPicture(string str)
		{
			ind = -1;
			index = (int)Nums.Zero;
			byte[] bt = Encoding.GetEncoding(1251).GetBytes(String.Format("*{0}*{1}", str.Length, str));
			Bits bits = null;
			bool f = false;
			for (var i = (int)Nums.Zero; i < this.im.Width; i++)
			{
				if (f)
					break;
				for (var j = (int)Nums.Zero; j < this.im.Height; j++)
				{
					if (index == 8 || index == 0)
					{
						index = (int)Nums.Zero;
						ind++;
						if (ind == bt.Count())
						{
							f = true;
							break;
						}
						bits = new Bits(bt[ind]);
						while (bits.Lenth != 8)
							bits.Insert((int)Nums.Zero, (int)Nums.Zero);
					}

					var pixel = this.bm.GetPixel(i, j);

					Bits r = new Bits(pixel.R);
					while (r.Lenth != 8)
						r.Insert((int)Nums.Zero, (int)Nums.Zero);
					r[r.Lenth - (int)Nums.One] = bits[index];
					index++;

					Bits b = new Bits(pixel.B);
					Bits g = new Bits(pixel.G);

					this.bm.SetPixel(i, j, Color.FromArgb(r.ToInt(), pixel.G, pixel.B));
				}
			}
			this.name = NewWriteName();
			this.bm.Save(this.name);
		}

		/// <summary>
		///  Method in which there is an interpretation of the text from the image
		/// </summary>
		public void ReadFromPictire()
		{
			ind = (int)Nums.Zero;
			index = (int)Nums.Zero;
			List<int> lst = new List<int>();
			Bits ar = new Bits(255);
			this.lstRead = new List<int>();
			bool f = false;
			this.sizeTxt = 0;
			ForRead();
			if (this.sizeTxt == 0)
				f = true; ;
			for (var i = (int)Nums.Zero; i < this.im.Width; i++)
			{
				if (f)
					break;
				for (var j = (int)Nums.Zero; j < this.im.Height; j++)
				{
					if (j < this.lstRead.Count * 8 && i == 0)
						continue;

					if ((lst.Count) == this.sizeTxt)
					{
						f = true;
						break;
					}

					if (index == 8)
					{
						lst.Add(ar.ToInt());
						ind++;
						index = (int)Nums.Zero;
					}

					var pixel = this.bm.GetPixel(i, j);
					Bits r = new Bits(pixel.R);
					while (r.Lenth != 8)
						r.Insert((int)Nums.Zero, (int)Nums.Zero);

					ar[index] = r[r.Lenth - (int)Nums.One];
					r[r.Lenth - (int)Nums.One] = (int)Nums.Zero;
					index++;
					this.bm.SetPixel(i, j, Color.FromArgb(r.ToInt(), pixel.G, pixel.B));
					if (f)
						break;
				}
			}
			byte[] rezult = new byte[lst.Count];
			ind = (int)Nums.Zero;
			for (var i = (int)Nums.Zero; i < lst.Count; i++)
			{
				rezult[ind] = Convert.ToByte(lst[i]);
				ind++;
			}
			this.name = NewReadName();
			this.bm.Save(this.name);
			this.readTxt = Encoding.GetEncoding(1251).GetString(rezult);
		}
		/// <summary>
		/// Method which reads out the first bytes and defines whether the picture, and the text size in the image is ciphered
		/// </summary>
		private void ForRead()
		{
			int index = (int)Nums.Zero;
			int ind = (int)Nums.Zero;
			Bits bt = new Bits(255);
			bool f = false;
			string str = null;
			for (var i = (int)Nums.Zero; i < this.im.Width; i++)
			{
				if (f)
					break;
				for (var j = (int)Nums.Zero; j < this.im.Height; j++)
				{
					if (index == 8)
					{
						index = (int)Nums.Zero;
						this.lstRead.Add(bt.ToInt());
						if (Convert.ToChar(this.lstRead[(int)Nums.Zero]) != '*')
						{
							MessageBox.Show("In this picture nothing is ciphered!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
							f = true;
							break;
						}
						int tmp = (int)Nums.Zero;

						if (int.TryParse(Convert.ToChar(this.lstRead[ind]).ToString(), out tmp))
						{

							if (tmp >= (int)Nums.Zero && tmp <= 9)
							{
								tmp = int.Parse(Convert.ToChar(this.lstRead[ind]).ToString());
								str += tmp.ToString();
							}

						}

						if (this.lstRead.Count > (int)Nums.One)
						{
							if (Convert.ToChar(this.lstRead[ind]) == '*')
							{
								f = true;
								break;
							}
						}
						ind++;
					}
					var pixel = this.bm.GetPixel(i, j);

					Bits r = new Bits(pixel.R);
					while (r.Lenth != 8)
						r.Insert((int)Nums.Zero, (int)Nums.Zero);
					bt[index] = r[r.Lenth - (int)Nums.One];
					r[r.Lenth - (int)Nums.One] = (int)Nums.Zero;

					this.bm.SetPixel(i, j, Color.FromArgb(r.ToInt(), pixel.G, pixel.B));
					index++;
				}
			}
			if (str != null)
				this.sizeTxt = int.Parse(str);
		}
		/// <summary>
		/// Method which creates a new name for the ciphered image
		/// </summary>
		/// <returns></returns>
		public string NewWriteName()
		{
			string strNew = null;
			var tmp = this.name.Split(new char[] { '.' });
			for (var i = (int)Nums.Zero; i < tmp.Length - (int)Nums.One; i++)
			{
				strNew += tmp[i];
			}
			strNew += " (cipher).";
			strNew += tmp[tmp.Length - (int)Nums.One];
			return strNew;
		}
		/// <summary>
		/// Method which creates a new name for the deciphered image
		/// </summary>
		/// <returns></returns>
		public string NewReadName()
		{
			string strNew = null;
			var tmp = this.name.Split(new char[] { '.' });
			for (var i = 0; i < tmp.Length - (int)Nums.One; i++)
			{
				strNew += tmp[i];
			}
			strNew += " (decrypt).";
			strNew += tmp[tmp.Length - (int)Nums.One];
			return strNew;
		}
		/// <summary>
		/// Closing of some variables
		/// </summary>
		public void Dispose()
		{
			try
			{
				this.bm.Dispose();

			}
			catch { }
			try
			{

				this.im.Dispose();
			}
			catch { }
		}

	}
}
