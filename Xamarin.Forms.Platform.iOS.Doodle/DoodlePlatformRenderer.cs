using UIKit;
using SkiaSharp;
using SkiaSharp.Views.iOS;

namespace Xamarin.Forms.Platform.iOS.Doodle
{
    public class DoodlePlatformRenderer : UIViewController
    {
        private SKCanvasView _canvas;

        public DoodlePlatform Platform { get; }

        public DoodlePlatformRenderer(DoodlePlatform platform)
        {
            Platform = platform;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _canvas = new SKCanvasView();
            // TODO: apply constraints
            _canvas.Frame = this.View.Bounds;
            this.View.AddSubview(_canvas);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            _canvas.PaintSurface += _canvas_PaintSurface;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            _canvas.PaintSurface -= _canvas_PaintSurface;
        }

        private void _canvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;

            canvas.Clear(SKColors.Beige);
            canvas.DrawText("Basic Platform View", 209.6016f, 74.88281f, new SKPaint 
            { 
                Color = SKColors.Black, 
                TextSize = 36,
                IsAntialias = true 
            });
        }
    }
}