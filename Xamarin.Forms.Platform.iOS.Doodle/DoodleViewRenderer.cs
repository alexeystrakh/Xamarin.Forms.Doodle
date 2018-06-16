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
        public DoodleVisualElementPackager Packager { get; private set; }

        protected TView Element { get; set; }

        public abstract void DrawView(SKSurface canvas);

        public virtual void Touch()
        {
            //do nothing by default
        }

        public void SetElement(VisualElement element)
        {
            Element = (TView)element;

            if (Packager == null)
            {
                Packager = new DoodleVisualElementPackager(element);
                Packager.Load();
            }
        }
    }
}