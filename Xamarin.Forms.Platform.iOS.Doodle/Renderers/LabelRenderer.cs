using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;
using SkiaSharp;
using SkiaSharp.Views.iOS;
using UIKit;

namespace Xamarin.Forms.Platform.iOS.Doodle.Renderers
{
    public class LabelRenderer : DoodleViewRenderer<Label>
    {
        public LabelRenderer()
        {
            
        }

        public override void DrawView(SKSurface surface)
        {
            var canvas = surface.Canvas;
            canvas.DrawText(Element.Text, 80, 180, new SKPaint
            {
                Color = SKColors.Black,
                TextSize = 36,
                IsAntialias = true
            });
        }
    }
}
