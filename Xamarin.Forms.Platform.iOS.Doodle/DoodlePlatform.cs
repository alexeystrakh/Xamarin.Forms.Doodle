using System;
using UIKit;
using RectangleF = CoreGraphics.CGRect;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.iOS.Doodle
{
    public class DoodlePlatform
    {
        internal static readonly BindableProperty RendererProperty = BindableProperty.CreateAttached("Renderer", typeof(IVisualElementRenderer), typeof(DoodlePlatform), default(IVisualElementRenderer),
           propertyChanged: (bindable, oldvalue, newvalue) =>
           {
               var view = bindable as VisualElement;
               if (view != null)
                   view.IsPlatformEnabled = newvalue != null;
           });

        internal static readonly BindableProperty DoodleRendererProperty = BindableProperty.CreateAttached("DoodleRenderer", typeof(IDoodleElementRenderer), typeof(DoodlePlatform), default(IDoodleElementRenderer),
           propertyChanged: (bindable, oldvalue, newvalue) =>
           {
               var view = bindable as VisualElement;
               if (view != null)
                   view.IsPlatformEnabled = newvalue != null;
           });

        public Page Page { get; private set; }

        public DoodlePlatformRenderer Renderer { get; }

        public UIViewController ViewController => Renderer;

        public DoodlePlatform()
        {
            Renderer = new DoodlePlatformRenderer(this);
        }

        public static IVisualElementRenderer CreateRenderer(VisualElement element)
        {
            var renderer = Internals.Registrar.Registered.GetHandlerForObject<IVisualElementRenderer>(element);
            renderer.SetElement(element);
            return renderer;
        }

        public static IVisualElementRenderer GetRenderer(VisualElement bindable)
        {
            return (IVisualElementRenderer)bindable.GetValue(RendererProperty);
        }

        public static void SetRenderer(VisualElement bindable, IVisualElementRenderer value)
        {
            bindable.SetValue(RendererProperty, value);
        }

        public static IDoodleElementRenderer CreateDoodleRenderer(VisualElement element)
        {
            var renderer = Internals.Registrar.Registered.GetHandlerForObject<IDoodleElementRenderer>(element);
            renderer.SetElement(element);
            return renderer;
        }

        public static IDoodleElementRenderer GetDoodleRenderer(VisualElement bindable)
        {
            return (IDoodleElementRenderer)bindable.GetValue(DoodleRendererProperty);
        }

        public static void SetDoodleRenderer(VisualElement bindable, IDoodleElementRenderer value)
        {
            bindable.SetValue(DoodleRendererProperty, value);
        }

        public void SetPage(Page newRoot)
        {
            if (newRoot == null)
                return;
            
            if (Page != null)
                throw new NotImplementedException();
            
            Page = newRoot;
            AddChild(Page);
        }


        private void AddChild(VisualElement view)
        {
            if (!Application.IsApplicationOrNull(view.RealParent))
                Console.Error.WriteLine("Tried to add parented view to canvas directly");

            if (GetRenderer(view) == null)
            {
                var viewRenderer = CreateRenderer(view);
                SetRenderer(view, viewRenderer);

                Renderer.View.AddSubview(viewRenderer.NativeView);
                if (viewRenderer.ViewController != null)
                    Renderer.AddChildViewController(viewRenderer.ViewController);
                viewRenderer.NativeView.Frame = new RectangleF(0, 0, Renderer.View.Bounds.Width, Renderer.View.Bounds.Height);
                viewRenderer.SetElementSize(new Size(Renderer.View.Bounds.Width, Renderer.View.Bounds.Height));
            }
            else
            {
                Console.Error.WriteLine("Potential view double add");
            }
        }
    }
}