namespace TELEGRAM_SPAMER.Views
{
    partial class Console
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Console));
            this.Log_TB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Log_TB
            // 
            this.Log_TB.BackColor = System.Drawing.Color.Black;
            this.Log_TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Log_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Log_TB.Font = new System.Drawing.Font("Verdana", 11F);
            this.Log_TB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Log_TB.Location = new System.Drawing.Point(0, 0);
            this.Log_TB.Multiline = true;
            this.Log_TB.Name = "Log_TB";
            this.Log_TB.ReadOnly = true;
            this.Log_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log_TB.Size = new System.Drawing.Size(771, 426);
            this.Log_TB.TabIndex = 3;
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 426);
            this.Controls.Add(this.Log_TB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(787, 465);
            this.Name = "Console";
            this.Text = "Консоль";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Console_FormClosing);
            this.Load += new System.EventHandler(this.Console_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox Log_TB;
    }
}