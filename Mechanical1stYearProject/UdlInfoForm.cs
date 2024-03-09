using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mechanical1stYearProject
{
    public partial class UdlInfoForm : Form
    {
        float udl = 0;
        float start = 0;
        float end = 0;
        float barLength;

        float[] udlValues;

        // udlValues array will be used to return the values of {udl, start, end}
        public UdlInfoForm(float barLength, float[] udlValues)
        {
            InitializeComponent();
            this.barLength = barLength;
            this.udlValues = udlValues;
            this.udlValues = udlValues;
        }

        private void udlTextBox_TextChanged(object sender, EventArgs e)
        {
            if (udlTextBox.Text == "")
            {
                udl = 0.0f;
                return;
            }
            try
            {
                udl = float.Parse(udlTextBox.Text);
            }
            catch (Exception ex)
            {
                udlTextBox.Text = Convert.ToString(udl);
                udlTextBox.Select(udlTextBox.Text.Length, 0);
            }
        }

        private void startTextBox_TextChanged(object sender, EventArgs e)
        {
            if (startTextBox.Text == "")
            {
                start = 0.0f;
                return;
            }
            try
            {
                start = float.Parse(startTextBox.Text);
            }
            catch (Exception ex)
            {
                startTextBox.Text = Convert.ToString(start);
                startTextBox.Select(startTextBox.Text.Length, 0);
            }
        }

        private void endTextBox_TextChanged(object sender, EventArgs e)
        {
            if (endTextBox.Text == "")
            {
                end = 0.0f;
                return;
            }
            try
            {
                end = float.Parse(endTextBox.Text);
            }
            catch (Exception ex)
            {
                endTextBox.Text = Convert.ToString(end);
                endTextBox.Select(endTextBox.Text.Length, 0);
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            udlValues[0] = udl;
            udlValues[1] = Math.Clamp(Math.Min(start, end), 0, barLength);
            udlValues[2] = Math.Clamp(Math.Max(start, end), 0, barLength);

            Close();
        }

        private void UdlInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            udlValues[0] = udl;
            udlValues[1] = Math.Clamp(Math.Min(start, end), 0, barLength);
            udlValues[2] = Math.Clamp(Math.Max(start, end), 0, barLength);
        }
    }
}
