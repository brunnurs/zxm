using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Zxm.Core.ViewModels.Tabs;
using Cirrious.MvvmCross.Binding.Touch.Views;

namespace Zxm.iOS
{
	public partial class MessagesView : MvxViewController
	{
		public MessagesView () : base ("MessagesView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var refreshButton = new UIBarButtonItem (UIBarButtonSystemItem.Refresh);
			var newMessageButton = new UIBarButtonItem (UIBarButtonSystemItem.Add);

			NavigationItem.RightBarButtonItems = new UIBarButtonItem[] {newMessageButton,refreshButton};


			var tableView = new UITableView (new RectangleF (0, 0, 320, 600), UITableViewStyle.Plain);
			tableView.RowHeight = 201;

			Add (tableView);


			var source = new MvxSimpleTableViewSource(tableView, MessageCell.Key, MessageCell.Key);
			tableView.Source = source;

			var set = this.CreateBindingSet<MessagesView,MessagesViewModel> ();
			set.Bind (source).To (vm => vm.Messages);
            set.Bind (refreshButton).To (vm => vm.LoadMessagesCommand);
			set.Bind (newMessageButton).To (vm => vm.ComposeMessageCommand);
			set.Apply ();
		}
	}
}

