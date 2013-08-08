using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GifStudio.ChildForms
{
    public partial class VideoUploadControl : UserControl
    {
        public VideoUploadControl()
        {
            InitializeComponent();
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            listBoxTags.Items.Add(textBoxTagAdder.Text);
        }
    }
}
