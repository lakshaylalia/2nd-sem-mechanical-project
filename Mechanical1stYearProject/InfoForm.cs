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
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private void github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            github.LinkVisited = true;
            // opening the github repository of the project when the link is clicked
            System.Diagnostics.Process.Start("explorer.exe", 
                "https://github.com/Aryan171/2nd-sem-mechanical-project");
        }
    }
}
