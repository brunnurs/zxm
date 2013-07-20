using System;

namespace Zxm.Android.Views.ActionBarTabs
{
    public class TabFragmentDescription
    {
        public TabFragmentDescription(string tabSpecName, int titleResourceId, Type fragmentType, Type viewModelType)
        {
            TabSpecName = tabSpecName;
            FragmentType = fragmentType;
            ViewModelType = viewModelType;
            TitleResourceId = titleResourceId;
        }

        public int? MenueResourceId { get; set; }
        public int TitleResourceId { get; private set; }
        public string TabSpecName { get; private set; }
        public Type ViewModelType { get; private set; }
        public Type FragmentType { get; private set; }
    }
}