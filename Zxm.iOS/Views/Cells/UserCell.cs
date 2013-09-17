using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace Zxm.iOS
{
    public partial class UserCell : MvxTableViewCell
    {
        public static readonly UINib Nib = UINib.FromName("UserCell", NSBundle.MainBundle);
        public static readonly NSString Key = new NSString("UserCell");

        MvxImageViewLoader imageLoader;

        public UserCell(IntPtr handle) : base (handle)
        {


        }

        public static UserCell Create()
        {
            return (UserCell)Nib.Instantiate(null, null)[0];
        }
    }
}

