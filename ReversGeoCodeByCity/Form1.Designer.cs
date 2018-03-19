namespace ReversGeoCodeByCity
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
            this.components = new System.ComponentModel.Container();
            this.btnLoad = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtProcessesed = new System.Windows.Forms.TextBox();
            this.txtUnprocessed = new System.Windows.Forms.TextBox();
            this.txtPercentage = new System.Windows.Forms.TextBox();
            this.txtGoogleMapsKey = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pBPercentage = new System.Windows.Forms.ProgressBar();
            this.txtExcel = new System.Windows.Forms.TextBox();
            this.lblPerc = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Location = new System.Drawing.Point(39, 27);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 43);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Ngarko";
            this.toolTip1.SetToolTip(this.btnLoad, "Ngarko skedarin Excel");
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(347, 21);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 43);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Nis";
            this.toolTip1.SetToolTip(this.btnStart, "Ngarko skedarin Excel");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtCount
            // 
            this.txtCount.BackColor = System.Drawing.Color.White;
            this.txtCount.Location = new System.Drawing.Point(115, 167);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(78, 20);
            this.txtCount.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtCount, "Numri i rreshtave në \r\nskedarin Excel");
            // 
            // txtProcessesed
            // 
            this.txtProcessesed.BackColor = System.Drawing.Color.White;
            this.txtProcessesed.Location = new System.Drawing.Point(199, 167);
            this.txtProcessesed.Name = "txtProcessesed";
            this.txtProcessesed.ReadOnly = true;
            this.txtProcessesed.Size = new System.Drawing.Size(78, 20);
            this.txtProcessesed.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtProcessesed, "Numri i rreshtave të gjetur");
            // 
            // txtUnprocessed
            // 
            this.txtUnprocessed.BackColor = System.Drawing.Color.White;
            this.txtUnprocessed.Location = new System.Drawing.Point(283, 167);
            this.txtUnprocessed.Name = "txtUnprocessed";
            this.txtUnprocessed.ReadOnly = true;
            this.txtUnprocessed.Size = new System.Drawing.Size(78, 20);
            this.txtUnprocessed.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtUnprocessed, "Numri i rreshtave të papërpunuar");
            // 
            // txtPercentage
            // 
            this.txtPercentage.BackColor = System.Drawing.Color.White;
            this.txtPercentage.Location = new System.Drawing.Point(367, 167);
            this.txtPercentage.Name = "txtPercentage";
            this.txtPercentage.ReadOnly = true;
            this.txtPercentage.Size = new System.Drawing.Size(78, 20);
            this.txtPercentage.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtPercentage, "Përqindja");
            this.txtPercentage.TextChanged += new System.EventHandler(this.txtPercentage_TextChanged);
            // 
            // txtGoogleMapsKey
            // 
            this.txtGoogleMapsKey.Location = new System.Drawing.Point(6, 31);
            this.txtGoogleMapsKey.Name = "txtGoogleMapsKey";
            this.txtGoogleMapsKey.Size = new System.Drawing.Size(335, 20);
            this.txtGoogleMapsKey.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.txtGoogleMapsKey);
            this.groupBox1.Location = new System.Drawing.Point(29, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 70);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Google Maps Key";
            // 
            // pBPercentage
            // 
            this.pBPercentage.Location = new System.Drawing.Point(39, 224);
            this.pBPercentage.Name = "pBPercentage";
            this.pBPercentage.Size = new System.Drawing.Size(513, 28);
            this.pBPercentage.TabIndex = 3;
            // 
            // txtExcel
            // 
            this.txtExcel.Location = new System.Drawing.Point(138, 39);
            this.txtExcel.Name = "txtExcel";
            this.txtExcel.Size = new System.Drawing.Size(335, 20);
            this.txtExcel.TabIndex = 8;
            // 
            // lblPerc
            // 
            this.lblPerc.AutoSize = true;
            this.lblPerc.BackColor = System.Drawing.Color.Transparent;
            this.lblPerc.Location = new System.Drawing.Point(280, 239);
            this.lblPerc.Name = "lblPerc";
            this.lblPerc.Size = new System.Drawing.Size(24, 13);
            this.lblPerc.TabIndex = 9;
            this.lblPerc.Text = "0 %";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(596, 282);
            this.Controls.Add(this.lblPerc);
            this.Controls.Add(this.txtExcel);
            this.Controls.Add(this.txtPercentage);
            this.Controls.Add(this.txtUnprocessed);
            this.Controls.Add(this.txtProcessesed);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.pBPercentage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximumSize = new System.Drawing.Size(616, 325);
            this.MinimumSize = new System.Drawing.Size(616, 325);
            this.Name = "Form1";
            this.Opacity = 0.85D;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtGoogleMapsKey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar pBPercentage;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.TextBox txtProcessesed;
        private System.Windows.Forms.TextBox txtUnprocessed;
        private System.Windows.Forms.TextBox txtPercentage;
        private System.Windows.Forms.TextBox txtExcel;
        private System.Windows.Forms.Label lblPerc;
    }
}

