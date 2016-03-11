using System;
using System.Windows.Forms;

namespace Cod4ServerTool
{
    public partial class getStringBox : Form
    {
        public String returnvalue = "";

        public getStringBox()
        {
            InitializeComponent();
        }

        private void getStringBox_Load(object sender, EventArgs e)
        {
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            returnvalue = textBox1.Text;
            Close();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}