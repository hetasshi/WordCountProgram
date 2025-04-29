using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WordCountProgram.Logic
{
    /// <summary>
    /// Анализирует текст: считает слова, предложения, символы,
    /// и нормализует символы в нижний регистр для подсчёта.
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

        public IReadOnlyDictionary<string, int> WordFrequency => _wordFreq;
        public IReadOnlyDictionary<char, int> CharFrequency => _charFreq;

        /// <summary>Запускает анализ текста.</summary>
        public void Analyze(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Текст не должен быть пустым.", nameof(text));

            Reset();
            TextSizeBytes = Encoding.UTF8.GetByteCount(text);

            var sentences = ExtractSentences(text);
            CalculateSentenceStats(sentences);

            var words = ExtractWords(text);
            CalculateWordStats(words);

            CalculateCharStats(text);
        }

        /// <summary>Сбрасывает всю статистику.</summary>
        public void Clear() => Reset();

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
            // Режем по . ! ? (look-behind сохраняет разделитель)
            string[] parts = Regex.Split(text, "(?<=[.!?])", RegexOptions.Multiline);
            return parts
                .Select(s => s.Trim())
                .Where(s => s.Length > 0)
                .ToList();
        }

        private static List<string> ExtractWords(string text)
        {
            // Слово: буква/цифра + (буквы/цифры/дефисы)*
            const string pattern = "[\\p{L}\\p{N}][\\p{L}\\p{N}\\p{Pd}]*";
            return Regex.Matches(text, pattern,
                                 RegexOptions.Multiline | RegexOptions.CultureInvariant)
                        .Cast<Match>()
                        .Select(m => m.Value)
                        .ToList();
        }

        private void CalculateSentenceStats(IReadOnlyList<string> sentences)
            => TotalSentences = sentences.Count;

        private void CalculateWordStats(IReadOnlyList<string> words)
        {
            TotalWords = words.Count;
            if (TotalWords == 0) return;

            int sumLen = 0;
            foreach (string w in words)
            {
                sumLen += w.Length;
                _wordFreq[w] = _wordFreq.TryGetValue(w, out var cnt) ? cnt + 1 : 1;
            }
            AvgWordLength = Math.Round((double)sumLen / TotalWords, 1);

            if (TotalSentences > 0)
                AvgSentenceLength = Math.Round((double)TotalWords / TotalSentences, 1);
        }

        private void CalculateCharStats(string text)
        {
            foreach (char c in text)
            {
                // приводим в нижний регистр
                char lower = char.ToLowerInvariant(c);
                if (lower == ' ')
                    TotalSpaces++;

                _charFreq[lower] = _charFreq.TryGetValue(lower, out var cnt) ? cnt + 1 : 1;
            }
        }
    }
}