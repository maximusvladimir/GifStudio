using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GifStudio
{
    public partial class AnimatedGifChildForm : Form
    {
        public AnimatedGifChildForm()
        {
            InitializeComponent();
        }

        public void SetGif(string path)
        {
            FilePath = path;
            pictureBox1.LoadProgressChanged += pictureBox1_LoadProgressChanged;
            pictureBox1.LoadCompleted += pictureBox1_LoadCompleted;
            pictureBox1.LoadAsync(path);
        }

        void pictureBox1_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Action action = (Action)delegate()
            {
                Studio.SetProgress(this, e.ProgressPercentage);
                Studio.SetStatus(this, "Loading GIF " + e.ProgressPercentage + "%.");
            };
            if (InvokeRequired)
            {
                Invoke(action);  
            }
            action.Invoke();
        }

        void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Action action = (Action)delegate()
            {
                Studio.SetProgress(this, 100);
                Studio.SetStatus(this, "GIF loaded.");
                ImageWidth = pictureBox1.Image.Width;
                ImageHeight = pictureBox1.Image.Height;
            };
            if (InvokeRequired)
            {
                Invoke(action);
            }
            action.Invoke();
        }

        public string FilePath
        {
            get;
            private set;
        }

        public int ImageWidth
        {
            get;
            private set;
        }

        public int ImageHeight
        {
            get;
            private set;
        }
    }
}
