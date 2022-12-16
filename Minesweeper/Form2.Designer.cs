namespace Minesweeper
{
    partial class Form2
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btn_mainmenu = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_stopwatch = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(32, 31);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(892, 873);
            this.mainPanel.TabIndex = 0;
            // 
            // btn_mainmenu
            // 
            this.btn_mainmenu.BackColor = System.Drawing.Color.LightGray;
            this.btn_mainmenu.Font = new System.Drawing.Font("Atari Classic", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mainmenu.Location = new System.Drawing.Point(955, 859);
            this.btn_mainmenu.Name = "btn_mainmenu";
            this.btn_mainmenu.Size = new System.Drawing.Size(229, 45);
            this.btn_mainmenu.TabIndex = 1;
            this.btn_mainmenu.Text = "Main Menu";
            this.btn_mainmenu.UseVisualStyleBackColor = false;
            this.btn_mainmenu.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_stopwatch
            // 
            this.lbl_stopwatch.AutoSize = true;
            this.lbl_stopwatch.Font = new System.Drawing.Font("Atari Classic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stopwatch.Location = new System.Drawing.Point(1026, 110);
            this.lbl_stopwatch.Name = "lbl_stopwatch";
            this.lbl_stopwatch.Size = new System.Drawing.Size(54, 38);
            this.lbl_stopwatch.TabIndex = 2;
            this.lbl_stopwatch.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Atari Classic", 10F);
            this.label1.Location = new System.Drawing.Point(990, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Time:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1216, 937);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_stopwatch);
            this.Controls.Add(this.btn_mainmenu);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btn_mainmenu;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_stopwatch;
        private System.Windows.Forms.Label label1;
    }
}