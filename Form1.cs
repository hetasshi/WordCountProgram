using System;
using System.Linq;
using System.Windows.Forms;
using WordCountProgram.Logic;

namespace WordCountProgram
{
    public partial class Form1 : Form
    {
        private readonly TextAnalyzer _analyzer = new TextAnalyzer();

        public Form1()
        {
            InitializeComponent();
        }

        // === «Анализировать» =====================================
        private void analyzeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(inputTextBox.Text))
                {
                    MessageBox.Show("Введите текст для анализа",
                                    "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                _analyzer.Analyze(inputTextBox.Text);
                UpdateStatsUI();
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        // === «Загрузить файл» ====================================
        private void loadFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text files (*.txt)|*.txt";
                ofd.Title = "Выберите текстовый файл";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try { inputTextBox.Text = FileHandler.LoadText(ofd.FileName); }
                    catch (Exception ex) { ShowError(ex.Message); }
                }
            }
        }

        // === «Очистить» ==========================================
        private void clearButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Clear();
            _analyzer.Clear();
            UpdateStatsUI();
        }


        // === Вывод статистики ====================================
        private void UpdateStatsUI()
        {
            totalWordsLabel.Text = "Общее количество слов: " + _analyzer.TotalWords;
            spacesLabel.Text = "Пробелов: " + _analyzer.TotalSpaces;
            sentencesLabel.Text = "Предложений: " + _analyzer.TotalSentences;
            avgWordLengthLabel.Text = "Средняя длина слова: " + _analyzer.AvgWordLength;
            avgSentenceLengthLabel.Text = "Средняя длина предложения: " + _analyzer.AvgSentenceLength;
            textSizeLabel.Text = "Размер текста: " + _analyzer.TextSizeBytes + " байт";

            topWordsLabel.Text = "Топ-10 слов:\n" +
                string.Join("\n",
                    _analyzer.WordFrequency
                              .OrderByDescending(p => p.Value)
                              .Take(10)
                              .Select((p, i) =>
                                  (i + 1) + ". " + p.Key + " — " + p.Value));

            topCharsLabel.Text = "Топ-10 символов:\n" +
                string.Join("\n",
                    _analyzer.CharFrequency
                              .OrderByDescending(p => p.Value)
                              .Where(p => p.Key != ' ')
                              .Take(10)
                              .Select((p, i) =>
                                  (i + 1) + ". '" + p.Key + "' — " + p.Value));
        }

        private static void ShowError(string msg)
        {
            MessageBox.Show(msg, "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
