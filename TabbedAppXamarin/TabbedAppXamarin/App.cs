﻿using TabbedAppXamarin.Services.Entities;
using TabbedAppXamarin.Views;
using Xamarin.Forms;

namespace TabbedAppXamarin
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            DependencyService.Register<EntityService>();
            MainPage = new MainPage();
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
