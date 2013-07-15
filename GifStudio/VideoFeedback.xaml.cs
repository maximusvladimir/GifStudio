using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GifStudio
{
    /// <summary>
    /// Interaction logic for VideoFeedback.xaml
    /// </summary>
    public partial class VideoFeedback : UserControl
    {
        public VideoFeedback()
        {
            InitializeComponent();
        }

        public WPFMediaKit.DirectShow.Controls.MediaUriElement Player
        {
            get
            {
                return player;
            }
        }
    }
}
