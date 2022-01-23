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
            this.TypingField = new System.Windows.Forms.RichTextBox();
            this.Start = new System.Windows.Forms.Button();
            this.Time = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TypingField
            // 
            this.TypingField.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TypingField.DetectUrls = false;
            this.TypingField.Enabled = false;
            this.TypingField.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypingField.Location = new System.Drawing.Point(12, 12);
            this.TypingField.Name = "TypingField";
            this.TypingField.ReadOnly = true;
            this.TypingField.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.TypingField.ShowSelectionMargin = true;
            this.TypingField.Size = new System.Drawing.Size(721, 239);
            this.TypingField.TabIndex = 0;
            this.TypingField.Text = "";
            // 
            // Start
            // 
            this.Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start.Location = new System.Drawing.Point(12, 290);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(96, 38);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(53, 254);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(49, 13);
            this.Time.TabIndex = 2;
            this.Time.Text = "00:00:00";
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.Location = new System.Drawing.Point(145, 255);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(31, 13);
            this.Speed.TabIndex = 5;
            this.Speed.Text = "0WP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Speed:";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(745, 341);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.TypingField);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blind typing trainer";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TypingField;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label Speed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

