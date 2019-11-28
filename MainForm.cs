using System;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace SS_OpenCV
{ 
    public partial class MainForm : Form
    {
        Image<Bgr, Byte> img = null; // working image
        Image<Bgr, Byte> imgUndo = null; // undo backup image - UNDO
        string title_bak = "";

        public MainForm()
        {
            InitializeComponent();
            title_bak = Text;
        }

        /// <summary>
        /// Opens a new image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = new Image<Bgr, byte>(openFileDialog1.FileName);
                Text = title_bak + " [" +
                        openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("\\") + 1) +
                        "]";
                imgUndo = img.Copy();
                ImageViewer.Image = img.Bitmap;
                ImageViewer.Refresh();
            }
        }

        /// <summary>
        /// Saves an image with a new name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImageViewer.Image.Save(saveFileDialog1.FileName);
            }
        }

        /// <summary>
        /// Closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// restore last undo copy of the working image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgUndo == null) // verify if the image is already opened
                return; 
            Cursor = Cursors.WaitCursor;
            img = imgUndo.Copy();

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
        }

        /// <summary>
        /// Change visualization mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // zoom
            if (autoZoomToolStripMenuItem.Checked)
            {
                ImageViewer.SizeMode = PictureBoxSizeMode.Zoom;
                ImageViewer.Dock = DockStyle.Fill;
            }
            else // with scroll bars
            {
                ImageViewer.Dock = DockStyle.None;
                ImageViewer.SizeMode = PictureBoxSizeMode.AutoSize;
            }
        }

        /// <summary>
        /// Show authors form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorsForm form = new AuthorsForm();
            form.ShowDialog();
        }

        /// <summary>
        /// Calculate the image negative
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            ImageClass.Negative(img);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
        }

        /// <summary>
        /// Call automated image processing check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void evalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EvalForm eval = new EvalForm();
            eval.ShowDialog();
        }

        /// <summary>
        /// Call image convertion to gray scale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            ImageClass.ConvertToGray(img);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
        }

        private void RedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            ImageClass.RedChannel(img);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 

        }

        private void BlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            ImageClass.ConvertToBlue(img);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 

        }

        private void GreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            ImageClass.ConvertToGreen(img);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 


        }

        private void ContrastBrightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            InputBox input = new InputBox("Contrast (0 to 3):");
            input.ShowDialog();
            double contrast_value = Convert.ToDouble(input.ValueTextBox.Text);


            input = new InputBox("Brightness (0 to 255):");
            input.ShowDialog();
            int brightness_value = Convert.ToInt32(input.ValueTextBox.Text);
            //copy Undo Image
            imgUndo = img.Copy();

            ImageClass.BrightContrast(img, brightness_value, contrast_value);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 

        }

        private void TranslationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            InputBox input = new InputBox("Dx:");
            input.ShowDialog();
            int trans_x = Convert.ToInt32(input.ValueTextBox.Text);


            input = new InputBox("Dy:");
            input.ShowDialog();
            int trans_y = Convert.ToInt32(input.ValueTextBox.Text);
            //copy Undo Image
            imgUndo = img.Copy();

            Image<Bgr, byte> imgCopy = img.Clone();
            ImageClass.Translation(img, imgCopy, trans_x, trans_y);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }

        private void RotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 
                       
            InputBox input = new InputBox("Degrees:");
            input.ShowDialog();
            double degrees = Convert.ToDouble(input.ValueTextBox.Text);

            //convert to rads
            double rad_degrees = degrees * Math.PI / 180;

            //copy Undo Image
            imgUndo = img.Copy();

            Image<Bgr, Byte> imgCopy = img.Clone();

            ImageClass.Rotation(img, imgCopy, rad_degrees);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }


        //create mouse variables
        int mouseX, mouseY;
        bool mouseFlag = false;

        private void ImageViewer_MouseClick(object sender, MouseEventArgs e)
        {
            if (mouseFlag)
            {
                mouseX = e.X;
                mouseY = e.Y;
                
                mouseFlag = false;
            }
        }

        private void x3MediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;

            //copy Undo Image
            imgUndo = img.Copy();

            Image<Bgr, Byte> imgCopy = img.Clone();

            ImageClass.Mean(img, imgCopy);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }

        private void MeanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 Gui = new Form1();
            Gui.ShowDialog();

            float[,] matrix = Gui.matrix;
            float weight = Gui.weight_T;



            if (img == null) // verify if the image is already opened
                return;

            //copy Undo Image
            imgUndo = img.Copy();

            Image<Bgr, Byte> imgCopy = img.Clone();

            ImageClass.NonUniform(img, imgCopy, matrix, weight);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }

        private void MedianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;

            //copy Undo Image
            imgUndo = img.Copy();

            Image<Bgr, Byte> imgCopy = img.Clone();

            ImageClass.Median(img, imgCopy);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }

        private void SobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;

            //copy Undo Image
            imgUndo = img.Copy();

            Image<Bgr, Byte> imgCopy = img.Clone();

            ImageClass.Sobel(img, imgCopy);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }

        private void DiferentiationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;

            //copy Undo Image
            imgUndo = img.Copy();

            Image<Bgr, Byte> imgCopy = img.Clone();

            ImageClass.Diferentiation(img, imgCopy);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }

        private void GrayBinManToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            InputBox input = new InputBox("Threshold:");
            input.ShowDialog();
            int threshold = Convert.ToInt32(input.ValueTextBox.Text);

            imgUndo = img.Copy();

            ImageClass.ConvertToBW(img, threshold);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }

        private void AllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;

            imgUndo = img.Copy();
            
            Histogram his = new Histogram(ImageClass.Histogram_All(img), -1);

            img = imgUndo;
            his.ShowDialog();
        }

        private void RedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;

            imgUndo = img.Copy();

            Histogram his = new Histogram(ImageClass.Histogram_All(img), 3);

            img = imgUndo;

            his.ShowDialog();
        }

        private void GreenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;

            imgUndo = img.Copy();

            Histogram his = new Histogram(ImageClass.Histogram_All(img), 2);

            img = imgUndo;

            his.ShowDialog();
        }

        private void BlueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;

            imgUndo = img.Copy();
            
            Histogram his = new Histogram(ImageClass.Histogram_All(img), 1);

            img = imgUndo;

            his.ShowDialog();
        }

        private void GrayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;

            imgUndo = img.Copy();

            Histogram his = new Histogram(ImageClass.Histogram_All(img), 0);

            img = imgUndo;

            his.ShowDialog();
        }

        private void RGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;

            imgUndo = img.Copy();

            Histogram his = new Histogram(ImageClass.Histogram_All(img), -2);

            img = imgUndo;

            his.ShowDialog();
        }

        private void CompligToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;

            //copy Undo Image
            imgUndo = img.Copy();

            ImageClass.ConnectedComponents(img);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }

        private void ZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            
            Cursor = Cursors.WaitCursor; // clock cursor 
            
            InputBox input = new InputBox("Scale Factor:");
            input.ShowDialog();
            double scale_factor = Convert.ToDouble(input.ValueTextBox.Text);

            mouseFlag = true;
            while (mouseFlag)
                Application.DoEvents();

            //copy Undo Image
            imgUndo = img.Copy();

            Image<Bgr, Byte> imgCopy = img.Clone();
            float scale_ff= (float)Math.Round(scale_factor);
            ImageClass.Scale_point_xy(img, imgCopy, scale_ff, mouseX, mouseY);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }
    }




}