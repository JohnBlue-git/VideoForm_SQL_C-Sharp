/*
Auther: JohnBlue

Time: 2021/5

Platform: VS 2017

Object: It is a MDI application form for video playing and image saving/exporting.

Support by: WinForm, EmguCV, SQL
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_MyForm
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm("MainForm"));
        }
    }
}
