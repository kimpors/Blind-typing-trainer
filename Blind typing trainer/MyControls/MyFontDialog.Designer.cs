namespace Blind_typing_trainer.MyControls
{
    partial class MyFontDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyFontDialog));
            this.fonts = new System.Windows.Forms.ComboBox();
            this.sizes = new System.Windows.Forms.ComboBox();
            this.styles = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.example = new System.Windows.Forms.Label();
            this.Ok = new Blind_typing_trainer.NSButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fonts
            // 
            resources.ApplyResources(this.fonts, "fonts");
            this.fonts.DropDownHeight = 100;
            this.fonts.FormattingEnabled = true;
            this.fonts.Name = "fonts";
            this.fonts.Sorted = true;
            this.fonts.SelectedIndexChanged += new System.EventHandler(this.fonts_SelectedIndexChanged);
            // 
            // sizes
            // 
            resources.ApplyResources(this.sizes, "sizes");
            this.sizes.DropDownHeight = 100;
            this.sizes.FormattingEnabled = true;
            this.sizes.Name = "sizes";
            this.sizes.SelectedIndexChanged += new System.EventHandler(this.sizes_SelectedIndexChanged);
            // 
            // styles
            // 
            resources.ApplyResources(this.styles, "styles");
            this.styles.DropDownHeight = 100;
            this.styles.FormattingEnabled = true;
            this.styles.Name = "styles";
            this.styles.Sorted = true;
            this.styles.SelectedIndexChanged += new System.EventHandler(this.styles_SelectedIndexChanged);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.example);
            this.panel1.Name = "panel1";
            // 
            // example
            // 
            resources.ApplyResources(this.example, "example");
            this.example.Name = "example";
            // 
            // Ok
            // 
            resources.ApplyResources(this.Ok, "Ok");
            this.Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok.FlatAppearance.BorderSize = 0;
            this.Ok.Name = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Yes_Click);
            // 
            // MyFontDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.styles);
            this.Controls.Add(this.sizes);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.fonts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MyFontDialog";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox fonts;
        private NSButton Ok;
        private System.Windows.Forms.ComboBox sizes;
        private System.Windows.Forms.ComboBox styles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label example;
    }
}