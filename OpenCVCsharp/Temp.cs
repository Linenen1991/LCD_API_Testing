/*
 * Image<Rgb, byte> img1 = new Image<Rgb, byte>(640, 480);
MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_SIMPLEX, 1d, 1d);
img1.Draw("Hello 4A1G0905", ref font, new Point(100, 100), new Rgb(255, 255, 255));
new ImageViewer(img1).ShowDialog();

 * if (pictureBox1.Image == null)
    return;
Image<Rgb, byte> img1 = new Image<Rgb, byte>((Bitmap)pictureBox1.Image);
Image<Gray, byte> img2 = img1.Convert<Gray, byte>();//灰階
Image<Gray, byte> img3 = img2.Resize(0.5d, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);//縮小
pictureBox1.Image = img3.Bitmap;
 * Image<Gray, byte> img1 = new Image<Gray, byte>(@"C:\Users\Uader\Documents\Visual Studio 2012\Projects\1.png");
*/
