using System;
using System.ComponentModel;
using System.Globalization;
using CoreSpotlight;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS.Skia;

namespace Xamarin.Forms.Platform.iOS.Skia
{
    public class FormsApplicationDelegate : UIApplicationDelegate
    {
        private Application _application;
        private bool _isSuspended;

        public override UIWindow Window { get; set; }

		public FormsApplicationDelegate()
        {
        }

        public override bool ContinueUserActivity(UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
        {
            CheckForAppLink(userActivity);
            return true;
        }

        public override void DidEnterBackground(UIApplication uiApplication)
        {
        }

        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            if (Window == null)
                Window = new UIWindow(UIScreen.MainScreen.Bounds);

            if (_application == null)
                throw new InvalidOperationException("You MUST invoke LoadApplication () before calling base.FinishedLaunching ()");

            SetMainPage();
            _application.SendStart();
            return true;
        }

        public override void OnActivated(UIApplication uiApplication)
        {
            if (_application != null && _isSuspended)
            {
                _isSuspended = false;
                CultureInfo.CurrentCulture.ClearCachedData();
                TimeZoneInfo.ClearCachedData();
                _application.SendResume();
            }
        }

        public override void OnResignActivation(UIApplication uiApplication)
        {
            if (_application != null)
            {
                _isSuspended = true;
                _application.SendSleep();
            }
        }

        public override void UserActivityUpdated(UIApplication application, NSUserActivity userActivity)
        {
            CheckForAppLink(userActivity);
        }

        public override void WillEnterForeground(UIApplication uiApplication)
        {
        }

        public override bool WillFinishLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            return true;
        }

        public override void WillTerminate(UIApplication uiApplication)
        {
           //_application.SendTerminate ();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _application != null)
                _application.PropertyChanged -= ApplicationOnPropertyChanged;

            base.Dispose(disposing);
        }

        protected void LoadApplication(Application application)
        {
            if (application == null)
                throw new ArgumentNullException("application");
            
            Application.SetCurrentApplication(application);
            _application = application;

            //TODO: (application as IApplicationController)?.SetAppIndexingProvider(new IOSAppIndexingProvider());
            application.PropertyChanged += ApplicationOnPropertyChanged;
        }

        private void ApplicationOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "MainPage")
                UpdateMainPage();
        }

        private void CheckForAppLink(NSUserActivity userActivity)
        {
            var strLink = string.Empty;

            switch (userActivity.ActivityType)
            {
                case "NSUserActivityTypeBrowsingWeb":
                    strLink = userActivity.WebPageUrl.AbsoluteString;
                    break;
                case "com.apple.corespotlightitem":
                    if (userActivity.UserInfo.ContainsKey(CSSearchableItem.ActivityIdentifier))
                        strLink = userActivity.UserInfo.ObjectForKey(CSSearchableItem.ActivityIdentifier).ToString();
                    break;
                default:
                    if (userActivity.UserInfo.ContainsKey(new NSString("link")))
                        strLink = userActivity.UserInfo[new NSString("link")].ToString();
                    break;
            }

            if (!string.IsNullOrEmpty(strLink))
                _application.SendOnAppLinkRequestReceived(new Uri(strLink));
        }

        private void SetMainPage()
        {
            UpdateMainPage();
            Window.MakeKeyAndVisible();
        }

        private void UpdateMainPage()
        {
            if (_application.MainPage == null)
                return;
            
            var platformRenderer = Window.RootViewController as PlatformRenderer;
            if (platformRenderer != null)
                ((IDisposable)platformRenderer.Platform).Dispose();

			Window.RootViewController = _application.MainPage.CreateViewController();
        }
    }
}
