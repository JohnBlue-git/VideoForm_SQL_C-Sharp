namespace CSharp_MyForm
{
    partial class ChildForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.file_but = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.imageBox = new Emgu.CV.UI.ImageBox();
            this.Play_Pause_Buttton = new System.Windows.Forms.Button();
            this.Stop_Buttton = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Page1 = new System.Windows.Forms.TabPage();
            this.Filepath = new System.Windows.Forms.Label();
            this.Page2 = new System.Windows.Forms.TabPage();
            this.textBox_speed = new System.Windows.Forms.TextBox();
            this.Speed_Button = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.label_export = new System.Windows.Forms.Label();
            this.textBox_export = new System.Windows.Forms.TextBox();
            this.Export_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.tabControl.SuspendLayout();
            this.Page1.SuspendLayout();
            this.Page2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // file_but
            // 
            this.file_but.Location = new System.Drawing.Point(53, 135);
            this.file_but.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.file_but.Name = "file_but";
            this.file_but.Size = new System.Drawing.Size(78, 34);
            this.file_but.TabIndex = 0;
            this.file_but.Text = "...";
            this.file_but.UseVisualStyleBackColor = true;
            this.file_but.Click += new System.EventHandler(this.dia_for_file);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(39, 86);
            this.textBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(506, 33);
            this.textBox.TabIndex = 1;
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(165, 24);
            this.imageBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(391, 281);
            this.imageBox.TabIndex = 2;
            this.imageBox.TabStop = false;
            // 
            // Play_Pause_Buttton
            // 
            this.Play_Pause_Buttton.Enabled = false;
            this.Play_Pause_Buttton.Location = new System.Drawing.Point(35, 24);
            this.Play_Pause_Buttton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Play_Pause_Buttton.Name = "Play_Pause_Buttton";
            this.Play_Pause_Buttton.Size = new System.Drawing.Size(100, 61);
            this.Play_Pause_Buttton.TabIndex = 3;
            this.Play_Pause_Buttton.Text = "Play";
            this.Play_Pause_Buttton.UseVisualStyleBackColor = true;
            this.Play_Pause_Buttton.Click += new System.EventHandler(this.Play_Pause);
            // 
            // Stop_Buttton
            // 
            this.Stop_Buttton.Enabled = false;
            this.Stop_Buttton.Location = new System.Drawing.Point(35, 192);
            this.Stop_Buttton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Stop_Buttton.Name = "Stop_Buttton";
            this.Stop_Buttton.Size = new System.Drawing.Size(100, 61);
            this.Stop_Buttton.TabIndex = 4;
            this.Stop_Buttton.Text = "Stop";
            this.Stop_Buttton.UseVisualStyleBackColor = true;
            this.Stop_Buttton.Click += new System.EventHandler(this.Stop);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(165, 315);
            this.trackBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(391, 80);
            this.trackBar.TabIndex = 5;
            this.trackBar.Scroll += new System.EventHandler(this.scroll_trackBar);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Page1);
            this.tabControl.Controls.Add(this.Page2);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(579, 458);
            this.tabControl.TabIndex = 6;
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.Export_Button);
            this.Page1.Controls.Add(this.textBox_export);
            this.Page1.Controls.Add(this.label_export);
            this.Page1.Controls.Add(this.Filepath);
            this.Page1.Controls.Add(this.textBox);
            this.Page1.Controls.Add(this.file_but);
            this.Page1.Location = new System.Drawing.Point(4, 31);
            this.Page1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Page1.Name = "Page1";
            this.Page1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Page1.Size = new System.Drawing.Size(571, 423);
            this.Page1.TabIndex = 0;
            this.Page1.Text = "Select";
            this.Page1.UseVisualStyleBackColor = true;
            // 
            // Filepath
            // 
            this.Filepath.AutoSize = true;
            this.Filepath.Location = new System.Drawing.Point(49, 48);
            this.Filepath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Filepath.Name = "Filepath";
            this.Filepath.Size = new System.Drawing.Size(74, 21);
            this.Filepath.TabIndex = 2;
            this.Filepath.Text = "Filepath";
            // 
            // Page2
            // 
            this.Page2.Controls.Add(this.Save_Button);
            this.Page2.Controls.Add(this.textBox_speed);
            this.Page2.Controls.Add(this.Speed_Button);
            this.Page2.Controls.Add(this.imageBox);
            this.Page2.Controls.Add(this.trackBar);
            this.Page2.Controls.Add(this.Play_Pause_Buttton);
            this.Page2.Controls.Add(this.Stop_Buttton);
            this.Page2.Location = new System.Drawing.Point(4, 31);
            this.Page2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Page2.Name = "Page2";
            this.Page2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Page2.Size = new System.Drawing.Size(571, 423);
            this.Page2.TabIndex = 1;
            this.Page2.Text = "Play";
            this.Page2.UseVisualStyleBackColor = true;
            // 
            // textBox_speed
            // 
            this.textBox_speed.Location = new System.Drawing.Point(35, 362);
            this.textBox_speed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_speed.Name = "textBox_speed";
            this.textBox_speed.ReadOnly = true;
            this.textBox_speed.Size = new System.Drawing.Size(99, 33);
            this.textBox_speed.TabIndex = 7;
            this.textBox_speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Speed_Button
            // 
            this.Speed_Button.Location = new System.Drawing.Point(34, 281);
            this.Speed_Button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Speed_Button.Name = "Speed_Button";
            this.Speed_Button.Size = new System.Drawing.Size(100, 61);
            this.Speed_Button.TabIndex = 6;
            this.Speed_Button.Text = "Speed";
            this.Speed_Button.UseVisualStyleBackColor = true;
            this.Speed_Button.Click += new System.EventHandler(this.Speed);
            // 
            // Save_Button
            // 
            this.Save_Button.Enabled = false;
            this.Save_Button.Location = new System.Drawing.Point(35, 109);
            this.Save_Button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(100, 61);
            this.Save_Button.TabIndex = 8;
            this.Save_Button.Text = "Save";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.SavePic);
            // 
            // label_export
            // 
            this.label_export.AutoSize = true;
            this.label_export.Location = new System.Drawing.Point(49, 212);
            this.label_export.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_export.Name = "label_export";
            this.label_export.Size = new System.Drawing.Size(173, 21);
            this.label_export.TabIndex = 3;
            this.label_export.Text = "Export Folder Name";
            // 
            // textBox_export
            // 
            this.textBox_export.Location = new System.Drawing.Point(39, 257);
            this.textBox_export.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_export.Name = "textBox_export";
            this.textBox_export.Size = new System.Drawing.Size(506, 33);
            this.textBox_export.TabIndex = 4;
            // 
            // Export_Button
            // 
            this.Export_Button.Location = new System.Drawing.Point(53, 305);
            this.Export_Button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Export_Button.Name = "Export_Button";
            this.Export_Button.Size = new System.Drawing.Size(100, 61);
            this.Export_Button.TabIndex = 9;
            this.Export_Button.Text = "Export";
            this.Export_Button.UseVisualStyleBackColor = true;
            this.Export_Button.Click += new System.EventHandler(this.ExportPic);
            // 
            // ChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 460);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ChildForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseF);
            this.Load += new System.EventHandler(this.LoadF);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.Page1.PerformLayout();
            this.Page2.ResumeLayout(false);
            this.Page2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button file_but;
        private System.Windows.Forms.TextBox textBox;
        private Emgu.CV.UI.ImageBox imageBox;
        private System.Windows.Forms.Button Play_Pause_Buttton;
        private System.Windows.Forms.Button Stop_Buttton;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Page1;
        private System.Windows.Forms.Label Filepath;
        private System.Windows.Forms.TabPage Page2;
        private System.Windows.Forms.Button Speed_Button;
        private System.Windows.Forms.TextBox textBox_speed;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.TextBox textBox_export;
        private System.Windows.Forms.Label label_export;
        private System.Windows.Forms.Button Export_Button;
    }
}

