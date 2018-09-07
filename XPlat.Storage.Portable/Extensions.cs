using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XPlat.Storage.Portable
{
    internal static class Extensions
    {
        public static XPlat.Storage.Pickers.IFileOpenPicker CreatePicker(this IEnumerable<string> filters)
        {
            var picker = Xamarin.Forms.DependencyService.Get<XPlat.Storage.Pickers.IFileOpenPicker>(Xamarin.Forms.DependencyFetchTarget.NewInstance);

            foreach (var f in filters)
                picker.FileTypeFilter.Add(f);

            return picker;
        }

        //public static XPlat.Storage.Pickers.IFileOpenPicker CreatePicker(this XPlat.Storage.Helpers.StorageHelper)
        //{
        //    return Services.XplatFactory.Create(filters);
        //}

        /// <summary>
        /// this is a band-aid since Xplat.storage seems broke on UWP...  the irony!
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        //public static Task<System.IO.Stream> OpenForReadAsync(this XPlat.Storage.IStorageFile file)
        //{
        //    return  Services.XplatFactory.OpenFileForRead(file);
        //}

        public static Task<XPlat.Storage.IStorageFile> GetFileFromPathAsync(this string path)
        {
            return XPlat.Storage.Portable.StorageFile.GetFileFromPathAsync(path);
        }

        public static Task<XPlat.Storage.IStorageFolder> GetFolderFromPatAsync(this string path)
        {
            return XPlat.Storage.Portable.StorageFolder.GetFolderFromPathAsync(path);
        }
    }
}
