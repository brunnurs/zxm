using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Zxm.iOS.Views;
using Cirrious.MvvmCross.Touch.Views;

namespace Zxm.iOS
{
	public class TabsWithNavigationControllerPresenter :MvxTouchViewPresenter
	{
		ZxmTabBarController tabBarController;

		public TabsWithNavigationControllerPresenter(UIApplicationDelegate applicationDelegate, UIWindow window)
			: base(applicationDelegate, window) 
		{
		}

		protected override UINavigationController CreateNavigationController (UIViewController viewController)
		{
			var navBar = base.CreateNavigationController (viewController);
			navBar.NavigationBarHidden = true;

			return navBar;
		}

		public override void Show(IMvxTouchView view)
		{
			if (view is ZxmTabBarController)
			{
				tabBarController = view as ZxmTabBarController;
			}
			else if (tabBarController != null && ViewIsChildLevelView(view))
			{
				tabBarController.ShowGrandChild(view);
				return;
			}

			base.Show(view);
		}

		private bool ViewIsChildLevelView(IMvxTouchView view)
		{
			return !tabBarController.ViewControllers.Contains<UIViewController>(view as UIViewController);
		}

	}
}
