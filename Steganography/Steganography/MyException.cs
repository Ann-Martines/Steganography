using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Steganography
{
	/// <summary>
	/// Class for error handling
	/// </summary>
	[Serializable]
	class MyException : ApplicationException
	{
		/// <summary>
		/// Default constructor
		/// </summary>
		public MyException()
		{ }
		/// <summary>
		/// The designer accepting a line in parameters
		/// </summary>
		/// <param name="s"></param>
		public MyException(string s) : base(s)
		{ }
		/// <summary>
		/// The designer accepting a line and a mistake in parameters
		/// </summary>
		/// <param name="s"></param>
		/// <param name="ex"></param>
		public MyException(string s, Exception ex) : base(s, ex)
		{ }
		/// <summary>
		/// The designer
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected MyException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{ }
		/// <summary>
		/// Returns the message if the image isn't loaded
		/// </summary>
		/// <returns></returns>
		public string NotImage()
		{
			return "There is no image! Please, load image!!!";
		}
		/// <summary>
		/// Returns the message if the text isn't entered
		/// </summary>
		/// <returns></returns>
		public string NotText()
		{
			return "There is no text! Please, Enter text!!!";
		}
		/// <summary>
		/// Returns the message if it has been entered more maximum value of symbols
		/// </summary>
		/// <returns></returns>
		public string MaxSimbol()
		{
			return "You have exceeded the maximum value of the entered symbols. Please, reduce the text to the maximum value!";
		}
	}
}
