namespace Blind_typing_trainer.MyControls
{
    partial class MyShortTextInfoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyShortTextInfoDialog));
            this.Ok = new Blind_typing_trainer.NSButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Ok
            // 
            this.Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.Ok, "Ok");
            this.Ok.Name = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // MyShortTextInfoDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MyShortTextInfoDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private NSButton Ok;
        private System.Windows.Forms.Label label1;
    }
}