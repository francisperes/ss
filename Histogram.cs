using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;

namespace SS_OpenCV
{
    public partial class Histogram : Form
    {

        public Histogram(int [,] array, int selector)
        {
            InitializeComponent();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();

            chart1.Series.Add(series2);
            chart1.Series.Add(series3);
            chart1.Series.Add(series4);
            
            switch (selector) {
                case -2:Hist_RGB(array);   break;
                case -1:Hist_All(array);   break;
                case 3: Hist_Red(array);   break;
                case 2: Hist_Green(array); break;
                case 1: Hist_Blue(array);  break;                    
                case 0: Hist_Gray(array);  break;
            }
                
            chart1.Series[0].Color = Color.Gray;
            chart1.Series[1].Color = Color.Blue;
            chart1.Series[2].Color = Color.Green;
            chart1.Series[3].Color = Color.Red;
            chart1.ChartAreas[0].AxisX.Maximum = 255;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Title = "Intensity";
            chart1.ChartAreas[0].AxisY.Title = "Pixel Count";
            chart1.ResumeLayout();

        }

        private void Hist_RGB(int [,] array)
        {
            for (int j = 1; j < 4; j++)
                for (int i = 0; i < 256; i++)
                    chart1.Series[j].Points.AddXY(i, array[j, i]);
        }
        private void Hist_All(int [,] array)
        {
            for (int j = 0; j < 4; j++)
                for (int i = 0; i < 256; i++)
                    chart1.Series[j].Points.AddXY(i, array[j, i]);
        }
        private void Hist_Red(int[,] array)
        {
            for (int i = 0; i < 256; i++)
                chart1.Series[3].Points.AddXY(i, array[3, i]);
        }
        private void Hist_Green(int[,] array)
        {
            for (int i = 0; i < 256; i++)
                chart1.Series[2].Points.AddXY(i, array[2, i]);
        }
        private void Hist_Blue(int[,] array)
        {
            for (int i = 0; i < 256; i++)
                chart1.Series[1].Points.AddXY(i, array[1, i]);
        }
        private void Hist_Gray(int[,] array)
        {
            for (int i = 0; i < 256; i++)
                chart1.Series[0].Points.AddXY(i, array[0, i]);
        }
    }
}
