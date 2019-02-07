
using System;
using System.Collections.Generic;
using System.Text;

namespace XPlat.Storage.Portable
{
    /// <summary>
    /// provides a portable API for XPlat.Storage types
    /// </summary>
    public interface IStoragePlugin
    {
        /// <summary>
        /// returns the current user's Videos library directory
        /// </summary>
        IStorageFolder VideoStorageFolder { get; }

        /// <summary>
        /// on windows, returns current user's 'MyDocuments', other platforms: TBD
        /// </summary>
        IStorageFolder Documents { get; }

        //this can go away?  Use ApplicationData?
        /// <summary>
        /// returns the the current user's LocalAppData directory
        /// </summary>
        IStorageFolder LocalAppData { get; }

        /// <summary>
        /// Returns the current root directory that launched the process/app
        /// </summary>
        IStorageFolder CurrentDirectory { get; }

        System.Threading.Tasks.Task<XPlat.Storage.IStorageFile> GetFileFromPathAsync(string path);

        System.Threading.Tasks.Task<XPlat.Storage.IStorageFolder> GetFolderFromPath(string path);


    }
}
