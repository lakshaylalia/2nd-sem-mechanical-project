namespace Mechanical1stYearProject
{
    partial class UdlInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UdlInfoForm));
            label1 = new Label();
            udlTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            startTextBox = new TextBox();
            label4 = new Label();
            label5 = new Label();
            endTextBox = new TextBox();
            label6 = new Label();
            doneButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(198, 20);
            label1.TabIndex = 0;
            label1.Text = "Uniformly Distributed Load:-";
            // 
            // udlTextBox
            // 
            udlTextBox.Location = new Point(216, 6);
            udlTextBox.Name = "udlTextBox";
            udlTextBox.Size = new Size(162, 27);
            udlTextBox.TabIndex = 1;
            udlTextBox.TextChanged += udlTextBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(384, 13);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 2;
            label2.Text = "N/m";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 65);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 3;
            label3.Text = "Start:-";
            label3.Click += label3_Click;
            // 
            // startTextBox
            // 
            startTextBox.Location = new Point(67, 62);
            startTextBox.Name = "startTextBox";
            startTextBox.Size = new Size(143, 27);
            startTextBox.TabIndex = 4;
            startTextBox.TextChanged += startTextBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(216, 65);
            label4.Name = "label4";
            label4.Size = new Size(22, 20);
            label4.TabIndex = 5;
            label4.Text = "m";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 117);
            label5.Name = "label5";
            label5.Size = new Size(43, 20);
            label5.TabIndex = 6;
            label5.Text = "End:-";
            // 
            // endTextBox
            // 
            endTextBox.Location = new Point(61, 114);
            endTextBox.Name = "endTextBox";
            endTextBox.Size = new Size(149, 27);
            endTextBox.TabIndex = 7;
            endTextBox.TextChanged += endTextBox_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(216, 117);
            label6.Name = "label6";
            label6.Size = new Size(22, 20);
            label6.TabIndex = 8;
            label6.Text = "m";
            // 
            // doneButton
            // 
            doneButton.Location = new Point(329, 112);
            doneButton.Name = "doneButton";
            doneButton.Size = new Size(94, 29);
            doneButton.TabIndex = 9;
            doneButton.Text = "Done";
            doneButton.UseVisualStyleBackColor = true;
            doneButton.Click += doneButton_Click;
            // 
            // UdlInfoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 145);
            Controls.Add(doneButton);
            Controls.Add(label6);
            Controls.Add(endTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(startTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(udlTextBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UdlInfoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Uld Info Window";
            FormClosing += UdlInfoForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox udlTextBox;
        private Label label2;
        private Label label3;
        private TextBox startTextBox;
        private Label label4;
        private Label label5;
        private TextBox endTextBox;
        private Label label6;
        private Button doneButton;
    }
}