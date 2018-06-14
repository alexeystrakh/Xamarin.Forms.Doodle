using SkiaSharp;
using SkiaSharp.Views.iOS;

namespace Xamarin.Forms.Platform.iOS.Doodle
{
    public abstract class DoodleViewRenderer : DoodleViewRenderer<View>
    {
    }

    public abstract class DoodleViewRenderer<TView> : IDoodleElementRenderer
        where TView : VisualElement
    {
        protected TView Element { get; set; }

        public abstract void DrawView(SKSurface canvas);

        public void SetElement(VisualElement element)
        {
            Element = (TView)element;
        }
    }
}