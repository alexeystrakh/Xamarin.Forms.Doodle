using SkiaSharp;
using SkiaSharp.Views.iOS;

namespace Xamarin.Forms.Platform.iOS.Doodle
{
    public interface IDoodleElementRenderer : IRegisterable
    {
        DoodleVisualElementPackager Packager { get; }

        void DrawView(SKSurface canvas);

        void SetElement(VisualElement element);
    }
}