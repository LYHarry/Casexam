namespace 截图
{
    partial class CutterForm
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
            this.SuspendLayout();
            // 
            // CutterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CutterForm";
            this.Text = "CutterForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CutterForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CutterForm_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CutterForm_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CutterForm_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CutterForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CutterForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CutterForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}