namespace TELEGRAM_SPAMER.Views
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Time_NUD = new System.Windows.Forms.NumericUpDown();
            this.NameForm_L = new System.Windows.Forms.Label();
            this.CodeName_L = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Cancel_B = new System.Windows.Forms.Button();
            this.OK_B = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Time_NUD)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Time_NUD, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.NameForm_L, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CodeName_L, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(459, 227);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Time_NUD
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.Time_NUD, 2);
            this.Time_NUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Time_NUD.Font = new System.Drawing.Font("Verdana", 12F);
            this.Time_NUD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(28)))), ((int)(((byte)(61)))));
            this.Time_NUD.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.Time_NUD.Location = new System.Drawing.Point(306, 55);
            this.Time_NUD.Margin = new System.Windows.Forms.Padding(0, 7, 5, 3);
            this.Time_NUD.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.Time_NUD.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Time_NUD.Name = "Time_NUD";
            this.Time_NUD.Size = new System.Drawing.Size(148, 27);
            this.Time_NUD.TabIndex = 26;
            this.Time_NUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Time_NUD.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            // 
            // NameForm_L
            // 
            this.NameForm_L.AutoSize = true;
            this.NameForm_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.tableLayoutPanel1.SetColumnSpan(this.NameForm_L, 3);
            this.NameForm_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameForm_L.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NameForm_L.Font = new System.Drawing.Font("Verdana", 14F);
            this.NameForm_L.ForeColor = System.Drawing.Color.White;
            this.NameForm_L.Location = new System.Drawing.Point(5, 5);
            this.NameForm_L.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.NameForm_L.Name = "NameForm_L";
            this.NameForm_L.Padding = new System.Windows.Forms.Padding(10);
            this.NameForm_L.Size = new System.Drawing.Size(449, 43);
            this.NameForm_L.TabIndex = 0;
            this.NameForm_L.Text = "Параметры";
            this.NameForm_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CodeName_L
            // 
            this.CodeName_L.AutoSize = true;
            this.CodeName_L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeName_L.Font = new System.Drawing.Font("Verdana", 10F);
            this.CodeName_L.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(28)))), ((int)(((byte)(61)))));
            this.CodeName_L.Location = new System.Drawing.Point(5, 53);
            this.CodeName_L.Margin = new System.Windows.Forms.Padding(5);
            this.CodeName_L.Name = "CodeName_L";
            this.CodeName_L.Size = new System.Drawing.Size(296, 27);
            this.CodeName_L.TabIndex = 10;
            this.CodeName_L.Text = "Время между инъекциями скрипта [мс]";
            this.CodeName_L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.Cancel_B, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.OK_B, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 186);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(459, 41);
            this.tableLayoutPanel2.TabIndex = 25;
            // 
            // Cancel_B
            // 
            this.Cancel_B.BackColor = System.Drawing.Color.White;
            this.Cancel_B.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cancel_B.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cancel_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.Cancel_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.Cancel_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.Cancel_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_B.Font = new System.Drawing.Font("Verdana", 10F);
            this.Cancel_B.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(92)))), ((int)(((byte)(161)))));
            this.Cancel_B.Location = new System.Drawing.Point(231, 0);
            this.Cancel_B.Margin = new System.Windows.Forms.Padding(2, 0, 5, 5);
            this.Cancel_B.Name = "Cancel_B";
            this.Cancel_B.Size = new System.Drawing.Size(223, 36);
            this.Cancel_B.TabIndex = 7;
            this.Cancel_B.Text = "Отмена";
            this.Cancel_B.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Cancel_B.UseVisualStyleBackColor = false;
            // 
            // OK_B
            // 
            this.OK_B.BackColor = System.Drawing.Color.White;
            this.OK_B.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OK_B.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OK_B.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.OK_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.OK_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.OK_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_B.Font = new System.Drawing.Font("Verdana", 10F);
            this.OK_B.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(92)))), ((int)(((byte)(161)))));
            this.OK_B.Location = new System.Drawing.Point(5, 0);
            this.OK_B.Margin = new System.Windows.Forms.Padding(5, 0, 2, 5);
            this.OK_B.Name = "OK_B";
            this.OK_B.Size = new System.Drawing.Size(222, 36);
            this.OK_B.TabIndex = 6;
            this.OK_B.Text = "Подтвердить";
            this.OK_B.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OK_B.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.button2, 3);
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 10F);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(92)))), ((int)(((byte)(161)))));
            this.button2.Location = new System.Drawing.Point(5, 85);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(449, 36);
            this.button2.TabIndex = 29;
            this.button2.Text = "Очистить кэш браузера и перезапустить приложение";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(459, 227);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Time_NUD)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label NameForm_L;
        private System.Windows.Forms.Label CodeName_L;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Cancel_B;
        private System.Windows.Forms.Button OK_B;
        public System.Windows.Forms.NumericUpDown Time_NUD;
        private System.Windows.Forms.Button button2;
    }
}