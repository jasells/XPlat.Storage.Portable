using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XPlat.Storage.Portable
{
    internal static class Extensions
    {
        public static XPlat.Storage.Pickers.IFileOpenPicker CreatePicker(this IEnumerable<string> filters)
        {
            var picker = FileOpenPicker.NewInstance;

            foreach (var f in filters)
                picker.FileTypeFilter.Add(f);

            return picker;
        }

        public static Task<XPlat.Storage.IStorageFile> GetFileFromPathAsync(this string path)
                        =>  XPlat.Storage.Portable.StorageFile.GetFileFromPathAsync(path);

        public static Task<XPlat.Storage.IStorageFolder> GetFolderFromPatAsync(this string path)
                        =>  XPlat.Storage.Portable.StorageFolder.GetFolderFromPathAsync(path);
    }
}
