
namespace Notepad_
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.новыйФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateFile = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.текущийФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseFile = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoSave = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeNotepadFontColor = new System.Windows.Forms.ToolStripMenuItem();
            this.форматToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выделитьВсёToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветШрифтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стильШрифтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветВыделенияТекстаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналированиеФайловToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoggingFrequency = new System.Windows.Forms.ToolStripMenuItem();
            this.VersionsOfCurrentFile = new System.Windows.Forms.ToolStripMenuItem();
            this.Instruction = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoSaveFrequencyTimer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.HighlightAll = new System.Windows.Forms.ToolStripMenuItem();
            this.Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyText = new System.Windows.Forms.ToolStripMenuItem();
            this.Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.FontOfText = new System.Windows.Forms.ToolStripMenuItem();
            this.TextFontColor = new System.Windows.Forms.ToolStripMenuItem();
            this.TextFontStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.HighlightText = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LoggingTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйФайлToolStripMenuItem,
            this.текущийФайлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.форматToolStripMenuItem,
            this.журналированиеФайловToolStripMenuItem,
            this.Instruction});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1100, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // новыйФайлToolStripMenuItem
            // 
            this.новыйФайлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateFile,
            this.OpenFile});
            this.новыйФайлToolStripMenuItem.Name = "новыйФайлToolStripMenuItem";
            this.новыйФайлToolStripMenuItem.Size = new System.Drawing.Size(141, 32);
            this.новыйФайлToolStripMenuItem.Text = "Новый файл";
            // 
            // CreateFile
            // 
            this.CreateFile.Name = "CreateFile";
            this.CreateFile.Size = new System.Drawing.Size(227, 32);
            this.CreateFile.Text = "Создать файл";
            this.CreateFile.Click += new System.EventHandler(this.CreateFile_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(227, 32);
            this.OpenFile.Text = "Открыть файл";
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // текущийФайлToolStripMenuItem
            // 
            this.текущийФайлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save,
            this.CloseFile});
            this.текущийФайлToolStripMenuItem.Name = "текущийФайлToolStripMenuItem";
            this.текущийФайлToolStripMenuItem.Size = new System.Drawing.Size(158, 32);
            this.текущийФайлToolStripMenuItem.Text = "Текущий файл";
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(224, 32);
            this.Save.Text = "Сохранить";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // CloseFile
            // 
            this.CloseFile.Name = "CloseFile";
            this.CloseFile.Size = new System.Drawing.Size(224, 32);
            this.CloseFile.Text = "Закрыть";
            this.CloseFile.Click += new System.EventHandler(this.CloseFile_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormTheme,
            this.AutoSave,
            this.ChangeNotepadFontColor});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(125, 32);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // FormTheme
            // 
            this.FormTheme.Name = "FormTheme";
            this.FormTheme.Size = new System.Drawing.Size(434, 32);
            this.FormTheme.Text = "Изменить цвет фона";
            this.FormTheme.Click += new System.EventHandler(this.ChangeNotepadBackColor_Click);
            // 
            // AutoSave
            // 
            this.AutoSave.Name = "AutoSave";
            this.AutoSave.Size = new System.Drawing.Size(434, 32);
            this.AutoSave.Text = "Частота автосохранения";
            this.AutoSave.Click += new System.EventHandler(this.AutoSave_Click);
            // 
            // ChangeNotepadFontColor
            // 
            this.ChangeNotepadFontColor.Name = "ChangeNotepadFontColor";
            this.ChangeNotepadFontColor.Size = new System.Drawing.Size(434, 32);
            this.ChangeNotepadFontColor.Text = "Изменить цвет шрифта приложения";
            this.ChangeNotepadFontColor.Click += new System.EventHandler(this.ChangeNotepadFontColor_Click);
            // 
            // форматToolStripMenuItem
            // 
            this.форматToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выделитьВсёToolStripMenuItem,
            this.цветШрифтаToolStripMenuItem,
            this.стильШрифтаToolStripMenuItem,
            this.цветВыделенияТекстаToolStripMenuItem});
            this.форматToolStripMenuItem.Name = "форматToolStripMenuItem";
            this.форматToolStripMenuItem.Size = new System.Drawing.Size(97, 32);
            this.форматToolStripMenuItem.Text = "Формат";
            // 
            // выделитьВсёToolStripMenuItem
            // 
            this.выделитьВсёToolStripMenuItem.Name = "выделитьВсёToolStripMenuItem";
            this.выделитьВсёToolStripMenuItem.Size = new System.Drawing.Size(308, 32);
            this.выделитьВсёToolStripMenuItem.Text = "Выделить всё";
            this.выделитьВсёToolStripMenuItem.Click += new System.EventHandler(this.HighlightAll_Click);
            // 
            // цветШрифтаToolStripMenuItem
            // 
            this.цветШрифтаToolStripMenuItem.Name = "цветШрифтаToolStripMenuItem";
            this.цветШрифтаToolStripMenuItem.Size = new System.Drawing.Size(308, 32);
            this.цветШрифтаToolStripMenuItem.Text = "Цвет шрифта";
            this.цветШрифтаToolStripMenuItem.Click += new System.EventHandler(this.TextFontColor_Click);
            // 
            // стильШрифтаToolStripMenuItem
            // 
            this.стильШрифтаToolStripMenuItem.Name = "стильШрифтаToolStripMenuItem";
            this.стильШрифтаToolStripMenuItem.Size = new System.Drawing.Size(308, 32);
            this.стильШрифтаToolStripMenuItem.Text = "Стиль шрифта";
            this.стильШрифтаToolStripMenuItem.Click += new System.EventHandler(this.FontOfText_Click_1);
            // 
            // цветВыделенияТекстаToolStripMenuItem
            // 
            this.цветВыделенияТекстаToolStripMenuItem.Name = "цветВыделенияТекстаToolStripMenuItem";
            this.цветВыделенияТекстаToolStripMenuItem.Size = new System.Drawing.Size(308, 32);
            this.цветВыделенияТекстаToolStripMenuItem.Text = "Цвет выделения текста";
            this.цветВыделенияТекстаToolStripMenuItem.Click += new System.EventHandler(this.HighlightText_Click);
            // 
            // журналированиеФайловToolStripMenuItem
            // 
            this.журналированиеФайловToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoggingFrequency,
            this.VersionsOfCurrentFile});
            this.журналированиеФайловToolStripMenuItem.Name = "журналированиеФайловToolStripMenuItem";
            this.журналированиеФайловToolStripMenuItem.Size = new System.Drawing.Size(264, 32);
            this.журналированиеФайловToolStripMenuItem.Text = "Журналирование файлов";
            // 
            // LoggingFrequency
            // 
            this.LoggingFrequency.Name = "LoggingFrequency";
            this.LoggingFrequency.Size = new System.Drawing.Size(353, 32);
            this.LoggingFrequency.Text = "Интервал журналирования";
            this.LoggingFrequency.Click += new System.EventHandler(this.LoggingFrequency_Click);
            // 
            // VersionsOfCurrentFile
            // 
            this.VersionsOfCurrentFile.Name = "VersionsOfCurrentFile";
            this.VersionsOfCurrentFile.Size = new System.Drawing.Size(353, 32);
            this.VersionsOfCurrentFile.Text = "Версии текущего файла";
            this.VersionsOfCurrentFile.Click += new System.EventHandler(this.VersionsOfCurrentFile_Click);
            // 
            // Instruction
            // 
            this.Instruction.Name = "Instruction";
            this.Instruction.Size = new System.Drawing.Size(189, 32);
            this.Instruction.Text = "Горячие клавиши";
            this.Instruction.Click += new System.EventHandler(this.Instruction_Click);
            // 
            // AutoSaveFrequencyTimer
            // 
            this.AutoSaveFrequencyTimer.Interval = 60000;
            this.AutoSaveFrequencyTimer.Tick += new System.EventHandler(this.AutoSaveFrequencyTimer_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HighlightAll,
            this.Cut,
            this.CopyText,
            this.Paste,
            this.FontOfText});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(267, 164);
            this.contextMenuStrip1.Text = "Действия с текстом";
            // 
            // HighlightAll
            // 
            this.HighlightAll.Name = "HighlightAll";
            this.HighlightAll.Size = new System.Drawing.Size(266, 32);
            this.HighlightAll.Text = "Выделить весь текст";
            this.HighlightAll.Click += new System.EventHandler(this.HighlightAll_Click);
            // 
            // Cut
            // 
            this.Cut.Name = "Cut";
            this.Cut.Size = new System.Drawing.Size(266, 32);
            this.Cut.Text = "Вырезать";
            this.Cut.Click += new System.EventHandler(this.Cut_Click);
            // 
            // CopyText
            // 
            this.CopyText.Name = "CopyText";
            this.CopyText.Size = new System.Drawing.Size(266, 32);
            this.CopyText.Text = "Копировать";
            this.CopyText.Click += new System.EventHandler(this.CopyText_Click);
            // 
            // Paste
            // 
            this.Paste.Name = "Paste";
            this.Paste.Size = new System.Drawing.Size(266, 32);
            this.Paste.Text = "Вставить";
            this.Paste.Click += new System.EventHandler(this.Paste_Click);
            // 
            // FontOfText
            // 
            this.FontOfText.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TextFontColor,
            this.TextFontStyle,
            this.HighlightText});
            this.FontOfText.Name = "FontOfText";
            this.FontOfText.Size = new System.Drawing.Size(266, 32);
            this.FontOfText.Text = "Шрифт";
            // 
            // TextFontColor
            // 
            this.TextFontColor.Name = "TextFontColor";
            this.TextFontColor.Size = new System.Drawing.Size(308, 32);
            this.TextFontColor.Text = " Цвет шрифта";
            this.TextFontColor.Click += new System.EventHandler(this.TextFontColor_Click);
            // 
            // TextFontStyle
            // 
            this.TextFontStyle.Name = "TextFontStyle";
            this.TextFontStyle.Size = new System.Drawing.Size(308, 32);
            this.TextFontStyle.Text = "Стиль шрифта";
            this.TextFontStyle.Click += new System.EventHandler(this.FontOfText_Click_1);
            // 
            // HighlightText
            // 
            this.HighlightText.Name = "HighlightText";
            this.HighlightText.Size = new System.Drawing.Size(308, 32);
            this.HighlightText.Text = "Цвет выделения текста";
            this.HighlightText.Click += new System.EventHandler(this.HighlightText_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1100, 591);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // LoggingTimer
            // 
            this.LoggingTimer.Tick += new System.EventHandler(this.LoggingTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 629);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Notepad+";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem новыйФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateFile;
        private System.Windows.Forms.ToolStripMenuItem OpenFile;
        private System.Windows.Forms.ToolStripMenuItem текущийФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem CloseFile;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FormTheme;
        private System.Windows.Forms.ToolStripMenuItem AutoSave;
        private System.Windows.Forms.ToolStripMenuItem FontOfText;
        private System.Windows.Forms.Timer AutoSaveFrequencyTimer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fdgfdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HighlightAll;
        private System.Windows.Forms.ToolStripMenuItem Cut;
        private System.Windows.Forms.ToolStripMenuItem CopyText;
        private System.Windows.Forms.ToolStripMenuItem Paste;
        private System.Windows.Forms.ToolStripMenuItem шрифтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Italics;
        private System.Windows.Forms.ToolStripMenuItem Bold;
        private System.Windows.Forms.ToolStripMenuItem Underlined;
        private System.Windows.Forms.ToolStripMenuItem StrikeOut;
        private System.Windows.Forms.ToolStripMenuItem TextFontColor;
        private System.Windows.Forms.ToolStripMenuItem TextFontStyle;
        private System.Windows.Forms.ToolStripMenuItem HighlightText;
        private System.Windows.Forms.ToolStripMenuItem форматToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выделитьВсёToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветШрифтаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стильШрифтаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветВыделенияТекстаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeNotepadFontColor;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem журналированиеФайловToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoggingFrequency;
        private System.Windows.Forms.ToolStripMenuItem версииТекущегоФайлаToolStripMenuItem;
        private System.Windows.Forms.Timer LoggingTimer;
        private System.Windows.Forms.ToolStripMenuItem VersionsOfCurrentFile;
        private System.Windows.Forms.ToolStripMenuItem Instruction;
    }
}