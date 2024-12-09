namespace MauiApp7Allnighter
{
    public static class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            return Path.Combine(FileSystem.AppDataDirectory, filename);  // Returns the path where the DB will be stored
        }
    }
}
