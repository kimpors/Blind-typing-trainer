namespace Blind_typing_trainer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Start = new System.Windows.Forms.Button();
            this.StartTimer = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Reset = new Blind_typing_trainer.NSButton();
            this.Theme = new Blind_typing_trainer.NSButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ukraineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.russiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nsButton1 = new Blind_typing_trainer.NSButton();
            this.TypingField = new Blind_typing_trainer.RichLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerTick
            // 
            this.timerTick.Interval = 1000;
            this.timerTick.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text| *.txt;*.rtf";
            // 
            // Start
            // 
            this.Start.AutoSize = true;
            this.Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start.FlatAppearance.BorderSize = 0;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold);
            this.Start.Location = new System.Drawing.Point(3, 15);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(85, 28);
            this.Start.TabIndex = 1;
            this.Start.TabStop = false;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // StartTimer
            // 
            this.StartTimer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StartTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartTimer.ForeColor = System.Drawing.SystemColors.Menu;
            this.StartTimer.Location = new System.Drawing.Point(332, 183);
            this.StartTimer.Name = "StartTimer";
            this.StartTimer.Size = new System.Drawing.Size(98, 108);
            this.StartTimer.TabIndex = 9;
            this.StartTimer.Text = "3";
            this.StartTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time.ForeColor = System.Drawing.SystemColors.Menu;
            this.Time.Location = new System.Drawing.Point(3, 75);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(118, 21);
            this.Time.TabIndex = 2;
            this.Time.Text = "Time: 00:00:00";
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Speed.ForeColor = System.Drawing.SystemColors.Menu;
            this.Speed.Location = new System.Drawing.Point(3, 54);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(100, 21);
            this.Speed.TabIndex = 5;
            this.Speed.Text = "Speed: 0WP";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.Reset);
            this.panel1.Controls.Add(this.Theme);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.Start);
            this.panel1.Controls.Add(this.Time);
            this.panel1.Controls.Add(this.Speed);
            this.panel1.Location = new System.Drawing.Point(538, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 453);
            this.panel1.TabIndex = 15;
            this.panel1.Visible = false;
            // 
            // Reset
            // 
            this.Reset.FlatAppearance.BorderSize = 0;
            this.Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reset.Image = ((System.Drawing.Image)(resources.GetObject("Reset.Image")));
            this.Reset.Location = new System.Drawing.Point(134, 11);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(40, 32);
            this.Reset.TabIndex = 16;
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Theme
            // 
            this.Theme.FlatAppearance.BorderSize = 0;
            this.Theme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Theme.Image = ((System.Drawing.Image)(resources.GetObject("Theme.Image")));
            this.Theme.Location = new System.Drawing.Point(88, 11);
            this.Theme.Name = "Theme";
            this.Theme.Size = new System.Drawing.Size(40, 32);
            this.Theme.TabIndex = 15;
            this.Theme.UseVisualStyleBackColor = true;
            this.Theme.Click += new System.EventHandler(this.Theme_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "All time you train: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "Average speed: ";
            // 
            // chart1
            // 
            chartArea9.BackColor = System.Drawing.Color.White;
            chartArea9.BorderWidth = 3;
            chartArea9.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea9);
            this.chart1.Location = new System.Drawing.Point(3, 254);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Name = "Series1";
            this.chart1.Series.Add(series9);
            this.chart1.Size = new System.Drawing.Size(241, 172);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.AutoSize = false;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.modeToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freeToolStripMenuItem,
            this.raceToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // freeToolStripMenuItem
            // 
            this.freeToolStripMenuItem.CheckOnClick = true;
            this.freeToolStripMenuItem.Name = "freeToolStripMenuItem";
            this.freeToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.freeToolStripMenuItem.Text = "Free";
            // 
            // raceToolStripMenuItem
            // 
            this.raceToolStripMenuItem.CheckOnClick = true;
            this.raceToolStripMenuItem.Name = "raceToolStripMenuItem";
            this.raceToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.raceToolStripMenuItem.Text = "Race";
            this.raceToolStripMenuItem.ToolTipText = "Recomended for books ";
            this.raceToolStripMenuItem.Click += new System.EventHandler(this.raceToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.themeToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.ukraineToolStripMenuItem,
            this.russiaToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.languageToolStripMenuItem.Text = "Language";
            this.languageToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.englishToolStripMenuItem.Text = "English";
            // 
            // ukraineToolStripMenuItem
            // 
            this.ukraineToolStripMenuItem.Name = "ukraineToolStripMenuItem";
            this.ukraineToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.ukraineToolStripMenuItem.Text = "Ukraine";
            // 
            // russiaToolStripMenuItem
            // 
            this.russiaToolStripMenuItem.Name = "russiaToolStripMenuItem";
            this.russiaToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.russiaToolStripMenuItem.Text = "Russia";
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // nsButton1
            // 
            this.nsButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nsButton1.FlatAppearance.BorderSize = 0;
            this.nsButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nsButton1.Location = new System.Drawing.Point(709, 1);
            this.nsButton1.Name = "nsButton1";
            this.nsButton1.Size = new System.Drawing.Size(75, 23);
            this.nsButton1.TabIndex = 11;
            this.nsButton1.Text = "=";
            this.nsButton1.UseVisualStyleBackColor = true;
            this.nsButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TypingField
            // 
            this.TypingField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TypingField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TypingField.CausesValidation = false;
            this.TypingField.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TypingField.DetectUrls = false;
            this.TypingField.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypingField.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TypingField.Location = new System.Drawing.Point(0, 22);
            this.TypingField.Margin = new System.Windows.Forms.Padding(10);
            this.TypingField.Name = "TypingField";
            this.TypingField.ReadOnly = true;
            this.TypingField.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.TypingField.Size = new System.Drawing.Size(784, 443);
            this.TypingField.TabIndex = 0;
            this.TypingField.TabStop = false;
            this.TypingField.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(784, 465);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nsButton1);
            this.Controls.Add(this.StartTimer);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.TypingField);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blind typing trainer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerTick;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label Speed;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label StartTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private RichLabel TypingField;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private NSButton Reset;
        private NSButton Theme;
        private NSButton nsButton1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ukraineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem russiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
    }
}

