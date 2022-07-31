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
    public delegate int FindTextHandler(string search, int start, RichTextBoxFinds options);

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        public static string findtext;
        public static string Replacetext;

        private Findfrm finderForm = null;
        public Findfrm FinderForm
        {
            get
            {
                if (finderForm == null)
                    finderForm = new Findfrm(FindText) { TopMost = true } ;
                return finderForm;
            }
        }

        private GoToForm gotoForm;
        public GoToForm GoToForm
        {
            get
            {
                if (gotoForm == null)
                    gotoForm = new GoToForm();
                return gotoForm;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        public int FindText(string search, int start, RichTextBoxFinds options)
        {
            int result = richTextBox1.Find(search, start, options);
            if (result == -1)
                MessageBox.Show("Axtaris netice vermedi");
            else
                richTextBox1.Focus();
            return result != -1 ? result + 1 : start;
        }

        public void GoToText(int lineNumber)
        {
            richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(lineNumber);

            
        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormAbout frmabout = new FormAbout())
            {
                frmabout.ShowDialog();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Qeyd Olunan Sayta Daxil Olaraq Melumatlana Bilersiniz.\nElaqe : www.turabbaxisli.com", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.BackColor = Color.White;
            richTextBox1.Clear();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
          
            
        }

        public void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
           
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text +=  DateTime.Now;
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinderForm.Show();
            FinderForm.Start = richTextBox1.SelectionStart;
            if (!string.IsNullOrEmpty(richTextBox1.SelectedText))
                FinderForm.SetSearchText(richTextBox1.SelectedText);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text(*.txt)|*.txt";
            openFileDialog1.Title = "Open File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "All text (*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "All text (*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
         
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Replace rrp = new Replace();
            rrp.ShowDialog();

            richTextBox1.Find(findtext);
            richTextBox1.SelectedText = Replacetext;
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.WordWrap == true)
            {
                richTextBox1.WordWrap = false;

            }
            else
            {
                richTextBox1.WordWrap = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.BackColor = colorDialog1.Color;
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.ForeColor = colorDialog1.Color;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Cixmaq Istediyinize eminsiniz mi?", "NotePad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
                  
            
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = richTextBox1.CanUndo;
            copyToolStripMenuItem.Enabled = cutToolStripMenuItem.Enabled = deleteToolStripMenuItem.Enabled = richTextBox1.SelectionLength > 0;
            pasteToolStripMenuItem.Enabled = richTextBox1.CanPaste(DataFormats.GetFormat(DataFormats.Text));
            findToolStripMenuItem.Enabled = findNextToolStripMenuItem.Enabled = richTextBox1.TextLength > 0;
            goToToolStripMenuItem.Enabled = !wordWrapToolStripMenuItem.Checked;
        }
    }
}
