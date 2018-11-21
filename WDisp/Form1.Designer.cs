namespace WDisp
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.labelDebug1 = new System.Windows.Forms.Label();
            this.TextBoxDebug = new System.Windows.Forms.RichTextBox();
            this.buttonColor1 = new System.Windows.Forms.Button();
            this.buttonColor3 = new System.Windows.Forms.Button();
            this.buttonColor2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(10, 440);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.buttonColor2);
            this.splitContainerMain.Panel1.Controls.Add(this.buttonColor3);
            this.splitContainerMain.Panel1.Controls.Add(this.buttonColor1);
            this.splitContainerMain.Panel1.Controls.Add(this.labelDebug1);
            this.splitContainerMain.Panel1.Controls.Add(this.TextBoxDebug);
            this.splitContainerMain.Panel1.Controls.Add(this.buttonRefresh);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainerMain.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainerMain.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainerMain_Panel2_Paint);
            this.splitContainerMain.Panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.splitContainerMain_Panel2_MouseClick);
            this.splitContainerMain.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitContainerMain_Panel2_MouseDown);
            this.splitContainerMain.Panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitContainerMain_Panel2_MouseMove);
            this.splitContainerMain.Panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitContainerMain_Panel2_MouseUp);
            this.splitContainerMain.Size = new System.Drawing.Size(778, 483);
            this.splitContainerMain.SplitterDistance = 192;
            this.splitContainerMain.TabIndex = 0;
            // 
            // labelDebug1
            // 
            this.labelDebug1.AutoSize = true;
            this.labelDebug1.Location = new System.Drawing.Point(20, 466);
            this.labelDebug1.Name = "labelDebug1";
            this.labelDebug1.Size = new System.Drawing.Size(24, 13);
            this.labelDebug1.TabIndex = 0;
            this.labelDebug1.Text = "X,Y";
            // 
            // TextBoxDebug
            // 
            this.TextBoxDebug.Location = new System.Drawing.Point(10, 3);
            this.TextBoxDebug.Name = "TextBoxDebug";
            this.TextBoxDebug.Size = new System.Drawing.Size(252, 261);
            this.TextBoxDebug.TabIndex = 2;
            this.TextBoxDebug.Text = "";
            // 
            // buttonColor1
            // 
            this.buttonColor1.BackColor = System.Drawing.Color.White;
            this.buttonColor1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonColor1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonColor1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonColor1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColor1.Location = new System.Drawing.Point(101, 382);
            this.buttonColor1.Name = "buttonColor1";
            this.buttonColor1.Size = new System.Drawing.Size(40, 23);
            this.buttonColor1.TabIndex = 0;
            this.buttonColor1.UseVisualStyleBackColor = false;
            this.buttonColor1.Click += new System.EventHandler(this.buttonColor1_Click);
            // 
            // buttonColor3
            // 
            this.buttonColor3.BackColor = System.Drawing.Color.Green;
            this.buttonColor3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonColor3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonColor3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.buttonColor3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColor3.Location = new System.Drawing.Point(101, 440);
            this.buttonColor3.Name = "buttonColor3";
            this.buttonColor3.Size = new System.Drawing.Size(40, 23);
            this.buttonColor3.TabIndex = 3;
            this.buttonColor3.UseVisualStyleBackColor = false;
            this.buttonColor3.Click += new System.EventHandler(this.buttonColor3_Click);
            // 
            // buttonColor2
            // 
            this.buttonColor2.BackColor = System.Drawing.Color.Yellow;
            this.buttonColor2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonColor2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.buttonColor2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.buttonColor2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColor2.Location = new System.Drawing.Point(101, 411);
            this.buttonColor2.Name = "buttonColor2";
            this.buttonColor2.Size = new System.Drawing.Size(40, 23);
            this.buttonColor2.TabIndex = 4;
            this.buttonColor2.UseVisualStyleBackColor = false;
            this.buttonColor2.Click += new System.EventHandler(this.buttonColor2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(778, 483);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "Form1";
            this.Text = "WDisp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Label labelDebug1;
        private System.Windows.Forms.RichTextBox TextBoxDebug;
        private System.Windows.Forms.Button buttonColor1;
        private System.Windows.Forms.Button buttonColor2;
        private System.Windows.Forms.Button buttonColor3;
    }
}

