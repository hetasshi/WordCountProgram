
namespace WordCountProgram
{
    partial class Form1
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // ----------  КОНТРОЛЫ  ----------
        private System.Windows.Forms.Button loadFileButton;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.RichTextBox inputTextBox;

        private System.Windows.Forms.GroupBox statsGroupBox;
        private System.Windows.Forms.Label totalWordsLabel;
        private System.Windows.Forms.Label spacesLabel;
        private System.Windows.Forms.Label sentencesLabel;
        private System.Windows.Forms.Label avgWordLengthLabel;
        private System.Windows.Forms.Label avgSentenceLengthLabel;
        private System.Windows.Forms.Label textSizeLabel;

        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.TextBox filterTextBox;

        private System.Windows.Forms.Label findLabel;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnFind;

        private System.Windows.Forms.ListView listViewWords;
        private System.Windows.Forms.ColumnHeader columnHeaderWord;
        private System.Windows.Forms.ColumnHeader columnHeaderCount;

        private System.Windows.Forms.ListView listViewChars;
        private System.Windows.Forms.ColumnHeader columnHeaderChar;
        private System.Windows.Forms.ColumnHeader columnHeaderCharCount;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Метод, необходимый для поддержки конструктора — не изменяйте
        /// содержимое этого метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ───── Верхние кнопки ──────────────────────────────────────────────
            this.loadFileButton = new System.Windows.Forms.Button();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();

            // ───── Поле ввода текста ───────────────────────────────────────────
            this.inputTextBox = new System.Windows.Forms.RichTextBox();

            // ───── Группа «Статистика» ─────────────────────────────────────────
            this.statsGroupBox = new System.Windows.Forms.GroupBox();
            this.totalWordsLabel = new System.Windows.Forms.Label();
            this.spacesLabel = new System.Windows.Forms.Label();
            this.sentencesLabel = new System.Windows.Forms.Label();
            this.avgWordLengthLabel = new System.Windows.Forms.Label();
            this.avgSentenceLengthLabel = new System.Windows.Forms.Label();
            this.textSizeLabel = new System.Windows.Forms.Label();

            this.filterLabel = new System.Windows.Forms.Label();
            this.filterTextBox = new System.Windows.Forms.TextBox();

            this.findLabel = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();

            this.listViewWords = new System.Windows.Forms.ListView();
            this.columnHeaderWord = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderCount = new System.Windows.Forms.ColumnHeader();

            this.listViewChars = new System.Windows.Forms.ListView();
            this.columnHeaderChar = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderCharCount = new System.Windows.Forms.ColumnHeader();

            // ───── Строка состояния ────────────────────────────────────────────
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();

            // ------------------------------------------------------------------
            //           НАСТРОЙКА КОНТРОЛОВ
            // ------------------------------------------------------------------

            // loadFileButton
            this.loadFileButton.Location = new System.Drawing.Point(12, 12);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(180, 23);
            this.loadFileButton.TabIndex = 0;
            this.loadFileButton.Text = "Загрузить файл...";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);

            // analyzeButton
            this.analyzeButton.Location = new System.Drawing.Point(198, 12);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(180, 23);
            this.analyzeButton.TabIndex = 1;
            this.analyzeButton.Text = "Анализировать";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);

            // clearButton
            this.clearButton.Location = new System.Drawing.Point(384, 12);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(180, 23);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Сбросить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);

            // inputTextBox
            this.inputTextBox.Location = new System.Drawing.Point(12, 45);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(760, 150);
            this.inputTextBox.TabIndex = 3;
            this.inputTextBox.Text = "";

            // ------------------------------------------------------------------
            // statsGroupBox
            // ------------------------------------------------------------------
            this.statsGroupBox.Location = new System.Drawing.Point(12, 210);
            this.statsGroupBox.Name = "statsGroupBox";
            this.statsGroupBox.Size = new System.Drawing.Size(760, 390);
            this.statsGroupBox.TabIndex = 4;
            this.statsGroupBox.TabStop = false;
            this.statsGroupBox.Text = "Статистика";

            // ───── Лейблы общей статистики (левая колонка) ─────────────────────
            this.totalWordsLabel.AutoSize = true;
            this.totalWordsLabel.Location = new System.Drawing.Point(10, 20);
            this.totalWordsLabel.Size = new System.Drawing.Size(165, 15);
            this.totalWordsLabel.Text = "Общее количество слов: 0";

            this.spacesLabel.AutoSize = true;
            this.spacesLabel.Location = new System.Drawing.Point(10, 40);
            this.spacesLabel.Size = new System.Drawing.Size(70, 15);
            this.spacesLabel.Text = "Пробелов: 0";

            this.sentencesLabel.AutoSize = true;
            this.sentencesLabel.Location = new System.Drawing.Point(10, 60);
            this.sentencesLabel.Size = new System.Drawing.Size(92, 15);
            this.sentencesLabel.Text = "Предложений: 0";

            this.avgWordLengthLabel.AutoSize = true;
            this.avgWordLengthLabel.Location = new System.Drawing.Point(10, 80);
            this.avgWordLengthLabel.Size = new System.Drawing.Size(140, 15);
            this.avgWordLengthLabel.Text = "Средняя длина слова: 0";

            this.avgSentenceLengthLabel.AutoSize = true;
            this.avgSentenceLengthLabel.Location = new System.Drawing.Point(10, 100);
            this.avgSentenceLengthLabel.Size = new System.Drawing.Size(185, 15);
            this.avgSentenceLengthLabel.Text = "Средняя длина предложения: 0";

            this.textSizeLabel.AutoSize = true;
            this.textSizeLabel.Location = new System.Drawing.Point(10, 120);
            this.textSizeLabel.Size = new System.Drawing.Size(105, 15);
            this.textSizeLabel.Text = "Размер текста: 0 B";

            // ───── Фильтр по минимальной длине слова ───────────────────────────
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(380, 20);
            this.filterLabel.Size = new System.Drawing.Size(145, 15);
            this.filterLabel.Text = "Мин. длина слова (N):";

            this.filterTextBox.Location = new System.Drawing.Point(380, 40);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(60, 23);
            this.filterTextBox.TabIndex = 7;

            // ───── Поиск слова ─────────────────────────────────────────────────
            this.findLabel.AutoSize = true;
            this.findLabel.Location = new System.Drawing.Point(380, 75); // подпись
            this.findLabel.Size = new System.Drawing.Size(80, 15);
            this.findLabel.Text = "Поиск слова:";

            this.txtFind.Location = new System.Drawing.Point(380, 95); // поле ввода
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(180, 23);
            this.txtFind.TabIndex = 8;

            this.btnFind.Location = new System.Drawing.Point(570, 95); // кнопка
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "Найти";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);

            // ───── ListView слов ──────────────────────────────────────────────
            this.listViewWords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.columnHeaderWord,
                this.columnHeaderCount});
            this.listViewWords.FullRowSelect = true;
            this.listViewWords.GridLines = true;
            this.listViewWords.HideSelection = false;
            this.listViewWords.Location = new System.Drawing.Point(10, 150);
            this.listViewWords.Name = "listViewWords";
            this.listViewWords.Size = new System.Drawing.Size(360, 230);
            this.listViewWords.UseCompatibleStateImageBehavior = false;
            this.listViewWords.View = System.Windows.Forms.View.Details;

            this.columnHeaderWord.Text = "Слово";
            this.columnHeaderWord.Width = 200;
            this.columnHeaderCount.Text = "Частота";
            this.columnHeaderCount.Width = 100;

            // ───── ListView символов ──────────────────────────────────────────
            this.listViewChars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.columnHeaderChar,
                this.columnHeaderCharCount});
            this.listViewChars.FullRowSelect = true;
            this.listViewChars.GridLines = true;
            this.listViewChars.HideSelection = false;
            this.listViewChars.Location = new System.Drawing.Point(380, 150);
            this.listViewChars.Name = "listViewChars";
            this.listViewChars.Size = new System.Drawing.Size(360, 230);
            this.listViewChars.UseCompatibleStateImageBehavior = false;
            this.listViewChars.View = System.Windows.Forms.View.Details;

            this.columnHeaderChar.Text = "Символ";
            this.columnHeaderChar.Width = 100;
            this.columnHeaderCharCount.Text = "Частота";
            this.columnHeaderCharCount.Width = 100;

            // ------------------------------------------------------------------
            // statusStrip1
            // ------------------------------------------------------------------
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 624);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);

            // toolStripStatusLabel1
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";

            // ------------------------------------------------------------------
            //  ДОБАВЛЕНИЕ КОНТРОЛОВ В ИЕРАРХИЮ
            // ------------------------------------------------------------------

            // внутрь statsGroupBox
            this.statsGroupBox.Controls.Add(this.totalWordsLabel);
            this.statsGroupBox.Controls.Add(this.spacesLabel);
            this.statsGroupBox.Controls.Add(this.sentencesLabel);
            this.statsGroupBox.Controls.Add(this.avgWordLengthLabel);
            this.statsGroupBox.Controls.Add(this.avgSentenceLengthLabel);
            this.statsGroupBox.Controls.Add(this.textSizeLabel);
            this.statsGroupBox.Controls.Add(this.filterLabel);
            this.statsGroupBox.Controls.Add(this.filterTextBox);
            this.statsGroupBox.Controls.Add(this.findLabel);
            this.statsGroupBox.Controls.Add(this.txtFind);
            this.statsGroupBox.Controls.Add(this.btnFind);
            this.statsGroupBox.Controls.Add(this.listViewWords);
            this.statsGroupBox.Controls.Add(this.listViewChars);

            // корневые элементы формы
            this.Controls.Add(this.loadFileButton);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.statsGroupBox);
            this.Controls.Add(this.statusStrip1);

            // ------------------------------------------------------------------
            //  НАСТРОЙКИ ФОРМЫ
            // ------------------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 646);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Word Count Analyzer";

            // Финальные вызовы ResumeLayout
            this.statsGroupBox.ResumeLayout(false);
            this.statsGroupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
        }
        #endregion
    }
}