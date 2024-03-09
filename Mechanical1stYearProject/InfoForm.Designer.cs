namespace Mechanical1stYearProject
{
    partial class InfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            github = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(201, 35);
            label1.TabIndex = 0;
            label1.Text = "Team Members:-";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(354, 35);
            label2.TabIndex = 1;
            label2.Text = "23BCS015 Akshat Mani Triphati";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(12, 79);
            label3.Name = "label3";
            label3.Size = new Size(272, 35);
            label3.TabIndex = 2;
            label3.Text = "23BCS016 Akshat Singh";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(12, 114);
            label4.Name = "label4";
            label4.Size = new Size(273, 35);
            label4.TabIndex = 3;
            label4.Text = "23BCS017 Akshit Dogra";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(12, 149);
            label5.Name = "label5";
            label5.Size = new Size(278, 35);
            label5.TabIndex = 4;
            label5.Text = "23BCS019 Akshit Thakur";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F);
            label6.Location = new Point(12, 184);
            label6.Name = "label6";
            label6.Size = new Size(405, 35);
            label6.TabIndex = 5;
            label6.Text = "23BCS021 Anshuman Singh Kapoor";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15F);
            label7.Location = new Point(12, 219);
            label7.Name = "label7";
            label7.Size = new Size(319, 35);
            label7.TabIndex = 6;
            label7.Text = "23BCS025 Aryan Chaudhary";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 15F);
            label8.Location = new Point(12, 254);
            label8.Name = "label8";
            label8.Size = new Size(287, 35);
            label8.TabIndex = 7;
            label8.Text = "23BCS027 Ayush Sharma";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15F);
            label9.Location = new Point(11, 289);
            label9.Name = "label9";
            label9.Size = new Size(273, 35);
            label9.TabIndex = 8;
            label9.Text = "23BCS054 Lakshay Lalia";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15F);
            label10.Location = new Point(12, 324);
            label10.Name = "label10";
            label10.Size = new Size(272, 35);
            label10.TabIndex = 9;
            label10.Text = "23BCS059 Mangal Patel";
            // 
            // github
            // 
            github.AutoSize = true;
            github.Location = new Point(421, 21);
            github.Name = "github";
            github.Size = new Size(165, 20);
            github.TabIndex = 10;
            github.TabStop = true;
            github.Text = "Goto Github Repository";
            github.LinkClicked += github_LinkClicked;
            // 
            // InfoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(800, 372);
            Controls.Add(github);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InfoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Info Window";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private LinkLabel github;
    }
}