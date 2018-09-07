using System;
using System.Collections.Generic;
using System.Text;

namespace XPlat.Storage.Portable
{

    public static class StorageFolder
    {
        public static System.Threading.Tasks.Task<XPlat.Storage.IStorageFolder> GetFolderFromPathAsync(string path)
        {
            return Xamarin.Forms.DependencyService.Get<IStoragePlugin>()
                        .GetFolderFromPath(path);
        }
    }
}
