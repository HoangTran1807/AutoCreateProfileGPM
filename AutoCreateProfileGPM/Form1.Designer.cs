namespace AutoCreateProfileGPM
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_test = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.lb_sessionfile = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_f2aDisplay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_refreshGroup = new System.Windows.Forms.Button();
            this.txt_FolderSession = new System.Windows.Forms.TextBox();
            this.N_Thread = new System.Windows.Forms.NumericUpDown();
            this.cbo_GPMGroup = new System.Windows.Forms.ComboBox();
            this.txt_F2A = new System.Windows.Forms.TextBox();
            this.btn_browser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.N_Thread)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_test);
            this.panel1.Controls.Add(this.btn_start);
            this.panel1.Controls.Add(this.lb_sessionfile);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 339);
            this.panel1.TabIndex = 0;
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(414, 301);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(98, 24);
            this.btn_test.TabIndex = 13;
            this.btn_test.Text = "test";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(221, 301);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(98, 24);
            this.btn_start.TabIndex = 11;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // lb_sessionfile
            // 
            this.lb_sessionfile.FormattingEnabled = true;
            this.lb_sessionfile.ItemHeight = 16;
            this.lb_sessionfile.Location = new System.Drawing.Point(561, 12);
            this.lb_sessionfile.Name = "lb_sessionfile";
            this.lb_sessionfile.Size = new System.Drawing.Size(204, 260);
            this.lb_sessionfile.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_f2aDisplay);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_refreshGroup);
            this.panel2.Controls.Add(this.txt_FolderSession);
            this.panel2.Controls.Add(this.N_Thread);
            this.panel2.Controls.Add(this.cbo_GPMGroup);
            this.panel2.Controls.Add(this.txt_F2A);
            this.panel2.Controls.Add(this.btn_browser);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(543, 255);
            this.panel2.TabIndex = 10;
            // 
            // btn_f2aDisplay
            // 
            this.btn_f2aDisplay.Location = new System.Drawing.Point(402, 93);
            this.btn_f2aDisplay.Name = "btn_f2aDisplay";
            this.btn_f2aDisplay.Size = new System.Drawing.Size(98, 24);
            this.btn_f2aDisplay.TabIndex = 10;
            this.btn_f2aDisplay.Text = "Show";
            this.btn_f2aDisplay.UseVisualStyleBackColor = true;
            this.btn_f2aDisplay.Click += new System.EventHandler(this.btn_f2aDisplay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Session Folder ";
            // 
            // btn_refreshGroup
            // 
            this.btn_refreshGroup.Location = new System.Drawing.Point(402, 148);
            this.btn_refreshGroup.Name = "btn_refreshGroup";
            this.btn_refreshGroup.Size = new System.Drawing.Size(98, 24);
            this.btn_refreshGroup.TabIndex = 9;
            this.btn_refreshGroup.Text = "Refresh";
            this.btn_refreshGroup.UseVisualStyleBackColor = true;
            this.btn_refreshGroup.Click += new System.EventHandler(this.btn_refreshGroup_Click);
            // 
            // txt_FolderSession
            // 
            this.txt_FolderSession.Location = new System.Drawing.Point(209, 39);
            this.txt_FolderSession.Name = "txt_FolderSession";
            this.txt_FolderSession.Size = new System.Drawing.Size(174, 22);
            this.txt_FolderSession.TabIndex = 1;
            // 
            // N_Thread
            // 
            this.N_Thread.Location = new System.Drawing.Point(209, 206);
            this.N_Thread.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.N_Thread.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.N_Thread.Name = "N_Thread";
            this.N_Thread.Size = new System.Drawing.Size(291, 22);
            this.N_Thread.TabIndex = 8;
            this.N_Thread.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbo_GPMGroup
            // 
            this.cbo_GPMGroup.FormattingEnabled = true;
            this.cbo_GPMGroup.Location = new System.Drawing.Point(209, 148);
            this.cbo_GPMGroup.Name = "cbo_GPMGroup";
            this.cbo_GPMGroup.Size = new System.Drawing.Size(174, 24);
            this.cbo_GPMGroup.TabIndex = 2;
            // 
            // txt_F2A
            // 
            this.txt_F2A.Location = new System.Drawing.Point(209, 95);
            this.txt_F2A.Name = "txt_F2A";
            this.txt_F2A.Size = new System.Drawing.Size(174, 22);
            this.txt_F2A.TabIndex = 7;
            // 
            // btn_browser
            // 
            this.btn_browser.Location = new System.Drawing.Point(402, 37);
            this.btn_browser.Name = "btn_browser";
            this.btn_browser.Size = new System.Drawing.Size(98, 24);
            this.btn_browser.TabIndex = 3;
            this.btn_browser.Text = "Browser";
            this.btn_browser.UseVisualStyleBackColor = true;
            this.btn_browser.Click += new System.EventHandler(this.btn_browser_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "NumberOfThread";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "F2A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Group GPM";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 339);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.N_Thread)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_browser;
        private System.Windows.Forms.ComboBox cbo_GPMGroup;
        private System.Windows.Forms.TextBox txt_FolderSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_refreshGroup;
        private System.Windows.Forms.NumericUpDown N_Thread;
        private System.Windows.Forms.TextBox txt_F2A;
        private System.Windows.Forms.Button btn_f2aDisplay;
        private System.Windows.Forms.ListBox lb_sessionfile;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_test;
    }
}

