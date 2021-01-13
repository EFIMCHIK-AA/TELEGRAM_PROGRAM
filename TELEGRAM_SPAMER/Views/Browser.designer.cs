namespace TELEGRAM_SPAMER.Views
{
    partial class Browser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
            this.Table_TLP = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.URL_TB = new System.Windows.Forms.TextBox();
            this.Table_TLP.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Table_TLP
            // 
            this.Table_TLP.ColumnCount = 1;
            this.Table_TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Table_TLP.Controls.Add(this.panel1, 0, 0);
            this.Table_TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table_TLP.Location = new System.Drawing.Point(0, 0);
            this.Table_TLP.Margin = new System.Windows.Forms.Padding(0);
            this.Table_TLP.Name = "Table_TLP";
            this.Table_TLP.RowCount = 2;
            this.Table_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Table_TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Table_TLP.Size = new System.Drawing.Size(984, 711);
            this.Table_TLP.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.URL_TB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 40);
            this.panel1.TabIndex = 12;
            // 
            // URL_TB
            // 
            this.URL_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.URL_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.URL_TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.URL_TB.Font = new System.Drawing.Font("Verdana", 12F);
            this.URL_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))));
            this.URL_TB.Location = new System.Drawing.Point(9, 11);
            this.URL_TB.Name = "URL_TB";
            this.URL_TB.ReadOnly = true;
            this.URL_TB.Size = new System.Drawing.Size(966, 20);
            this.URL_TB.TabIndex = 2;
            this.URL_TB.TabStop = false;
            this.URL_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 711);
            this.Controls.Add(this.Table_TLP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 750);
            this.Name = "Browser";
            this.Text = "Браузер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Browser_FormClosing);
            this.Load += new System.EventHandler(this.Browser_Load);
            this.Table_TLP.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel Table_TLP;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox URL_TB;
    }
}