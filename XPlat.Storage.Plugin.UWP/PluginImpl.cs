using System;
using System.Threading.Tasks;
using WinStorage = Windows.Storage;

//register the plugin impl with Xamarin's IoC framework
[assembly: Xamarin.Forms.Dependency(typeof(XPlat.Storage.Plugin.UWP.PluginImpl))]

//register the FileOpenPicker
[assembly: Xamarin.Forms.Dependency(typeof(XPlat.Storage.Pickers.FileOpenPicker))]

[assembly: Xamarin.Forms.Dependency(typeof(XPlat.Storage.ApplicationData))]

namespace XPlat.Storage.Plugin.UWP
{
    public class PluginImpl : XPlat.Storage.Portable.IStoragePlugin
    {
        public IStorageFolder VideoStorageFolder => vid.Value;

        public IStorageFolder LocalAppData => data.Value;

        public IStorageFolder CurrentDirectory => current.Value;

        public IStorageFolder Documents => docs.Value;

        public Task<IStorageFile> GetFileFromPathAsync(string path)
        {
            return XPlat.Storage.StorageFile.GetFileFromPathAsync(path);
        }

        public async Task<IStorageFolder> GetFolderFromPath(string path)
        {
            XPlat.Storage.StorageFolder folder = await WinStorage.StorageFolder.GetFolderFromPathAsync(path).AsTask().ConfigureAwait(false);

            return folder;
        }

        private static readonly Lazy<XPlat.Storage.StorageFolder> docs =
            new Lazy<XPlat.Storage.StorageFolder>(() => WinStorage.KnownFolders.DocumentsLibrary, System.Threading.LazyThreadSafetyMode.PublicationOnly);


        private static readonly Lazy<XPlat.Storage.StorageFolder> vid =
            new Lazy<XPlat.Storage.StorageFolder>(() => WinStorage.KnownFolders.VideosLibrary, System.Threading.LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<XPlat.Storage.StorageFolder> data =
            new Lazy<XPlat.Storage.StorageFolder>(() =>
            {
                return Windows.Storage.ApplicationData.Current.LocalFolder;
            }
            , System.Threading.LazyThreadSafetyMode.PublicationOnly);

        private static readonly Lazy<XPlat.Storage.StorageFolder> current =
            new Lazy<XPlat.Storage.StorageFolder>(() =>
            {
                return WinStorage.StorageFolder.GetFolderFromPathAsync(System.Environment.CurrentDirectory)
                                .AsTask()
                                .GetAwaiter()
                                .GetResult();
            }
            , System.Threading.LazyThreadSafetyMode.PublicationOnly);
    }
}
