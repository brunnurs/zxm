using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Webkit;

namespace Zxm.Android.Views
{
    public class BindableWebView : WebView
    {
        private string _bindableUrl;

        protected BindableWebView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public BindableWebView(Context context)
            : base(context)
        {
        }

        public BindableWebView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public BindableWebView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }

        public BindableWebView(Context context, IAttributeSet attrs, int defStyle, bool privateBrowsing)
            : base(context, attrs, defStyle, privateBrowsing)
        {
        }

        public string BindableUrl
        {
            get { return _bindableUrl; }
            set
            {
                _bindableUrl = value;
                LoadUrl(_bindableUrl);
            }
        }
    }
}