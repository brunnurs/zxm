using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Zxm.Core.ViewModels.Tabs;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace Zxm.iOS
{
	public partial class UserListView : MvxViewController
	{
		public UserListView () : base ("UserListView", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var refreshButton = new UIBarButtonItem (UIBarButtonSystemItem.Refresh);
			NavigationItem.RightBarButtonItem = refreshButton;


			var tableView = new UITableView (new RectangleF (0, 0, 320, 600), UITableViewStyle.Plain);
			tableView.RowHeight = 100;
			Add (tableView);

			var source = new MvxSimpleTableViewSource(tableView, UserCell.Key, UserCell.Key);
			tableView.Source = source;

			var set = this.CreateBindingSet<UserListView,UserListViewModel> ();
			set.Bind (source).To (vm => vm.Users);
			set.Bind (refreshButton).To (vm => vm.LoadUsersCommand);
            set.Bind (source).For(s => s.SelectionChangedCommand).To(vm => vm.ShowUserDetailsCommand);
			set.Apply ();

		}
	}
}

