using System;
using System.IO;
using System.Text;

namespace WordCountProgram.Logic
{
    /// <summary>Читает и валидирует .txt ≤ 1 МБ.</summary>
    public static class FileHandler
    {
        private const int MaxSize = 1 * 1024 * 1024;   // 1 МБ

        public static bool ValidateFileType(string path) =>
            Path.GetExtension(path).Equals(".txt", StringComparison.OrdinalIgnoreCase);

        public static bool ValidateFileSize(string path) =>
            new FileInfo(path).Length <= MaxSize;

        public static string LoadText(string path)
        {
            if (!ValidateFileType(path))
                throw new InvalidOperationException("Поддерживаются только файлы .txt");

            if (!ValidateFileSize(path))
                throw new InvalidOperationException("Файл слишком большой (лимит 1 МБ)");

            return File.ReadAllText(path, Encoding.UTF8);
        }
    }
}
