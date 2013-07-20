using System;
using Android.Content;
using Android.Support.V4.App;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.ViewModels;

namespace Zxm.Android.Views.ActionBarTabs
{
    public static class TabFragmentFactory
    {
        public static Fragment CreateFragment(Context context, TabFragmentDescription tabFragmentDescription)
        {
            var fragment = Fragment.Instantiate(context, FragmentJavaName(tabFragmentDescription.FragmentType));
            FixupDataContext(fragment, tabFragmentDescription.ViewModelType);
            return fragment;
        }

        private static void FixupDataContext(Fragment fragment, Type viewModelType)
        {
            var mvxDataConsumer = fragment as IMvxDataConsumer;
            if (mvxDataConsumer == null)
            {
                return;
            }

            var loaderService = Mvx.Resolve<IMvxViewModelLoader>();
            var vm = loaderService.LoadViewModel(new MvxViewModelRequest(viewModelType, null, null, null), null);
            mvxDataConsumer.DataContext = vm;
        }

        private static string FragmentJavaName(Type fragmentType)
        {
            string str = fragmentType.Namespace ?? "";
            if (str.Length > 0)
            {
                str = str.ToLowerInvariant() + ".";
            }
            return str + fragmentType.Name;
        }
    }
}