using ScottPlot;
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
        System.Windows.Forms.Label udlLabel, pointLoadLabel;

        float barLength = 10.0f;
        float stepLength; // stores barlength / numberOfSteps
        float m; // this is a multiplier which is used to convert length to array index
        float rfA, rfB; // reaction forces at the two ends of the bar

        float[] a; // this is used to make the udl and point forces

        double[] fd; // force diagram
        double[] bmd; // bending moment diagram
        double[] sfd; // sheer force diagram
        double[] xAxis; // is used to store the x axes values of the points displayed
        double[] zeros; // used to shade the graphs

        int numberOfSteps = 10000;

        /// <summary>
        /// this class stores some of the characteristics of a udl 
        /// like start, end and the value of the udl itself
        /// </summary>
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

        /// <summary>
        /// this class stores some of the characteristics of a point load like the
        /// point where the point load is applied and the value of the point load itself
        /// </summary>
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
            InitializeComponent();

            pointLoadButtons = new List<Button>();
            udlButtons = new List<Button>();

            pointLoadValues = new List<PointLoadValue>();
            udlValues = new List<UdlValue>();

            fd = new double[numberOfSteps];
            bmd = new double[numberOfSteps];
            sfd = new double[numberOfSteps];

            Button addUdl = new Button(),
                addPointLoad = new Button();

            addUdl.Text = "Add UDL";
            addPointLoad.Text = "Add point load";

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

            udlLabel = new System.Windows.Forms.Label();
            pointLoadLabel = new System.Windows.Forms.Label();

            udlLabel.Text = "UDLs:-";
            pointLoadLabel.Text = "Point Loads:-";

            udlLabel.AutoSize = true;
            pointLoadLabel.AutoSize = true;

            udlLabel.Dock = DockStyle.Left;
            pointLoadLabel.Dock = DockStyle.Left;

            stepLength = barLength / numberOfSteps;
            m = barLength / (numberOfSteps - 1);

            xAxis = new double[numberOfSteps];
            zeros = new double[numberOfSteps];

            for (int i = 0; i < numberOfSteps; i++)
            {
                xAxis[i] = i * m;
            }

            // adding title and axel lables to sfd and bmd graphs
            sfdGraph.Plot.Title("Shear Force Diagram");
            bmdGraph.Plot.Title("Bending Moment Diagram");

            sfdGraph.Plot.XLabel("Length in meters");
            bmdGraph.Plot.XLabel("Length in meters");

            sfdGraph.Plot.YLabel("Shear in N");
            bmdGraph.Plot.YLabel("Moment in N/m");

            // adding a title and axes lables to the load graph
            loadsGraph.Plot.Title("Graph of all loads");
            loadsGraph.Plot.XLabel("Length in meters");
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
                textBox1.Select(textBox1.Text.Length, 0);
            }

            if (textBox1.Text == "")
            {
                barLength = 0.0f;
                return;
            }
            try
            {
                barLength = float.Parse(textBox1.Text);
                if(barLength < 0)
                {
                    barLength = -barLength;
                    textBox1.Text = textBox1.Text.Substring(1);
                }
                stepLength = barLength / numberOfSteps;
                m = barLength / (numberOfSteps - 1);
                for (int i = 0; i < numberOfSteps; i++)
                {
                    xAxis[i] = i * m;
                }
                UpdateGraphs();
                DisplayGraphs();
            }
            catch (Exception ex)
            {
                textBox1.Text = Convert.ToString(barLength);
                textBox1.Select(textBox1.Text.Length, 0);
            }
        }

        private void UpdateGraphs()
        {
            // finding the reaction forces
            rfB = 0.0f;
            rfA = 0.0f;

            foreach (PointLoadValue p in pointLoadValues)
            {
                rfB += p.point * p.load;
                rfA += (barLength - p.point) * p.load;
            }

            foreach (UdlValue u in udlValues)
            {
                rfB += u.udl * (u.end - u.start) * (u.end + u.start) / 2;
                rfA += u.udl * (u.end - u.start) * (barLength - ((u.end + u.start) / 2));
            }

            rfB = rfB / barLength;
            rfA = rfA / barLength;

            // setting all the graphs to 0
            for(int i = 0; i < numberOfSteps; i++)
            {
                fd[i] = 0;
                sfd[i] = 0;
                bmd[i] = 0;
            }


            // updating the fd here
            // adding the reaction forces
            fd[0] += rfA;
            fd[numberOfSteps - 1] += rfB;

            // first adding all the point loads
            foreach (PointLoadValue p in pointLoadValues)
            {
                fd[(int)Math.Round(p.point / m)] -= p.load;
            }

            // now adding all the udls
            foreach (UdlValue u in udlValues)
            {
                int istart = (int)Math.Round(u.start / m);
                int iend = (int)Math.Round(u.end / m);

                float f = ((u.end - u.start) * u.udl) / (iend - istart);

                for (int i = istart; i <= iend; i++)
                {
                    fd[i] -= f;
                }
            }

            // updating the sfd and bmd here
            sfd[0] = rfA;
            bmd[0] = 0;

            for (int i = 1; i < numberOfSteps; i++)
            {
                sfd[i] = sfd[i - 1] + fd[i];
                bmd[i] = bmd[i - 1] + sfd[i - 1] * stepLength;
            }

            // this is done so that the last point looks more continuous
            sfd[numberOfSteps - 1] = sfd[numberOfSteps - 2];
        }

        // this function is called whenever a udl button is clicked
        private void udlButtons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            udlValues.RemoveAt(udlButtons.IndexOf(b));
            udlButtons.Remove(b);
            SetLoadsList();
            UpdateGraphs();
            DisplayGraphs();
        }

        // this function is called whenever a point load button is clicked
        private void pointLoadButtons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            pointLoadValues.RemoveAt(pointLoadButtons.IndexOf(b));
            pointLoadButtons.Remove(b);
            SetLoadsList();
            UpdateGraphs();
            DisplayGraphs();
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            if (udlBeingCreated || pointLoadBeingCreated || infoWindowOpened)
            {
                return;
            }
            LoadsList.Visible = false;
            InfoForm form = new InfoForm();
            form.Visible = true;
        }

        // function to diplays all the graphs
        private void DisplayGraphs()
        {
            bmdGraph.Reset();
            sfdGraph.Reset();
            loadsGraph.Reset();

            // displaying the load graph

            // adding a title and axes lables to the load graph
            loadsGraph.Plot.Title("Graph of all loads");
            loadsGraph.Plot.XLabel("Length in meters");

            // adding a rectangle for the bar
            var rect = loadsGraph.Plot.Add.Rectangle(0, barLength, -barLength / 20, barLength / 20);
            rect.FillStyle.Color = new ScottPlot.Color(0, 0, 0, 255);

            // adding rectangles for all the udls
            ScottPlot.Plottables.Rectangle[] udlRects = new ScottPlot.Plottables.Rectangle[udlValues.Count];
            for(int i = 1; i < udlValues.Count; i++)
            {
                udlRects[i] = loadsGraph.Plot.Add.Rectangle(udlValues[i].start, 
                    udlValues[i].end, barLength / 16, barLength / 10);
                udlRects[i].FillStyle.Color = new ScottPlot.Color(udlButtons[i].BackColor.R,
                    udlButtons[i].BackColor.G, udlButtons[i].BackColor.B, 100);
                //udlRects[i].LineStyle.Color = new ScottPlot.Color(0, 0)
            }

            // adding arrows for point loads
            ScottPlot.Plottables.Arrow[] plArrows = new ScottPlot.Plottables.Arrow[pointLoadValues.Count];
            for (int i = 1; i < pointLoadValues.Count; i++)
            {
                plArrows[i] = loadsGraph.Plot.Add.Arrow(pointLoadValues[i].point, barLength / 3, 
                    pointLoadValues[i].point, barLength / 10);
                plArrows[i].Color = new ScottPlot.Color(pointLoadButtons[i].BackColor.R,
                    pointLoadButtons[i].BackColor.G, pointLoadButtons[i].BackColor.B, 255);
            }

            // adding arrows for reaction forces
            var rfaArrow = loadsGraph.Plot.Add.Arrow(0, -barLength / 3,
                    0, -barLength / 20);
            var rfbArrow = loadsGraph.Plot.Add.Arrow(barLength, -barLength / 3,
                    barLength, -barLength / 20);
            rfaArrow.Color = new ScottPlot.Color(150, 0, 0);
            rfbArrow.Color = new ScottPlot.Color(150, 0, 0);

            // adding an invisible arrow to keep the scaling of the chart good
            var invisibleArrow = loadsGraph.Plot.Add.Arrow(0, barLength / 3, 0, barLength / 10);
            invisibleArrow.Color = new ScottPlot.Color(0, 0, 0, 0);

            // adding text for reaction forces
            loadsGraph.Plot.Add.Text(rfA.ToString() + "N", 0, -barLength / 3);
            loadsGraph.Plot.Add.Text(rfB.ToString() + "N", barLength * 0.975, -barLength / 3);

            // displaying the sfd and bmd graphs

            // adding title and axel lables to sfd and bmd graphs
            sfdGraph.Plot.Title("Shear Force Diagram");
            bmdGraph.Plot.Title("Bending Moment Diagram");

            sfdGraph.Plot.XLabel("Length in meters");
            bmdGraph.Plot.XLabel("Length in meters");

            sfdGraph.Plot.YLabel("Shear in N");
            bmdGraph.Plot.YLabel("Moment in N/m");

            var bmdFill = bmdGraph.Plot.Add.FillY(xAxis, bmd, zeros);
            var sfdFill = sfdGraph.Plot.Add.FillY(xAxis, sfd, zeros);

            bmdFill.MarkerStyle.Size = 0;
            sfdFill.MarkerStyle.Size = 0;

            // this makes the 3 graphs scale automatically
            sfdGraph.Plot.Axes.AutoScale();
            bmdGraph.Plot.Axes.AutoScale();
            loadsGraph.Plot.Axes.AutoScale();

            sfdFill.FillStyle.Color = new ScottPlot.Color(71, 105, 186, 150);
            bmdFill.FillStyle.Color = new ScottPlot.Color(71, 105, 186, 150);

            bmdGraph.Refresh();
            sfdGraph.Refresh();
            loadsGraph.Refresh();
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
            b.BackColor = System.Drawing.Color.FromArgb(red, green, blue);
            b.ForeColor = System.Drawing.Color.FromArgb(255 - red, 255 - green, 255 - blue);
            b.Margin = new Padding(0, 0, 0, 0);
            b.Text = a[0] + "N/m from " + a[1] + "m to " + a[2] + "m";

            udlButtons.Add(b);

            udlValues.Add(new UdlValue(a[1], a[2], a[0]));
            SetLoadsList();

            udlBeingCreated = false;

            UpdateGraphs();
            DisplayGraphs();
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
            b.BackColor = System.Drawing.Color.FromArgb(red, green, blue);
            b.ForeColor = System.Drawing.Color.FromArgb(255 - red, 255 - green, 255 - blue);
            b.Margin = new Padding(0, 0, 0, 0);
            b.Text = a[0] + "N at " + a[1] + "m";

            pointLoadButtons.Add(b);

            pointLoadValues.Add(new PointLoadValue(a[1] == 0.0f ? barLength / 10000.0f : a[1], a[0]));
            SetLoadsList();

            pointLoadBeingCreated = false;
            UpdateGraphs();
            DisplayGraphs();
        }
    }
}
