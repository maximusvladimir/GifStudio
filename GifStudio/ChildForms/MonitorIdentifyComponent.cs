using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GifStudio.ChildForms
{
    public partial class MonitorIdentifyComponent : Form
    {
        Timer ticker = new Timer();
        public MonitorIdentifyComponent(int num)
        {
            InitializeComponent();
            label1.Text = num.ToString();
            label1.Click += label1_Click;
            Click += MonitorIdentifyComponent_Click;
            ticker.Interval = 4500;
            ticker.Tick += ticker_Tick;
            ticker.Enabled = true;
            ticker.Start();
        }

        void ticker_Tick(object sender, EventArgs e)
        {
            Close();
        }

        void MonitorIdentifyComponent_Click(object sender, EventArgs e)
        {
            Close();
        }

        void label1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
