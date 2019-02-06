using System;
using System.Threading.Tasks;

//register the plugin impl with Xamarin's IoC framework
[assembly: Xamarin.Forms.Dependency(typeof(XPlat.Storage.Plugin.Droid.PluginImpl))]

//register the FileOpenPicker
[assembly: Xamarin.Forms.Dependency(typeof(XPlat.Storage.Pickers.FileOpenPicker))]

[assembly: Xamarin.Forms.Dependency(typeof(XPlat.Storage.ApplicationData))]

namespace XPlat.Storage.Plugin.Droid
{
    public class PluginImpl : XPlat.Storage.Portable.IStoragePlugin
    {
        public IStorageFolder VideoStorageFolder => vid.Value;

        public IStorageFolder LocalAppData => data.Value;

        public IStorageFolder CurrentDirectory => current.Value;

        public Task<IStorageFile> GetFileFromPathAsync(string path) => XPlat.Storage.StorageFile.GetFileFromPathAsync(path);

        public async Task<IStorageFolder> GetFolderFromPath(string path)
        {
            return await StorageFolder.GetFolderFromPathAsync(path).ConfigureAwait(false);
        }

        private static readonly Lazy<XPlat.Storage.IStorageFolder> vid =
            new Lazy<XPlat.Storage.IStorageFolder>(() => XPlat.Storage.KnownFolders.VideosLibrary, System.Threading.LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<XPlat.Storage.IStorageFolder> data =
            new Lazy<XPlat.Storage.IStorageFolder>(() =>
            {
                var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
                return StorageFolder.GetFolderFromPathAsync(path).GetAwaiter().GetResult();
            }
            , System.Threading.LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<XPlat.Storage.IStorageFolder> current =
            new Lazy<XPlat.Storage.IStorageFolder>(() =>
            {
                return StorageFolder.GetFolderFromPathAsync(System.Environment.CurrentDirectory)
                                .GetAwaiter()
                                .GetResult();
            }
            , System.Threading.LazyThreadSafetyMode.PublicationOnly);
    }
}