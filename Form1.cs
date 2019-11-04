using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SS_OpenCV
{
    public partial class Form1 : Form
    {
        public float[,] matrix = new float[3, 3] {{0,0,0},
                                       {0,0,0},
                                       {0,0,0}};
        public float weight_T = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {
            
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            matrix[0,0] = float.Parse(sender.ToString().Substring(36));
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            matrix[0, 1] = float.Parse(sender.ToString().Substring(36));
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            matrix[0, 2] = float.Parse(sender.ToString().Substring(36));
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            matrix[1, 0] = float.Parse(sender.ToString().Substring(36));
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            matrix[1, 1] = float.Parse(sender.ToString().Substring(36));
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            matrix[1, 2] = float.Parse(sender.ToString().Substring(36));
        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {
            matrix[2, 0] = float.Parse(sender.ToString().Substring(36));
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {
            matrix[2, 1] = float.Parse(sender.ToString().Substring(36));
        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {
            matrix[2, 2] = float.Parse(sender.ToString().Substring(36));
        }

        private void Weight_TextChanged(object sender, EventArgs e)
        {
            weight_T = float.Parse(sender.ToString().Substring(36));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }


}
