namespace L13
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileSystemTreeView = new System.Windows.Forms.TreeView();
            this.labelFiles = new System.Windows.Forms.Label();
            this.filePropertiesLabel = new System.Windows.Forms.Label();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemTreeView
            // 
            this.fileSystemTreeView.Location = new System.Drawing.Point(386, 36);
            this.fileSystemTreeView.Name = "fileSystemTreeView";
            this.fileSystemTreeView.Size = new System.Drawing.Size(865, 271);
            this.fileSystemTreeView.TabIndex = 2;
            this.fileSystemTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.fileSystemTreeView_AfterSelect);
            // 
            // labelFiles
            // 
            this.labelFiles.AutoSize = true;
            this.labelFiles.BackColor = System.Drawing.Color.GhostWhite;
            this.labelFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelFiles.Location = new System.Drawing.Point(637, 13);
            this.labelFiles.Name = "labelFiles";
            this.labelFiles.Size = new System.Drawing.Size(310, 20);
            this.labelFiles.TabIndex = 6;
            this.labelFiles.Text = "Відображення структури папок і файлів";
            // 
            // filePropertiesLabel
            // 
            this.filePropertiesLabel.AutoSize = true;
            this.filePropertiesLabel.BackColor = System.Drawing.Color.White;
            this.filePropertiesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.filePropertiesLabel.Location = new System.Drawing.Point(35, 36);
            this.filePropertiesLabel.Name = "filePropertiesLabel";
            this.filePropertiesLabel.Size = new System.Drawing.Size(70, 20);
            this.filePropertiesLabel.TabIndex = 8;
            this.filePropertiesLabel.Text = "Довідка";
            this.filePropertiesLabel.Click += new System.EventHandler(this.Form1_Load);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(12, 263);
            this.filterTextBox.Multiline = true;
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(339, 44);
            this.filterTextBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(89, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Фільтр каталогів та файлів";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(716, 357);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(456, 297);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 357);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(657, 297);
            this.textBox1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(230, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Перегляд текстових файлів";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(846, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Перегляд графічних об\'єктів";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1291, 680);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filterTextBox);
            this.Controls.Add(this.filePropertiesLabel);
            this.Controls.Add(this.labelFiles);
            this.Controls.Add(this.fileSystemTreeView);
            this.Name = "Form1";
            this.Text = "L13";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView fileSystemTreeView;
        private System.Windows.Forms.Label labelFiles;
        private System.Windows.Forms.Label filePropertiesLabel;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

