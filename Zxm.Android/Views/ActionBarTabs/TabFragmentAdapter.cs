using System;
using System.Collections.Generic;
using Android.Runtime;
using Android.Support.V4.App;

namespace Zxm.Android.Views.ActionBarTabs
{
    public class TabFragmentAdapter : FragmentStatePagerAdapter
    {
        private readonly List<Fragment> _fragments = new List<Fragment>();
        private readonly List<string> _fragmentTitles = new List<string>();

        public TabFragmentAdapter(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public void AddFragment(Fragment fragment, string title)
        {
            _fragments.Add(fragment);
            _fragmentTitles.Add(title);
        }

        public TabFragmentAdapter(FragmentManager fragmentManager)
            : base(fragmentManager)
        {
        }

        public override int Count
        {
            get { return _fragments.Count; }
        }

        public override Fragment GetItem(int index)
        {
            return _fragments[index];
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int index)
        {
            return new Java.Lang.String(_fragmentTitles[index]);
        }
    }
}