
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.loadFileButton = new System.Windows.Forms.Button();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.RichTextBox();
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
            this.columnHeaderWord = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewChars = new System.Windows.Forms.ListView();
            this.columnHeaderChar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCharCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statsGroupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(10, 10);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(154, 20);
            this.loadFileButton.TabIndex = 0;
            this.loadFileButton.Text = "Загрузить файл...";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // analyzeButton
            // 
            this.analyzeButton.Location = new System.Drawing.Point(170, 10);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(154, 20);
            this.analyzeButton.TabIndex = 1;
            this.analyzeButton.Text = "Анализировать";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(329, 10);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(154, 20);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Сбросить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(10, 39);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(652, 131);
            this.inputTextBox.TabIndex = 3;
            this.inputTextBox.Text = "";
            // 
            // statsGroupBox
            // 
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
            this.statsGroupBox.Location = new System.Drawing.Point(10, 182);
            this.statsGroupBox.Name = "statsGroupBox";
            this.statsGroupBox.Size = new System.Drawing.Size(651, 338);
            this.statsGroupBox.TabIndex = 4;
            this.statsGroupBox.TabStop = false;
            this.statsGroupBox.Text = "Статистика";
            // 
            // totalWordsLabel
            // 
            this.totalWordsLabel.AutoSize = true;
            this.totalWordsLabel.Location = new System.Drawing.Point(9, 17);
            this.totalWordsLabel.Name = "totalWordsLabel";
            this.totalWordsLabel.Size = new System.Drawing.Size(142, 13);
            this.totalWordsLabel.TabIndex = 0;
            this.totalWordsLabel.Text = "Общее количество слов: 0";
            // 
            // spacesLabel
            // 
            this.spacesLabel.AutoSize = true;
            this.spacesLabel.Location = new System.Drawing.Point(9, 35);
            this.spacesLabel.Name = "spacesLabel";
            this.spacesLabel.Size = new System.Drawing.Size(69, 13);
            this.spacesLabel.TabIndex = 1;
            this.spacesLabel.Text = "Пробелов: 0";
            // 
            // sentencesLabel
            // 
            this.sentencesLabel.AutoSize = true;
            this.sentencesLabel.Location = new System.Drawing.Point(9, 52);
            this.sentencesLabel.Name = "sentencesLabel";
            this.sentencesLabel.Size = new System.Drawing.Size(89, 13);
            this.sentencesLabel.TabIndex = 2;
            this.sentencesLabel.Text = "Предложений: 0";
            // 
            // avgWordLengthLabel
            // 
            this.avgWordLengthLabel.AutoSize = true;
            this.avgWordLengthLabel.Location = new System.Drawing.Point(9, 69);
            this.avgWordLengthLabel.Name = "avgWordLengthLabel";
            this.avgWordLengthLabel.Size = new System.Drawing.Size(128, 13);
            this.avgWordLengthLabel.TabIndex = 3;
            this.avgWordLengthLabel.Text = "Средняя длина слова: 0";
            // 
            // avgSentenceLengthLabel
            // 
            this.avgSentenceLengthLabel.AutoSize = true;
            this.avgSentenceLengthLabel.Location = new System.Drawing.Point(9, 87);
            this.avgSentenceLengthLabel.Name = "avgSentenceLengthLabel";
            this.avgSentenceLengthLabel.Size = new System.Drawing.Size(166, 13);
            this.avgSentenceLengthLabel.TabIndex = 4;
            this.avgSentenceLengthLabel.Text = "Средняя длина предложения: 0";
            // 
            // textSizeLabel
            // 
            this.textSizeLabel.AutoSize = true;
            this.textSizeLabel.Location = new System.Drawing.Point(9, 104);
            this.textSizeLabel.Name = "textSizeLabel";
            this.textSizeLabel.Size = new System.Drawing.Size(105, 13);
            this.textSizeLabel.TabIndex = 5;
            this.textSizeLabel.Text = "Размер текста: 0 B";
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(326, 17);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(117, 13);
            this.filterLabel.TabIndex = 6;
            this.filterLabel.Text = "Мин. длина слова (N):";
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(326, 35);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(52, 20);
            this.filterTextBox.TabIndex = 7;
            // 
            // findLabel
            // 
            this.findLabel.AutoSize = true;
            this.findLabel.Location = new System.Drawing.Point(326, 65);
            this.findLabel.Name = "findLabel";
            this.findLabel.Size = new System.Drawing.Size(75, 13);
            this.findLabel.TabIndex = 8;
            this.findLabel.Text = "Поиск слова:";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(326, 82);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(155, 20);
            this.txtFind.TabIndex = 8;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(489, 82);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(64, 20);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "Найти";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // listViewWords
            // 
            this.listViewWords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderWord,
            this.columnHeaderCount});
            this.listViewWords.FullRowSelect = true;
            this.listViewWords.GridLines = true;
            this.listViewWords.HideSelection = false;
            this.listViewWords.Location = new System.Drawing.Point(9, 130);
            this.listViewWords.Name = "listViewWords";
            this.listViewWords.Size = new System.Drawing.Size(309, 200);
            this.listViewWords.TabIndex = 10;
            this.listViewWords.UseCompatibleStateImageBehavior = false;
            this.listViewWords.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderWord
            // 
            this.columnHeaderWord.Text = "Слово";
            this.columnHeaderWord.Width = 200;
            // 
            // columnHeaderCount
            // 
            this.columnHeaderCount.Text = "Частота";
            this.columnHeaderCount.Width = 100;
            // 
            // listViewChars
            // 
            this.listViewChars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderChar,
            this.columnHeaderCharCount});
            this.listViewChars.FullRowSelect = true;
            this.listViewChars.GridLines = true;
            this.listViewChars.HideSelection = false;
            this.listViewChars.Location = new System.Drawing.Point(326, 130);
            this.listViewChars.Name = "listViewChars";
            this.listViewChars.Size = new System.Drawing.Size(309, 200);
            this.listViewChars.TabIndex = 11;
            this.listViewChars.UseCompatibleStateImageBehavior = false;
            this.listViewChars.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderChar
            // 
            this.columnHeaderChar.Text = "Символ";
            this.columnHeaderChar.Width = 100;
            // 
            // columnHeaderCharCount
            // 
            this.columnHeaderCharCount.Text = "Частота";
            this.columnHeaderCharCount.Width = 100;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(672, 22);
            this.statusStrip1.TabIndex = 5;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 560);
            this.Controls.Add(this.loadFileButton);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.statsGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Анализатор Текста";
            this.statsGroupBox.ResumeLayout(false);
            this.statsGroupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}