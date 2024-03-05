namespace Mechanical1stYearProject
{
    public partial class Form1 : Form
    {
        List<Button> pointLoadButtons, udlButtons;
        Label udlLabel, pointLoadLabel;

        float barLength = 1.0f;

        float[] fd; // force diagram
        float[] bmd; // bending moment diagram
        float[] sfd; // sheer force diagram

        public Form1()
        {
            pointLoadButtons = new List<Button>();
            udlButtons = new List<Button>();

            int numberOfSteps = 1000;

            fd = new float[numberOfSteps];
            bmd = new float[numberOfSteps];
            sfd = new float[numberOfSteps];

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
            LoadsList.RowCount = Math.Max(pointLoadButtons.Count, udlButtons.Count) + 1;
            LoadsList.ColumnCount = 2;

            LoadsList.Controls.Add(pointLoadLabel, 0, 0);

            for (int i = 0; i < pointLoadButtons.Count; i++)
            {
                LoadsList.Controls.Add(pointLoadButtons[i], 0, i + 1);
            }

            LoadsList.Controls.Add(udlLabel, 1, 0);

            for (int i = 0; i < udlButtons.Count; i++)
            {
                LoadsList.Controls.Add(udlButtons[i], 1, i + 1);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                textBox1.Text = "0.0";
                barLength = 0.0f;
            }
            try
            {
                barLength = float.Parse(textBox1.Text);
            }
            catch(Exception ex)
            {
                textBox1.Text = Convert.ToString(barLength);
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
