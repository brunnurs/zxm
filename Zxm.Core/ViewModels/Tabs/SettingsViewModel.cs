﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.ViewModels;

namespace Zxm.Core.ViewModels.Tabs
{
    public class SettingsViewModel : MvxViewModel
    {
		private string userName;

		public string UserName 
		{
			get { return userName; }
			set 
			{
				userName = value;
				RaisePropertyChanged (() => UserName);
			}
		}
    }
}
