using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Zxm.iOS
{
	public partial class MessageCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("MessageCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("MessageCell");

		public MessageCell (IntPtr handle) : base (handle)
		{
		}

		public static MessageCell Create ()
		{
			return (MessageCell)Nib.Instantiate (null, null) [0];
		}
	}
}

