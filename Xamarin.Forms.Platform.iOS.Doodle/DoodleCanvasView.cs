using UIKit;
using SkiaSharp;
using SkiaSharp.Views.iOS;
using Foundation;

namespace Xamarin.Forms.Platform.iOS.Doodle
{
    public class DoodleCanvasView : SKCanvasView
    {
        private PageRenderer _renderer;

        public DoodleCanvasView(PageRenderer renderer)
        {
            _renderer = renderer;
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            System.Diagnostics.Debug.WriteLine($"DoodleCanvasView.TouchesBegan: {touches.DebugDescription} | {evt.DebugDescription}");
            base.TouchesBegan(touches, evt);

            _renderer.Packager.Touch(_renderer.Element);

            this.SetNeedsDisplay();
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            System.Diagnostics.Debug.WriteLine($"DoodleCanvasView.TouchesEnded: {touches.DebugDescription} | {evt.DebugDescription}");
            base.TouchesEnded(touches, evt);
        }

        public override void DrawInSurface(SKSurface surface, SKImageInfo info)
        {
            base.DrawInSurface(surface, info);

            System.Diagnostics.Debug.WriteLine($"DoodleCanvasView.DrawInSurface...");

            var canvas = surface.Canvas;

            canvas.Clear(SKColors.Beige);
            canvas.DrawText("Skia Platform Page", 200, 100, new SKPaint
            {
                Color = SKColors.BlueViolet,
                TextSize = 36,
                IsAntialias = true
            });

            _renderer.Packager.Redraw(surface);
        }
    }
}