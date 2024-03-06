using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                if (start < 0.0f)
                {
                    start = 0.0f;
                }
                else if (start > barLength)
                {
                    start = barLength;
                }
                
                startTextBox.Text = Convert.ToString(start);
            }
            catch (Exception ex)
            {
                startTextBox.Text = Convert.ToString(start);
            }
        }

        private void endTextBox_TextChanged(object sender, EventArgs e)
        {
            if (endTextBox.Text == "")
            {
                end = 0.0f;
            }
            try
            {
                end = float.Parse(endTextBox.Text);

                if (end < 0.0f)
                {
                    end = 0.0f;
                }
                else if (end > barLength)
                {
                    end = barLength;
                }
                endTextBox.Text = Convert.ToString(end);
            }
            catch (Exception ex)
            {
                endTextBox.Text = Convert.ToString(end);
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            udlValues[0] = udl;
            udlValues[1] = start;
            udlValues[2] = end;
            Close();
        }

        private void UdlInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            udlValues[0] = udl;
            udlValues[1] = Math.Min(start, end);
            udlValues[2] = Math.Max(start, end);
        }
    }
}
