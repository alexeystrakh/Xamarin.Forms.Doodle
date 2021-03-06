﻿using System;
using UIKit;

namespace Xamarin.Forms
{
    public static class PageExtensions
    {
        public static UIViewController CreateViewController(this Page page)
        {
            if (!Forms.IsInitialized)
                throw new InvalidOperationException("call Forms.Init() before this");

            if (!(page.RealParent is Application))
            {
                Application app = new DefaultApplication();
                app.MainPage = page;
            }

            var result = new Platform.iOS.Doodle.DoodlePlatform();
            //var result = new Platform.iOS.Doodle.Platform();
            result.SetPage(page);
            return result.ViewController;
        }

        class DefaultApplication : Application
        {
        }
    }
}

namespace Xamarin.Forms.Platform.iOS.Doodle
{
    public static class PageExtensions
    {
        public static UIViewController CreateViewController(this ContentPage page)
        {
            return PageExtensions.CreateViewController(page);
        }
    }
}