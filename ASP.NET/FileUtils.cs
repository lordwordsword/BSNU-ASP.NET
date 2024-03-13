
using System.Text;

public static class FileUtils
    {
    public static void GenerateFile(MemoryStream ms, string str)
    {
        using (StreamWriter writer = new StreamWriter(ms, Encoding.UTF8, 1024, true))
        {
            writer.WriteLine(str);
            writer.Flush(); // Очистить буфер и записать данные в поток
        }
    }
    public static string RemoveInvalidFileNameChars(string fileName)
        {
            // Получаем массив недопустимых символов в названии файла
            char[] invalidChars = Path.GetInvalidFileNameChars();

            // Удаляем все недопустимые символы из названия файла
            foreach (char invalidChar in invalidChars)
            {
                fileName = fileName.Replace(invalidChar.ToString(), "");
            }

            return fileName;
        }
}

