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
            this.Reset = new Blind_typing_trainer.NSButton();
            this.StartTimer = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.Label();
            this.record = new System.Windows.Forms.Label();
            this.allTime = new System.Windows.Forms.Label();
            this.aveSpeed = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loremIpsumGenerateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ukraineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.russiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Start = new Blind_typing_trainer.NSButton();
            this.panelShow = new Blind_typing_trainer.NSButton();
            this.TypingField = new Blind_typing_trainer.RichLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // Reset
            // 
            resources.ApplyResources(this.Reset, "Reset");
            this.Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Reset.FlatAppearance.BorderSize = 0;
            this.Reset.Name = "Reset";
            this.toolTip1.SetToolTip(this.Reset, resources.GetString("Reset.ToolTip"));
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // StartTimer
            // 
            resources.ApplyResources(this.StartTimer, "StartTimer");
            this.StartTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartTimer.ForeColor = System.Drawing.SystemColors.Menu;
            this.StartTimer.Name = "StartTimer";
            this.toolTip1.SetToolTip(this.StartTimer, resources.GetString("StartTimer.ToolTip"));
            // 
            // Time
            // 
            resources.ApplyResources(this.Time, "Time");
            this.Time.ForeColor = System.Drawing.SystemColors.Menu;
            this.Time.Name = "Time";
            this.toolTip1.SetToolTip(this.Time, resources.GetString("Time.ToolTip"));
            // 
            // Speed
            // 
            resources.ApplyResources(this.Speed, "Speed");
            this.Speed.ForeColor = System.Drawing.SystemColors.Menu;
            this.Speed.Name = "Speed";
            this.toolTip1.SetToolTip(this.Speed, resources.GetString("Speed.ToolTip"));
            // 
            // record
            // 
            resources.ApplyResources(this.record, "record");
            this.record.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.record.Name = "record";
            this.toolTip1.SetToolTip(this.record, resources.GetString("record.ToolTip"));
            // 
            // allTime
            // 
            resources.ApplyResources(this.allTime, "allTime");
            this.allTime.Name = "allTime";
            this.toolTip1.SetToolTip(this.allTime, resources.GetString("allTime.ToolTip"));
            // 
            // aveSpeed
            // 
            resources.ApplyResources(this.aveSpeed, "aveSpeed");
            this.aveSpeed.Name = "aveSpeed";
            this.toolTip1.SetToolTip(this.aveSpeed, resources.GetString("aveSpeed.ToolTip"));
            // 
            // chart1
            // 
            resources.ApplyResources(this.chart1, "chart1");
            this.chart1.BackImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.chart1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BorderWidth = 0;
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.IsSoftShadows = false;
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DarkHorizontal;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.IsVisibleInLegend = false;
            series1.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series1.LabelBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series1.LabelBorderWidth = 0;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            series1.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chart1.Series.Add(series1);
            this.chart1.TabStop = false;
            this.toolTip1.SetToolTip(this.chart1, resources.GetString("chart1.ToolTip"));
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Name = "menuStrip1";
            this.toolTip1.SetToolTip(this.menuStrip1, resources.GetString("menuStrip1.ToolTip"));
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.loremIpsumGenerateToolStripMenuItem,
            this.onlineGeneratorToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // openToolStripMenuItem
            // 
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // loremIpsumGenerateToolStripMenuItem
            // 
            resources.ApplyResources(this.loremIpsumGenerateToolStripMenuItem, "loremIpsumGenerateToolStripMenuItem");
            this.loremIpsumGenerateToolStripMenuItem.Name = "loremIpsumGenerateToolStripMenuItem";
            this.loremIpsumGenerateToolStripMenuItem.Click += new System.EventHandler(this.loremIpsumGenerateToolStripMenuItem_Click);
            // 
            // onlineGeneratorToolStripMenuItem
            // 
            resources.ApplyResources(this.onlineGeneratorToolStripMenuItem, "onlineGeneratorToolStripMenuItem");
            this.onlineGeneratorToolStripMenuItem.Name = "onlineGeneratorToolStripMenuItem";
            this.onlineGeneratorToolStripMenuItem.Click += new System.EventHandler(this.onlineGeneratorToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.themeToolStripMenuItem,
            this.themeSelectToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            // 
            // languageToolStripMenuItem
            // 
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.ukraineToolStripMenuItem,
            this.russiaToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // ukraineToolStripMenuItem
            // 
            resources.ApplyResources(this.ukraineToolStripMenuItem, "ukraineToolStripMenuItem");
            this.ukraineToolStripMenuItem.Name = "ukraineToolStripMenuItem";
            this.ukraineToolStripMenuItem.Click += new System.EventHandler(this.ukraineToolStripMenuItem_Click);
            // 
            // russiaToolStripMenuItem
            // 
            resources.ApplyResources(this.russiaToolStripMenuItem, "russiaToolStripMenuItem");
            this.russiaToolStripMenuItem.Name = "russiaToolStripMenuItem";
            this.russiaToolStripMenuItem.Click += new System.EventHandler(this.russiaToolStripMenuItem_Click);
            // 
            // themeToolStripMenuItem
            // 
            resources.ApplyResources(this.themeToolStripMenuItem, "themeToolStripMenuItem");
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Click += new System.EventHandler(this.themeToolStripMenuItem_Click);
            // 
            // themeSelectToolStripMenuItem
            // 
            resources.ApplyResources(this.themeSelectToolStripMenuItem, "themeSelectToolStripMenuItem");
            this.themeSelectToolStripMenuItem.Name = "themeSelectToolStripMenuItem";
            this.themeSelectToolStripMenuItem.MouseEnter += new System.EventHandler(this.themeSelectToolStripMenuItem_MouseEnter);
            // 
            // infoToolStripMenuItem
            // 
            resources.ApplyResources(this.infoToolStripMenuItem, "infoToolStripMenuItem");
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.chart1);
            this.panel2.Name = "panel2";
            this.toolTip1.SetToolTip(this.panel2, resources.GetString("panel2.ToolTip"));
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.Reset);
            this.panel1.Controls.Add(this.Start);
            this.panel1.Controls.Add(this.record);
            this.panel1.Controls.Add(this.allTime);
            this.panel1.Controls.Add(this.aveSpeed);
            this.panel1.Controls.Add(this.Time);
            this.panel1.Controls.Add(this.Speed);
            this.panel1.Name = "panel1";
            this.toolTip1.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
            // 
            // Start
            // 
            resources.ApplyResources(this.Start, "Start");
            this.Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start.FlatAppearance.BorderSize = 0;
            this.Start.Name = "Start";
            this.toolTip1.SetToolTip(this.Start, resources.GetString("Start.ToolTip"));
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // panelShow
            // 
            resources.ApplyResources(this.panelShow, "panelShow");
            this.panelShow.FlatAppearance.BorderSize = 0;
            this.panelShow.Name = "panelShow";
            this.toolTip1.SetToolTip(this.panelShow, resources.GetString("panelShow.ToolTip"));
            this.panelShow.UseVisualStyleBackColor = true;
            this.panelShow.Click += new System.EventHandler(this.panelShow_Click);
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
            this.toolTip1.SetToolTip(this.TypingField, resources.GetString("TypingField.ToolTip"));
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CausesValidation = false;
            this.Controls.Add(this.StartTimer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelShow);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.TypingField);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerTick;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label Speed;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label StartTimer;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label aveSpeed;
        private System.Windows.Forms.Label allTime;
        private RichLabel TypingField;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private NSButton panelShow;
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
        private System.Windows.Forms.ToolStripMenuItem loremIpsumGenerateToolStripMenuItem;
        private System.Windows.Forms.Label record;
        private System.Windows.Forms.ToolStripMenuItem themeSelectToolStripMenuItem;
        private NSButton Start;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem onlineGeneratorToolStripMenuItem;
        private NSButton Reset;
    }
}

