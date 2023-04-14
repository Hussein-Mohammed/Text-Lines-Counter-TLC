using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lines_Counter.Headers
{
    public class Temp_Parameters
    {
        public string ID { get; set; } = "";
        public bool Rotate { get; set; } = false;
        public float Total_Evaluation { get; set; } = 0.0F;
        public float Length_mm { get; set; } = 20;
        public bool Resize { get; set; } = true;
        public double ResizeFactor { get; set; } = 0.5;
        public int CurrentImageIndex { get; set; } = 0;

        // Detection Parameters
        public int ksizeWidth { get; set; } = 51;
        public Size ksize { get; set; }
        public float Min_Scale { get; set; } = 0.6F;
        public float Max_Scale { get; set; } = 0.6F;
        public int TilesGridWidth { get; set; } = 4;
        public Size TilesGridSize { get; set; }
        public double ClipLimit { get; set; } = 40;
        public bool Apply_HistEqu { get; set; } = true;
        public bool Apply_CLAHE { get; set; } = true;
        public int Channel { get; set; } = 0;
        public double DetectionBorder { get; set; } = 0.1;
        public bool Detect_High_Intensity { get; set; } = false;

        public Temp_Parameters()
        {
            ksize = new Size(ksizeWidth,ksizeWidth);
            TilesGridSize = new Size(TilesGridWidth, TilesGridWidth);
        }
    }
}
