using System;
using System.Collections.Generic;
using System.Text;

namespace XPlat.Storage.Portable
{
    public static class FileOpenPicker
    {
        public static XPlat.Storage.Pickers.IFileOpenPicker NewInstance => Xamarin.Forms.DependencyService.Get<XPlat.Storage.Pickers.IFileOpenPicker>(Xamarin.Forms.DependencyFetchTarget.NewInstance);

        public static Pickers.IFileOpenPicker GetPickerWithFilters(IEnumerable<string> filters)
        {
            var p = NewInstance;

            foreach (var f in filters)
                p.FileTypeFilter.Add(f);

            return p;
        }
    }
}
