using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Collections.Specialized;

namespace Notepad_
{
    /// <summary>
    /// Основная форма приложения.
    /// </summary>
    public partial class MainForm : Form
    {

        // Все файлы, октрытые на данный момент.
        List<MyFile> files = new List<MyFile>();
        // Вкладка открываемого файла.
        TabPage newTabPage;
        // RichTextBox открываемого файла.
        RichTextBox newTextBox;
        //рассматриваемых файл.
        MyFile currentFile;
        // Путь к рассматриваему файлу.
        string filePath;


        public MainForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Создание и открытие нового файла.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void CreateFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            Data.FileName = "File" + files.Count;
            (new CreateFileForm()).ShowDialog(this);
            filePath = dialog.SelectedPath + "\\" + Data.FileName+".rtf";
            try
            {
                AlreadyExists();
                newTabPage = new TabPage(Data.FileName+".rtf");
                newTextBox = new RichTextBox();
                newTextBox.BackColor = Data.BackColor;
                tabControl1.Controls.Add(newTabPage);
                newTextBox.Dock = DockStyle.Fill;
                newTabPage.Controls.Add(newTextBox);
                currentFile = new MyFile(newTextBox, filePath, newTabPage);
                files.Add(currentFile);
                newTextBox.ContextMenuStrip = contextMenuStrip1;
                tabControl1.SelectedIndex = files.Count-1;
                File.WriteAllText(filePath, null);
                CreateFolderForVersions();
                SaveVersionfOfCurrentFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Открытие нового файла.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            filePath = dialog.FileName;
            try
            {
                AlreadyExists();
                newTabPage = new TabPage(Path.GetFileName(filePath));
                newTextBox = new RichTextBox();
                newTextBox.BackColor = Data.BackColor;
                newTextBox.Font = new Font(newTextBox.Font, FontStyle.Regular);
                LoadNewFile();
                tabControl1.Controls.Add(newTabPage);
                newTextBox.Dock = DockStyle.Fill;
                newTabPage.Controls.Add(newTextBox);
                currentFile = new MyFile(newTextBox, filePath, newTabPage);
                files.Add(currentFile);
                newTextBox.ContextMenuStrip = contextMenuStrip1;
                tabControl1.SelectedIndex = files.Count - 1;
                CreateFolderForVersions();
                SaveVersionfOfCurrentFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Загрузка текста из нового файла в newTextBox.
        /// </summary>
        private void LoadNewFile()
        {
            if (Path.GetExtension(filePath) == ".rtf")
            {
                newTextBox.LoadFile(filePath, RichTextBoxStreamType.RichText);
            }
            else if (Path.GetExtension(filePath) == ".txt")
            {
                newTextBox.Text = File.ReadAllText(filePath, Encoding.UTF8);
            }
            else
            {
                throw new ArgumentException("File format is not invalid");
            }
        }

        /// <summary>
        /// Создания папки для журналирования текущего файла.
        /// </summary>
        public void CreateFolderForVersions()
        {
            DirectoryInfo hiddenDir = Directory.CreateDirectory(@"VersionsOfFiles\"+Path.GetFileName(filePath)[..^4]);
            hiddenDir.Attributes = FileAttributes.Hidden;

        }

        /// <summary>
        /// Проверка того, открыт ли уже текущий файл.
        /// </summary>
        private void AlreadyExists()
        {
            if (files.Exists(x => x.Path == filePath))
            {
                throw new ArgumentException("This file with this name is already open/exists.");
            }
        }

        /// <summary>
        /// Сохранение текущего файла.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Save_Click(object sender, EventArgs e)
        {
            if (files.Count != 0)
            {
                SaveCurrentFile();
            }
        }

        /// <summary>
        /// Сохранение файла.
        /// </summary>
        private void SaveCurrentFile()
        {
            try
            {
                if (files.Count != 0)
                {
                    filePath = currentFile.Path;
                    if (Path.GetExtension(filePath) == ".rtf")
                    {
                        currentFile.TextBox.SaveFile(currentFile.Path);
                    }
                    else
                    {
                        File.WriteAllText(filePath, currentFile.TextBox.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(currentFile.Path+"\n\n"+ex.Message);
            }
        }


        /// <summary>
        /// Закрытие текущего файла.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void CloseFile_Click(object sender, EventArgs e)
        {
            if (files.Count != 0)
            {
                SaveCurrentFile();
                files.Remove(currentFile);
                tabControl1.Controls.Remove(currentFile.Page);
                MessageBox.Show("Файл был автоматически сохранён");
                if (files.Count != 0)
                {
                    tabControl1.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Закрытие формы и сохранение всех пользовательский настроек.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            (new CloseForm()).ShowDialog(this);
            try
            {
                switch (Data.ClosingChoice)
                {
                    case "Save":
                        foreach (MyFile elem in files)
                        {
                            currentFile = elem;
                            SaveCurrentFile();
                        }
                        SaveAllSettings();
                        (new DirectoryInfo("VersionsOFFiles")).Delete(true);
                        break;
                    case "NotSave":
                        SaveAllSettings();
                        (new DirectoryInfo("VersionsOFFiles")).Delete(true);
                        break;
                    case "NotSaveSettings":
                        MySettings.Default.Reset();
                        foreach (MyFile elem in files)
                        {
                            currentFile = elem;
                            SaveCurrentFile();
                        }
                        MessageBox.Show("Все файлы были сохранены.");
                        (new DirectoryInfo("VersionsOFFiles")).Delete(true);
                        break;
                    default:
                        e.Cancel = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Выюор частоты автосохранения файла.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void AutoSave_Click(object sender, EventArgs e)
        {
            (new AutoSaveForm()).ShowDialog(this);
            if (Data.AutoSaveFrequency== "Выключить автосохранение")
            {
                AutoSaveFrequencyTimer.Stop();
            }
            else
            {
                AutoSaveFrequencyTimer.Start();
                AutoSaveFrequencyTimer.Interval = 1000*int.Parse(Data.AutoSaveFrequency);
            }
        }

        /// <summary>
        /// Сохранение всех файлов по прошествии выбранного интервала времени.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void AutoSaveFrequencyTimer_Tick(object sender, EventArgs e)
        {
            foreach (MyFile elem in files)
            {
                currentFile = elem;
                SaveCurrentFile();
            }
        }

        /// <summary>
        /// Загрузка формы и пременение выбранной ранее темы ко всем элементам и запись их в Data.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Data.BackColor = MySettings.Default.backColor;
            Data.FontColor = MySettings.Default.fontColor;
            Data.AutoSaveFrequency = MySettings.Default.autoSaveFrequency;
            Data.LoggingFrequency = MySettings.Default.loggingFrequency;
            if (Data.AutoSaveFrequency != "Выключить автосохранение")
            {
                AutoSaveFrequencyTimer.Start();
                AutoSaveFrequencyTimer.Interval = 1000 * int.Parse(Data.AutoSaveFrequency);
            }
            if (Data.LoggingFrequency != "Выключить журналирование")
            {
                LoggingTimer.Start();
                LoggingTimer.Interval = 1000 * 60 * int.Parse(Data.LoggingFrequency);
            }
            DirectoryInfo versions = new DirectoryInfo("VersionsOfFiles");
            versions.Create();
            versions.Attributes = FileAttributes.Hidden;
            if (MySettings.Default.namesOfFiles != null)
            {
                foreach (string path in MySettings.Default.namesOfFiles)
                {
                    if (File.Exists(path))
                    {
                        AddFile(path);
                        filePath = path;
                        CreateFolderForVersions();
                    }
                }
            }
            this.BackColor = Data.BackColor;
            menuStrip1.BackColor = Data.BackColor;
            contextMenuStrip1.BackColor = Data.BackColor;
            this.ForeColor = Data.FontColor;
            menuStrip1.ForeColor = Data.FontColor;
            contextMenuStrip1.ForeColor = Data.FontColor;
            LoggingTimer_Tick(null, null);
        }

        /// <summary>
        /// Открытие нового файла в новой вклаке по его пути.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        private void AddFile(string path)
        {
            try
            {
                newTabPage = new TabPage(Path.GetFileName(path));
                newTextBox = new RichTextBox();
                newTextBox.BackColor = Data.BackColor;
                newTextBox.Font = new Font(newTextBox.Font, FontStyle.Regular);
                if (Path.GetExtension(path) == ".rtf")
                {
                    newTextBox.LoadFile(path, RichTextBoxStreamType.RichText);
                }
                else if (Path.GetExtension(path) == ".txt")
                {
                    newTextBox.Text = File.ReadAllText(path, Encoding.UTF8);
                }
                tabControl1.Controls.Add(newTabPage);
                newTextBox.Dock = DockStyle.Fill;
                newTabPage.Controls.Add(newTextBox);
                currentFile = new MyFile(newTextBox, path, newTabPage);
                files.Add(currentFile);
                newTextBox.ContextMenuStrip = contextMenuStrip1;
                tabControl1.SelectedIndex = files.Count - 1;
            }
            catch(Exception e)
            {
                MessageBox.Show(currentFile.Path+"\n\n"+e.Message);
            }
        }

        /// <summary>
        /// Сохранение всех настроек.
        /// </summary>
        public void SaveAllSettings()
        {
            MySettings.Default.backColor = Data.BackColor;
            MySettings.Default.fontColor = Data.FontColor;
            MySettings.Default.autoSaveFrequency = Data.AutoSaveFrequency;
            MySettings.Default.loggingFrequency = Data.LoggingFrequency;
            StringCollection namesOfFiles = new StringCollection();
            foreach(MyFile elem in files)
            {
                namesOfFiles.Add(elem.Path);
            }
            MySettings.Default.namesOfFiles = namesOfFiles;
            MySettings.Default.Save();
        }

        /// <summary>
        /// Выделение всего текста в втекущем файле.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void HighlightAll_Click(object sender, EventArgs e)
        {
            if (files.Count != 0)
            {
                currentFile.TextBox.SelectAll();
            }
        }

        /// <summary>
        /// Вырезание выбранного фрагмента текста в текущем файле.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Cut_Click(object sender, EventArgs e)
        {
            if (files.Count != 0)
            {
                currentFile.TextBox.SelectedRtf = "";
            }
        }

        /// <summary>
        /// Копированеи выбранного фрагмента текста в буфер обмена.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void CopyText_Click(object sender, EventArgs e)
        {
            if (files.Count != 0)
            {
                Clipboard.SetDataObject(currentFile.TextBox.SelectedText);
            }
        }

        /// <summary>
        /// Вставка текста из буфера обмена на место выбранного текста.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Paste_Click(object sender, EventArgs e)
        {
            if (files.Count != 0)
            {
                currentFile.TextBox.SelectedText = Clipboard.GetText();
            }
        }

        /// <summary>
        /// Изменение текущего файла при изменении вкладки.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFile = files.Find(x => x.Page == tabControl1.SelectedTab);
        }

        /// <summary>
        /// Изменение шрифта выюранного текста.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void FontOfText_Click_1(object sender, EventArgs e)
        {
            if (files.Count != 0)
            {
                FontDialog fontDialog = new FontDialog();
                if (fontDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                currentFile.TextBox.SelectionFont = fontDialog.Font;
            }
        }

        /// <summary>
        /// Изменение цвета шрифта выбранного текста.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void TextFontColor_Click(object sender, EventArgs e)
        {
            if (files.Count != 0)
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                currentFile.TextBox.SelectionColor = colorDialog.Color;
            }
        }

        /// <summary>
        /// Изменение цвета выделения текста.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void HighlightText_Click(object sender, EventArgs e)
        {
            if (files.Count != 0)
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                currentFile.TextBox.SelectionBackColor = colorDialog.Color;
            }
            
        }

        /// <summary>
        /// Горячие клавишы.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control&&e.Alt)
            {
                if (e.KeyCode == Keys.O)
                {
                    CreateFile_Click(CreateFile, null);
                }
                else if (e.KeyCode == Keys.S)
                {
                    SaveCurrentFile();
                }
                else if (e.KeyCode == Keys.A)
                {
                    foreach (MyFile elem in files)
                    {
                        currentFile = elem;
                        SaveCurrentFile();
                    }
                }
                else if (e.KeyCode == Keys.C)
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Изменение фона приложения.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void ChangeNotepadBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            Data.BackColor = colorDialog.Color;
            foreach (MyFile elem in files)
            {
                currentFile = elem;
                currentFile.TextBox.BackColor = colorDialog.Color;
            }
            this.BackColor = colorDialog.Color;
            menuStrip1.BackColor = colorDialog.Color;
            contextMenuStrip1.BackColor = colorDialog.Color;

        }

        /// <summary>
        /// Изменение цвета шрифта приложения.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void ChangeNotepadFontColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            Data.FontColor = colorDialog.Color;
            this.ForeColor = colorDialog.Color;
            menuStrip1.ForeColor = colorDialog.Color;
            contextMenuStrip1.ForeColor = colorDialog.Color;
        }

        /// <summary>
        /// Изменение частоты журналированияя файлов.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void LoggingFrequency_Click(object sender, EventArgs e)
        {
            (new LoggingForm()).ShowDialog(this);
            if (Data.LoggingFrequency == "Выключить журналирование")
            {
                LoggingTimer.Stop();
            }
            else
            {
                LoggingTimer.Start();
                LoggingTimer.Interval = 1000*60*int.Parse(Data.LoggingFrequency);
            }
        }

        /// <summary>
        /// Журналированеи всех файлов по прошествию выбранного интервала времени.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        public void LoggingTimer_Tick(object sender, EventArgs e)
        {

            foreach (MyFile elem in files)
            {
                if (Path.GetExtension(elem.Path) == ".rtf")
                {
                    elem.TextBox.SaveFile("VersionsOfFiles\\"+(Path.GetFileName(elem.Path)[..^4])+"\\"+
                        Directory.GetFiles("VersionsOfFiles\\" + Path.GetFileName(elem.Path[..^4])).Length+".rtf");
                }
                else
                {
                    File.WriteAllText("VersionsOfFiles\\" + (Path.GetFileName(elem.Path)[..^4]) + "\\" + 
                        Directory.GetFiles("VersionsOfFiles\\" + Path.GetFileName(elem.Path[..^4])).Length+".txt",
                        elem.TextBox.Text);
                }
            }
        }

        /// <summary>
        /// Возврат к предыдущей версии текущего файла.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void VersionsOfCurrentFile_Click(object sender, EventArgs e)
        {
            if (files.Count != 0)
            {
                Data.CurrentFile = currentFile;
                Data.VersionOfFile = currentFile.Path;
                (new VersionsOfFileForm()).ShowDialog(this);
                if (Path.GetExtension(currentFile.Path) == ".rtf")
                {
                    currentFile.TextBox.LoadFile(Data.VersionOfFile, RichTextBoxStreamType.RichText);
                }
                else
                {
                    currentFile.TextBox.Text = File.ReadAllText(Data.VersionOfFile, Encoding.UTF8);
                }
            }
        }

        /// <summary>
        /// Сохрание первой версии текущего файла.
        /// </summary>
        public void SaveVersionfOfCurrentFile()
        {
            if (Path.GetExtension(currentFile.Path) == ".rtf")
            {
                currentFile.TextBox.SaveFile("VersionsOfFiles\\" + (Path.GetFileName(currentFile.Path)[..^4]) + "\\" +
                    Directory.GetFiles("VersionsOfFiles\\" + Path.GetFileName(currentFile.Path[..^4])).Length + 
                    ".rtf");
            }
            else
            {
                File.WriteAllText("VersionsOfFiles\\" + (Path.GetFileName(currentFile.Path)[..^4]) + "\\" +
                    Directory.GetFiles("VersionsOfFiles\\" + Path.GetFileName(currentFile.Path[..^4])).Length + ".txt",
                    currentFile.TextBox.Text);
            }
        }



        /// <summary>
        /// Вывод иснтрукции по горячим клавишам.
        /// </summary>
        /// <param name="sender">Издатель.</param>
        /// <param name="e">Информация о событии.</param>
        private void Instruction_Click(object sender, EventArgs e)
        {
            (new InstructionForm()).ShowDialog(this);
        }
    }
}
