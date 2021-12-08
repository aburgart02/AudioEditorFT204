
namespace Audio_Editor
{
    partial class UI
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.LoadButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SaveButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CutAudio = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ReverseButton = new System.Windows.Forms.Button();
            this.IncreaseVolumeButton = new System.Windows.Forms.Button();
            this.DecreaseVolumeButton = new System.Windows.Forms.Button();
            this.SoundWaveButton = new System.Windows.Forms.Button();
            this.VolumeLevelDiagramButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CycleCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoopCountValue = new System.Windows.Forms.TextBox();
            this.Mp3ToWavButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(8, 6);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(192, 40);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load audio";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(51, 567);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(194, 45);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(295, 567);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(193, 45);
            this.PauseButton.TabIndex = 2;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(463, 262);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SaveButton);
            this.tabPage1.Controls.Add(this.LoadButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(455, 233);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(8, 61);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(192, 44);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save audio";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(455, 233);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CutAudio
            // 
            this.CutAudio.Location = new System.Drawing.Point(1000, 82);
            this.CutAudio.Name = "CutAudio";
            this.CutAudio.Size = new System.Drawing.Size(198, 53);
            this.CutAudio.TabIndex = 4;
            this.CutAudio.Text = "Cut";
            this.CutAudio.UseVisualStyleBackColor = true;
            this.CutAudio.Click += new System.EventHandler(this.CutAudio_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(51, 318);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(868, 198);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(999, 151);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(199, 22);
            this.textBox1.TabIndex = 7;
            // 
            // ReverseButton
            // 
            this.ReverseButton.Location = new System.Drawing.Point(788, 82);
            this.ReverseButton.Name = "ReverseButton";
            this.ReverseButton.Size = new System.Drawing.Size(182, 53);
            this.ReverseButton.TabIndex = 8;
            this.ReverseButton.Text = "Reverse";
            this.ReverseButton.UseVisualStyleBackColor = true;
            this.ReverseButton.Click += new System.EventHandler(this.ReverseButton_Click);
            // 
            // IncreaseVolumeButton
            // 
            this.IncreaseVolumeButton.Location = new System.Drawing.Point(542, 567);
            this.IncreaseVolumeButton.Name = "IncreaseVolumeButton";
            this.IncreaseVolumeButton.Size = new System.Drawing.Size(184, 45);
            this.IncreaseVolumeButton.TabIndex = 9;
            this.IncreaseVolumeButton.Text = "Increase Volume Level";
            this.IncreaseVolumeButton.UseVisualStyleBackColor = true;
            this.IncreaseVolumeButton.Click += new System.EventHandler(this.IncreaseVolumeButton_Click);
            // 
            // DecreaseVolumeButton
            // 
            this.DecreaseVolumeButton.Location = new System.Drawing.Point(778, 566);
            this.DecreaseVolumeButton.Name = "DecreaseVolumeButton";
            this.DecreaseVolumeButton.Size = new System.Drawing.Size(183, 46);
            this.DecreaseVolumeButton.TabIndex = 10;
            this.DecreaseVolumeButton.Text = "Decrease Volume Level";
            this.DecreaseVolumeButton.UseVisualStyleBackColor = true;
            this.DecreaseVolumeButton.Click += new System.EventHandler(this.DecreaseVolumeButton_Click);
            // 
            // SoundWaveButton
            // 
            this.SoundWaveButton.Location = new System.Drawing.Point(984, 318);
            this.SoundWaveButton.Name = "SoundWaveButton";
            this.SoundWaveButton.Size = new System.Drawing.Size(156, 63);
            this.SoundWaveButton.TabIndex = 11;
            this.SoundWaveButton.Text = "Show Sound Wave";
            this.SoundWaveButton.UseVisualStyleBackColor = true;
            this.SoundWaveButton.Click += new System.EventHandler(this.SoundWaveButton_Click);
            // 
            // VolumeLevelDiagramButton
            // 
            this.VolumeLevelDiagramButton.Location = new System.Drawing.Point(984, 422);
            this.VolumeLevelDiagramButton.Name = "VolumeLevelDiagramButton";
            this.VolumeLevelDiagramButton.Size = new System.Drawing.Size(156, 61);
            this.VolumeLevelDiagramButton.TabIndex = 12;
            this.VolumeLevelDiagramButton.Text = "Show Volume Level Diagram";
            this.VolumeLevelDiagramButton.UseVisualStyleBackColor = true;
            this.VolumeLevelDiagramButton.Click += new System.EventHandler(this.VolumeLevelDiagramButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(51, 318);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(868, 198);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // CycleCheckBox
            // 
            this.CycleCheckBox.AutoSize = true;
            this.CycleCheckBox.Location = new System.Drawing.Point(106, 619);
            this.CycleCheckBox.Name = "CycleCheckBox";
            this.CycleCheckBox.Size = new System.Drawing.Size(104, 21);
            this.CycleCheckBox.TabIndex = 14;
            this.CycleCheckBox.Text = "Cycle Audio";
            this.CycleCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(571, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "Loop Count";
            // 
            // LoopCountValue
            // 
            this.LoopCountValue.Location = new System.Drawing.Point(576, 135);
            this.LoopCountValue.Name = "LoopCountValue";
            this.LoopCountValue.Size = new System.Drawing.Size(143, 22);
            this.LoopCountValue.TabIndex = 16;
            // 
            // Mp3ToWavButton
            // 
            this.Mp3ToWavButton.Location = new System.Drawing.Point(753, 218);
            this.Mp3ToWavButton.Name = "Mp3ToWavButton";
            this.Mp3ToWavButton.Size = new System.Drawing.Size(165, 43);
            this.Mp3ToWavButton.TabIndex = 17;
            this.Mp3ToWavButton.Text = "Covert To Wave Format";
            this.Mp3ToWavButton.UseVisualStyleBackColor = true;
            this.Mp3ToWavButton.Click += new System.EventHandler(this.Mp3ToWavButton_Click);
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.Mp3ToWavButton);
            this.Controls.Add(this.LoopCountValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CycleCheckBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.VolumeLevelDiagramButton);
            this.Controls.Add(this.SoundWaveButton);
            this.Controls.Add(this.DecreaseVolumeButton);
            this.Controls.Add(this.IncreaseVolumeButton);
            this.Controls.Add(this.ReverseButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.CutAudio);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.PlayButton);
            this.Name = "UI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CutAudio;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ReverseButton;
        private System.Windows.Forms.Button IncreaseVolumeButton;
        private System.Windows.Forms.Button DecreaseVolumeButton;
        private System.Windows.Forms.Button SoundWaveButton;
        private System.Windows.Forms.Button VolumeLevelDiagramButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox CycleCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LoopCountValue;
        private System.Windows.Forms.Button Mp3ToWavButton;
    }
}

