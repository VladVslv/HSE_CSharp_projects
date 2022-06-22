
namespace Notepad_
{
    partial class CloseForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.notSaveButton = new System.Windows.Forms.Button();
            this.cancelClosingButton = new System.Windows.Forms.Button();
            this.notSaveSettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.saveButton.Location = new System.Drawing.Point(634, 13);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "Save";
            this.saveButton.Size = new System.Drawing.Size(271, 41);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Сохранить изменения";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NotSave
            // 
            this.notSaveButton.Location = new System.Drawing.Point(14, 13);
            this.notSaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.notSaveButton.Name = "NotSave";
            this.notSaveButton.Size = new System.Drawing.Size(313, 41);
            this.notSaveButton.TabIndex = 1;
            this.notSaveButton.Text = "Оставить файлы без изменений";
            this.notSaveButton.UseVisualStyleBackColor = true;
            this.notSaveButton.Click += new System.EventHandler(this.NotSaveButton_Click);
            // 
            // CancelClosing
            // 
            this.cancelClosingButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancelClosingButton.Location = new System.Drawing.Point(913, 13);
            this.cancelClosingButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelClosingButton.Name = "CancelClosing";
            this.cancelClosingButton.Size = new System.Drawing.Size(232, 41);
            this.cancelClosingButton.TabIndex = 2;
            this.cancelClosingButton.Text = "Отмена";
            this.cancelClosingButton.UseVisualStyleBackColor = true;
            this.cancelClosingButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NotSaveSettings
            // 
            this.notSaveSettingsButton.Location = new System.Drawing.Point(334, 13);
            this.notSaveSettingsButton.Name = "NotSaveSettings";
            this.notSaveSettingsButton.Size = new System.Drawing.Size(293, 41);
            this.notSaveSettingsButton.TabIndex = 3;
            this.notSaveSettingsButton.Text = "Сбросить настройки";
            this.notSaveSettingsButton.UseVisualStyleBackColor = true;
            this.notSaveSettingsButton.Click += new System.EventHandler(this.NotSaveSettingsButton_Click);
            // 
            // CloseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 64);
            this.Controls.Add(this.notSaveSettingsButton);
            this.Controls.Add(this.cancelClosingButton);
            this.Controls.Add(this.notSaveButton);
            this.Controls.Add(this.saveButton);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CloseForm";
            this.Text = "Закрытие приложения";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button notSaveButton;
        private System.Windows.Forms.Button cancelClosingButton;
        private System.Windows.Forms.Button notSaveSettingsButton;
    }
}