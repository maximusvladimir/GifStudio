﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gifbrary.Common
{
    public class Exportable
    {
        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }
        public string SourceFilePath
        {
            get;
            set;
        }

        public string DestinationFilePath
        {
            get;
            set;
        }

        public int FPS
        {
            get;
            set;
        }

        public int Quality
        {
            get;
            set;
        }

        public long TrimStart
        {
            get;
            set;
        }

        public long TrimLength
        {
            get;
            set;
        }

        public bool OriginalSize { get; set; }
    }
}