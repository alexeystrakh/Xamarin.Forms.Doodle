using System;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.iOS.Doodle
{
    public class DoodleVisualElementPackager : IDisposable
    {
        private VisualElement _element;
        private PageRenderer _renderer;
        private IElementController ElementController => _element;

        public DoodleVisualElementPackager(PageRenderer renderer)
        {
            if (renderer == null)
                throw new ArgumentNullException(nameof(renderer));

            _renderer = renderer;
            _element = renderer.Element;
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
                    OnChildRedraw(child, surface);
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