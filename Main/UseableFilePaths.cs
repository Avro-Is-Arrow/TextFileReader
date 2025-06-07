static class UseableFilePaths
{
    public static string SupportedFilePaths(string[] filePaths)
    {
        string allFilePaths = "";

        foreach (string filePath in filePaths)
        {
            allFilePaths += $"[{filePath}] ";
        }

        return allFilePaths;
    }
    
    
}