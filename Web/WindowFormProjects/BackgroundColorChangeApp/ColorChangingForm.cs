using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgroundColorChangeApp
{
    public partial class ColorChangingForm : Form
    {
        public ColorChangingForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.BackColor != Color.Red)
            {
                this.BackColor = Color.Red;
            }
           
        }

        private void ColorChangingForm_Load(object sender, EventArgs e)
        {
           

        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (this.BackColor != Color.Blue)
            {
                this.BackColor = Color.Blue;

            }
        }
    }
}
