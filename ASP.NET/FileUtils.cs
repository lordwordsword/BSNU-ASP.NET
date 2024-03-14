
using System.Text;

public static class FileUtils
    {
    public static void GenerateFile(MemoryStream ms, string str)
    {
        using (StreamWriter writer = new StreamWriter(ms, Encoding.UTF8, 1024, true))
        {
            writer.WriteLine(str);
            writer.Flush(); 
        }
    }
    public static string RemoveInvalidFileNameChars(string fileName)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            foreach (char invalidChar in invalidChars)
            {
                fileName = fileName.Replace(invalidChar.ToString(), "");
            }

            return fileName;
        }
}

