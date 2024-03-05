namespace Mechanical1stYearProject
{
    public partial class Form1 : Form
    {
        List<Button> pointLoadButtons, udlButtons;
        Label udlLabel, pointLoadLabel;

        public Form1()
        {
            pointLoadButtons = new List<Button>();
            udlButtons = new List<Button>();

            Button addUdl = new Button(),
                addPointLoad = new Button();

            addUdl.Text = "Add UDL";
            addPointLoad.Text = "Add point force";

            addUdl.Dock = DockStyle.None;
            addPointLoad.Dock = DockStyle.None;

            addUdl.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            addPointLoad.Anchor = AnchorStyles.Left | AnchorStyles.Top;

            addUdl.AutoSize = true;
            addPointLoad.AutoSize = true;

            addUdl.Click += new System.EventHandler(this.addUdl_Click);
            addPointLoad.Click += new System.EventHandler(this.addPointLoad_Click);

            pointLoadButtons.Add(addPointLoad);
            udlButtons.Add(addUdl);

            udlLabel = new Label();
            pointLoadLabel = new Label();

            udlLabel.Text = "UDLs:-";
            pointLoadLabel.Text = "Point Loads:-";

            udlLabel.AutoSize = true;
            pointLoadLabel.AutoSize = true;

            udlLabel.Dock = DockStyle.Left;
            pointLoadLabel.Dock = DockStyle.Left;

            InitializeComponent();
        }

        private void addUdl_Click(object sender, EventArgs e)
        {
            Button b = new Button();

            b.Text = udlButtons.Count + ") UDL";
            b.Dock = DockStyle.None;
            b.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            b.AutoSize = true;
            b.Font = new Font("Segoe UI", 5);

            udlButtons.Insert(udlButtons.Count - 1, b);

            SetLoadsList();
        }

        private void addPointLoad_Click(object sender, EventArgs e) 
        {
            Button b = new Button();

            b.Text = pointLoadButtons.Count + ") Point Load";
            b.Dock = DockStyle.None;
            b.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            b.AutoSize = true;
            b.Font = new Font("Segoe UI", 5);

            pointLoadButtons.Insert(pointLoadButtons.Count - 1, b);

            SetLoadsList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadsList.Visible = !LoadsList.Visible;
            if (LoadsList.Visible)
            {
                SetLoadsList();
            }
        }

        private void SetLoadsList()
        {
            LoadsList.Controls.Clear();
            LoadsList.RowCount = pointLoadButtons.Count + udlButtons.Count + 2;
            LoadsList.ColumnCount = 1;

            LoadsList.Controls.Add(pointLoadLabel, 0, 0);

            for (int i = 0; i < pointLoadButtons.Count; i++)
            {
                LoadsList.Controls.Add(pointLoadButtons[i], 0, i + 1);
            }

            LoadsList.Controls.Add(udlLabel, 0, pointLoadButtons.Count + 1);

            for (int i = 0; i < udlButtons.Count; i++)
            {
                LoadsList.Controls.Add(udlButtons[i], 0, i + pointLoadButtons.Count + 2);
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
