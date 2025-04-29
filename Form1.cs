using System;
using System.Linq;
using System.Windows.Forms;
using WordCountProgram.Logic;

namespace WordCountProgram
{
    public partial class Form1 : Form
    {
        // Убираем target-typed new, инициализируем в конструкторе
        private readonly TextAnalyzer _analyzer;

        public Form1()
        {
            InitializeComponent();
            _analyzer = new TextAnalyzer();
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputTextBox.Text))
            {
                MessageBox.Show("Введите текст для анализа", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _analyzer.Analyze(inputTextBox.Text);
                UpdateStatsUI();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            // Традиционный using statement вместо C# 8 using declaration
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text files (*.txt)|*.txt";
                ofd.Title = "Выберите текстовый файл";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        inputTextBox.Text = FileHandler.LoadText(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex.Message);
                    }
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Clear();
            _analyzer.Clear();
            UpdateStatsUI();
        }

        private void UpdateStatsUI()
        {
            // Основная статистика
            totalWordsLabel.Text = "Общее количество слов: " + _analyzer.TotalWords;
            spacesLabel.Text = "Пробелов: " + _analyzer.TotalSpaces;
            sentencesLabel.Text = "Предложений: " + _analyzer.TotalSentences;
            avgWordLengthLabel.Text = "Средняя длина слова: " + _analyzer.AvgWordLength;
            avgSentenceLengthLabel.Text = "Средняя длина предложения: " + _analyzer.AvgSentenceLength;
            textSizeLabel.Text = "Размер текста: " + _analyzer.TextSizeBytes + " байт";

            // Фильтрация по минимальной длине слова
            bool applyFilter = false;
            int minLen = 0;
            string txt = filterTextBox.Text.Trim();
            if (txt.Length > 0)
            {
                if (!int.TryParse(txt, out minLen) || minLen < 1)
                {
                    MessageBox.Show("Введите корректное число для минимальной длины слова", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int maxLen = (_analyzer.WordFrequency.Keys.Any()
                        ? _analyzer.WordFrequency.Keys.Max(w => w.Length)
                        : 0);
                    if (minLen > maxLen)
                    {
                        MessageBox.Show($"Нет слов длиной ≥ {minLen}", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        applyFilter = true;
                    }
                }
            }

            // Топ-10 слов с фильтром
            var wordsQ = _analyzer.WordFrequency.AsEnumerable();
            if (applyFilter)
                wordsQ = wordsQ.Where(p => p.Key.Length >= minLen);

            var topWords = wordsQ
                .OrderByDescending(p => p.Value)
                .Take(10)
                .ToList();

            topWordsLabel.Text = "Топ-10 слов:\n" +
                string.Join("\n",
                    topWords.Select((p, i) => string.Format("{0}. {1} — {2}", i + 1, p.Key, p.Value)));

            // Топ-10 символов
            var topChars = _analyzer.CharFrequency
                .Where(p => p.Key != ' ')
                .OrderByDescending(p => p.Value)
                .Take(10)
                .ToList();

            topCharsLabel.Text = "Топ-10 символов:\n" +
                string.Join("\n",
                    topChars.Select((p, i) => string.Format("{0}. '{1}' — {2}", i + 1, p.Key, p.Value)));
        }

        private static void ShowError(string msg)
        {
            MessageBox.Show(msg, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
