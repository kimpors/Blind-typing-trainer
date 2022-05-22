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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Start = new System.Windows.Forms.Button();
            this.StartTimer = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.allTime = new System.Windows.Forms.Label();
            this.aveSpeed = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ukraineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.russiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.nsButton1 = new Blind_typing_trainer.NSButton();
            this.Reset = new Blind_typing_trainer.NSButton();
            this.Theme = new Blind_typing_trainer.NSButton();
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
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // Start
            // 
            resources.ApplyResources(this.Start, "Start");
            this.Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start.FlatAppearance.BorderSize = 0;
            this.Start.Name = "Start";
            this.Start.TabStop = false;
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // StartTimer
            // 
            resources.ApplyResources(this.StartTimer, "StartTimer");
            this.StartTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartTimer.ForeColor = System.Drawing.SystemColors.Menu;
            this.StartTimer.Name = "StartTimer";
            // 
            // Time
            // 
            resources.ApplyResources(this.Time, "Time");
            this.Time.ForeColor = System.Drawing.SystemColors.Menu;
            this.Time.Name = "Time";
            // 
            // Speed
            // 
            resources.ApplyResources(this.Speed, "Speed");
            this.Speed.ForeColor = System.Drawing.SystemColors.Menu;
            this.Speed.Name = "Speed";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.Reset);
            this.panel1.Controls.Add(this.Theme);
            this.panel1.Controls.Add(this.allTime);
            this.panel1.Controls.Add(this.aveSpeed);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.Start);
            this.panel1.Controls.Add(this.Time);
            this.panel1.Controls.Add(this.Speed);
            this.panel1.Name = "panel1";
            // 
            // allTime
            // 
            resources.ApplyResources(this.allTime, "allTime");
            this.allTime.Name = "allTime";
            // 
            // aveSpeed
            // 
            resources.ApplyResources(this.aveSpeed, "aveSpeed");
            this.aveSpeed.Name = "aveSpeed";
            // 
            // chart1
            // 
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BorderWidth = 3;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            resources.ApplyResources(this.chart1, "chart1");
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.themeToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.ukraineToolStripMenuItem,
            this.russiaToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // ukraineToolStripMenuItem
            // 
            this.ukraineToolStripMenuItem.Name = "ukraineToolStripMenuItem";
            resources.ApplyResources(this.ukraineToolStripMenuItem, "ukraineToolStripMenuItem");
            this.ukraineToolStripMenuItem.Click += new System.EventHandler(this.ukraineToolStripMenuItem_Click);
            // 
            // russiaToolStripMenuItem
            // 
            this.russiaToolStripMenuItem.Name = "russiaToolStripMenuItem";
            resources.ApplyResources(this.russiaToolStripMenuItem, "russiaToolStripMenuItem");
            this.russiaToolStripMenuItem.Click += new System.EventHandler(this.russiaToolStripMenuItem_Click);
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            resources.ApplyResources(this.themeToolStripMenuItem, "themeToolStripMenuItem");
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            resources.ApplyResources(this.infoToolStripMenuItem, "infoToolStripMenuItem");
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // nsButton1
            // 
            resources.ApplyResources(this.nsButton1, "nsButton1");
            this.nsButton1.FlatAppearance.BorderSize = 0;
            this.nsButton1.Name = "nsButton1";
            this.nsButton1.UseVisualStyleBackColor = true;
            this.nsButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Reset
            // 
            this.Reset.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.Reset, "Reset");
            this.Reset.Name = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Theme
            // 
            this.Theme.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.Theme, "Theme");
            this.Theme.Name = "Theme";
            this.Theme.UseVisualStyleBackColor = true;
            this.Theme.Click += new System.EventHandler(this.Theme_Click);
            // 
            // TypingField
            // 
            resources.ApplyResources(this.TypingField, "TypingField");
            this.TypingField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TypingField.CausesValidation = false;
            this.TypingField.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TypingField.DetectUrls = false;
            this.TypingField.Name = "TypingField";
            this.TypingField.ReadOnly = true;
            this.TypingField.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CausesValidation = false;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.nsButton1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StartTimer);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.TypingField);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
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
        private System.Windows.Forms.Label aveSpeed;
        private System.Windows.Forms.Label allTime;
        private RichLabel TypingField;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private NSButton Reset;
        private NSButton Theme;
        private NSButton nsButton1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ukraineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem russiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
    }
}

