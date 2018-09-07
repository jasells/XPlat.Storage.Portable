using System;
using System.Collections.Generic;
using System.Text;

namespace XPlat.Storage.Portable
{
    public static class KnownFolders
    {
        public static IStorageFolder CurrentDirectory { get { return Xamarin.Forms.DependencyService.Get<IStoragePlugin>().CurrentDirectory; } }
        public static IStorageFolder LocalAppData { get { return ApplicationData.Instance.LocalFolder; } }
        public static IStorageFolder VideosLibrary { get { return Xamarin.Forms.DependencyService.Get<IStoragePlugin>().VideoStorageFolder; } }
    }
}
