using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV.Structure;
using Emgu.CV;

namespace SS_OpenCV
{
    class ImageClass
    {

        /// <summary>
        /// Image Negative using EmguCV library
        /// Slower method
        /// </summary>
        /// <param name="img">Image</param>
        public unsafe static void Negative(Image<Bgr, byte> img)
        {

            int x, y;
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();
            byte blue, green, red;
            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int padding = mipl.widthStep - mipl.nChannels * mipl.width;


            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {
                    blue = data_ptr[0];
                    green = data_ptr[1];
                    red = data_ptr[2];

                    // acesso directo : mais lento 
                    data_ptr[0] = (byte)(255 - (int)data_ptr[0]);
                    data_ptr[1] = (byte)(255 - (int)data_ptr[1]);
                    data_ptr[2] = (byte)(255 - (int)data_ptr[2]);
                    data_ptr += nChannels;

                }
                data_ptr += padding;
            }
        }

        /// <summary>
        /// Convert to gray
        /// Direct access to memory - faster method
        /// </summary>
        /// <param name="img">image</param>
        public static void ConvertToGray(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red, gray;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = (dataPtr + x * nChan + y * m.widthStep)[0];
                            green = (dataPtr + x * nChan + y * m.widthStep)[1];
                            red = (dataPtr + x * nChan + y * m.widthStep)[2];

                            // convert to gray
                            gray = (byte)Math.Round(((int)blue + green + red) / 3.0);

                            // store in the image
                            (dataPtr + x * nChan + y * m.widthStep)[0] = gray;
                            (dataPtr + x * nChan + y * m.widthStep)[1] = gray;
                            (dataPtr + x * nChan + y * m.widthStep)[2] = gray;

                            // advance the pointer to the next pixel
                            //dataPtr += nChan;

                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        //dataPtr += padding;
                    }
                }
            }
        }

        public static void RedChannel(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];


                            // store in the image
                            dataPtr[0] = red;
                            dataPtr[1] = red;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }

        public static void ConvertToBlue(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];


                            // store in the image
                            dataPtr[1] = blue;
                            dataPtr[2] = blue;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }

        public static void ConvertToGreen(Image<Bgr, byte> img)
        {
            unsafe
            {
                // direct access to the image memory(sequencial)
                // direcion top left -> bottom right

                MIplImage m = img.MIplImage;
                byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
                byte blue, green, red;

                int width = img.Width;
                int height = img.Height;
                int nChan = m.nChannels; // number of channels - 3
                int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                int x, y;

                if (nChan == 3) // image in RGB
                {
                    for (y = 0; y < height; y++)
                    {
                        for (x = 0; x < width; x++)
                        {
                            //retrive 3 colour components
                            blue = dataPtr[0];
                            green = dataPtr[1];
                            red = dataPtr[2];


                            // store in the image
                            dataPtr[0] = green;
                            dataPtr[2] = green;

                            // advance the pointer to the next pixel
                            dataPtr += nChan;
                        }

                        //at the end of the line advance the pointer by the aligment bytes (padding)
                        dataPtr += padding;
                    }
                }
            }
        }

        public unsafe static void BrightContrast(Image<Bgr, byte> img, int bright, double contrast)
        {

            int x, y;
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();
            byte blue, green, red;
            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int padding = mipl.widthStep - mipl.nChannels * mipl.width;


            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {
                    blue = data_ptr[0];
                    green = data_ptr[1];
                    red = data_ptr[2];

                    int blue_res = (int)Math.Round((contrast * (double)blue) + (double)bright);
                    int green_res = (int)Math.Round((contrast * (double)green) + (double)bright);
                    int red_res = (int)Math.Round((contrast * (double)red) + (double)bright);

                    if (blue_res > 255) blue_res = 255;
                    if (green_res > 255) green_res = 255;
                    if (red_res > 255) red_res = 255;

                    // acesso directo : mais lento 
                    data_ptr[0] = (byte)blue_res;
                    data_ptr[1] = (byte)green_res;
                    data_ptr[2] = (byte)red_res;
                    data_ptr += nChannels;

                }
                data_ptr += padding;
            }
        }

        // Translation helper function
        private unsafe static void TranslationXPositiveYPositive(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, int offset_x, int offset_y)
        {
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();
            int n_channels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int width_step = mipl.widthStep;
            int padding = mipl.widthStep - mipl.nChannels * mipl.width;

            img.SetZero();
            byte* data_ptr_clone = (byte*)imgCopy.MIplImage.imageData.ToPointer();

            for (int y = offset_y; y < height; y++)
            {
                for (int x = offset_x; x < width; x++)
                {
                    byte* new_byte = (byte*)(data_ptr_clone + (x - offset_x) * n_channels + (y - offset_y) * width_step);
                    byte* byte_to_change = (byte*)(data_ptr + x * n_channels + y * width_step);

                    byte_to_change[0] = new_byte[0];
                    byte_to_change[1] = new_byte[1];
                    byte_to_change[2] = new_byte[2];
                }
            }
        }

        // Translation helper function
        private unsafe static void TranslationXPositiveYNegative(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, int offset_x, int offset_y)
        {
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();
            int n_channels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int width_step = mipl.widthStep;
            int padding = mipl.widthStep - mipl.nChannels * mipl.width;

            img.SetZero();
            byte* data_ptr_clone = (byte*)imgCopy.MIplImage.imageData.ToPointer();

            for (int y = 0; y < height + offset_y; y++)
            {
                for (int x = offset_x; x < width; x++)
                {
                    byte* new_byte = (byte*)(data_ptr_clone + (x - offset_x) * n_channels + (y - offset_y) * width_step);
                    byte* byte_to_change = (byte*)(data_ptr + x * n_channels + y * width_step);

                    byte_to_change[0] = new_byte[0];
                    byte_to_change[1] = new_byte[1];
                    byte_to_change[2] = new_byte[2];
                }
            }
        }

        // Translation helper function
        private unsafe static void TranslationXNegativeYPositive(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, int offset_x, int offset_y)
        {
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();
            int n_channels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int width_step = mipl.widthStep;
            int padding = mipl.widthStep - mipl.nChannels * mipl.width;

            img.SetZero();
            byte* data_ptr_clone = (byte*)imgCopy.MIplImage.imageData.ToPointer();

            for (int y = offset_y; y < height; y++)
            {
                for (int x = 0; x < width + offset_x; x++)
                {
                    byte* new_byte = (byte*)(data_ptr_clone + (x - offset_x) * n_channels + (y - offset_y) * width_step);
                    byte* byte_to_change = (byte*)(data_ptr + x * n_channels + y * width_step);

                    byte_to_change[0] = new_byte[0];
                    byte_to_change[1] = new_byte[1];
                    byte_to_change[2] = new_byte[2];
                }
            }
        }

        // Translation helper function
        private unsafe static void TranslationXNegativeYNegative(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, int offset_x, int offset_y)
        {
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();
            int n_channels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int width_step = mipl.widthStep;
            int padding = mipl.widthStep - mipl.nChannels * mipl.width;

            img.SetZero();
            byte* data_ptr_clone = (byte*)imgCopy.MIplImage.imageData.ToPointer();

            for (int y = 0; y < height + offset_y; y++)
            {
                for (int x = 0; x < width + offset_x; x++)
                {
                    byte* new_byte = (byte*)(data_ptr_clone + (x - offset_x) * n_channels + (y - offset_y) * width_step);
                    byte* byte_to_change = (byte*)(data_ptr + x * n_channels + y * width_step);

                    byte_to_change[0] = new_byte[0];
                    byte_to_change[1] = new_byte[1];
                    byte_to_change[2] = new_byte[2];
                }
            }
        }

        public unsafe static void Translation(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, int trans_x, int trans_y)
        {
            if (trans_x >= 0 && trans_y >= 0)
            {
                TranslationXPositiveYPositive(img, imgCopy, trans_x, trans_y);
            }
            else if (trans_x >= 0 && trans_y < 0)
            {
                TranslationXPositiveYNegative(img, imgCopy, trans_x, trans_y);
            }
            else if (trans_x < 0 && trans_y >= 0)
            {
                TranslationXNegativeYPositive(img, imgCopy, trans_x, trans_y);
            }
            else
            {
                TranslationXNegativeYNegative(img, imgCopy, trans_x, trans_y);
            }
        }

        public unsafe static void Rotation(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, double degrees)
        {
            ConvertRGBToHSV(img);
            ConvertToBR_HSV(img);
            ConvertHSVToRGB(img);
            return;
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();
            byte* data_ptr_clone = (byte*)imgCopy.MIplImage.imageData.ToPointer();

            img.SetZero();

            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int padding = mipl.widthStep - mipl.nChannels * mipl.width;
            int widthStep = mipl.widthStep;

            double rot_cos = Math.Cos(degrees);
            double rot_sin = Math.Sin(degrees);

            int x_dest, y_dest;
            int x_orig, y_orig;

            double width_division = width / 2.0;
            double height_division = height / 2.0;

            for (y_dest = 0; y_dest < height; y_dest++)
            {
                for (x_dest = 0; x_dest < width; x_dest++)
                {
                    x_orig = (int)Math.Round((x_dest - width_division) * rot_cos - (height_division - y_dest) * rot_sin + width_division);
                    y_orig = (int)Math.Round(height_division - (x_dest - width_division) * rot_sin - (height_division - y_dest) * rot_cos);

                    if (x_orig >= 0 && x_orig < width && y_orig >= 0 && y_orig < height)
                    {
                        (data_ptr + nChannels * x_dest + y_dest * widthStep)[0] = (data_ptr_clone + nChannels * x_orig + y_orig * widthStep)[0];
                        (data_ptr + nChannels * x_dest + y_dest * widthStep)[1] = (data_ptr_clone + nChannels * x_orig + y_orig * widthStep)[1];
                        (data_ptr + nChannels * x_dest + y_dest * widthStep)[2] = (data_ptr_clone + nChannels * x_orig + y_orig * widthStep)[2];
                    }
                }
            }
        }

        public unsafe static void Scale_point_xy(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float scale_factor, int centerx, int centery)
        {
            int x_orig, y_orig;

            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();
            byte* data_ptr_clone = (byte*)imgCopy.MIplImage.imageData.ToPointer();

            img.SetZero();

            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int padding = mipl.widthStep - mipl.nChannels * mipl.width;
            int widthStep = mipl.widthStep;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Zoom at center
                    //x_orig = (int)Math.Round((x + width / 2.0) / scale_factor);
                    //y_orig = (int)Math.Round((y + height / 2.0) / scale_factor);

                    // No idea why this doesn't work
                    x_orig = (int)Math.Round((x - width / 2) / scale_factor + centerx);
                    y_orig = (int)Math.Round((y - height / 2) / scale_factor + centery);

                    // Not efficient
                    if (x_orig >= 0 && x_orig < width && y_orig >= 0 && y_orig < height)
                    {
                        (data_ptr + nChannels * x + y * widthStep)[0] = (data_ptr_clone + nChannels * x_orig + y_orig * widthStep)[0];
                        (data_ptr + nChannels * x + y * widthStep)[1] = (data_ptr_clone + nChannels * x_orig + y_orig * widthStep)[1];
                        (data_ptr + nChannels * x + y * widthStep)[2] = (data_ptr_clone + nChannels * x_orig + y_orig * widthStep)[2];
                    }
                }
            }
        }

        public unsafe static void Mean(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            int x, y;
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();

            byte* data_ptr_clone = (byte*)imgCopy.MIplImage.imageData.ToPointer();

            //img.SetZero();

            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int padding = mipl.widthStep - mipl.nChannels * mipl.width;
            int widthStep = mipl.widthStep;
            int lastXPixel = width - 1;
            int lastYPixel = height - 1;

            byte* pos_1, pos_2, pos_3;
            byte* pos_4, pos_5, pos_6;
            byte* pos_7, pos_8, pos_9;

            //Top left corner
            pos_5 = (data_ptr_clone);
            pos_6 = (data_ptr_clone + nChannels);
            pos_8 = (data_ptr_clone + widthStep);
            pos_9 = (data_ptr_clone + nChannels + widthStep);

            int blue_avg = (int)Math.Round((pos_5[0] * 4 + pos_6[0] * 2 + pos_8[0] * 2 + pos_9[0]) / 9.0);
            int green_avg = (int)Math.Round((pos_5[1] * 4 + pos_6[1] * 2 + pos_8[1] * 2 + pos_9[1]) / 9.0);
            int red_avg = (int)Math.Round((pos_5[2] * 4 + pos_6[2] * 2 + pos_8[2] * 2 + pos_9[2]) / 9.0);

            (data_ptr)[0] = (byte)blue_avg;
            (data_ptr)[1] = (byte)green_avg;
            (data_ptr)[2] = (byte)red_avg;

            //Top right corner
            pos_4 = (data_ptr_clone + nChannels * (lastXPixel - 1));
            pos_5 = (data_ptr_clone + nChannels * lastXPixel);
            pos_7 = (data_ptr_clone + nChannels * (lastXPixel - 1) + widthStep);
            pos_8 = (data_ptr_clone + nChannels * lastXPixel + widthStep);

            blue_avg = (int)Math.Round((pos_4[0] * 2 + pos_5[0] * 4 + pos_7[0] + pos_8[0] * 2) / 9.0);
            green_avg = (int)Math.Round((pos_4[1] * 2 + pos_5[1] * 4 + pos_7[1] + pos_8[1] * 2) / 9.0);
            red_avg = (int)Math.Round((pos_4[2] * 2 + pos_5[2] * 4 + pos_7[2] + pos_8[2] * 2) / 9.0);

            (data_ptr + nChannels * lastXPixel)[0] = (byte)blue_avg;
            (data_ptr + nChannels * lastXPixel)[1] = (byte)green_avg;
            (data_ptr + nChannels * lastXPixel)[2] = (byte)red_avg;

            //Lower left corner
            pos_2 = (data_ptr_clone + (lastYPixel - 1) * widthStep);
            pos_3 = (data_ptr_clone + nChannels + (lastYPixel - 1) * widthStep);
            pos_5 = (data_ptr_clone + lastYPixel * widthStep);
            pos_6 = (data_ptr_clone + nChannels + lastYPixel * widthStep);

            blue_avg = (int)Math.Round((pos_2[0] * 2 + pos_3[0] + pos_5[0] * 4 + pos_6[0] * 2) / 9.0);
            green_avg = (int)Math.Round((pos_2[1] * 2 + pos_3[1] + pos_5[1] * 4 + pos_6[1] * 2) / 9.0);
            red_avg = (int)Math.Round((pos_2[2] * 2 + pos_3[2] + pos_5[2] * 4 + pos_6[2] * 2) / 9.0);

            (data_ptr + lastYPixel * widthStep)[0] = (byte)blue_avg;
            (data_ptr + lastYPixel * widthStep)[1] = (byte)green_avg;
            (data_ptr + lastYPixel * widthStep)[2] = (byte)red_avg;

            //Lower right corner
            pos_1 = (data_ptr_clone + (lastXPixel - 1) * nChannels + (lastYPixel - 1) * widthStep);
            pos_2 = (data_ptr_clone + lastXPixel * nChannels + (lastYPixel - 1) * widthStep);
            pos_4 = (data_ptr_clone + (lastXPixel - 1) * nChannels + lastYPixel * widthStep);
            pos_5 = (data_ptr_clone + lastXPixel * nChannels + lastYPixel * widthStep);

            blue_avg = (int)Math.Round((pos_1[0] + pos_2[0] * 2 + pos_4[0] * 2 + pos_5[0] * 4) / 9.0);
            green_avg = (int)Math.Round((pos_1[1] + pos_2[1] * 2 + pos_4[1] * 2 + pos_5[1] * 4) / 9.0);
            red_avg = (int)Math.Round((pos_1[2] + pos_2[2] * 2 + pos_4[2] * 2 + pos_5[2] * 4) / 9.0);

            (data_ptr + lastXPixel * nChannels + lastYPixel * widthStep)[0] = (byte)blue_avg;
            (data_ptr + lastXPixel * nChannels + lastYPixel * widthStep)[1] = (byte)green_avg;
            (data_ptr + lastXPixel * nChannels + lastYPixel * widthStep)[2] = (byte)red_avg;

            // First line
            for (x = 1; x < width - 1; x++)
            {
                /* |pos_1|pos_2|pos_3|
                 * |pos_4|pos_5|pos_6|
                 * |pos_7|pos_8|pos_9|
                 */
                pos_4 = (data_ptr_clone + (x - 1) * nChannels);
                pos_5 = (data_ptr_clone + x * nChannels);
                pos_6 = (data_ptr_clone + (x + 1) * nChannels);
                pos_7 = (data_ptr_clone + (x - 1) * nChannels + widthStep);
                pos_8 = (data_ptr_clone + x * nChannels + widthStep);
                pos_9 = (data_ptr_clone + (x + 1) * nChannels + widthStep);

                blue_avg = (int)Math.Round(((pos_4[0] + pos_5[0] + pos_6[0]) * 2 + pos_7[0] + pos_8[0] + pos_9[0]) / 9.0);
                green_avg = (int)Math.Round(((pos_4[1] + pos_5[1] + pos_6[1]) * 2 + pos_7[1] + pos_8[1] + pos_9[1]) / 9.0);
                red_avg = (int)Math.Round(((pos_4[2] + pos_5[2] + pos_6[2]) * 2 + pos_7[2] + pos_8[2] + pos_9[2]) / 9.0);

                (data_ptr + (x * nChannels))[0] = (byte)(blue_avg);
                (data_ptr + (x * nChannels))[1] = (byte)(green_avg);
                (data_ptr + (x * nChannels))[2] = (byte)(red_avg);
            }

            // First Column
            for (y = 1; y < height - 1; y++)
            {
                pos_2 = (data_ptr_clone + (y - 1) * widthStep);
                pos_3 = (data_ptr_clone + nChannels + (y - 1) * widthStep);
                pos_5 = (data_ptr_clone + y * widthStep);
                pos_6 = (data_ptr_clone + nChannels + y * widthStep);
                pos_8 = (data_ptr_clone + (y + 1) * widthStep);
                pos_9 = (data_ptr_clone + nChannels + (y + 1) * widthStep);

                blue_avg = (int)Math.Round(((pos_2[0] + pos_5[0] + pos_8[0]) * 2 + pos_3[0] + pos_6[0] + pos_9[0]) / 9.0);
                green_avg = (int)Math.Round(((pos_2[1] + pos_5[1] + pos_8[1]) * 2 + pos_3[1] + pos_6[1] + pos_9[1]) / 9.0);
                red_avg = (int)Math.Round(((pos_2[2] + pos_5[2] + pos_8[2]) * 2 + pos_3[2] + pos_6[2] + pos_9[2]) / 9.0);

                (data_ptr + (y * widthStep))[0] = (byte)(blue_avg);
                (data_ptr + (y * widthStep))[1] = (byte)(green_avg);
                (data_ptr + (y * widthStep))[2] = (byte)(red_avg);
            }

            // Last line
            for (x = 1; x < width - 1; x++)
            {
                /* |pos_1|pos_2|pos_3|
                 * |pos_4|pos_5|pos_6|
                 * |pos_7|pos_8|pos_9|
                 */
                pos_1 = (data_ptr_clone + (x - 1) * nChannels + (lastYPixel - 1) * widthStep);
                pos_2 = (data_ptr_clone + x * nChannels + (lastYPixel - 1) * widthStep);
                pos_3 = (data_ptr_clone + (x + 1) * nChannels + (lastYPixel - 1) * widthStep);
                pos_4 = (data_ptr_clone + (x - 1) * nChannels + lastYPixel * widthStep);
                pos_5 = (data_ptr_clone + x * nChannels + lastYPixel * widthStep);
                pos_6 = (data_ptr_clone + (x + 1) * nChannels + lastYPixel * widthStep);

                blue_avg = (int)Math.Round(((pos_4[0] + pos_5[0] + pos_6[0]) * 2 + pos_1[0] + pos_2[0] + pos_3[0]) / 9.0);
                green_avg = (int)Math.Round(((pos_4[1] + pos_5[1] + pos_6[1]) * 2 + pos_1[1] + pos_2[1] + pos_3[1]) / 9.0);
                red_avg = (int)Math.Round(((pos_4[2] + pos_5[2] + pos_6[2]) * 2 + pos_1[2] + pos_2[2] + pos_3[2]) / 9.0);

                (data_ptr + (x * nChannels) + (lastYPixel * widthStep))[0] = (byte)(blue_avg);
                (data_ptr + (x * nChannels) + (lastYPixel * widthStep))[1] = (byte)(green_avg);
                (data_ptr + (x * nChannels) + (lastYPixel * widthStep))[2] = (byte)(red_avg);
            }

            // Last Collumn
            for (y = 1; y < height - 1; y++)
            {
                pos_1 = (data_ptr_clone + nChannels * (lastXPixel - 1) + (y - 1) * widthStep);
                pos_2 = (data_ptr_clone + nChannels * lastXPixel + (y - 1) * widthStep);
                pos_4 = (data_ptr_clone + nChannels * (lastXPixel - 1) + y * widthStep);
                pos_5 = (data_ptr_clone + nChannels * lastXPixel + y * widthStep);
                pos_7 = (data_ptr_clone + nChannels * (lastXPixel - 1) + (y + 1) * widthStep);
                pos_8 = (data_ptr_clone + nChannels * lastXPixel + (y + 1) * widthStep);

                blue_avg = (int)Math.Round(((pos_2[0] + pos_5[0] + pos_8[0]) * 2 + pos_1[0] + pos_4[0] + pos_7[0]) / 9.0);
                green_avg = (int)Math.Round(((pos_2[1] + pos_5[1] + pos_8[1]) * 2 + pos_1[1] + pos_4[1] + pos_7[1]) / 9.0);
                red_avg = (int)Math.Round(((pos_2[2] + pos_5[2] + pos_8[2]) * 2 + pos_1[2] + pos_4[2] + pos_7[2]) / 9.0);

                (data_ptr + (lastXPixel * nChannels) + (y * widthStep))[0] = (byte)(blue_avg);
                (data_ptr + (lastXPixel * nChannels) + (y * widthStep))[1] = (byte)(green_avg);
                (data_ptr + (lastXPixel * nChannels) + (y * widthStep))[2] = (byte)(red_avg);
            }

            for (y = 1; y < height - 1; y++)
            {
                for (x = 1; x < width - 1; x++)
                {
                    pos_1 = (data_ptr_clone + (x - 1) * nChannels + (y - 1) * widthStep);
                    pos_2 = (data_ptr_clone + x * nChannels + (y - 1) * widthStep);
                    pos_3 = (data_ptr_clone + (x + 1) * nChannels + (y - 1) * widthStep);
                    pos_4 = (data_ptr_clone + (x - 1) * nChannels + y * widthStep);
                    pos_5 = (data_ptr_clone + x * nChannels + y * widthStep);
                    pos_6 = (data_ptr_clone + (x + 1) * nChannels + y * widthStep);
                    pos_7 = (data_ptr_clone + (x - 1) * nChannels + (y + 1) * widthStep);
                    pos_8 = (data_ptr_clone + x * nChannels + (y + 1) * widthStep);
                    pos_9 = (data_ptr_clone + (x + 1) * nChannels + (y + 1) * widthStep);

                    blue_avg = (int)Math.Round((pos_1[0] + pos_2[0] + pos_3[0] + pos_4[0] + pos_5[0] + pos_6[0] + pos_7[0] + pos_8[0] + pos_9[0]) / 9.0);
                    green_avg = (int)Math.Round((pos_1[1] + pos_2[1] + pos_3[1] + pos_4[1] + pos_5[1] + pos_6[1] + pos_7[1] + pos_8[1] + pos_9[1]) / 9.0);
                    red_avg = (int)Math.Round((pos_1[2] + pos_2[2] + pos_3[2] + pos_4[2] + pos_5[2] + pos_6[2] + pos_7[2] + pos_8[2] + pos_9[2]) / 9.0);

                    (data_ptr + x * nChannels + y * widthStep)[0] = (byte)(blue_avg);
                    (data_ptr + x * nChannels + y * widthStep)[1] = (byte)(green_avg);
                    (data_ptr + x * nChannels + y * widthStep)[2] = (byte)(red_avg);
                }
            }
        }

        public unsafe static void NonUniform(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float[,] matrix, float matrixWeight)
        {
            int x, y;
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();

            byte* data_ptr_clone = (byte*)imgCopy.MIplImage.imageData.ToPointer();

            //img.SetZero();

            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int padding = mipl.widthStep - mipl.nChannels * mipl.width;
            int widthStep = mipl.widthStep;
            int lastXPixel = width - 1;
            int lastYPixel = height - 1;

            byte* pos_1, pos_2, pos_3;
            byte* pos_4, pos_5, pos_6;
            byte* pos_7, pos_8, pos_9;

            //Top left corner
            pos_5 = (data_ptr_clone);
            pos_6 = (data_ptr_clone + nChannels);
            pos_8 = (data_ptr_clone + widthStep);
            pos_9 = (data_ptr_clone + nChannels + widthStep);

            int blue_avg  = (int)Math.Round((pos_5[0] * matrix[1,1] + pos_5[0] * matrix[0,0] + pos_5[0] * matrix[0,1] + pos_5[0] * matrix[1,0] + pos_6[0] * matrix[1,2] + pos_6[0] * matrix[0,2] + pos_8[0] * matrix[2,1] + pos_8[0] * matrix[2,0] + pos_9[0] * matrix[2,2]) / matrixWeight);
            int green_avg = (int)Math.Round((pos_5[1] * matrix[1,1] + pos_5[1] * matrix[0,0] + pos_5[1] * matrix[0,1] + pos_5[1] * matrix[1,0] + pos_6[1] * matrix[1,2] + pos_6[1] * matrix[0,2] + pos_8[1] * matrix[2,1] + pos_8[1] * matrix[2,0] + pos_9[1] * matrix[2,2]) / matrixWeight);
            int red_avg   = (int)Math.Round((pos_5[2] * matrix[1,1] + pos_5[2] * matrix[0,0] + pos_5[2] * matrix[0,1] + pos_5[2] * matrix[1,0] + pos_6[2] * matrix[1,2] + pos_6[2] * matrix[0,2] + pos_8[2] * matrix[2,1] + pos_8[2] * matrix[2,0] + pos_9[2] * matrix[2,2]) / matrixWeight);
            if (blue_avg > 255)
                blue_avg = 255;
            if (green_avg > 255)
                green_avg = 255;
            if (red_avg > 255)
                red_avg = 255;

            (data_ptr)[0] = (byte)blue_avg;
            (data_ptr)[1] = (byte)green_avg;
            (data_ptr)[2] = (byte)red_avg;

            //Top right corner
            pos_4 = (data_ptr_clone + nChannels * (lastXPixel - 1));
            pos_5 = (data_ptr_clone + nChannels * lastXPixel);
            pos_7 = (data_ptr_clone + nChannels * (lastXPixel - 1) + widthStep);
            pos_8 = (data_ptr_clone + nChannels * lastXPixel + widthStep);

            blue_avg  = (int)Math.Round((pos_4[0] * matrix[1,0] + pos_4[0] * matrix[0,0] + pos_5[0] * matrix[1,1] + pos_5[0] * matrix[0,1] + pos_5[0] * matrix[0,2] + pos_5[0] * matrix[1,2] + pos_7[0] * matrix[2,0] + pos_8[0] * matrix[2,1] + pos_8[0] * matrix[2,2]) / matrixWeight);
            green_avg = (int)Math.Round((pos_4[1] * matrix[1,0] + pos_4[1] * matrix[0,0] + pos_5[1] * matrix[1,1] + pos_5[1] * matrix[0,1] + pos_5[1] * matrix[0,2] + pos_5[1] * matrix[1,2] + pos_7[1] * matrix[2,0] + pos_8[1] * matrix[2,1] + pos_8[1] * matrix[2,2]) / matrixWeight);
            red_avg   = (int)Math.Round((pos_4[2] * matrix[1,0] + pos_4[2] * matrix[0,0] + pos_5[2] * matrix[1,1] + pos_5[2] * matrix[0,1] + pos_5[2] * matrix[0,2] + pos_5[2] * matrix[1,2] + pos_7[2] * matrix[2,0] + pos_8[2] * matrix[2,1] + pos_8[2] * matrix[2,2]) / matrixWeight);
            if (blue_avg > 255)
                blue_avg = 255;
            if (green_avg > 255)
                green_avg = 255;
            if (red_avg > 255)
                red_avg = 255;

            (data_ptr + nChannels * lastXPixel)[0] = (byte)blue_avg;
            (data_ptr + nChannels * lastXPixel)[1] = (byte)green_avg;
            (data_ptr + nChannels * lastXPixel)[2] = (byte)red_avg;

            //Lower left corner
            pos_2 = (data_ptr_clone + (lastYPixel - 1) * widthStep);
            pos_3 = (data_ptr_clone + nChannels + (lastYPixel - 1) * widthStep);
            pos_5 = (data_ptr_clone + lastYPixel * widthStep);
            pos_6 = (data_ptr_clone + nChannels + lastYPixel * widthStep);

            blue_avg  = (int)Math.Round((pos_2[0] * matrix[0,1] + pos_2[0] * matrix[0,0] + pos_3[0] * matrix[0,2] + pos_5[0] * matrix[1,1] + pos_5[0] * matrix[1,0] + pos_5[0] * matrix[2,0] + pos_5[0] * matrix[2,1] + pos_6[0] * matrix[1,2] + pos_6[0] * matrix[2,2]) / matrixWeight);
            green_avg = (int)Math.Round((pos_2[1] * matrix[0,1] + pos_2[1] * matrix[0,0] + pos_3[1] * matrix[0,2] + pos_5[1] * matrix[1,1] + pos_5[1] * matrix[1,0] + pos_5[1] * matrix[2,0] + pos_5[1] * matrix[2,1] + pos_6[1] * matrix[1,2] + pos_6[1] * matrix[2,2]) / matrixWeight);
            red_avg   = (int)Math.Round((pos_2[2] * matrix[0,1] + pos_2[2] * matrix[0,0] + pos_3[2] * matrix[0,2] + pos_5[2] * matrix[1,1] + pos_5[2] * matrix[1,0] + pos_5[2] * matrix[2,0] + pos_5[2] * matrix[2,1] + pos_6[2] * matrix[1,2] + pos_6[2] * matrix[2,2]) / matrixWeight);

            if (blue_avg > 255)
                blue_avg = 255;
            if (green_avg > 255)
                green_avg = 255;
            if (red_avg > 255)
                red_avg = 255;

            (data_ptr + lastYPixel * widthStep)[0] = (byte)blue_avg;
            (data_ptr + lastYPixel * widthStep)[1] = (byte)green_avg;
            (data_ptr + lastYPixel * widthStep)[2] = (byte)red_avg;

            //Lower right corner
            pos_1 = (data_ptr_clone + (lastXPixel - 1) * nChannels + (lastYPixel - 1) * widthStep);
            pos_2 = (data_ptr_clone + lastXPixel * nChannels + (lastYPixel - 1) * widthStep);
            pos_4 = (data_ptr_clone + (lastXPixel - 1) * nChannels + lastYPixel * widthStep);
            pos_5 = (data_ptr_clone + lastXPixel * nChannels + lastYPixel * widthStep);

            blue_avg  = (int) Math.Round((pos_1[0] * matrix[0,0] + pos_2[0] * matrix[0, 1] + pos_2[0] * matrix[0,2] + pos_4[0] * matrix[1,0] + pos_4[0] * matrix[2,0] + pos_5[0] * matrix[1,1] + pos_5[0] * matrix[1,2] + pos_5[0] * matrix[2,2] + pos_5[0] * matrix[2,1]) / matrixWeight);
            green_avg = (int) Math.Round((pos_1[1] * matrix[0,0] + pos_2[1] * matrix[0, 1] + pos_2[1] * matrix[0,2] + pos_4[1] * matrix[1,0] + pos_4[1] * matrix[2,0] + pos_5[1] * matrix[1,1] + pos_5[1] * matrix[1,2] + pos_5[1] * matrix[2,2] + pos_5[1] * matrix[2,1]) / matrixWeight);
            red_avg   = (int) Math.Round((pos_1[2] * matrix[0,0] + pos_2[2] * matrix[0, 1] + pos_2[2] * matrix[0,2] + pos_4[2] * matrix[1,0] + pos_4[2] * matrix[2,0] + pos_5[2] * matrix[1,1] + pos_5[2] * matrix[1,2] + pos_5[2] * matrix[2,2] + pos_5[2] * matrix[2,1]) / matrixWeight);


            if (blue_avg > 255)
                blue_avg = 255;
            if (green_avg > 255)
                green_avg = 255;
            if (red_avg > 255)
                red_avg = 255;

            (data_ptr + lastXPixel * nChannels + lastYPixel * widthStep)[0] = (byte)blue_avg;
            (data_ptr + lastXPixel * nChannels + lastYPixel * widthStep)[1] = (byte)green_avg;
            (data_ptr + lastXPixel * nChannels + lastYPixel * widthStep)[2] = (byte)red_avg;

            // First line
            for (x = 1; x < width - 1; x++)
            {
                /* |pos_1|pos_2|pos_3|
                 * |pos_4|pos_5|pos_6|
                 * |pos_7|pos_8|pos_9|
                 */
                pos_4 = (data_ptr_clone + (x - 1) * nChannels);
                pos_5 = (data_ptr_clone + x * nChannels);
                pos_6 = (data_ptr_clone + (x + 1) * nChannels);
                pos_7 = (data_ptr_clone + (x - 1) * nChannels + widthStep);
                pos_8 = (data_ptr_clone + x * nChannels + widthStep);
                pos_9 = (data_ptr_clone + (x + 1) * nChannels + widthStep);

                blue_avg  = (int)Math.Round((pos_4[0] * matrix[1,0] + pos_4[0] * matrix[0,0] + pos_5[0] * matrix[1,1] + pos_5[0] * matrix[0,1] + pos_6[0] * matrix[1,2] + pos_6[0] * matrix[0,2] + pos_7[0] * matrix[2,0] + pos_8[0] * matrix[2,1] + pos_9[0] * matrix[2,2]) / matrixWeight);
                green_avg = (int)Math.Round((pos_4[1] * matrix[1,0] + pos_4[1] * matrix[0,0] + pos_5[1] * matrix[1,1] + pos_5[1] * matrix[0,1] + pos_6[1] * matrix[1,2] + pos_6[1] * matrix[0,2] + pos_7[1] * matrix[2,0] + pos_8[1] * matrix[2,1] + pos_9[1] * matrix[2,2]) / matrixWeight);
                red_avg   = (int)Math.Round((pos_4[2] * matrix[1,0] + pos_4[2] * matrix[0,0] + pos_5[2] * matrix[1,1] + pos_5[2] * matrix[0,1] + pos_6[2] * matrix[1,2] + pos_6[2] * matrix[0,2] + pos_7[2] * matrix[2,0] + pos_8[2] * matrix[2,1] + pos_9[2] * matrix[2,2]) / matrixWeight);


                if (blue_avg > 255)
                    blue_avg = 255;
                if (green_avg > 255)
                    green_avg = 255;
                if (red_avg > 255)
                    red_avg = 255;

                (data_ptr + (x * nChannels))[0] = (byte)(blue_avg);
                (data_ptr + (x * nChannels))[1] = (byte)(green_avg);
                (data_ptr + (x * nChannels))[2] = (byte)(red_avg);
            }

            // First Column
            for (y = 1; y < height - 1; y++)
            {
                pos_2 = (data_ptr_clone + (y - 1) * widthStep);
                pos_3 = (data_ptr_clone + nChannels + (y - 1) * widthStep);
                pos_5 = (data_ptr_clone + y * widthStep);
                pos_6 = (data_ptr_clone + nChannels + y * widthStep);
                pos_8 = (data_ptr_clone + (y + 1) * widthStep);
                pos_9 = (data_ptr_clone + nChannels + (y + 1) * widthStep);

                blue_avg  = (int)Math.Round((pos_2[0] * matrix[0,1] + pos_2[0] * matrix[0,0] + pos_5[0] * matrix[1,1] + pos_5[0] * matrix[1,0] + pos_8[0] * matrix[2,1] + pos_8[0] * matrix[2,0] + pos_3[0] * matrix[0,2] + pos_6[0] * matrix[1,2] + pos_9[0] * matrix[2,2]) / matrixWeight);
                green_avg = (int)Math.Round((pos_2[1] * matrix[0,1] + pos_2[1] * matrix[0,0] + pos_5[1] * matrix[1,1] + pos_5[1] * matrix[1,0] + pos_8[1] * matrix[2,1] + pos_8[1] * matrix[2,0] + pos_3[1] * matrix[0,2] + pos_6[1] * matrix[1,2] + pos_9[1] * matrix[2,2]) / matrixWeight);
                red_avg   = (int)Math.Round((pos_2[2] * matrix[0,1] + pos_2[2] * matrix[0,0] + pos_5[2] * matrix[1,1] + pos_5[2] * matrix[1,0] + pos_8[2] * matrix[2,1] + pos_8[2] * matrix[2,0] + pos_3[2] * matrix[0,2] + pos_6[2] * matrix[1,2] + pos_9[2] * matrix[2,2]) / matrixWeight);

                if (blue_avg > 255)
                    blue_avg = 255;
                if (green_avg > 255)
                    green_avg = 255;
                if (red_avg > 255)
                    red_avg = 255;

                (data_ptr + (y * widthStep))[0] = (byte)(blue_avg);
                (data_ptr + (y * widthStep))[1] = (byte)(green_avg);
                (data_ptr + (y * widthStep))[2] = (byte)(red_avg);
            }

            // Last line
            for (x = 1; x < width - 1; x++)
            {
                /* |pos_1|pos_2|pos_3|
                 * |pos_4|pos_5|pos_6|
                 * |pos_7|pos_8|pos_9|
                 */
                pos_1 = (data_ptr_clone + (x - 1) * nChannels + (lastYPixel - 1) * widthStep);
                pos_2 = (data_ptr_clone + x * nChannels + (lastYPixel - 1) * widthStep);
                pos_3 = (data_ptr_clone + (x + 1) * nChannels + (lastYPixel - 1) * widthStep);
                pos_4 = (data_ptr_clone + (x - 1) * nChannels + lastYPixel * widthStep);
                pos_5 = (data_ptr_clone + x * nChannels + lastYPixel * widthStep);
                pos_6 = (data_ptr_clone + (x + 1) * nChannels + lastYPixel * widthStep);

                blue_avg  = (int)Math.Round((pos_4[0] * matrix[1,0] + pos_4[0] * matrix[2,0] + pos_5[0] * matrix[1,1] + pos_5[0] * matrix[2,1] + pos_6[0] * matrix[1,2] + pos_6[0] * matrix[2,2] + pos_1[0] * matrix[0,0] + pos_2[0] * matrix[0,1] + pos_3[0] * matrix[0,2]) / matrixWeight);
                green_avg = (int)Math.Round((pos_4[1] * matrix[1,0] + pos_4[1] * matrix[2,0] + pos_5[1] * matrix[1,1] + pos_5[1] * matrix[2,1] + pos_6[1] * matrix[1,2] + pos_6[1] * matrix[2,2] + pos_1[1] * matrix[0,0] + pos_2[1] * matrix[0,1] + pos_3[1] * matrix[0,2]) / matrixWeight);
                red_avg   = (int)Math.Round((pos_4[2] * matrix[1,0] + pos_4[2] * matrix[2,0] + pos_5[2] * matrix[1,1] + pos_5[2] * matrix[2,1] + pos_6[2] * matrix[1,2] + pos_6[2] * matrix[2,2] + pos_1[2] * matrix[0,0] + pos_2[2] * matrix[0,1] + pos_3[2] * matrix[0,2]) / matrixWeight);

                if (blue_avg > 255)
                    blue_avg = 255;
                if (green_avg > 255)
                    green_avg = 255;
                if (red_avg > 255)
                    red_avg = 255;

                (data_ptr + (x * nChannels) + (lastYPixel * widthStep))[0] = (byte)(blue_avg);
                (data_ptr + (x * nChannels) + (lastYPixel * widthStep))[1] = (byte)(green_avg);
                (data_ptr + (x * nChannels) + (lastYPixel * widthStep))[2] = (byte)(red_avg);
            }

            // Last Collumn
            for (y = 1; y < height - 1; y++)
            {
                pos_1 = (data_ptr_clone + nChannels * (lastXPixel - 1) + (y - 1) * widthStep);
                pos_2 = (data_ptr_clone + nChannels * lastXPixel + (y - 1) * widthStep);
                pos_4 = (data_ptr_clone + nChannels * (lastXPixel - 1) + y * widthStep);
                pos_5 = (data_ptr_clone + nChannels * lastXPixel + y * widthStep);
                pos_7 = (data_ptr_clone + nChannels * (lastXPixel - 1) + (y + 1) * widthStep);
                pos_8 = (data_ptr_clone + nChannels * lastXPixel + (y + 1) * widthStep);

                blue_avg  = (int)Math.Round((pos_2[0] * matrix[0,1] + pos_2[0] * matrix[0,2] + pos_5[0] * matrix[1,1] + pos_5[0] * matrix[1,2] + pos_8[0] * matrix[2,1] + pos_8[0] * matrix[2,2] + pos_1[0] * matrix[0,0] + pos_4[0] * matrix[1,0] + pos_7[0] * matrix[2,0]) / matrixWeight);
                green_avg = (int)Math.Round((pos_2[1] * matrix[0,1] + pos_2[1] * matrix[0,2] + pos_5[1] * matrix[1,1] + pos_5[1] * matrix[1,2] + pos_8[1] * matrix[2,1] + pos_8[1] * matrix[2,2] + pos_1[1] * matrix[0,0] + pos_4[1] * matrix[1,0] + pos_7[1] * matrix[2,0]) / matrixWeight);
                red_avg   = (int)Math.Round((pos_2[2] * matrix[0,1] + pos_2[2] * matrix[0,2] + pos_5[2] * matrix[1,1] + pos_5[2] * matrix[1,2] + pos_8[2] * matrix[2,1] + pos_8[2] * matrix[2,2] + pos_1[2] * matrix[0,0] + pos_4[2] * matrix[1,0] + pos_7[2] * matrix[2,0]) / matrixWeight);

                if (blue_avg > 255)
                    blue_avg = 255;
                if (green_avg > 255)
                    green_avg = 255;
                if (red_avg > 255)
                    red_avg = 255;

                (data_ptr + (lastXPixel * nChannels) + (y * widthStep))[0] = (byte)(blue_avg);
                (data_ptr + (lastXPixel * nChannels) + (y * widthStep))[1] = (byte)(green_avg);
                (data_ptr + (lastXPixel * nChannels) + (y * widthStep))[2] = (byte)(red_avg);
            }

            for (y = 1; y < height - 1; y++)
            {
                for (x = 1; x < width - 1; x++)
                {
                    pos_1 = (data_ptr_clone + (x - 1) * nChannels + (y - 1) * widthStep);
                    pos_2 = (data_ptr_clone + x * nChannels + (y - 1) * widthStep);
                    pos_3 = (data_ptr_clone + (x + 1) * nChannels + (y - 1) * widthStep);
                    pos_4 = (data_ptr_clone + (x - 1) * nChannels + y * widthStep);
                    pos_5 = (data_ptr_clone + x * nChannels + y * widthStep);
                    pos_6 = (data_ptr_clone + (x + 1) * nChannels + y * widthStep);
                    pos_7 = (data_ptr_clone + (x - 1) * nChannels + (y + 1) * widthStep);
                    pos_8 = (data_ptr_clone + x * nChannels + (y + 1) * widthStep);
                    pos_9 = (data_ptr_clone + (x + 1) * nChannels + (y + 1) * widthStep);

                    blue_avg  = (int)Math.Round((pos_1[0] * matrix[0,0] + pos_2[0] * matrix[0,1] + pos_3[0] * matrix[0,2] + pos_4[0] * matrix[1, 0] + pos_5[0] * matrix[1,1] + pos_6[0] * matrix[1,2] + pos_7[0] * matrix[2,0] + pos_8[0] * matrix[2,1] + pos_9[0] * matrix[2,2]) / matrixWeight);
                    green_avg = (int)Math.Round((pos_1[1] * matrix[0,0] + pos_2[1] * matrix[0,1] + pos_3[1] * matrix[0,2] + pos_4[1] * matrix[1, 0] + pos_5[1] * matrix[1,1] + pos_6[1] * matrix[1,2] + pos_7[1] * matrix[2,0] + pos_8[1] * matrix[2,1] + pos_9[1] * matrix[2,2]) / matrixWeight);
                    red_avg   = (int)Math.Round((pos_1[2] * matrix[0,0] + pos_2[2] * matrix[0,1] + pos_3[2] * matrix[0,2] + pos_4[2] * matrix[1,0] + pos_5[2] * matrix[1,1] + pos_6[2] * matrix[1,2] + pos_7[2] * matrix[2,0] + pos_8[2] * matrix[2,1] + pos_9[2] * matrix[2,2]) / matrixWeight);

                    if (blue_avg > 255)
                        blue_avg = 255;
                    if (green_avg > 255)
                        green_avg = 255;
                    if (red_avg > 255)
                        red_avg = 255;

                    (data_ptr + x * nChannels + y * widthStep)[0] = (byte)(blue_avg);
                    (data_ptr + x * nChannels + y * widthStep)[1] = (byte)(green_avg);
                    (data_ptr + x * nChannels + y * widthStep)[2] = (byte)(red_avg);
                }
            }
        }

        public unsafe static void Sobel(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            int x, y;
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();

            byte* data_ptr_clone = (byte*)imgCopy.MIplImage.imageData.ToPointer();

            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int padding = mipl.widthStep - mipl.nChannels * mipl.width;
            int widthStep = mipl.widthStep;
            int lastXPixel = width - 1;
            int lastYPixel = height - 1;

            byte* pos_a, pos_b, pos_c;
            byte* pos_d, pos_e, pos_f;
            byte* pos_g, pos_h, pos_i;

            int S_blue , Sx_blue , Sy_blue;
            int S_green, Sx_green, Sy_green;
            int S_red  , Sx_red  , Sy_red;

            //Top left corner
            pos_e = (data_ptr_clone);
            pos_f = (data_ptr_clone + nChannels);
            pos_h = (data_ptr_clone + widthStep);
            pos_i = (data_ptr_clone + nChannels + widthStep);

            pos_a = pos_b = pos_d = pos_e;
            pos_c = pos_f;
            pos_g = pos_h;

            Sx_blue = (pos_a[0] + 2 * pos_d[0] + pos_g[0]) - (pos_c[0] + 2 * pos_f[0] + pos_i[0]);
            Sy_blue = (pos_g[0] + 2 * pos_h[0] + pos_i[0]) - (pos_a[0] + 2 * pos_b[0] + pos_c[0]);
            S_blue = Math.Abs(Sx_blue) + Math.Abs(Sy_blue);
            Sx_green = (pos_a[1] + 2 * pos_d[1] + pos_g[1]) - (pos_c[1] + 2 * pos_f[1] + pos_i[1]);
            Sy_green = (pos_g[1] + 2 * pos_h[1] + pos_i[1]) - (pos_a[1] + 2 * pos_b[1] + pos_c[1]);
            S_green = Math.Abs(Sx_green) + Math.Abs(Sy_green);
            Sx_red = (pos_a[2] + 2 * pos_d[2] + pos_g[2]) - (pos_c[2] + 2 * pos_f[2] + pos_i[2]);
            Sy_red = (pos_g[2] + 2 * pos_h[2] + pos_i[2]) - (pos_a[2] + 2 * pos_b[2] + pos_c[2]);
            S_red = Math.Abs(Sx_red) + Math.Abs(Sy_red);
            if (S_blue > 255)
                S_blue = 255;
            if (S_green > 255)
                S_green = 255;
            if (S_red > 255)
                S_red = 255;

            (data_ptr)[0]  = (byte)(S_blue);
            (data_ptr)[1]  = (byte)(S_green);
            (data_ptr)[2]  = (byte)(S_red);

            //Top right corner
            pos_d = (data_ptr_clone + nChannels * (lastXPixel - 1));
            pos_e = (data_ptr_clone + nChannels * lastXPixel);
            pos_g = (data_ptr_clone + nChannels * (lastXPixel - 1) + widthStep);
            pos_h = (data_ptr_clone + nChannels * lastXPixel + widthStep);

            pos_a = pos_d;
            pos_b = pos_c = pos_f = pos_e;
            pos_i = pos_h;

            Sx_blue = (pos_a[0] + 2 * pos_d[0] + pos_g[0]) - (pos_c[0] + 2 * pos_f[0] + pos_i[0]);
            Sy_blue = (pos_g[0] + 2 * pos_h[0] + pos_i[0]) - (pos_a[0] + 2 * pos_b[0] + pos_c[0]);
            S_blue = Math.Abs(Sx_blue) + Math.Abs(Sy_blue);
            Sx_green = (pos_a[1] + 2 * pos_d[1] + pos_g[1]) - (pos_c[1] + 2 * pos_f[1] + pos_i[1]);
            Sy_green = (pos_g[1] + 2 * pos_h[1] + pos_i[1]) - (pos_a[1] + 2 * pos_b[1] + pos_c[1]);
            S_green = Math.Abs(Sx_green) + Math.Abs(Sy_green);
            Sx_red = (pos_a[2] + 2 * pos_d[2] + pos_g[2]) - (pos_c[2] + 2 * pos_f[2] + pos_i[2]);
            Sy_red = (pos_g[2] + 2 * pos_h[2] + pos_i[2]) - (pos_a[2] + 2 * pos_b[2] + pos_c[2]);
            S_red = Math.Abs(Sx_red) + Math.Abs(Sy_red);
            if (S_blue > 255)
                S_blue = 255;
            if (S_green > 255)
                S_green = 255;
            if (S_red > 255)
                S_red = 255;

            (data_ptr + nChannels * lastXPixel)[0] = (byte)(S_blue);
            (data_ptr + nChannels * lastXPixel)[1] = (byte)(S_green);
            (data_ptr + nChannels * lastXPixel)[2] = (byte)(S_red);

            //Lower left corner
            pos_b = (data_ptr_clone + (lastYPixel - 1) * widthStep);
            pos_c = (data_ptr_clone + nChannels + (lastYPixel - 1) * widthStep);
            pos_e = (data_ptr_clone + lastYPixel * widthStep);
            pos_f = (data_ptr_clone + nChannels + lastYPixel * widthStep);

            pos_a = pos_b;
            pos_d = pos_g = pos_h = pos_e;
            pos_i = pos_f;

            Sx_blue = (pos_a[0] + 2 * pos_d[0] + pos_g[0]) - (pos_c[0] + 2 * pos_f[0] + pos_i[0]);
            Sy_blue = (pos_g[0] + 2 * pos_h[0] + pos_i[0]) - (pos_a[0] + 2 * pos_b[0] + pos_c[0]);
            S_blue = Math.Abs(Sx_blue) + Math.Abs(Sy_blue);
            Sx_green = (pos_a[1] + 2 * pos_d[1] + pos_g[1]) - (pos_c[1] + 2 * pos_f[1] + pos_i[1]);
            Sy_green = (pos_g[1] + 2 * pos_h[1] + pos_i[1]) - (pos_a[1] + 2 * pos_b[1] + pos_c[1]);
            S_green = Math.Abs(Sx_green) + Math.Abs(Sy_green);
            Sx_red = (pos_a[2] + 2 * pos_d[2] + pos_g[2]) - (pos_c[2] + 2 * pos_f[2] + pos_i[2]);
            Sy_red = (pos_g[2] + 2 * pos_h[2] + pos_i[2]) - (pos_a[2] + 2 * pos_b[2] + pos_c[2]);
            S_red = Math.Abs(Sx_red) + Math.Abs(Sy_red);
            if (S_blue > 255)
                S_blue = 255;
            if (S_green > 255)
                S_green = 255;
            if (S_red > 255)
                S_red = 255;

            (data_ptr + lastYPixel * widthStep)[0] = (byte)(S_blue);
            (data_ptr + lastYPixel * widthStep)[1] = (byte)(S_green);
            (data_ptr + lastYPixel * widthStep)[2] = (byte)(S_red);

            //Lower right corner
            pos_a = (data_ptr_clone + (lastXPixel - 1) * nChannels + (lastYPixel - 1) * widthStep);
            pos_b = (data_ptr_clone + lastXPixel * nChannels + (lastYPixel - 1) * widthStep);
            pos_d = (data_ptr_clone + (lastXPixel - 1) * nChannels + lastYPixel * widthStep);
            pos_e = (data_ptr_clone + lastXPixel * nChannels + lastYPixel * widthStep);

            pos_c = pos_b;
            pos_f = pos_h = pos_i = pos_e;
            pos_g = pos_d;

            Sx_blue = (pos_a[0] + 2 * pos_d[0] + pos_g[0]) - (pos_c[0] + 2 * pos_f[0] + pos_i[0]);
            Sy_blue = (pos_g[0] + 2 * pos_h[0] + pos_i[0]) - (pos_a[0] + 2 * pos_b[0] + pos_c[0]);
            S_blue = Math.Abs(Sx_blue) + Math.Abs(Sy_blue);
            Sx_green = (pos_a[1] + 2 * pos_d[1] + pos_g[1]) - (pos_c[1] + 2 * pos_f[1] + pos_i[1]);
            Sy_green = (pos_g[1] + 2 * pos_h[1] + pos_i[1]) - (pos_a[1] + 2 * pos_b[1] + pos_c[1]);
            S_green = Math.Abs(Sx_green) + Math.Abs(Sy_green);
            Sx_red = (pos_a[2] + 2 * pos_d[2] + pos_g[2]) - (pos_c[2] + 2 * pos_f[2] + pos_i[2]);
            Sy_red = (pos_g[2] + 2 * pos_h[2] + pos_i[2]) - (pos_a[2] + 2 * pos_b[2] + pos_c[2]);
            S_red = Math.Abs(Sx_red) + Math.Abs(Sy_red);
            if (S_blue > 255)
                S_blue = 255;
            if (S_green > 255)
                S_green = 255;
            if (S_red > 255)
                S_red = 255;

            (data_ptr + lastXPixel * nChannels + lastYPixel * widthStep)[0] = (byte)(S_blue);
            (data_ptr + lastXPixel * nChannels + lastYPixel * widthStep)[1] = (byte)(S_green);
            (data_ptr + lastXPixel * nChannels + lastYPixel * widthStep)[2] = (byte)(S_red);

            // First line
            for (x = 1; x < width - 1; x++)
            {
                pos_d = (data_ptr_clone + (x - 1) * nChannels);
                pos_e = (data_ptr_clone + x * nChannels);
                pos_f = (data_ptr_clone + (x + 1) * nChannels);
                pos_g = (data_ptr_clone + (x - 1) * nChannels + widthStep);
                pos_h = (data_ptr_clone + x * nChannels + widthStep);
                pos_i = (data_ptr_clone + (x + 1) * nChannels + widthStep);

                pos_a = pos_d;
                pos_b = pos_e;
                pos_c = pos_f;

                Sx_blue = (pos_a[0] + 2 * pos_d[0] + pos_g[0]) - (pos_c[0] + 2 * pos_f[0] + pos_i[0]);
                Sy_blue = (pos_g[0] + 2 * pos_h[0] + pos_i[0]) - (pos_a[0] + 2 * pos_b[0] + pos_c[0]);
                S_blue = Math.Abs(Sx_blue) + Math.Abs(Sy_blue);
                Sx_green = (pos_a[1] + 2 * pos_d[1] + pos_g[1]) - (pos_c[1] + 2 * pos_f[1] + pos_i[1]);
                Sy_green = (pos_g[1] + 2 * pos_h[1] + pos_i[1]) - (pos_a[1] + 2 * pos_b[1] + pos_c[1]);
                S_green = Math.Abs(Sx_green) + Math.Abs(Sy_green);
                Sx_red = (pos_a[2] + 2 * pos_d[2] + pos_g[2]) - (pos_c[2] + 2 * pos_f[2] + pos_i[2]);
                Sy_red = (pos_g[2] + 2 * pos_h[2] + pos_i[2]) - (pos_a[2] + 2 * pos_b[2] + pos_c[2]);
                S_red = Math.Abs(Sx_red) + Math.Abs(Sy_red);
                if (S_blue > 255)
                    S_blue = 255;
                if (S_green > 255)
                    S_green = 255;
                if (S_red > 255)
                    S_red = 255;

                (data_ptr + (x * nChannels))[0] = (byte)(S_blue);
                (data_ptr + (x * nChannels))[1] = (byte)(S_green);
                (data_ptr + (x * nChannels))[2] = (byte)(S_red);
            }

            // First Column
            for (y = 1; y < height - 1; y++)
            {
                pos_b = (data_ptr_clone + (y - 1) * widthStep);
                pos_c = (data_ptr_clone + nChannels + (y - 1) * widthStep);
                pos_e = (data_ptr_clone + y * widthStep);
                pos_f = (data_ptr_clone + nChannels + y * widthStep);
                pos_h = (data_ptr_clone + (y + 1) * widthStep);
                pos_i = (data_ptr_clone + nChannels + (y + 1) * widthStep);

                pos_a = pos_b;
                pos_d = pos_e;
                pos_g = pos_h;

                Sx_blue = (pos_a[0] + 2 * pos_d[0] + pos_g[0]) - (pos_c[0] + 2 * pos_f[0] + pos_i[0]);
                Sy_blue = (pos_g[0] + 2 * pos_h[0] + pos_i[0]) - (pos_a[0] + 2 * pos_b[0] + pos_c[0]);
                S_blue = Math.Abs(Sx_blue) + Math.Abs(Sy_blue);
                Sx_green = (pos_a[1] + 2 * pos_d[1] + pos_g[1]) - (pos_c[1] + 2 * pos_f[1] + pos_i[1]);
                Sy_green = (pos_g[1] + 2 * pos_h[1] + pos_i[1]) - (pos_a[1] + 2 * pos_b[1] + pos_c[1]);
                S_green = Math.Abs(Sx_green) + Math.Abs(Sy_green);
                Sx_red = (pos_a[2] + 2 * pos_d[2] + pos_g[2]) - (pos_c[2] + 2 * pos_f[2] + pos_i[2]);
                Sy_red = (pos_g[2] + 2 * pos_h[2] + pos_i[2]) - (pos_a[2] + 2 * pos_b[2] + pos_c[2]);
                S_red = Math.Abs(Sx_red) + Math.Abs(Sy_red);
                if (S_blue > 255)
                    S_blue = 255;
                if (S_green > 255)
                    S_green = 255;
                if (S_red > 255)
                    S_red = 255;

                (data_ptr + (y * widthStep))[0] = (byte)(S_blue);
                (data_ptr + (y * widthStep))[1] = (byte)(S_green);
                (data_ptr + (y * widthStep))[2] = (byte)(S_red);
            }

            // Last line
            for (x = 1; x < width - 1; x++)
            {
                pos_a = (data_ptr_clone + (x - 1) * nChannels + (lastYPixel - 1) * widthStep);
                pos_b = (data_ptr_clone + x * nChannels + (lastYPixel - 1) * widthStep);
                pos_c = (data_ptr_clone + (x + 1) * nChannels + (lastYPixel - 1) * widthStep);
                pos_d = (data_ptr_clone + (x - 1) * nChannels + lastYPixel * widthStep);
                pos_e = (data_ptr_clone + x * nChannels + lastYPixel * widthStep);
                pos_f = (data_ptr_clone + (x + 1) * nChannels + lastYPixel * widthStep);

                pos_g = pos_d;
                pos_h = pos_e;
                pos_i = pos_f;

                Sx_blue = (pos_a[0] + 2 * pos_d[0] + pos_g[0]) - (pos_c[0] + 2 * pos_f[0] + pos_i[0]);
                Sy_blue = (pos_g[0] + 2 * pos_h[0] + pos_i[0]) - (pos_a[0] + 2 * pos_b[0] + pos_c[0]);
                S_blue = Math.Abs(Sx_blue) + Math.Abs(Sy_blue);
                Sx_green = (pos_a[1] + 2 * pos_d[1] + pos_g[1]) - (pos_c[1] + 2 * pos_f[1] + pos_i[1]);
                Sy_green = (pos_g[1] + 2 * pos_h[1] + pos_i[1]) - (pos_a[1] + 2 * pos_b[1] + pos_c[1]);
                S_green = Math.Abs(Sx_green) + Math.Abs(Sy_green);
                Sx_red = (pos_a[2] + 2 * pos_d[2] + pos_g[2]) - (pos_c[2] + 2 * pos_f[2] + pos_i[2]);
                Sy_red = (pos_g[2] + 2 * pos_h[2] + pos_i[2]) - (pos_a[2] + 2 * pos_b[2] + pos_c[2]);
                S_red = Math.Abs(Sx_red) + Math.Abs(Sy_red);
                if (S_blue > 255)
                    S_blue = 255;
                if (S_green > 255)
                    S_green = 255;
                if (S_red > 255)
                    S_red = 255;

                (data_ptr + (x * nChannels) + (lastYPixel * widthStep))[0] = (byte)(S_blue);
                (data_ptr + (x * nChannels) + (lastYPixel * widthStep))[1] = (byte)(S_green);
                (data_ptr + (x * nChannels) + (lastYPixel * widthStep))[2] = (byte)(S_red);
            }

            // Last Collumn
            for (y = 1; y < height - 1; y++)
            {
                pos_a = (data_ptr_clone + nChannels * (lastXPixel - 1) + (y - 1) * widthStep);
                pos_b = (data_ptr_clone + nChannels * lastXPixel + (y - 1) * widthStep);
                pos_d = (data_ptr_clone + nChannels * (lastXPixel - 1) + y * widthStep);
                pos_e = (data_ptr_clone + nChannels * lastXPixel + y * widthStep);
                pos_g = (data_ptr_clone + nChannels * (lastXPixel - 1) + (y + 1) * widthStep);
                pos_h = (data_ptr_clone + nChannels * lastXPixel + (y + 1) * widthStep);

                pos_c = pos_b;
                pos_f = pos_e;
                pos_i = pos_h;

                Sx_blue = (pos_a[0] + 2 * pos_d[0] + pos_g[0]) - (pos_c[0] + 2 * pos_f[0] + pos_i[0]);
                Sy_blue = (pos_g[0] + 2 * pos_h[0] + pos_i[0]) - (pos_a[0] + 2 * pos_b[0] + pos_c[0]);
                S_blue = Math.Abs(Sx_blue) + Math.Abs(Sy_blue);
                Sx_green = (pos_a[1] + 2 * pos_d[1] + pos_g[1]) - (pos_c[1] + 2 * pos_f[1] + pos_i[1]);
                Sy_green = (pos_g[1] + 2 * pos_h[1] + pos_i[1]) - (pos_a[1] + 2 * pos_b[1] + pos_c[1]);
                S_green = Math.Abs(Sx_green) + Math.Abs(Sy_green);
                Sx_red = (pos_a[2] + 2 * pos_d[2] + pos_g[2]) - (pos_c[2] + 2 * pos_f[2] + pos_i[2]);
                Sy_red = (pos_g[2] + 2 * pos_h[2] + pos_i[2]) - (pos_a[2] + 2 * pos_b[2] + pos_c[2]);
                S_red = Math.Abs(Sx_red) + Math.Abs(Sy_red);
                if (S_blue > 255)
                    S_blue = 255;
                if (S_green > 255)
                    S_green = 255;
                if (S_red > 255)
                    S_red = 255;

                (data_ptr + (lastXPixel * nChannels) + (y * widthStep))[0] = (byte)(S_blue);
                (data_ptr + (lastXPixel * nChannels) + (y * widthStep))[1] = (byte)(S_green);
                (data_ptr + (lastXPixel * nChannels) + (y * widthStep))[2] = (byte)(S_red);
            }

            for(y = 1 ; y < height - 1 ; y++)
                for (x = 1; x < width - 1; x++)
                {
                    pos_a = (data_ptr_clone + (x - 1) * nChannels + (y - 1) * widthStep);
                    pos_b = (data_ptr_clone + x * nChannels + (y - 1) * widthStep);
                    pos_c = (data_ptr_clone + (x + 1) * nChannels + (y - 1) * widthStep);
                    pos_d = (data_ptr_clone + (x - 1) * nChannels + y * widthStep);
                    pos_e = (data_ptr_clone + x * nChannels + y * widthStep);
                    pos_f = (data_ptr_clone + (x + 1) * nChannels + y * widthStep);
                    pos_g = (data_ptr_clone + (x - 1) * nChannels + (y + 1) * widthStep);
                    pos_h = (data_ptr_clone + x * nChannels + (y + 1) * widthStep);
                    pos_i = (data_ptr_clone + (x + 1) * nChannels + (y + 1) * widthStep);
                    
                    Sx_blue = (pos_a[0] + 2 * pos_d[0] + pos_g[0]) - (pos_c[0] + 2 * pos_f[0] + pos_i[0]);
                    Sy_blue = (pos_g[0] + 2 * pos_h[0] + pos_i[0]) - (pos_a[0] + 2 * pos_b[0] + pos_c[0]);
                    S_blue   = Math.Abs(Sx_blue) + Math.Abs(Sy_blue);
                    Sx_green = (pos_a[1] + 2 * pos_d[1] + pos_g[1]) - (pos_c[1] + 2 * pos_f[1] + pos_i[1]);
                    Sy_green = (pos_g[1] + 2 * pos_h[1] + pos_i[1]) - (pos_a[1] + 2 * pos_b[1] + pos_c[1]);
                    S_green  = Math.Abs(Sx_green) + Math.Abs(Sy_green);
                    Sx_red = (pos_a[2] + 2 * pos_d[2] + pos_g[2]) - (pos_c[2] + 2 * pos_f[2] + pos_i[2]);
                    Sy_red = (pos_g[2] + 2 * pos_h[2] + pos_i[2]) - (pos_a[2] + 2 * pos_b[2] + pos_c[2]);
                    S_red    = Math.Abs(Sx_red) + Math.Abs(Sy_red);
                    if (S_blue > 255)
                        S_blue = 255;
                    if (S_green > 255)
                        S_green = 255;
                    if (S_red > 255)
                        S_red = 255;

                    (data_ptr + x * nChannels + y * widthStep)[0] = (byte)(S_blue);
                    (data_ptr + x * nChannels + y * widthStep)[1] = (byte)(S_green);
                    (data_ptr + x * nChannels + y * widthStep)[2] = (byte)(S_red);
                }
        }

        public unsafe static void Diferentiation(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            int x, y;
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();

            byte* data_ptr_clone = (byte*)imgCopy.MIplImage.imageData.ToPointer();

            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int padding = mipl.widthStep - mipl.nChannels * mipl.width;
            int widthStep = mipl.widthStep;
            int lastXPixel = width - 1;
            int lastYPixel = height - 1;

            byte* pos_a, pos_b, pos_c;

            int S_blue, S_green, S_red;

            //Top right corner
            pos_a = (data_ptr_clone + nChannels * lastXPixel);
            pos_c = (data_ptr_clone + nChannels * lastXPixel + widthStep);

            pos_b = pos_a;

            S_blue  = Math.Abs(pos_a[0] - pos_b[0]) + Math.Abs(pos_a[0] - pos_c[0]);
            S_green = Math.Abs(pos_a[1] - pos_b[1]) + Math.Abs(pos_a[1] - pos_c[1]);
            S_red   = Math.Abs(pos_a[2] - pos_b[2]) + Math.Abs(pos_a[2] - pos_c[2]);
            if (S_blue > 255)
                S_blue = 255;
            if (S_green > 255)
                S_green = 255;
            if (S_red > 255)
                S_red = 255;

            (data_ptr + nChannels * lastXPixel)[0] = (byte)(S_blue);
            (data_ptr + nChannels * lastXPixel)[1] = (byte)(S_green);
            (data_ptr + nChannels * lastXPixel)[2] = (byte)(S_red);

            //Lower left corner
            pos_a = (data_ptr_clone + lastYPixel * widthStep);
            pos_b = (data_ptr_clone + nChannels + lastYPixel * widthStep);

            pos_c = pos_a;

            S_blue  = Math.Abs(pos_a[0] - pos_b[0]) + Math.Abs(pos_a[0] - pos_c[0]);
            S_green = Math.Abs(pos_a[1] - pos_b[1]) + Math.Abs(pos_a[1] - pos_c[1]);
            S_red   = Math.Abs(pos_a[2] - pos_b[2]) + Math.Abs(pos_a[2] - pos_c[2]);
            if (S_blue > 255)
                S_blue = 255;
            if (S_green > 255)
                S_green = 255;
            if (S_red > 255)
                S_red = 255;

            (data_ptr + lastYPixel * widthStep)[0] = (byte)(S_blue);
            (data_ptr + lastYPixel * widthStep)[1] = (byte)(S_green);
            (data_ptr + lastYPixel * widthStep)[2] = (byte)(S_red);

            //Lower right corner
            pos_a = (data_ptr_clone + lastXPixel * nChannels + lastYPixel * widthStep);

            pos_c = pos_b = pos_a;
            
            S_blue  = Math.Abs(pos_a[0] - pos_b[0]) + Math.Abs(pos_a[0] - pos_c[0]);
            S_green = Math.Abs(pos_a[1] - pos_b[1]) + Math.Abs(pos_a[1] - pos_c[1]);
            S_red   = Math.Abs(pos_a[2] - pos_b[2]) + Math.Abs(pos_a[2] - pos_c[2]);
            if (S_blue > 255)
                S_blue = 255;
            if (S_green > 255)
                S_green = 255;
            if (S_red > 255)
                S_red = 255;

            (data_ptr + lastXPixel * nChannels + lastYPixel * widthStep)[0] = (byte)(S_blue);
            (data_ptr + lastXPixel * nChannels + lastYPixel * widthStep)[1] = (byte)(S_green);
            (data_ptr + lastXPixel * nChannels + lastYPixel * widthStep)[2] = (byte)(S_red);

            // Last line
            for (x = 1; x < width - 1; x++)
            {
                pos_a = (data_ptr_clone + x * nChannels + lastYPixel * widthStep);
                pos_b = (data_ptr_clone + (x + 1) * nChannels + lastYPixel * widthStep);


                pos_c = pos_a;

                S_blue  = Math.Abs(pos_a[0] - pos_b[0]) + Math.Abs(pos_a[0] - pos_c[0]);
                S_green = Math.Abs(pos_a[1] - pos_b[1]) + Math.Abs(pos_a[1] - pos_c[1]);
                S_red   = Math.Abs(pos_a[2] - pos_b[2]) + Math.Abs(pos_a[2] - pos_c[2]);
                if (S_blue > 255)
                    S_blue = 255;
                if (S_green > 255)
                    S_green = 255;
                if (S_red > 255)
                    S_red = 255;

                (data_ptr + (x * nChannels) + (lastYPixel * widthStep))[0] = (byte)(S_blue);
                (data_ptr + (x * nChannels) + (lastYPixel * widthStep))[1] = (byte)(S_green);
                (data_ptr + (x * nChannels) + (lastYPixel * widthStep))[2] = (byte)(S_red);
            }

            // Last Collumn
            for (y = 1; y < height - 1; y++)
            {
                pos_a = (data_ptr_clone + nChannels * lastXPixel + y * widthStep);
                pos_c = (data_ptr_clone + nChannels * lastXPixel + (y + 1) * widthStep);

                pos_b = pos_a;
                
                S_blue  = Math.Abs(pos_a[0] - pos_b[0]) + Math.Abs(pos_a[0] - pos_c[0]);
                S_green = Math.Abs(pos_a[1] - pos_b[1]) + Math.Abs(pos_a[1] - pos_c[1]);
                S_red   = Math.Abs(pos_a[2] - pos_b[2]) + Math.Abs(pos_a[2] - pos_c[2]);
                if (S_blue > 255)
                    S_blue = 255;
                if (S_green > 255)
                    S_green = 255;
                if (S_red > 255)
                    S_red = 255;

                (data_ptr + (lastXPixel * nChannels) + (y * widthStep))[0] = (byte)(S_blue);
                (data_ptr + (lastXPixel * nChannels) + (y * widthStep))[1] = (byte)(S_green);
                (data_ptr + (lastXPixel * nChannels) + (y * widthStep))[2] = (byte)(S_red);
            }

            for(y = 0 ; y < height - 1 ; y++)
                for (x = 0; x < width - 1; x++)
                {
                    pos_a = (data_ptr_clone + x * nChannels + y * widthStep);
                    pos_b = (data_ptr_clone + (x + 1) * nChannels + y * widthStep);
                    pos_c = (data_ptr_clone + x * nChannels + (y + 1) * widthStep);
                    
                    S_blue  = Math.Abs(pos_a[0] - pos_b[0]) + Math.Abs(pos_a[0] - pos_c[0]);
                    S_green = Math.Abs(pos_a[1] - pos_b[1]) + Math.Abs(pos_a[1] - pos_c[1]);
                    S_red   = Math.Abs(pos_a[2] - pos_b[2]) + Math.Abs(pos_a[2] - pos_c[2]);
                    if (S_blue > 255)
                        S_blue = 255;
                    if (S_green > 255)
                        S_green = 255;
                    if (S_red > 255)
                        S_red = 255;

                    (data_ptr + x * nChannels + y * widthStep)[0] = (byte)(S_blue);
                    (data_ptr + x * nChannels + y * widthStep)[1] = (byte)(S_green);
                    (data_ptr + x * nChannels + y * widthStep)[2] = (byte)(S_red);
                }
        }

        public unsafe static void Median(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            int x, y;
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();

            byte* data_ptr_clone = (byte*)imgCopy.MIplImage.imageData.ToPointer();

            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int padding = mipl.widthStep - mipl.nChannels * mipl.width;
            int widthStep = mipl.widthStep;
            int lastXPixel = width - 1;
            int lastYPixel = height - 1;

            int[] blue_values = new int[9];
            int[] green_values = new int[9];
            int[] red_values = new int[9];
            int min_distance; int min_distance_pixel;

            //int head, tail;
            //int min, max;
            //head = 0;
            //tail = (int)Math.Round((double)blue_values.GetLength(0) / 2.0 + 1);
            /*
            // Top left
            y = 0;
            x = 0;
            // This can be optimized
            blue_values[0] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
            blue_values[1] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
            blue_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[0];
            blue_values[3] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
            blue_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
            blue_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[0];
            blue_values[6] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[0];
            blue_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[0];
            blue_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + (y + 1) * widthStep)[0];

            green_values[0] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
            green_values[1] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
            green_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[1];
            green_values[3] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
            green_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
            green_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[1];
            green_values[6] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[1];
            green_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[1];
            green_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + (y + 1) * widthStep)[1];

            red_values[0] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
            red_values[1] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
            red_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[2];
            red_values[3] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
            red_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
            red_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[2];
            red_values[6] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[2];
            red_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[2];
            red_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + (y + 1) * widthStep)[2];

            //
            // The Indian Algorithm
            //

            min_distance = int.MaxValue;
            min_distance_pixel = -1;

            // Get the pixel index closer to ever other pixel
            for (int i = 0; i < 9; i++)
            {
                int tmp_distance = 0;

                for (int j = 0; j < 9; j++)
                {
                    tmp_distance += Math.Abs(blue_values[i] - blue_values[j]) + Math.Abs(green_values[i] - green_values[j]) + Math.Abs(red_values[i] - red_values[j]);
                }

                if (tmp_distance < min_distance)
                {
                    min_distance = tmp_distance;
                    min_distance_pixel = i;
                }
            }

            (data_ptr + x * nChannels + y * widthStep)[0] = (byte)(blue_values[min_distance_pixel]);
            (data_ptr + x * nChannels + y * widthStep)[1] = (byte)(green_values[min_distance_pixel]);
            (data_ptr + x * nChannels + y * widthStep)[2] = (byte)(red_values[min_distance_pixel]);

            // Top right
            y = 0;
            x = width - 1;
            // This can be optimized
            blue_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[0];
            blue_values[1] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
            blue_values[2] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
            blue_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[0];
            blue_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
            blue_values[5] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
            blue_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + (y + 1) * widthStep)[0];
            blue_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[0];
            blue_values[8] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[0];

            green_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[1];
            green_values[1] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
            green_values[2] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
            green_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[1];
            green_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
            green_values[5] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
            green_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + (y + 1) * widthStep)[1];
            green_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[1];
            green_values[8] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[1];

            red_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[2];
            red_values[1] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
            red_values[2] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
            red_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[2];
            red_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
            red_values[5] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
            red_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + (y + 1) * widthStep)[2];
            red_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[2];
            red_values[8] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[2];

            //
            // The Indian Algorithm
            //

            min_distance = int.MaxValue;
            min_distance_pixel = -1;

            // Get the pixel index closer to ever other pixel
            for (int i = 0; i < 9; i++)
            {
                int tmp_distance = 0;

                for (int j = 0; j < 9; j++)
                {
                    tmp_distance += Math.Abs(blue_values[i] - blue_values[j]) + Math.Abs(green_values[i] - green_values[j]) + Math.Abs(red_values[i] - red_values[j]);
                }

                if (tmp_distance < min_distance)
                {
                    min_distance = tmp_distance;
                    min_distance_pixel = i;
                }
            }

            (data_ptr + x * nChannels + y * widthStep)[0] = (byte)(blue_values[min_distance_pixel]);
            (data_ptr + x * nChannels + y * widthStep)[1] = (byte)(green_values[min_distance_pixel]);
            (data_ptr + x * nChannels + y * widthStep)[2] = (byte)(red_values[min_distance_pixel]);
            
            // Bottom left
            y = height - 1;
            x = 0;
            // This can be optimized
            blue_values[0] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[0];
            blue_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[0];
            blue_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + (y - 1) * widthStep)[0];
            blue_values[3] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
            blue_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
            blue_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[0];
            blue_values[6] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
            blue_values[7] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
            blue_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[0];

            green_values[0] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[1];
            green_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[1];
            green_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + (y - 1) * widthStep)[1];
            green_values[3] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
            green_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
            green_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[1];
            green_values[6] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
            green_values[7] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
            green_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[1];

            red_values[0] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[2];
            red_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[2];
            red_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + (y - 1) * widthStep)[2];
            red_values[3] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
            red_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
            red_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[2];
            red_values[6] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
            red_values[7] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
            red_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[2];

            //
            // The Indian Algorithm
            //

            min_distance = int.MaxValue;
            min_distance_pixel = -1;

            // Get the pixel index closer to ever other pixel
            for (int i = 0; i < 9; i++)
            {
                int tmp_distance = 0;

                for (int j = 0; j < 9; j++)
                {
                    tmp_distance += Math.Abs(blue_values[i] - blue_values[j]) + Math.Abs(green_values[i] - green_values[j]) + Math.Abs(red_values[i] - red_values[j]);
                }

                if (tmp_distance < min_distance)
                {
                    min_distance = tmp_distance;
                    min_distance_pixel = i;
                }
            }

            (data_ptr + x * nChannels + y * widthStep)[0] = (byte)(blue_values[min_distance_pixel]);
            (data_ptr + x * nChannels + y * widthStep)[1] = (byte)(green_values[min_distance_pixel]);
            (data_ptr + x * nChannels + y * widthStep)[2] = (byte)(red_values[min_distance_pixel]);
            
            // Bottom right
            y = height - 1;
            x = width - 1;
            // This can be optimized
            blue_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + (y - 1) * widthStep)[0];
            blue_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[0];
            blue_values[2] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[0];
            blue_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[0];
            blue_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
            blue_values[5] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
            blue_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[0];
            blue_values[7] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
            blue_values[8] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];

            green_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + (y - 1) * widthStep)[1];
            green_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[1];
            green_values[2] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[1];
            green_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[1];
            green_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
            green_values[5] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
            green_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[1];
            green_values[7] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
            green_values[8] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];

            red_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + (y - 1) * widthStep)[2];
            red_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[2];
            red_values[2] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[2];
            red_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[2];
            red_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
            red_values[5] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
            red_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[2];
            red_values[7] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
            red_values[8] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];

            //
            // The Indian Algorithm
            //

            min_distance = int.MaxValue;
            min_distance_pixel = -1;

            // Get the pixel index closer to ever other pixel
            for (int i = 0; i < 9; i++)
            {
                int tmp_distance = 0;

                for (int j = 0; j < 9; j++)
                {
                    tmp_distance += Math.Abs(blue_values[i] - blue_values[j]) + Math.Abs(green_values[i] - green_values[j]) + Math.Abs(red_values[i] - red_values[j]);
                }

                if (tmp_distance < min_distance)
                {
                    min_distance = tmp_distance;
                    min_distance_pixel = i;
                }
            }

            (data_ptr + x * nChannels + y * widthStep)[0] = (byte)(blue_values[min_distance_pixel]);
            (data_ptr + x * nChannels + y * widthStep)[1] = (byte)(green_values[min_distance_pixel]);
            (data_ptr + x * nChannels + y * widthStep)[2] = (byte)(red_values[min_distance_pixel]);

            
            
            // Top row
            y = 0;
            for (x = 1; x < width - 1; x++)
            {
                // This can be optimized
                blue_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[0];
                blue_values[1] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
                blue_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[0];
                blue_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[0];
                blue_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
                blue_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[0];
                blue_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + (y + 1) * widthStep)[0];
                blue_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[0];
                blue_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + (y + 1) * widthStep)[0];

                green_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[1];
                green_values[1] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
                green_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[1];
                green_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[1];
                green_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
                green_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[1];
                green_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + (y + 1) * widthStep)[1];
                green_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[1];
                green_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + (y + 1) * widthStep)[1];

                red_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[2];
                red_values[1] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
                red_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[2];
                red_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[2];
                red_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
                red_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[2];
                red_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + (y + 1) * widthStep)[2];
                red_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[2];
                red_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + (y + 1) * widthStep)[2];

                //
                // The Indian Algorithm
                //

                min_distance = int.MaxValue;
                min_distance_pixel = -1;

                // Get the pixel index closer to ever other pixel
                for (int i = 0; i < 9; i++)
                {
                    int tmp_distance = 0;

                    for (int j = 0; j < 9; j++)
                    {
                        tmp_distance += Math.Abs(blue_values[i] - blue_values[j]) + Math.Abs(green_values[i] - green_values[j]) + Math.Abs(red_values[i] - red_values[j]);
                    }

                    if (tmp_distance < min_distance)
                    {
                        min_distance = tmp_distance;
                        min_distance_pixel = i;
                    }
                }

                (data_ptr + x * nChannels + y * widthStep)[0] = (byte)(blue_values[min_distance_pixel]);
                (data_ptr + x * nChannels + y * widthStep)[1] = (byte)(green_values[min_distance_pixel]);
                (data_ptr + x * nChannels + y * widthStep)[2] = (byte)(red_values[min_distance_pixel]);
            }

            // Left column
            for (y = 1; y < height - 1; y++)
            {
                x = 0;
                // This can be optimized
                blue_values[0] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[0];
                blue_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[0];
                blue_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + (y - 1) * widthStep)[0];
                blue_values[3] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
                blue_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
                blue_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[0];
                blue_values[6] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[0];
                blue_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[0];
                blue_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + (y + 1) * widthStep)[0];

                green_values[0] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[1];
                green_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[1];
                green_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + (y - 1) * widthStep)[1];
                green_values[3] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
                green_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
                green_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[1];
                green_values[6] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[1];
                green_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[1];
                green_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + (y + 1) * widthStep)[1];

                red_values[0] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[2];
                red_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[2];
                red_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + (y - 1) * widthStep)[2];
                red_values[3] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
                red_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
                red_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[2];
                red_values[6] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[2];
                red_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[2];
                red_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + (y + 1) * widthStep)[2];

                //
                // The Indian Algorithm
                //

                min_distance = int.MaxValue;
                min_distance_pixel = -1;

                // Get the pixel index closer to ever other pixel
                for (int i = 0; i < 9; i++)
                {
                    int tmp_distance = 0;

                    for (int j = 0; j < 9; j++)
                    {
                        tmp_distance += Math.Abs(blue_values[i] - blue_values[j]) + Math.Abs(green_values[i] - green_values[j]) + Math.Abs(red_values[i] - red_values[j]);
                    }

                    if (tmp_distance < min_distance)
                    {
                        min_distance = tmp_distance;
                        min_distance_pixel = i;
                    }
                }

                (data_ptr + x * nChannels + y * widthStep)[0] = (byte)(blue_values[min_distance_pixel]);
                (data_ptr + x * nChannels + y * widthStep)[1] = (byte)(green_values[min_distance_pixel]);
                (data_ptr + x * nChannels + y * widthStep)[2] = (byte)(red_values[min_distance_pixel]);
            }
            // Right column
            for (y = 1; y < height - 1; y++)
            {
                x = width - 1;
                // This can be optimized
                blue_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + (y - 1) * widthStep)[0];
                blue_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[0];
                blue_values[2] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[0];
                blue_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[0];
                blue_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
                blue_values[5] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
                blue_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + (y + 1) * widthStep)[0];
                blue_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[0];
                blue_values[8] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[0];

                green_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + (y - 1) * widthStep)[1];
                green_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[1];
                green_values[2] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[1];
                green_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[1];
                green_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
                green_values[5] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
                green_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + (y + 1) * widthStep)[1];
                green_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[1];
                green_values[8] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[1];

                red_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + (y - 1) * widthStep)[2];
                red_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[2];
                red_values[2] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[2];
                red_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[2];
                red_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
                red_values[5] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
                red_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + (y + 1) * widthStep)[2];
                red_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[2];
                red_values[8] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[2];

                //
                // The Indian Algorithm
                //

                min_distance = int.MaxValue;
                min_distance_pixel = -1;

                // Get the pixel index closer to ever other pixel
                for (int i = 0; i < 9; i++)
                {
                    int tmp_distance = 0;

                    for (int j = 0; j < 9; j++)
                    {
                        tmp_distance += Math.Abs(blue_values[i] - blue_values[j]) + Math.Abs(green_values[i] - green_values[j]) + Math.Abs(red_values[i] - red_values[j]);
                    }

                    if (tmp_distance < min_distance)
                    {
                        min_distance = tmp_distance;
                        min_distance_pixel = i;
                    }
                }

                (data_ptr + x * nChannels + y * widthStep)[0] = (byte)(blue_values[min_distance_pixel]);
                (data_ptr + x * nChannels + y * widthStep)[1] = (byte)(green_values[min_distance_pixel]);
                (data_ptr + x * nChannels + y * widthStep)[2] = (byte)(red_values[min_distance_pixel]);
            }
            // Bottom row
            y = height - 1;
            for (x = 1; x < width - 1; x++)
            {
                // This can be optimized
                blue_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + (y - 1) * widthStep)[0];
                blue_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[0];
                blue_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + (y - 1) * widthStep)[0];
                blue_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[0];
                blue_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
                blue_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[0];
                blue_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[0];
                blue_values[7] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
                blue_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[0];

                green_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + (y - 1) * widthStep)[1];
                green_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[1];
                green_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + (y - 1) * widthStep)[1];
                green_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[1];
                green_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
                green_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[1];
                green_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[1];
                green_values[7] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
                green_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[1];

                red_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + (y - 1) * widthStep)[2];
                red_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[2];
                red_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + (y - 1) * widthStep)[2];
                red_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[2];
                red_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
                red_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[2];
                red_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[2];
                red_values[7] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
                red_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[2];

                //
                // The Indian Algorithm
                //

                min_distance = int.MaxValue;
                min_distance_pixel = -1;

                // Get the pixel index closer to ever other pixel
                for (int i = 0; i < 9; i++)
                {
                    int tmp_distance = 0;

                    for (int j = 0; j < 9; j++)
                    {
                        tmp_distance += Math.Abs(blue_values[i] - blue_values[j]) + Math.Abs(green_values[i] - green_values[j]) + Math.Abs(red_values[i] - red_values[j]);
                    }

                    if (tmp_distance < min_distance)
                    {
                        min_distance = tmp_distance;
                        min_distance_pixel = i;
                    }
                }

                (data_ptr + x * nChannels + y * widthStep)[0] = (byte)(blue_values[min_distance_pixel]);
                (data_ptr + x * nChannels + y * widthStep)[1] = (byte)(green_values[min_distance_pixel]);
                (data_ptr + x * nChannels + y * widthStep)[2] = (byte)(red_values[min_distance_pixel]);

            }*/
            
            // Image center
            for (y = 1; y < height - 1; y++)
            {
                for (x = 1; x < width - 1; x++)
                {
                    // This can be optimized
                    blue_values[0]  = (int)(data_ptr_clone + (x - 1) * nChannels + (y - 1) * widthStep)[0];
                    blue_values[1]  = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[0];
                    blue_values[2]  = (int)(data_ptr_clone + (x + 1) * nChannels + (y - 1) * widthStep)[0];
                    blue_values[3]  = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[0];
                    blue_values[4]  = (int)(data_ptr_clone + x * nChannels + y * widthStep)[0];
                    blue_values[5]  = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[0];
                    blue_values[6]  = (int)(data_ptr_clone + (x - 1) * nChannels + (y + 1) * widthStep)[0];
                    blue_values[7]  = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[0];
                    blue_values[8]  = (int)(data_ptr_clone + (x + 1) * nChannels + (y + 1) * widthStep)[0];

                    green_values[0] = (int)(data_ptr_clone + (x - 1) * nChannels + (y - 1) * widthStep)[1];
                    green_values[1] = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[1];
                    green_values[2] = (int)(data_ptr_clone + (x + 1) * nChannels + (y - 1) * widthStep)[1];
                    green_values[3] = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[1];
                    green_values[4] = (int)(data_ptr_clone + x * nChannels + y * widthStep)[1];
                    green_values[5] = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[1];
                    green_values[6] = (int)(data_ptr_clone + (x - 1) * nChannels + (y + 1) * widthStep)[1];
                    green_values[7] = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[1];
                    green_values[8] = (int)(data_ptr_clone + (x + 1) * nChannels + (y + 1) * widthStep)[1];

                    red_values[0]   = (int)(data_ptr_clone + (x - 1) * nChannels + (y - 1) * widthStep)[2];
                    red_values[1]   = (int)(data_ptr_clone + x * nChannels + (y - 1) * widthStep)[2];
                    red_values[2]   = (int)(data_ptr_clone + (x + 1) * nChannels + (y - 1) * widthStep)[2];
                    red_values[3]   = (int)(data_ptr_clone + (x - 1) * nChannels + y * widthStep)[2];
                    red_values[4]   = (int)(data_ptr_clone + x * nChannels + y * widthStep)[2];
                    red_values[5]   = (int)(data_ptr_clone + (x + 1) * nChannels + y * widthStep)[2];
                    red_values[6]   = (int)(data_ptr_clone + (x - 1) * nChannels + (y + 1) * widthStep)[2];
                    red_values[7]   = (int)(data_ptr_clone + x * nChannels + (y + 1) * widthStep)[2];
                    red_values[8]   = (int)(data_ptr_clone + (x + 1) * nChannels + (y + 1) * widthStep)[2];

                    //
                    // The Indian Algorithm
                    //

                    min_distance = int.MaxValue;
                    min_distance_pixel = -1;

                    // Get the pixel index closer to ever other pixel
                    for (int i = 0; i < 9; i++)
                    {
                        int tmp_distance = 0;
                        

                        for (int j = 0; j < 9; j++)
                        {
                            tmp_distance += Math.Abs(blue_values[i] - blue_values[j]) + Math.Abs(green_values[i] - green_values[j]) + Math.Abs(red_values[i] - red_values[j]);
                        }

                        if (tmp_distance < min_distance)
                        {
                            min_distance = tmp_distance;
                            min_distance_pixel = i;
                        }
                    }

                    (data_ptr + x * nChannels + y * widthStep)[0] = (byte)(blue_values[min_distance_pixel]);
                    (data_ptr + x * nChannels + y * widthStep)[1] = (byte)(green_values[min_distance_pixel]);
                    (data_ptr + x * nChannels + y * widthStep)[2] = (byte)(red_values[min_distance_pixel]);

                }
            }
        }

        public unsafe static int[,] Histogram_All(Image<Bgr, byte> img)
        {
            int[,] All = new int[4, 256];
            int[,] RGB = Histogram_RGB(img);
            int[] Gray = Histogram_Gray(img);
            for(int j = 1; j < 4; j++)
                for (int i = 0; i <256; i++)
                    All[j, i] = RGB[j - 1, i];
            for (int i = 0; i < 256; i++)
                All[0, i] = Gray[i];
            return All;
        }

        public unsafe static int[] Histogram_Gray(Image<Bgr, byte> img)
        {
            int x, y;
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();

            ConvertToGray(img);

            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int padding = mipl.widthStep - mipl.nChannels * mipl.width;
            int widthStep = mipl.widthStep;

            int[] Gray = new int[256];

            for (int i = 0; i < 256; i++)
                Gray[i] = 0;

            for (y = 0; y < height; y++)
                for (x = 0; x < width; x++)
                    Gray[(data_ptr + x * nChannels + y * widthStep)[0]]++;

            return Gray;
        }

        public unsafe static int[,] Histogram_RGB(Image<Bgr, byte> img)
        {
            int x, y;
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();

            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int widthStep = mipl.widthStep;

            int[,] RGB = new int[3, 256];

            for (int i = 0; i < 256; i++)
                for (int j = 0; j < 3; j++)
                    RGB[j, i] = 0;

            for (y = 0; y < height; y++)
                for (x = 0; x < width; x++)
                {
                    RGB[0, (data_ptr + x * nChannels + y * widthStep)[0]]++;
                    RGB[1, (data_ptr + x * nChannels + y * widthStep)[1]]++;
                    RGB[2, (data_ptr + x * nChannels + y * widthStep)[2]]++;
                }

            return RGB;
        }

        public unsafe static void ConvertToBW(Image<Bgr, byte> img, int threshold)
        {
            ConvertToGray(img);
            int x, y;
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();

            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int widthStep = mipl.widthStep;

            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {
                    if ((data_ptr + x * nChannels + y * widthStep)[0] > threshold)
                    {
                        (data_ptr + x * nChannels + y * widthStep)[0] = 255;
                        (data_ptr + x * nChannels + y * widthStep)[1] = 255;
                        (data_ptr + x * nChannels + y * widthStep)[2] = 255;
                    } else
                    {
                        (data_ptr + x * nChannels + y * widthStep)[0] = 0;
                        (data_ptr + x * nChannels + y * widthStep)[1] = 0;
                        (data_ptr + x * nChannels + y * widthStep)[2] = 0;
                    }
                }
            }
        }

        public unsafe static void ConvertToBW_Otsu(Image<Bgr, byte> img)
        {
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();

            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int widthStep = mipl.widthStep;

            int pixel_count = height * width;

            int[] histogram = Histogram_Gray(img);

            int sum = 0;
            int threshold = 0;
            int wB = 0;
            int wF = 0;
            float varianceMax = 0;
            float sumB = 0;

            for(int i = 0; i < 256; i++)
                sum += i * histogram[i];

            for (int i = 0; i < 256; i++)
            {
                wB += histogram[i];
                if (wB == 0) continue;

                wF = pixel_count - wB;
                if (wF == 0) break;

                sumB += (float)(i * histogram[i]);

                float meanB = sumB / wB;
                float meanF = (sum - sumB) / wF;

                float variance = (float)wB * (float)wF * (meanB - meanF) * (meanB - meanF);

                if(variance > varianceMax)
                {
                    varianceMax = variance;
                    threshold = i;
                }
            }
            ConvertToBW(img, threshold);
        }

        // TODO, THIS IS JUST A TESTING VERSION
        public unsafe static void ConvertRGBToHSV(Image<Bgr, byte> img)
        {
            float fR, fG, fB;
            float fH, fS, fV;
            const float FLOAT_TO_BYTE = 255.0f;
            const float BYTE_TO_FLOAT = 1.0f / FLOAT_TO_BYTE;
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();
            int nChannels = mipl.nChannels;
            int height = mipl.height;
            int width = mipl.width;
            int widthStep = mipl.widthStep;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // OpenCV RBG order is B, G, R
                    byte* p_Pixel = (data_ptr + x * nChannels + y * widthStep); // RBG pointer
                    int bB = p_Pixel[0];
                    int bG = p_Pixel[1];
                    int bR = p_Pixel[2];

                    // Convert to float
                    fR = bR * BYTE_TO_FLOAT;
                    fG = bG * BYTE_TO_FLOAT;
                    fB = bB * BYTE_TO_FLOAT;

                    // Convert from RGB to HSV, using float ranges 0.0 to 1.0
                    float fDelta;
                    float fMin, fMax;
                    int iMax;
                    // Get the min and max
                    if (bB < bG)
                    {
                        if (bB < bR)
                        {
                            fMin = fB;
                            if (bR > bG)
                            {
                                iMax = bR;
                                fMax = fR;
                            }
                            else
                            {
                                iMax = bG;
                                fMax = fG;
                            }
                        }
                        else
                        {
                            fMin = fR;
                            fMax = fG;
                            iMax = bG;
                        }
                    }
                    else if (bG < bR)
                    {
                        fMin = fG;
                        if (bB > bR)
                        {
                            fMax = fB;
                            iMax = bB;
                        }
                        else
                        {
                            fMax = fR;
                            iMax = bB;
                        }
                    }
                    else 
                    {
                        fMin = fR;
                        fMax = fB;
                        iMax = bB;
                    }

                    fDelta = fMax - fMin;
                    fV = fMax;
                    if (iMax != 0)
                    {
                        fS = fDelta / fMax;
                        float ANGLE_TO_UNIT = 1.0f / (6.0f * fDelta);
                        if (iMax == bR)
                        {
                            fH = (fG - fB) * ANGLE_TO_UNIT;
                        }
                        else if (iMax == bG)
                        {
                            fH = (2.0f / 6.0f) + (fB - fR) * ANGLE_TO_UNIT;
                        }
                        else
                        {
                            fH = (4.0f / 6.0f) + (fR - fG) * ANGLE_TO_UNIT;
                        }
                        // Wrap outlier hues around the circle
                        if (fH < 0.0f)
                        {
                            fH += 1.0f;
                        }
                        if (fH >= 1.0f)
                        {
                            fH -= 1.0f;
                        }
                    }
                    else
                    {
                        // Colour is pure black
                        fS = 0;
                        fH = 0;
                    }

                    // Convert from floats to 8-bit integers
                    int bH = (int)(0.5f + fH * 255.0f);
                    int bS = (int)(0.5f + fS * 255.0f);
                    int bV = (int)(0.5f + fV * 255.0f);

                    // Clip the values to make sure it fits within the 8bits.
			        if (bH > 255)   bH = 255;
		    	    if (bH < 0)    	bH = 0;
			        if (bS > 255)  	bS = 255;
			        if (bS < 0)   	bS = 0;
			        if (bV > 255)   bV = 255;
			        if (bV < 0)     bV = 0;
                    
                    // Set HSV values
                    p_Pixel[0] = (byte)bH;
                    p_Pixel[1] = (byte)bS;
                    p_Pixel[2] = (byte)bV;
                }
            }
            // Goto https://shervinemami.info/colorConversion.html for implementations
        }

        public unsafe static void ConvertHSVToRGB(Image<Bgr, byte> img)
        {
            float fR, fG, fB;
            float fH, fS, fV;
            const float FLOAT_TO_BYTE = 255.0f;
            const float BYTE_TO_FLOAT = 1.0f / FLOAT_TO_BYTE;
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();
            int nChannels = mipl.nChannels;
            int height = mipl.height;
            int width = mipl.width;
            int widthStep = mipl.widthStep;

            for (int y = 0; y < height; y++) {
		        for (int x = 0; x < width; x++) {
                    byte* p_Pixel = (data_ptr + x * nChannels + y * widthStep); // RBG pointer 
                    int bH = p_Pixel[0];
                    int bS = p_Pixel[1];
                    int bV = p_Pixel[2];

                    // Convert from 8-bit to float
                    fH = bH * BYTE_TO_FLOAT;
                    fS = bS * BYTE_TO_FLOAT;
                    fV = bV * BYTE_TO_FLOAT;

                    // Convert from HSV to RGB, using float ranges from 0.0 to 1.0
                    int iI;
                    float fI, fF, p, q, t;;

                    if (bS == 0)
                    {
                        // Grey
                        fR = fG = fB = fV;
                    }
                    else
                    {
                        if (fH >= 1.0f)
                        {
                            fH = 0.0f;
                        }

                        fH *= 6.0f;
                        fI = (float)Math.Truncate(fH);
                        iI = (int)fH;
                        fF = fH - fI;

                        p = fV * (1.0f - fS);
                        q = fV * (1.0f - fS * fF);
                        t = fV * (1.0f - fS * (1.0f - fF));

                        switch(iI)
                        {
                        case 0:
                            fR = fV;
                            fG = t;
                            fB = p;
                            break;
                        case 1:
                            fR = q;
                            fG = fV;
                            fB = p;
                            break;
                        case 2:
                            fR = p;
                            fG = fV;
                            fB = t;
                            break;
                        case 3:
                            fR = p;
                            fG = q;
                            fB = fV;
                            break;
                        case 4:
                            fR = t;
                            fG = p;
                            fB = fV;
                            break;
                        default:
                            fR = fV;
                            fG = p;
                            fB = q;
                            break;
                        }
                    }

                    // Convert from floats to 8-bit integers
                    int bR = (int)(fR * FLOAT_TO_BYTE);
                    int bG = (int)(fG * FLOAT_TO_BYTE);
                    int bB = (int)(fB * FLOAT_TO_BYTE);

                    // Clip the values to make sure it fits within the 8bits.
			        if (bR > 255)
			        	bR = 255;
		        	if (bR < 0)
		           		bR = 0;
		        	if (bG > 255)
			        	bG = 255;
		        	if (bG < 0)
		        		bG = 0;
		        	if (bB > 255)
		        		bB = 255;
		        	if (bB < 0)
		        		bB = 0;
        
                    p_Pixel[0] = (byte)bB;
                    p_Pixel[1] = (byte)bG;
                    p_Pixel[2] = (byte)bR;
                }
            }
        }

        public unsafe static void ConvertToBR_HSV(Image<Bgr, byte> img)
        {
            int x, y;
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();

            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int widthStep = mipl.widthStep;

            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {
                    if (((data_ptr + x * nChannels + y * widthStep)[0] <= 10 || (data_ptr + x * nChannels + y * widthStep)[0] >= 160) &&
                        ((data_ptr + x * nChannels + y * widthStep)[1] >= 100 && (data_ptr + x * nChannels + y * widthStep)[2] >= 100))
                    {
                        //(data_ptr + x * nChannels + y * widthStep)[0] = 255;
                        //(data_ptr + x * nChannels + y * widthStep)[1] = 255;
                        //(data_ptr + x * nChannels + y * widthStep)[2] = 255;
                        // Preserve colour
                    } else
                    {
                        (data_ptr + x * nChannels + y * widthStep)[0] = 0;
                        (data_ptr + x * nChannels + y * widthStep)[1] = 0;
                        (data_ptr + x * nChannels + y * widthStep)[2] = 0;
                    }
                }
            } 
        }

        //used in ConvertToRed_Otsu, TODO
        public unsafe static int[] Histogram_Red(Image<Bgr, byte> img)
        {
            int x, y;
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();

            ConvertToGray(img);

            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int padding = mipl.widthStep - mipl.nChannels * mipl.width;
            int widthStep = mipl.widthStep;

            int[] Gray = new int[256];

            for (int i = 0; i < 256; i++)
                Gray[i] = 0;

            for (y = 0; y < height; y++)
                for (x = 0; x < width; x++)
                    Gray[(data_ptr + x * nChannels + y * widthStep)[0]]++;

            return Gray;
        }

        //maybe TODO
        public unsafe static void ConvertToRed_Otsu(Image<Bgr, byte> img)
        {
            MIplImage mipl = img.MIplImage;
            byte* data_ptr = (byte*)mipl.imageData.ToPointer();

            int nChannels = mipl.nChannels;
            int height = img.Height;
            int width = img.Width;
            int widthStep = mipl.widthStep;

            int pixel_count = height * width;

            int[] histogram = Histogram_Red(img);

            int sum = 0;
            int threshold = 0;
            int wB = 0;
            int wF = 0;
            float varianceMax = 0;
            float sumB = 0;

            for (int i = 0; i < 256; i++)
                sum += i * histogram[i];

            for (int i = 0; i < 256; i++)
            {
                wB += histogram[i];
                if (wB == 0) continue;

                wF = pixel_count - wB;
                if (wF == 0) break;

                sumB += (float)(i * histogram[i]);

                float meanB = sumB / wB;
                float meanF = (sum - sumB) / wF;

                float variance = (float)wB * (float)wF * (meanB - meanF) * (meanB - meanF);

                if (variance > varianceMax)
                {
                    varianceMax = variance;
                    threshold = i;
                }
            }
            ConvertToBW(img, threshold);
        }

        public unsafe static void DetectSigns(Image<Bgr, byte> otsu, Image<Bgr, byte> otsu_red, out List<string[]> limitSign, 
                                out List<string[]> warningSign, out List<string[]> prohibitionSign)
        {
            // GetWhiteObjects(otsu, out whiteObjects);
            // GetRedObjects(otsu_red, out redObjects);

            // FindLimitSigns(whiteObjects, redObjects, out limitSign);
            // FindWarningSigns(whiteObjects, redObjects, out warningSign);
            // FindProhibitionSigns(whiteObjects, redObjects, out prohibitionSign);

            // Return
            limitSign = new List<string[]>();
            warningSign = new List<string[]>();
            prohibitionSign = new List<string[]>();
        }

        public static Image<Bgr, byte> Signs(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, out List<string[]> limitSign, 
                                out List<string[]> warningSign, out List<string[]> prohibitionSign, int level)
        {
            // New architecture
            //ConvertRGBToHSV(img);
            //ConvertToBR_HSV(img);
            //ConvertHSVToRGB(img);
            // You can test BR_HSV with this ^^

            //ConvertToBR_HSV(hsv_image);
            //ConvertToBW(imgCopy);

            //GetConnectedComponents_BR(hsv_image);
            //GetConnectedComponents_BW(imgCopy);

            // DetectSigns();

            limitSign = new List<string[]>();
            warningSign = new List<string[]>();
            prohibitionSign = new List<string[]>();

            Image<Bgr, byte> otsu_red = img.Clone();
            Image<Bgr, byte> otsu = img.Clone();

            ConvertToRed_Otsu(otsu_red);
            ConvertToBW_Otsu(otsu);

            DetectSigns(otsu, otsu_red, out limitSign, out warningSign, out prohibitionSign);

            return img;
        }
    }
}
