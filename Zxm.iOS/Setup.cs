using MonoTouch.UIKit;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;

namespace Zxm.iOS
{
	public class Setup : MvxTouchSetup
	{
		MvxApplicationDelegate _applicationDelegate;
		UIWindow _window;

		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
		{
			this._applicationDelegate = applicationDelegate;
			this._window = window;
		}

		protected override IMvxApplication CreateApp ()
		{
			return new Core.App();
		}
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

		protected override IMvxTouchViewPresenter CreatePresenter ()
		{
			return new MyViewPresenter (_applicationDelegate, _window);
		}

		protected override void AddPluginsLoaders (Cirrious.CrossCore.Plugins.MvxLoaderPluginRegistry registry)
		{
			registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.DownloadCache.Touch.Plugin>();
			registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.File.Touch.Plugin>();

			base.AddPluginsLoaders(registry);
		}

	}

	public class MyViewPresenter :MvxTouchViewPresenter
	{
		public MyViewPresenter(UIApplicationDelegate applicationDelegate, UIWindow window)
		: base(applicationDelegate, window) 
		{
		}

		protected override UINavigationController CreateNavigationController (UIViewController viewController)
		{
			var navBar = base.CreateNavigationController (viewController);
			navBar.NavigationBarHidden = true;

			return navBar;
		}
	}
}