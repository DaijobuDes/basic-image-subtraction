using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace image_subtraction
{
    public partial class Form1 : Form
    {
        private Bitmap _foreground, _background;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
        }


        private void LoadGreenImage(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void LoadBackgroundImage(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void SubtractImages(object sender, EventArgs e)
        {
            Color green = Color.FromArgb(0, 255, 0);
            int threshold = 100;

            Bitmap result = new Bitmap(_foreground.Width, _foreground.Height);

            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    Color pixel = _foreground.GetPixel(x, y);
                    Color bgpixel = _background.GetPixel(x, y);
                    int r, g, b;
                    r = Math.Abs(green.R - pixel.R);
                    g = Math.Abs(green.G - pixel.G);
                    b = Math.Abs(green.B - pixel.B);

                    if (r < threshold && g < threshold && b < threshold)
                    {
                        result.SetPixel(x, y, bgpixel);
                    }
                    else
                    {
                        result.SetPixel(x, y, pixel);
                    }
                }
            }
            pictureBox3.Image = result;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            _foreground = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = _foreground;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            _background = new Bitmap(openFileDialog2.FileName);
            pictureBox2.Image = _background;
        }

    }
}
