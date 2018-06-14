using UIKit;
using SkiaSharp;
using SkiaSharp.Views.iOS;

namespace Xamarin.Forms.Platform.iOS.Doodle
{
    public class DoodlePlatformRenderer : UIViewController
    {
        public DoodlePlatform Platform { get; }

        public DoodlePlatformRenderer(DoodlePlatform platform)
        {
            Platform = platform;
        }
    }
}