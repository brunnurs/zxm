using Cirrious.MvvmCross.ViewModels;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Zxm.Core.ViewModels;

namespace Zxm.iOS.Views
{
    public sealed class TabBarController
        : MvxTabBarViewController        
    {
		public TabBarController()
        {
			// because the UIKit base class does ViewDidLoad, we have to make a second call here
			ViewDidLoad();
		}

		public new HomeViewModel ViewModel {
			get { return (HomeViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// first time around this will be null, second time it will be OK
			if (ViewModel == null)
				return;

			var viewControllers = new UIViewController[]
			{
				//TODO: use here the right ViewModel (watch the screencast about tables)
				CreateTabFor("Users", "settings", ViewModel.SettingsViewModel),
				CreateTabFor("Settings", "settings", ViewModel.SettingsViewModel),
				CreateTabFor("Messages", "messages", ViewModel.MessagesViewModel),
			};
			ViewControllers = viewControllers;

			CustomizableViewControllers = new UIViewController[] { };
			SelectedViewController = ViewControllers[0];
		}




		private int _createdSoFarCount = 0;

        private UIViewController CreateTabFor(string title, string imageName, IMvxViewModel viewModel)
        {
            var controller = new UINavigationController();
            controller.NavigationBar.TintColor = UIColor.Black;
            var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
            SetTitleAndTabBarItem(screen, title, imageName);
            controller.PushViewController(screen, false);
            return controller;
        }

        private void SetTitleAndTabBarItem(UIViewController screen, string title, string imageName)
        {
			screen.Title = title;
            screen.TabBarItem = new UITabBarItem(title, UIImage.FromBundle("Images/Tabs/" + imageName + ".png"),
                                                 _createdSoFarCount);
            _createdSoFarCount++;
        }



        public bool GoBack()
        {
            var subNavigation = this.SelectedViewController as UINavigationController;
            if (subNavigation == null)
                return false;

            if (subNavigation.ViewControllers.Length <= 1)
                return false;

            subNavigation.PopViewControllerAnimated(true);
            return true;
        }

        public bool ShowView(IMvxTouchView view)
        {
            if (TryShowViewInCurrentTab(view))
                return true;

            return false;
        }

        private bool TryShowViewInCurrentTab(IMvxTouchView view)
        {
            var navigationController = (UINavigationController)this.SelectedViewController;
            navigationController.PushViewController((UIViewController)view, true);
            return true;
        }
    }
}