using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steganography
{
	class Bits
	{
		/// <summary>
		/// Leaf for work with bits
		/// </summary>
		List<byte> bits = new List<byte>();
		/// <summary>
		/// Line in which there is a transformation from number to binary system
		/// </summary>
		string num = null;
		/// <summary>
		/// Length, number of bits
		/// </summary>
		int len = 0;
		/// <summary>
		/// The designer accepting number in parameters and transforming him to dvoichnuy system
		/// </summary>
		/// <param name="value"></param>
		public Bits(int value)
		{
			this.num = Convert.ToString(value, 2);
			ToBits();
		}
		/// <summary>
		/// The designer accepting in parameters of bytes and transforming him to dvoichnuy system
		/// </summary>
		/// <param name="value"></param>
		public Bits(byte value)
		{
			this.num = Convert.ToString((int)value, 2);
			ToBits();
		}
		/// <summary>
		/// Property the returning number of bits
		/// </summary>
		public int Lenth
		{
			get
			{
				return len;
			}
		}
		/// <summary>
		/// Property for indexation, for more convenient work with bits
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public byte this[int i]
		{
			get
			{
				if (i <= Lenth && i >= 0)
					return this.bits[i];
				else
					return 0;
			}
			set
			{
				if (i <= Lenth && i >= 0)
					this.bits[i] = value;
			}
		}

		/// <summary>
		/// Method for filling with the set number on the set position
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		public void Insert(int index, byte value)
		{
			if (value > 1 && value < 0 || index > bits.Count)
				return;
			this.bits.Insert(index, value);
			this.len = bits.Count;
		}

		/// <summary>
		/// Method for filling of a leaf with bits
		/// </summary>
		public void ToBits()
		{
			foreach (var i in num)
			{
				bits.Add(byte.Parse(i.ToString()));
			}
			this.len = bits.Count;
		}
		/// <summary>
		/// Transfer of bits to number
		/// </summary>
		/// <returns></returns>
		public int ToInt()
		{
			string str = null;
			foreach (var i in this.bits)
				str += i;
			var conv = Convert.ToInt32(str, 2);
			return conv;
		}
		/// <summary>
		/// Transfer of the massif of bits to a line
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string str = null;
			foreach (var i in bits)
			{
				str += i;
			}
			return str;
		}
	}
}
