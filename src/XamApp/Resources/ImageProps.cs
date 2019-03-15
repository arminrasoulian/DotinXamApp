using FFImageLoading.Forms;
using System;
using Xamarin.Forms;

namespace XamApp.Resources
{
    public static class ImageProps
    {
        public static readonly BindableProperty FileNameProperty = BindableProperty.CreateAttached(
            propertyName: "FileName",
            returnType: typeof(string),
            declaringType: typeof(View),
            defaultValue: null,
            propertyChanged: (sender, oldValue, newValue) =>
            {
                View view = (View)sender;

                if (newValue == null)
                {
                    view.IsVisible = false;

                    if (view is CachedImage)
                        ((CachedImage)view).Source = null;
                    if (view is ImageButton)
                        ((ImageButton)view).Source = null;

                    return;
                }
                else
                {
                    view.IsVisible = true;
                }

                string resource = $"XamApp.Resources.Images.{newValue}.jpg";

                if (view is CachedImage)
                    ((CachedImage)view).Source = new EmbeddedResourceImageSource(resource, typeof(ImageProps).Assembly);
                else if (view is ImageButton)
                    ((ImageButton)view).Source = ImageSource.FromResource(resource, typeof(ImageProps).Assembly);
                else
                    throw new NotSupportedException();
            });

        public static string GetFileName(BindableObject view)
        {
            return (string)view.GetValue(FileNameProperty);
        }

        public static void SetFileName(BindableObject view, string value)
        {
            view.SetValue(FileNameProperty, value);
        }
    }
}
