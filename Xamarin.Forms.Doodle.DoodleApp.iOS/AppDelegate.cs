extern alias doodle;

using Foundation;
using UIKit;

namespace Xamarin.Forms.Doodle.DoodleApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : doodle::Xamarin.Forms.Platform.iOS.Doodle.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            doodle::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
