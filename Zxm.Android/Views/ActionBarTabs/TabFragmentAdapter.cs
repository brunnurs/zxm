using System;
using System.Collections.Generic;
using Android.Runtime;
using Android.Support.V4.App;

namespace Zxm.Android.Views.ActionBarTabs
{
    public class TabFragmentAdapter : FragmentStatePagerAdapter
    {
        private readonly List<Fragment> _fragments = new List<Fragment>();

        public TabFragmentAdapter(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public void AddFragment(Fragment fragment)
        {
            _fragments.Add(fragment);
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
    }
}