using Gifbrary.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GifStudio.Exports
{
    public partial class ExportWindow : Form
    {
        public ExportWindow()
        {
            InitializeComponent();
        }

        public Exportable ExportData
        {
            get;
            set;
        }

        public Conversion Converter
        {
            get;
            set;
        }

        public float CountProgress
        {
            get;
            set;
        }
    }
}
