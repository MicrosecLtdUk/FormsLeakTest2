// <copyright file="BasicPageModel.cs" company = "Thinking Software">
// Copyright Thinking Software
// </copyright>

using System;
using System.Windows.Input;
using FreshMvvm;

using Xamarin.Forms;

namespace FormsLeakTest
{
	public class BasicPageModel : FreshBasePageModel
	{


		public BasicPageModel()
		{
		}

		private ICommand _GoCommand;
		public ICommand GoCommand
		{
			get
			{
				if (_GoCommand == null)
				{
					_GoCommand = new Command(() => this.Go());

				}
				return _GoCommand;
			}
		}
		private void Go()
		{
			CoreMethods.PushPageModel<Basic2PageModel>();
		}


	}
}
