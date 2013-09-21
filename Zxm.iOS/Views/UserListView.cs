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
        UIBarButtonItem refreshButton;

        UITableView tableView;

		public UserListView () : base ("UserListView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            CreateUI();

			var source = new MvxSimpleTableViewSource(tableView, UserCell.Key, UserCell.Key);
			tableView.Source = source;

			var set = this.CreateBindingSet<UserListView,UserListViewModel> ();
			set.Bind (source).To (vm => vm.Users);
			set.Bind (refreshButton).To (vm => vm.LoadUsersCommand);

            set.Bind (source).For(s => s.SelectionChangedCommand).To(vm => vm.ShowUserDetailsCommand);

			set.Apply ();

		}

        void CreateUI()
        {
            refreshButton = new UIBarButtonItem(UIBarButtonSystemItem.Refresh);
            NavigationItem.RightBarButtonItem = refreshButton;

            tableView = new UITableView(new RectangleF(0, 0, 320, ViewSettings.REMAINING_VIEW_HEIGHT), UITableViewStyle.Plain);
            tableView.RowHeight = 100;
            Add(tableView);
        }
	}
}

