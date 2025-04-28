using System;
using System.IO;
using System.Text;

namespace WordCountProgram.Logic
{
    /// <summary>Читает .txt ≤ 1 МБ и проверяет ограничения.</summary>
    public static class FileHandler
    {
        private const int MaxSize = 1 * 1024 * 1024;   // 1 МБ

        public static string LoadText(string path)
        {
            if (!Path.GetExtension(path)
                     .Equals(".txt", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Поддерживаются только файлы .txt");

            if (new FileInfo(path).Length > MaxSize)
                throw new InvalidOperationException("Файл слишком большой (лимит 1 МБ)");

            return File.ReadAllText(path, Encoding.UTF8);
        }
    }
}
