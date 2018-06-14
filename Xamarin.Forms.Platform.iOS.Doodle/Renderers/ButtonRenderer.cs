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
    public class ButtonRenderer : DoodleViewRenderer<Button>
    {
        public ButtonRenderer()
        {
            
        }

        public override void DrawView(SKSurface surface)
        {
            var canvas = surface.Canvas;

            // Fill color for Group Style
            var GroupStyleFillColor = SKColors.Aqua;

            // New Group Style fill paint
            var GroupStyleFillPaint = new SKPaint()
            {
                Style = SKPaintStyle.Fill,
                Color = GroupStyleFillColor,
                BlendMode = SKBlendMode.SrcOver,
                IsAntialias = true
            };

            // Frame color for Group Style
            var GroupStyleFrameColor = SKColors.Black;

            // New Group Style frame paint
            var GroupStyleFramePaint = new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                Color = GroupStyleFrameColor,
                BlendMode = SKBlendMode.SrcOver,
                IsAntialias = true,
                StrokeWidth = 1f,
                StrokeMiter = 4f,
                StrokeJoin = SKStrokeJoin.Miter,
                StrokeCap = SKStrokeCap.Butt
            };

            //-----------------------------------------------------------------------------
            // Draw Group shape group
            // Fill color for Round Rectangle Style
            var RoundRectangleStyleFillColor = SKColors.Aqua;

            // New Round Rectangle Style fill paint
            var RoundRectangleStyleFillPaint = new SKPaint()
            {
                Style = SKPaintStyle.Fill,
                Color = RoundRectangleStyleFillColor,
                BlendMode = SKBlendMode.SrcOver,
                IsAntialias = true
            };

            // Frame color for Round Rectangle Style
            var RoundRectangleStyleFrameColor = SKColors.Black;

            // New Round Rectangle Style frame paint
            var RoundRectangleStyleFramePaint = new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                Color = RoundRectangleStyleFrameColor,
                BlendMode = SKBlendMode.SrcOver,
                IsAntialias = true,
                StrokeWidth = 1f,
                StrokeMiter = 4f,
                StrokeJoin = SKStrokeJoin.Miter,
                StrokeCap = SKStrokeCap.Butt
            };

            // Draw Round Rectangle shape
            canvas.DrawRoundRect(new SKRect(100, 300, 600, 200), 32f, 32f, RoundRectangleStyleFillPaint);
            canvas.DrawRoundRect(new SKRect(100, 300, 600, 200), 32f, 32f, RoundRectangleStyleFramePaint);

            // Fill color for Text Style
            var TextStyleFillColor = SKColors.Black;

            // New Text Style fill paint
            var TextStyleFillPaint = new SKPaint()
            {
                Style = SKPaintStyle.Fill,
                Color = TextStyleFillColor,
                BlendMode = SKBlendMode.SrcOver,
                IsAntialias = true,
                Typeface = SKTypeface.FromFamilyName("System", SKTypefaceStyle.Normal),
                TextSize = 36f,
                TextAlign = SKTextAlign.Center,
                IsVerticalText = false,
                TextScaleX = 1f,
                TextSkewX = 0f
            };

            // Draw Text shape
            canvas.DrawText(Element.Text, 340, 265, TextStyleFillPaint);
        }
    }
}
