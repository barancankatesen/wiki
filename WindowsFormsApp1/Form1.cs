using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            TabPage page = tabControl1.SelectedTab; ;

            var tp2 = page.Controls;
            foreach (Control item in tp2)
            {
                if (item is TextBox||item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            ResizeForm(tabPage1);
        }

        private void ResizeForm(TabPage tbpg)
        {
            int maxleft = 0;
            int maxheight = 0;
            foreach (Control item in tbpg.Controls)
            {
                if (maxleft < (item.Location.X + item.Width))
                {
                    maxleft = item.Location.X + item.Width;
                }
                if (maxheight < (item.Location.Y + item.Height))
                {
                    maxheight = item.Location.Y + item.Height;
                }
            }
            ((Form)Application.OpenForms["Form1"]).Width = maxleft+30;
            ((Form)Application.OpenForms["Form1"]).Height = maxheight+70;
           
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            ResizeForm(tabPage2);
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            ResizeForm(tabPage3);
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            ResizeForm(tabPage4);
        }
    }
}
