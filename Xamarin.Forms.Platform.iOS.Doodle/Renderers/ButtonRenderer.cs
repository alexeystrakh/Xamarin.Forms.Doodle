using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;
using SkiaSharp;
using SkiaSharp.Views.iOS;
using UIKit;

namespace Xamarin.Forms.Platform.iOS.Skia.Renderers
{
    public class ButtonRenderer : ViewRenderer<Button, SKCanvasView>
    {
		public ButtonRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    SetNativeControl(CreateNativeControl());

                    Debug.Assert(Control != null, "Control != null");

                    this.Control.PaintSurface += _skiaView_PaintSurface;
                    this.Control.Frame = new CoreGraphics.CGRect(0, 0, 200, 100);
                }
            }

            // TODO: unsubscribe
        }

        protected override SKCanvasView CreateNativeControl()
        {
            return new SKCanvasView();
        }

        private void _skiaView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;

			canvas.Clear(SKColors.Beige);
        }
    }
}
