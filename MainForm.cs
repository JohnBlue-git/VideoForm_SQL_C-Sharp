/*
Auther: JohnBlue

Time: 2021/5

Platform: VS 2017

Object: It is a MDI application form for video playing and image saving/exporting.

Support by: WinForm, EmguCV, SQL
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_MyForm
{
    public partial class MainForm : Form
    {
        ////// my memeber
        // form
        private int num_form = 0;
        private string form_name;
        //
        //
        public MainForm(string s)
        {
            // initial
            InitializeComponent();
            // initial my setting of form
            form_name = s;
            this.menuStrip1.MdiWindowListItem = this.viewToolStripMenuItem;// view mdi list
        }
        ////// function
        private void newForm1ToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            num_form++;
            string s = "Form " + Convert.ToString(num_form);
            ChildForm form = new ChildForm(s);
            //CheckForIllegalCrossThreadCalls = false;
            form.MdiParent = this;
            form.Show();
            //form.ShowDialog(); // not work with mdi
            //System.Windows.Forms.Application.Run(form);// not efficient, and not allowed
        }

        /////// the following function is for rearranging MyForms as a child form
        /////// but the size will change if we do so; therefore, a FixFormBorder or Sizable Form border is used here

        private void FixFormBorder()
        {
            foreach (Form f in this.MdiChildren)

            {
                ChildForm F = (ChildForm)f;
                F.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            }
        }

        private void SizableFormBorder()
        {
            foreach (Form f in this.MdiChildren)

            {
                ChildForm F = (ChildForm)f;
                F.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        private void cascadeToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            // fix
            FixFormBorder();
            // Cascade
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
            // sizable
            SizableFormBorder();
        }

        private void verticalToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            // fix
            FixFormBorder();
            // Vertical
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
            // sizable
            SizableFormBorder();
        }

        private void horizontalToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            // fix
            FixFormBorder();
            // Horizontal
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
            // sizable
            SizableFormBorder();
        }
        // close
        private void CloseF(Object sender, FormClosingEventArgs e)
        {
            // close by foreach
            /*
            foreach (Form f in this.MdiChildren) {
                ChildForm F = (ChildForm)f;
                F.Close();
            }*/            

            // can close all the System::Windows::Forms::Application::Run(...)
            System.Windows.Forms.Application.Exit();
        }
    }
}
