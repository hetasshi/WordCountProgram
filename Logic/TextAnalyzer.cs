using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WordCountProgram.Logic
{
    /// <summary>
    /// Обрабатывает текст и выдаёт статистику (C# 7.3).
    /// Добавлен публичный метод <see cref="Clear"/> для полного сброса.
    /// </summary>
    public sealed class TextAnalyzer
    {
        public int TotalWords { get; private set; }
        public int TotalSpaces { get; private set; }
        public int TotalSentences { get; private set; }
        public double AvgWordLength { get; private set; }
        public double AvgSentenceLength { get; private set; }
        public int TextSizeBytes { get; private set; }

        private readonly Dictionary<string, int> _wordFreq =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<char, int> _charFreq =
            new Dictionary<char, int>();

        public IReadOnlyDictionary<string, int> WordFrequency { get { return _wordFreq; } }
        public IReadOnlyDictionary<char, int> CharFrequency { get { return _charFreq; } }

        /// <summary>
        /// Выполнить анализ указанного текста.
        /// </summary>
        /// <param name="text">Текст (не пустой).</param>
        public void Analyze(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Текст не должен быть пустым.", nameof(text));

            Reset();
            TextSizeBytes = Encoding.UTF8.GetByteCount(text);

            List<string> sentences = ExtractSentences(text);
            CalculateSentenceStats(sentences);

            List<string> words = ExtractWords(text);
            CalculateWordStats(words);

            CalculateCharStats(text);
        }

        /// <summary>
        /// Полностью очищает все накопленные данные (используйте при очистке формы).
        /// </summary>
        public void Clear()
        {
            Reset();
        }

        // ─────────── Helpers ───────────
        private void Reset()
        {
            TotalWords = TotalSpaces = TotalSentences = 0;
            AvgWordLength = AvgSentenceLength = 0;
            TextSizeBytes = 0;
            _wordFreq.Clear();
            _charFreq.Clear();
        }

        private static List<string> ExtractSentences(string text)
        {
            string[] parts = Regex.Split(text, "(?<=[.!?])", RegexOptions.Multiline);
            return parts.Select(s => s.Trim()).Where(s => s.Length > 0).ToList();
        }

        private static List<string> ExtractWords(string text)
        {
            const string pattern = "[\\p{L}\\p{N}][\\p{L}\\p{N}\\p{Pd}]*";
            return Regex.Matches(text, pattern,
                                 RegexOptions.Multiline | RegexOptions.CultureInvariant)
                        .Cast<Match>()
                        .Select(m => m.Value)
                        .ToList();
        }

        private void CalculateSentenceStats(IReadOnlyList<string> sentences)
        {
            TotalSentences = sentences.Count;
        }

        private void CalculateWordStats(IReadOnlyList<string> words)
        {
            TotalWords = words.Count;
            if (TotalWords == 0) return;

            int charSum = 0;
            foreach (string w in words)
            {
                charSum += w.Length;
                int cur; _wordFreq.TryGetValue(w, out cur);
                _wordFreq[w] = cur + 1;
            }
            AvgWordLength = Math.Round((double)charSum / TotalWords, 1);

            if (TotalSentences > 0)
                AvgSentenceLength = Math.Round((double)TotalWords / TotalSentences, 1);
        }

        private void CalculateCharStats(string text)
        {
            foreach (char c in text)
            {
                if (c == ' ') TotalSpaces++;
                int cur; _charFreq.TryGetValue(c, out cur);
                _charFreq[c] = cur + 1;
            }
        }
    }
}
