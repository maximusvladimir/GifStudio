using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GifStudio.ChildForms
{
    public partial class FLVChildForm : Form
    {
        public FLVChildForm()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.google.ru");
        }

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            string nativeString = "";
            try
            {
                nativeString = Clipboard.GetText(TextDataFormat.Text);
            }
            catch (Exception)
            {
                try
                {
                    nativeString = Clipboard.GetText(TextDataFormat.Text);
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(250);
                    try
                    {
                        nativeString = Clipboard.GetText(TextDataFormat.Text);
                    }
                    catch (Exception)
                    {
                        System.Threading.Thread.Sleep(750);
                        try
                        {
                            nativeString = Clipboard.GetText(TextDataFormat.Text);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(nativeString))
                boxURL.Text = nativeString;
        }
    }
}
