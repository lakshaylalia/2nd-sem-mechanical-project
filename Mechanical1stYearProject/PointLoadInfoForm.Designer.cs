namespace Mechanical1stYearProject
{
    partial class PointLoadInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PointLoadInfoForm));
            label1 = new Label();
            label2 = new Label();
            loadTextBox = new TextBox();
            locationTextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            doneButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 0;
            label1.Text = "Load:-";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 1;
            label2.Text = "Location:-";
            // 
            // loadTextBox
            // 
            loadTextBox.Location = new Point(69, 6);
            loadTextBox.Name = "loadTextBox";
            loadTextBox.Size = new Size(174, 27);
            loadTextBox.TabIndex = 2;
            loadTextBox.TextChanged += loadTextBox_TextChanged;
            // 
            // locationTextBox
            // 
            locationTextBox.Location = new Point(93, 42);
            locationTextBox.Name = "locationTextBox";
            locationTextBox.Size = new Size(150, 27);
            locationTextBox.TabIndex = 3;
            locationTextBox.TextChanged += locationTextBox_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(249, 9);
            label3.Name = "label3";
            label3.Size = new Size(22, 20);
            label3.TabIndex = 4;
            label3.Text = "m";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(249, 45);
            label4.Name = "label4";
            label4.Size = new Size(22, 20);
            label4.TabIndex = 5;
            label4.Text = "m";
            // 
            // doneButton
            // 
            doneButton.Location = new Point(277, 40);
            doneButton.Name = "doneButton";
            doneButton.Size = new Size(94, 29);
            doneButton.TabIndex = 6;
            doneButton.Text = "Done";
            doneButton.UseVisualStyleBackColor = true;
            doneButton.Click += doneButton_Click;
            // 
            // PointLoadInfoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 84);
            Controls.Add(doneButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(locationTextBox);
            Controls.Add(loadTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PointLoadInfoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Point Load Info Window";
            FormClosing += PointLoadInfoForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox loadTextBox;
        private TextBox locationTextBox;
        private Label label3;
        private Label label4;
        private Button doneButton;
    }
}