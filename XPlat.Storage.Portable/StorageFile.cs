using System;
using System.Collections.Generic;
using System.Text;

namespace XPlat.Storage.Portable
{
    /// <summary>
    /// privdes portable static APIs found on XPLat.Storage.IStorageFile platform types
    /// </summary>
    public static class StorageFile
    {
        public static System.Threading.Tasks.Task<XPlat.Storage.IStorageFile> GetFileFromPathAsync(string path)
        {
            return Xamarin.Forms.DependencyService.Get<IStoragePlugin>()
                     .GetFileFromPathAsync(path);

        }

        //public static System.Threading.Tasks.Task InitializeKnownFoldersAsync()
        //{
        //    return Xamarin.Forms.DependencyService.Get<XStreamer.Services.IFileOpener>()
        //            .InitializeKnownFoldersAsync();
        //}

        public static XPlat.Storage.IStorageFolder VideoStorageFolder
        { get { return Xamarin.Forms.DependencyService.Get<IStoragePlugin>().VideoStorageFolder; } }
    }
}
