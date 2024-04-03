namespace Mechanical1stYearProject
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            infoButton = new Button();
            LoadsButton = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            LoadsList = new TableLayoutPanel();
            loadsGraph = new ScottPlot.WinForms.FormsPlot();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel3 = new Panel();
            sfdGraph = new ScottPlot.WinForms.FormsPlot();
            panel4 = new Panel();
            bmdGraph = new ScottPlot.WinForms.FormsPlot();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(infoButton);
            panel1.Controls.Add(LoadsButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(882, 47);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(701, 13);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 8;
            label2.Text = "N/m";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(570, 13);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 7;
            textBox2.Text = "0.0";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(368, 13);
            label1.Name = "label1";
            label1.Size = new Size(210, 20);
            label1.TabIndex = 6;
            label1.Text = "Weight per unit length of bar:-";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(340, 19);
            label5.Name = "label5";
            label5.Size = new Size(22, 20);
            label5.TabIndex = 5;
            label5.Text = "m";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(244, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(90, 27);
            textBox1.TabIndex = 4;
            textBox1.Text = "10.0";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(131, 13);
            label4.Name = "label4";
            label4.Size = new Size(107, 20);
            label4.TabIndex = 3;
            label4.Text = "Length of bar:-";
            // 
            // infoButton
            // 
            infoButton.BackColor = SystemColors.AppWorkspace;
            infoButton.Dock = DockStyle.Right;
            infoButton.FlatAppearance.BorderSize = 0;
            infoButton.FlatStyle = FlatStyle.Flat;
            infoButton.Location = new Point(788, 0);
            infoButton.Name = "infoButton";
            infoButton.Size = new Size(94, 47);
            infoButton.TabIndex = 2;
            infoButton.Text = "( i ) Info";
            infoButton.UseVisualStyleBackColor = false;
            infoButton.Click += infoButton_Click;
            // 
            // LoadsButton
            // 
            LoadsButton.BackColor = SystemColors.AppWorkspace;
            LoadsButton.Dock = DockStyle.Left;
            LoadsButton.FlatAppearance.BorderSize = 0;
            LoadsButton.FlatStyle = FlatStyle.Flat;
            LoadsButton.Location = new Point(0, 0);
            LoadsButton.Name = "LoadsButton";
            LoadsButton.Size = new Size(125, 47);
            LoadsButton.TabIndex = 0;
            LoadsButton.Text = "Loads";
            LoadsButton.UseVisualStyleBackColor = false;
            LoadsButton.Click += button1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 47);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(882, 606);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(LoadsList);
            panel2.Controls.Add(loadsGraph);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(876, 297);
            panel2.TabIndex = 1;
            // 
            // LoadsList
            // 
            LoadsList.AutoSize = true;
            LoadsList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LoadsList.BackColor = SystemColors.ActiveBorder;
            LoadsList.ColumnCount = 1;
            LoadsList.ColumnStyles.Add(new ColumnStyle());
            LoadsList.Location = new Point(1, 0);
            LoadsList.Margin = new Padding(0);
            LoadsList.Name = "LoadsList";
            LoadsList.RowCount = 1;
            LoadsList.RowStyles.Add(new RowStyle());
            LoadsList.Size = new Size(0, 0);
            LoadsList.TabIndex = 0;
            LoadsList.Visible = false;
            // 
            // loadsGraph
            // 
            loadsGraph.DisplayScale = 1.25F;
            loadsGraph.Dock = DockStyle.Fill;
            loadsGraph.Location = new Point(0, 0);
            loadsGraph.Name = "loadsGraph";
            loadsGraph.Size = new Size(876, 297);
            loadsGraph.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel3, 0, 0);
            tableLayoutPanel2.Controls.Add(panel4, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 306);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(876, 297);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(sfdGraph);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(432, 291);
            panel3.TabIndex = 0;
            // 
            // sfdGraph
            // 
            sfdGraph.DisplayScale = 1.25F;
            sfdGraph.Dock = DockStyle.Fill;
            sfdGraph.Location = new Point(0, 0);
            sfdGraph.Name = "sfdGraph";
            sfdGraph.Size = new Size(432, 291);
            sfdGraph.TabIndex = 0;
            sfdGraph.Tag = "";
            // 
            // panel4
            // 
            panel4.Controls.Add(bmdGraph);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(441, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(432, 291);
            panel4.TabIndex = 1;
            // 
            // bmdGraph
            // 
            bmdGraph.DisplayScale = 1.25F;
            bmdGraph.Dock = DockStyle.Fill;
            bmdGraph.Location = new Point(0, 0);
            bmdGraph.Name = "bmdGraph";
            bmdGraph.Size = new Size(432, 291);
            bmdGraph.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 653);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(900, 700);
            Name = "Form1";
            Text = "SFD, BMD maker";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button LoadsButton;
        private Button infoButton;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel2;
        private TableLayoutPanel LoadsList;
        private TextBox textBox1;
        private Label label4;
        private Label label5;
        private ScottPlot.WinForms.FormsPlot loadsGraph;
        private ScottPlot.WinForms.FormsPlot sfdGraph;
        private ScottPlot.WinForms.FormsPlot bmdGraph;
        private Label label2;
        private TextBox textBox2;
        private Label label1;
    }
}
