using UIKit;

namespace Xamarin.Forms.Platform.iOS.Doodle
{
    public class DoodlePlatform
    {
        public DoodlePlatformRenderer Renderer { get; }

        public UIViewController ViewController => Renderer;

        public DoodlePlatform()
        {
            Renderer = new DoodlePlatformRenderer(this);
        }

        public void SetPage(Page page)
        {
            // TODO: load page elements
        }
    }
}