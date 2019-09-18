using System.IO;

namespace NSW.EliteDangerous.Events
{
    public static class TestHelpers
    {
        public static string TestFolder => Path.Combine(Directory.GetCurrentDirectory(), "files");
    }
}