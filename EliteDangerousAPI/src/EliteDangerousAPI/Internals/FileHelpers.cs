using System;
using System.IO;
using System.Runtime.InteropServices;

namespace NSW.EliteDangerous.Internals
{
    internal class FileHelpers
    {
        private const string ElitePath = @"Frontier Developments\Elite Dangerous";
        private static readonly Guid SaveGamesFolder = new Guid("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4");
        
        [DllImport("Shell32.dll")]
        public static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr ppszPath);

        public static string GetJournalDirectory()
        {
            int result = SHGetKnownFolderPath(SaveGamesFolder, 0, new IntPtr(0), out IntPtr path);
            if (result >= 0)
            {
                try { return Path.Combine(Marshal.PtrToStringUni(path), ElitePath); }
                catch { }
            }

            return Environment.CurrentDirectory;
        }

        public static T ReadJsonFile<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    using (var reader = File.OpenRead(filePath))
                    {
                        return JsonHelper.FromJson<T>(reader);
                    }
                }
                catch
                {

                }
            }

            return default;
        }
    }
}
