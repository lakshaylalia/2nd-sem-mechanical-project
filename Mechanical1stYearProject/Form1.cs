using System.Net.Mail;

namespace Mechanical1stYearProject
{
    public partial class Form1 : Form
    {
        // these are used to make it so that only one extra window is opened at a time
        bool udlBeingCreated = false, pointLoadBeingCreated = false, infoWindowOpened = false;

        Random r = new Random(); // to create random colors

        List<Button> pointLoadButtons, udlButtons;
        List<UdlValue> udlValues;
        List<PointLoadValue> pointLoadValues;
        Label udlLabel, pointLoadLabel;

        float barLength = 1.0f;
        float rfA, rfB; // reaction forces at the two ends of the bar

        float[] fd; // force diagram
        float[] bmd; // bending moment diagram
        float[] sfd; // sheer force diagram
        float[] a; // this is used to make the udl and point forces

        int numberOfSteps = 1000;

        public class UdlValue
        {
            public UdlValue(float start, float end, float udl)
            {
                this.start = start;
                this.end = end;
                this.udl = udl;
            }

            public UdlValue()
            {
                this.start = 0.0f;
                this.end = 0.0f;
                this.udl = 0.0f;
            }

            public float start, end, udl;
        }

        public class PointLoadValue
        {
            public PointLoadValue(float point, float load)
            {
                this.point = point;
                this.load = load;
            }

            public PointLoadValue()
            {
                this.point = 0.0f;
                this.load = 0.0f;
            }

            public float point, load;
        }

        public Form1()
        {
            pointLoadButtons = new List<Button>();
            udlButtons = new List<Button>();

            pointLoadValues = new List<PointLoadValue>();
            udlValues = new List<UdlValue>();

            fd = new float[numberOfSteps];
            bmd = new float[numberOfSteps];
            sfd = new float[numberOfSteps];

            Button addUdl = new Button(),
                addPointLoad = new Button();

            addUdl.Text = "Add UDL";
            addPointLoad.Text = "Add point force";

            addUdl.TextAlign = ContentAlignment.MiddleCenter;
            addPointLoad.TextAlign = ContentAlignment.MiddleCenter;

            addUdl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            addPointLoad.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            addUdl.AutoSize = true;
            addPointLoad.AutoSize = true;

            addUdl.FlatAppearance.BorderSize = 0;
            addPointLoad.FlatAppearance.BorderSize = 0;

            addUdl.FlatStyle = FlatStyle.Flat;
            addPointLoad.FlatStyle = FlatStyle.Flat;

            addUdl.TextAlign = ContentAlignment.MiddleLeft;
            addPointLoad.TextAlign = ContentAlignment.MiddleCenter;

            addUdl.Click += addUdl_Click;
            addPointLoad.Click += addPointLoad_Click;

            pointLoadButtons.Add(addPointLoad);
            pointLoadValues.Add(new PointLoadValue());
            udlButtons.Add(addUdl);
            udlValues.Add(new UdlValue());

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
            if (udlBeingCreated || pointLoadBeingCreated || infoWindowOpened)
            {
                return;
            }
            udlBeingCreated = true;
            a = new float[3];

            // taking the different values of the udl from the user
            UdlInfoForm udlInfoForm = new UdlInfoForm(barLength, a);
            udlInfoForm.Visible = true;
            udlInfoForm.FormClosed += udlInfoFormClosed;
        }

        private void addPointLoad_Click(object sender, EventArgs e)
        {
            if (udlBeingCreated || pointLoadBeingCreated || infoWindowOpened)
            {
                return;
            }
            pointLoadBeingCreated = true;
            a = new float[2];

            // taking the different values of the udl from the user
            PointLoadInfoForm pointLoadInfoForm = new PointLoadInfoForm(barLength, a);
            pointLoadInfoForm.Visible = true;
            pointLoadInfoForm.FormClosed += pointLoadInfoFormClosed;
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
            // bar length text box will remain inactive when ever another window is open
            if (udlBeingCreated || pointLoadBeingCreated || infoWindowOpened)
            {
                textBox1.Text = Convert.ToString(barLength);
            }

            if (textBox1.Text == "")
            {
                textBox1.Text = "0.0";
                barLength = 0.0f;
            }
            try
            {
                barLength = float.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                textBox1.Text = Convert.ToString(barLength);
            }
        }

        private void updateDiagrams()
        {
            // finding the reaction force rfA
            rfA = 0.0f;
            foreach (PointLoadValue p in pointLoadValues)
            {
                rfA += p.point * p.load;
            }

            foreach (UdlValue u in udlValues)
            {
                rfA += u.udl * (u.end - u.start) * (u.end + u.start) / 2;
            }

            rfA = rfA / barLength;

            // finding the reaction force rfB
            foreach (PointLoadValue p in pointLoadValues)
            {
                rfB += (barLength - p.point) * p.load;
            }

            foreach (UdlValue u in udlValues)
            {
                rfB += u.udl * (u.end - u.start) * (barLength - ((u.end + u.start) / 2));
            }

            rfB = rfB / barLength;

            // updating the fd here
            // first adding all the point loads
            foreach (PointLoadValue p in pointLoadValues)
            {
                fd[(int)Math.Round(p.point * numberOfSteps / barLength)] += p.point;
            }

            // now adding all the udls
            foreach (UdlValue u in udlValues)
            {
                int istart = (int)Math.Round(u.start * numberOfSteps / barLength);
                int iend = (int)Math.Round(u.end * numberOfSteps / barLength);

                float f = ((u.end - u.start) * u.udl) / (iend - istart);

                for (int i = istart; i < iend; i++)
                {
                    fd[i] += f;
                }
            }

            // updating the sfd here
            sfd[0] = fd[0];

            for (int i = 1; i < numberOfSteps; i++)
            {
                sfd[i] = sfd[i - 1] + fd[i];
            }

            // updating the bmd here
            bmd[0] = 0;
            for (int i = 1; i < numberOfSteps; i++)
            {
                bmd[i] = bmd[i - 1] + ((i * barLength / (float)numberOfSteps) * fd[i]);
            }
        }

        // this function is called whenever a udl button is clicked
        private void udlButtons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            udlValues.RemoveAt(udlButtons.IndexOf(b));
            udlButtons.Remove(b);
            SetLoadsList();
        }

        // this function is called whenever a point load button is clicked
        private void pointLoadButtons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            pointLoadValues.RemoveAt(pointLoadButtons.IndexOf(b));
            pointLoadButtons.Remove(b);
            SetLoadsList();
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            if(udlBeingCreated || pointLoadBeingCreated || infoWindowOpened)
            {
                return;
            }
            LoadsList.Visible = false;
            InfoForm form = new InfoForm();
            form.Visible = true;
        }

        private void udlInfoFormClosed(object sender, FormClosedEventArgs e)
        {
            int red = r.Next(256), green = r.Next(256), blue = r.Next(256);

            Button b = new Button();

            b.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            b.AutoSize = true;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Click += udlButtons_Click;
            b.BackColor = Color.FromArgb(red, green, blue);
            b.ForeColor = Color.FromArgb(255 - red, 255 - green, 255 - blue);
            b.Margin = new Padding(0, 0, 0, 0);
            b.Text = a[0] + "N/m from " + a[1] + "m to " + a[2] + "m";

            udlButtons.Add(b);

            udlValues.Add(new UdlValue(a[1], a[2], a[0]));
            SetLoadsList();

            udlBeingCreated = false;
        }

        private void pointLoadInfoFormClosed(object sender, FormClosedEventArgs e)
        {
            int red = r.Next(256), green = r.Next(256), blue = r.Next(256);

            Button b = new Button();

            b.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            b.AutoSize = true;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Click += pointLoadButtons_Click;
            b.BackColor = Color.FromArgb(red, green, blue);
            b.ForeColor = Color.FromArgb(255 - red, 255 - green, 255 - blue);
            b.Margin = new Padding(0, 0, 0, 0);
            b.Text = a[0] + "N at " + a[1] + "m";

            pointLoadButtons.Add(b);

            pointLoadValues.Add(new PointLoadValue(a[1], a[0]));
            SetLoadsList();

            pointLoadBeingCreated = false;
        }
    }
}
