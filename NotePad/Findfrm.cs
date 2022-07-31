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
    public partial class Findfrm : Form
    {
        public Findfrm(FindTextHandler method)
        {
            InitializeComponent();
            handle = method ?? throw new ArgumentNullException();
        }

        FindTextHandler handle = null;
        public int Start { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Start = handle(richTextBox1.Text, Start, RichTextBoxFinds.None);

        }

        public void SetSearchText(string text)
        {
            richTextBox1.Text = text;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length>0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Findfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
