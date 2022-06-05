namespace Blind_typing_trainer
{
    partial class InfoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoDialog));
            this.Ok = new Blind_typing_trainer.NSButton();
            this.richLabel1 = new Blind_typing_trainer.RichLabel();
            this.SuspendLayout();
            // 
            // Ok
            // 
            resources.ApplyResources(this.Ok, "Ok");
            this.Ok.FlatAppearance.BorderSize = 0;
            this.Ok.Name = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // richLabel1
            // 
            resources.ApplyResources(this.richLabel1, "richLabel1");
            this.richLabel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richLabel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richLabel1.Name = "richLabel1";
            this.richLabel1.ReadOnly = true;
            // 
            // InfoDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.richLabel1);
            this.Controls.Add(this.Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InfoDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private NSButton Ok;
        private RichLabel richLabel1;
    }
}