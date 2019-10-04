using System;
using System.IO;
using System.Runtime.InteropServices;

namespace NSW.EliteDangerous.API
{
    /// <summary>
    /// EliteDangerousAPI settings
    /// </summary>
    public class ApiOptions
    {
        #region DefaultJournalDirectory

        [DllImport("Shell32.dll")]
        private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr ppszPath);

        internal static string DefaultJournalDirectory
        {
            get
            {
                if (SHGetKnownFolderPath(new Guid("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4"), 0, new IntPtr(0), out var path) >= 0)
                {
                    try { return Path.Combine(Marshal.PtrToStringUni(path), @"Frontier Developments\Elite Dangerous"); }
                    catch { }
                }

                return Environment.CurrentDirectory;
            }
        }
        #endregion

        /// <summary>
        /// Automatically run API on creation.
        /// </summary>
        public bool AutoRun { get; set; }

        /// <summary>
        /// Elite Dangerous journal location path 
        /// </summary>
        public string JournalDirectory { get; set; } = DefaultJournalDirectory;

        /// <summary>
        /// Elite Dangerous API plugins location path 
        /// </summary>
        public string PluginsDirectory { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");

        /// <summary>
        /// Journal check interval
        /// </summary>
        public TimeSpan CheckInterval { get; set; } = TimeSpan.FromMilliseconds(10000);

        /// <summary>
        /// Enable <see cref="IEliteDangerousPlugin"/> support
        /// </summary>
        public bool UsePlugins { get; set; }
    }
}