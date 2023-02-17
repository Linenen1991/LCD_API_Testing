using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;

namespace OpenCVCsharp
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image<Rgb, Byte> Source, Display;
        Bitmap MapSoure;
        private bool Func(Bitmap toDisplay, int Value)
        {
            int Width = MapSoure.Width, Height = MapSoure.Height, WHBound = 10;
            Boolean Flag = false;
            for (int X = WHBound; X < Width - WHBound; X++) 
            {
                int Sum = 0;
                for (int Y = WHBound; Y < Height - WHBound; Y++)
                    Sum += toDisplay.GetPixel(X, Y).R;
                int Average = Sum / (Height - WHBound * 2);
                for (int Y = WHBound; Y < Height - WHBound; Y++)
                {
                    int R = toDisplay.GetPixel(X, Y).R;
                    if (Value < Math.Abs(Average - R))
                    {
                        MapSoure.SetPixel(X, Y, Color.Red);
                        if (!Flag)
                        {
                            Color pixel = MapSoure.GetPixel(X - 1, Y), pixel2 = MapSoure.GetPixel(X, Y - 1);
                            if ((pixel.R == 255 && pixel.R != pixel.G) || (pixel2.R == 255 && pixel2.R != pixel2.G))
                                Flag = true;
                        }
                    }
                }
            }
            if (Flag)
                pictureBox1.Image = MapSoure;
            return Flag ;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            if (OP.ShowDialog() == DialogResult.OK)
            {
                Source = new Image<Rgb, Byte>(OP.FileName);
                MapSoure = Source.Bitmap;
                Display = Source;
                pictureBox1.Image = MapSoure;
                label1.Text = "品質:";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int Value = 10;
            for (int i = 0; i < Value; i++)
                Display._SmoothGaussian(5);
            if (Func(Display.Bitmap, Value))
                label1.Text = "品質: 瑕疵";
            else
            {
                Display = Display.Sobel(0, 1, 25).Convert<Rgb, Byte>();
                Value *= 8;
                if (Func(Display.Bitmap, Value))
                    label1.Text = "品質: 瑕疵";
                else
                    label1.Text = "品質: OK";
            }
        }
    }//class
}//form
