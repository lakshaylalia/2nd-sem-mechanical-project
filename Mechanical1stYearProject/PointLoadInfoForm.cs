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
    public partial class PointLoadInfoForm : Form
    {
        float barLength, position, load;
        float[] pointLoadValues;

        // a is used to return the values relating to the point load a = {load, position}
        public PointLoadInfoForm(float barLength, float[] a)
        {
            InitializeComponent();
            this.barLength = barLength;
            this.pointLoadValues = a;
        }

        private void loadTextBox_TextChanged(object sender, EventArgs e)
        {
            if (loadTextBox.Text == "")
            {
                load = 0.0f;
                return;
            }
            try
            {
                load = float.Parse(loadTextBox.Text);
            }
            catch (Exception ex)
            {
                loadTextBox.Text = Convert.ToString(load);
            }
        }

        private void locationTextBox_TextChanged(object sender, EventArgs e)
        {
            if (locationTextBox.Text == ".")
            {
                locationTextBox.Text = "0";
            }
            else if (locationTextBox.Text == "")
            {
                position = 0.0f;
                return;
            }
            try
            {
                position = float.Parse(locationTextBox.Text);
                if(position > barLength)
                {
                    position = barLength;
                    locationTextBox.Text = Convert.ToString(position);
                    locationTextBox.Select(locationTextBox.Text.Length, 0);
                }
                else if(position < 0.0f)
                {
                    position = 0.0f;
                    locationTextBox.Text = Convert.ToString(position);
                    locationTextBox.Select(locationTextBox.Text.Length, 0);
                }
            }
            catch (Exception ex)
            {
                locationTextBox.Text = Convert.ToString(position);
                locationTextBox.Select(locationTextBox.Text.Length, 0);
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            pointLoadValues[0] = load;
            pointLoadValues[1] = position;
            Close();
        }

        private void PointLoadInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pointLoadValues[0] = load;
            pointLoadValues[1] = position; 
        }
    }
}
