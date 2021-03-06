﻿using FreshMvvm;
using Xamarin.Forms;

namespace FormsLeakTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

			var page = FreshPageModelResolver.ResolvePageModel<BasicPageModel>();



			var basicNavContainer = new FreshNavigationContainer(page);
			MainPage = basicNavContainer;

			MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
