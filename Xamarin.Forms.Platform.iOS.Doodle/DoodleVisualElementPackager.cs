using System;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.iOS.Doodle
{
    public class DoodleVisualElementPackager : IDisposable
    {
        private VisualElement _element;
        private IElementController ElementController => _element;

        public DoodleVisualElementPackager(VisualElement element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            _element = element;
        }

        public void Load()
        {
            for (var i = 0; i < ElementController.LogicalChildren.Count; i++)
            {
                var child = ElementController.LogicalChildren[i] as VisualElement;
                if (child != null)
                    OnChildAdded(child);
            }
        }

        public void Redraw(SkiaSharp.SKSurface surface)
        {
            for (var i = 0; i < ElementController.LogicalChildren.Count; i++)
            {
                var child = ElementController.LogicalChildren[i] as VisualElement;
                if (child != null)
                {
                    OnChildRedraw(child, surface);

                    // update logical children
                    var viewRenderer = DoodlePlatform.GetDoodleRenderer(child);
                    viewRenderer.Packager.Redraw(surface);
                }
            }
        }

        protected virtual void OnChildAdded(VisualElement view)
        {
            var viewRenderer = DoodlePlatform.CreateDoodleRenderer(view);
            DoodlePlatform.SetDoodleRenderer(view, viewRenderer);
        }

        protected virtual void OnChildRedraw(VisualElement view, SkiaSharp.SKSurface surface)
        {
            var viewRenderer = DoodlePlatform.GetDoodleRenderer(view);
            viewRenderer.DrawView(surface);
        }

        public void Dispose()
        {

        }
    }
}