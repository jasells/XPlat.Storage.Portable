using System;
using System.Collections.Generic;
using System.Text;

namespace XPlat.Storage.Portable
{
    public static class ApplicationData
    {
        public static XPlat.Storage.IApplicationData Instance => Xamarin.Forms.DependencyService.Get<IApplicationData>();
    }
}
