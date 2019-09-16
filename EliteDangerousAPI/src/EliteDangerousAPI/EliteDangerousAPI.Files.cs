using System;
using System.IO;
using System.Runtime.InteropServices;

namespace NSW.EliteDangerous
{
    public partial class EliteDangerousAPI
    {
        private const string ElitePath = @"Frontier Developments\Elite Dangerous";
        private static readonly Guid SaveGamesFolder = new Guid("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4");
        
        [DllImport("Shell32.dll")]
        private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr ppszPath);

        private static string DefaultJournalDirectory
        {
            get
            {
                int result = SHGetKnownFolderPath(SaveGamesFolder, 0, new IntPtr(0), out IntPtr path);
                if (result >= 0)
                {
                    try { return Path.Combine(Marshal.PtrToStringUni(path), ElitePath); }
                    catch { }
                }

                return Environment.CurrentDirectory;
            }
        }
    }
}