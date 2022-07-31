using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = $"Micsosoft Windows\nVersion 1803(OS Build 17134 .950)\n2018 Microsoft Corporation.All right reserved.\nThe Windows 10 Pro operating system and its user interface are protected  by trademark and other  pending or existing  intelectuall  property  rights  int the United States and  other countries /region\n\n\n\nThis product is license under the \t\t\t\t to:\n\nHp";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
