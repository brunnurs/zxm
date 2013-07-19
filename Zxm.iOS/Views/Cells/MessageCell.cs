using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Zxm.Core.Model;

namespace Zxm.iOS
{
    public partial class MessageCell : MvxTableViewCell
    {
        public static readonly UINib Nib = UINib.FromName("MessageCell", NSBundle.MainBundle);
        public static readonly NSString Key = new NSString("MessageCell");

        public MessageCell (IntPtr handle) : base (handle)
        {
            this.DelayBind(() => {
                var set = this.CreateBindingSet<MessageCell, Message> ();
                set.Bind (MessageContentLabel).To (item => item.Content);
                set.Bind (MessageSenderLabel).To (item => item.Sender); 
                set.Bind (MessageTimestampLabel).To (item => item.DateTime);
                set.Apply();
            });
        }

        public static MessageCell Create()
        {
            return (MessageCell)Nib.Instantiate(null, null)[0];
        }
    }
}

