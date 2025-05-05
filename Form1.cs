using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WordCountProgram.Logic;

namespace WordCountProgram
{
    public partial class Form1 : Form
    {
        private readonly TextAnalyzer _analyzer;
        private string _currentFilePath;

        public Form1()
        {
            InitializeComponent();
            _analyzer = new TextAnalyzer();
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text files (*.txt)|*.txt";
                ofd.Title = "Выберите текстовый файл";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        inputTextBox.Text = FileHandler.LoadText(ofd.FileName);
                        _currentFilePath = ofd.FileName;
                        _analyzer.Clear();
                        UpdateStatsUI();
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex.Message);
                    }
                }
            }
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

        private void clearButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Clear();
            filterTextBox.Clear();
            _analyzer.Clear();
            _currentFilePath = null;
            UpdateStatsUI();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var word = txtFind.Text.Trim();
            if (string.IsNullOrEmpty(word))
            {
                MessageBox.Show("Введите слово для поиска", "Внимание",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            word = word.ToLowerInvariant();
            var count = _analyzer.WordFrequency.TryGetValue(word, out var c) ? c : 0;
            MessageBox.Show(
                $"Слово «{word}» встречается {count} раз(а).",
                "Результат",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void UpdateStatsUI()
        {
            // 1) очищаем ListView
            listViewWords.Items.Clear();
            listViewChars.Items.Clear();

            // 2) основная статистика
            totalWordsLabel.Text = "Общее количество слов: " + _analyzer.TotalWords;
            spacesLabel.Text = "Пробелов: " + _analyzer.TotalSpaces;
            sentencesLabel.Text = "Предложений: " + _analyzer.TotalSentences;
            avgWordLengthLabel.Text = "Средняя длина слова: " + _analyzer.AvgWordLength;
            avgSentenceLengthLabel.Text = "Средняя длина предложения: " + _analyzer.AvgSentenceLength;
            textSizeLabel.Text = "Размер текста: " + _analyzer.TextSizeBytes + " байт";

            // 3) фильтрация по мин. длине слова
            bool applyFilter = false;
            if (int.TryParse(filterTextBox.Text.Trim(), out var minLen) && minLen > 0)
                applyFilter = true;

            // 4) топ-10 слов
            var topWords = _analyzer.WordFrequency
                .Where(p => !applyFilter || p.Key.Length >= minLen)
                .OrderByDescending(p => p.Value)
                .Take(10);

            foreach (var p in topWords)
            {
                var item = new ListViewItem(p.Key);
                item.SubItems.Add(p.Value.ToString());
                listViewWords.Items.Add(item);
            }

            // 5) топ-10 символов
            var topChars = _analyzer.CharFrequency
                .Where(p => p.Key != ' ')
                .OrderByDescending(p => p.Value)
                .Take(10);

            foreach (var p in topChars)
            {
                var item = new ListViewItem(p.Key.ToString());
                item.SubItems.Add(p.Value.ToString());
                listViewChars.Items.Add(item);
            }

            // 6) статус-строка
            if (!string.IsNullOrEmpty(_currentFilePath))
            {
                var sizeKb = new FileInfo(_currentFilePath).Length / 1024;
                toolStripStatusLabel1.Text =
                    $"{Path.GetFileName(_currentFilePath)}; {sizeKb} KB; Анализ: {DateTime.Now:HH:mm:ss}";
            }
            else
            {
                toolStripStatusLabel1.Text = $"Анализ: {DateTime.Now:HH:mm:ss}";
            }
        }

        private static void ShowError(string msg)
        {
            MessageBox.Show(msg, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}