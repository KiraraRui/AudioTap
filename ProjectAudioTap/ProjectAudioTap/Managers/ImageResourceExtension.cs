using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace ProjectAudioTap.Managers
{
    class ImageResourceExtension
    {
        public static ImageSource GetImageSource(string sourceName)
        {
            if (sourceName == null)
            {
                return null;
            }

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(sourceName, typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}
