using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcess
{
    public partial class ImageProcessMachine : Form
    {
        //To control form's move
        private bool b_FormIsMoving = false;
        private int i_OrgFormLoc_x = 0, i_OrgFormLoc_y = 0, i_OrgMouseLoc_x = 0, i_OrgMouseLoc_y = 0;

        //Image Datas
        private Bitmap bmp_OrigImage;

        //Constructor
        public ImageProcessMachine()
        {
            InitializeComponent();
            Dialog_loadImages.Filter = "JPG|*.jpg;*.jpeg|PNG|*.png|BMP|*.bmp";
            Dialog_saveImages.Filter = "JPG,JPEG|*.jpg;*.jpeg|PNG|*.png|BMP|*.bmp";
        }
        
        //To control form's move
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            b_FormIsMoving = true;
            i_OrgFormLoc_x = this.Location.X;
            i_OrgFormLoc_y = this.Location.Y;
            i_OrgMouseLoc_x = MousePosition.X;
            i_OrgMouseLoc_y = MousePosition.Y;
        }
        private void ImageProcessMachine_MouseLeave(object sender, EventArgs e)
        {
            b_FormIsMoving = false;
        }
        private void ImageProcessMachine_MouseUp(object sender, MouseEventArgs e)
        {
            b_FormIsMoving = false;
        }
        private void ImageProcessMachine_MouseMove(object sender, MouseEventArgs e)
        {
            if (b_FormIsMoving)
                this.SetDesktopLocation(i_OrgFormLoc_x + MousePosition.X - i_OrgMouseLoc_x, i_OrgFormLoc_y + MousePosition.Y - i_OrgMouseLoc_y);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            b_FormIsMoving = true;
            i_OrgFormLoc_x = this.Location.X;
            i_OrgFormLoc_y = this.Location.Y;
            i_OrgMouseLoc_x = MousePosition.X;
            i_OrgMouseLoc_y = MousePosition.Y;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            b_FormIsMoving = false;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            b_FormIsMoving = false;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (b_FormIsMoving)
                this.SetDesktopLocation(i_OrgFormLoc_x + MousePosition.X - i_OrgMouseLoc_x, i_OrgFormLoc_y + MousePosition.Y - i_OrgMouseLoc_y);
        }

        //Load & Save Images
        private void LoadImages_Click(object sender, EventArgs e)
        {
            if (Dialog_loadImages.ShowDialog() != DialogResult.OK) return;
            
            string s_FileName = Dialog_loadImages.FileName;
            Bitmap bmp_TempBitmap = new Bitmap(s_FileName);
            bmp_OrigImage = new Bitmap(bmp_TempBitmap); //Change pixel format to 32argb

            DisplayZone.Image = bmp_OrigImage;
            DisplayZone_02.Image = bmp_OrigImage;

            Gray_Scale_Average.Enabled = true;
            Mean_Filter.Enabled = true;
            Weighted_Filter.Enabled = true;
            Median_Filter.Enabled = true;
            SaveImages.Enabled = true;
            Sobel.Enabled = true;
            Laplacian.Enabled = true;
            Shape_Laplacian.Enabled = true;
            Shape_Sobel.Enabled = true;
            Histogram_Equalization.Enabled = true;
            Histogram_Equalization_Nega.Enabled = true;
            Negative.Enabled = true;
            K_Mean.Enabled = true;
            Erosion.Enabled = true;
            Dilation.Enabled = true;
            Opening.Enabled = true;
            Closing_process.Enabled = true;
            HOGU.Enabled = true;
            Gamma.Enabled = true;
            //

            Histogram_R.LoadData(bmp_OrigImage, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_OrigImage, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_OrigImage, 'B');
            Histogram_B.ShowData();
        }
        private void SaveImages_Click(object sender, EventArgs e)
        {
            if (Dialog_saveImages.ShowDialog() != DialogResult.OK || Dialog_saveImages.FileName == "") return;
            Bitmap bmp_saveBitmap = new Bitmap(DisplayZone.Image);

            switch (Dialog_saveImages.FilterIndex)
            {
                case 1:
                    bmp_saveBitmap.Save(Dialog_saveImages.FileName, ImageFormat.Jpeg);
                    break;
                case 2:
                    bmp_saveBitmap.Save(Dialog_saveImages.FileName, ImageFormat.Png);
                    break;
                case 3:
                    bmp_saveBitmap.Save(Dialog_saveImages.FileName, ImageFormat.Bmp);
                    break;
            }
        }
        //Grayscale_Average
        private void Gray_Scale_Click(object sender, EventArgs e)
        {
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData = new BitmapData();
                byte* ptr_Pointer_0;

                bd_BitmapData = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                ptr_Pointer_0 = (byte*)bd_BitmapData.Scan0;
                int i_stride = bd_BitmapData.Stride,
                    i_height = bd_BitmapData.Height,
                    i_width = bd_BitmapData.Width;
                //
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_baseIndex = y * i_stride + x * 4,
                           i_grayScaleValue =
                           (int)((double)ptr_Pointer_0[i_baseIndex + 2] * 0.299
                           + (double)ptr_Pointer_0[i_baseIndex + 1] * 0.587
                           + (double)ptr_Pointer_0[i_baseIndex] * 0.114);

                        ptr_Pointer_0[i_baseIndex + 2] = (byte)i_grayScaleValue;   //R
                        ptr_Pointer_0[i_baseIndex + 1] = (byte)i_grayScaleValue;   //G
                        ptr_Pointer_0[i_baseIndex] = (byte)i_grayScaleValue;   //B           
                    }
                }
                //
                bmp_TempBitmap.UnlockBits(bd_BitmapData);
            }
            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }
        
        //FilterS
        private void Mean_Filter_Click(object sender, EventArgs e)
        {
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData_Temp = new BitmapData(), bd_BitmapData_Original = new BitmapData();
                byte* ptr_Pointer_0_Temp, ptr_Pointer_0_Original;

                bd_BitmapData_Temp = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                bd_BitmapData_Original = bmp_OrigImage.LockBits(new Rectangle(0, 0, bmp_OrigImage.Width, bmp_OrigImage.Height), ImageLockMode.ReadWrite, bmp_OrigImage.PixelFormat);

                ptr_Pointer_0_Temp = (byte*)bd_BitmapData_Temp.Scan0;
                ptr_Pointer_0_Original = (byte*)bd_BitmapData_Original.Scan0;

                int i_stride = bd_BitmapData_Original.Stride,
                    i_height = bd_BitmapData_Original.Height,
                    i_width = bd_BitmapData_Original.Width;
                //
                for (int y = 0; y < i_height; y++) {
                    for (int x = 0; x < i_width; x++){
                        int i_counter = 0, i_counter_R = 0, i_counter_G = 0, i_counter_B = 0
                            , i_baseIndex = 0;
                        //Start calculate the mean of nearby pixels
                        for (int yi = y - 2; yi <= y + 2; yi++){
                            if (yi < 0 || yi >= i_height) continue;
                            for (int xi = x - 2; xi <= x + 2; xi++){
                                if (xi < 0 || xi >= i_width) continue;
                                i_baseIndex = yi * i_stride + xi * 4;

                                i_counter++;
                                i_counter_R += ptr_Pointer_0_Original[i_baseIndex + 2];
                                i_counter_G += ptr_Pointer_0_Original[i_baseIndex + 1];
                                i_counter_B += ptr_Pointer_0_Original[i_baseIndex];
                            }
                        }
                        i_baseIndex = y * i_stride + x * 4;

                        ptr_Pointer_0_Temp[i_baseIndex + 2] = (byte)(i_counter_R / i_counter);   //R
                        ptr_Pointer_0_Temp[i_baseIndex + 1] = (byte)(i_counter_G / i_counter);   //G
                        ptr_Pointer_0_Temp[i_baseIndex] = (byte)(i_counter_B / i_counter);   //B
                    }
                }
                //
                bmp_TempBitmap.UnlockBits(bd_BitmapData_Temp);
                bmp_OrigImage.UnlockBits(bd_BitmapData_Original);
            }
            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }
        private void Weighted_Filter_Click(object sender, EventArgs e)
        {
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData_Temp = new BitmapData(), bd_BitmapData_Original = new BitmapData();
                byte* ptr_Pointer_0_Temp, ptr_Pointer_0_Original;

                bd_BitmapData_Temp = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                bd_BitmapData_Original = bmp_OrigImage.LockBits(new Rectangle(0, 0, bmp_OrigImage.Width, bmp_OrigImage.Height), ImageLockMode.ReadWrite, bmp_OrigImage.PixelFormat);

                ptr_Pointer_0_Temp = (byte*)bd_BitmapData_Temp.Scan0;
                ptr_Pointer_0_Original = (byte*)bd_BitmapData_Original.Scan0;

                int i_stride = bd_BitmapData_Original.Stride,
                    i_height = bd_BitmapData_Original.Height,
                    i_width = bd_BitmapData_Original.Width;

                int[] WeightS = { 1,5,1,
                                5,10,5,
                                1,5,1};
                //
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_counter = 0, i_counter_R = 0, i_counter_G = 0, i_counter_B = 0
                            , i_baseIndex = 0;
                        //
                        for (int yi = y - 1; yi <= y + 1; yi++)
                        {
                            if (yi < 0 || yi >= i_height) continue;
                            for (int xi = x - 1; xi <= x + 1; xi++)
                            {
                                if (xi < 0 || xi >= i_width) continue;
                                i_baseIndex = yi * i_stride + xi * 4;
                                int i_weight = WeightS[(yi - y + 1) * 3 + xi - x + 1];

                                i_counter += i_weight;
                                i_counter_R += (ptr_Pointer_0_Original[i_baseIndex + 2] * i_weight);
                                i_counter_G += (ptr_Pointer_0_Original[i_baseIndex + 1] * i_weight);
                                i_counter_B += (ptr_Pointer_0_Original[i_baseIndex] * i_weight);
                            }
                        }
                        i_baseIndex = y * i_stride + x * 4;

                        ptr_Pointer_0_Temp[i_baseIndex + 2] = (byte)(i_counter_R / i_counter);   //R
                        ptr_Pointer_0_Temp[i_baseIndex + 1] = (byte)(i_counter_G / i_counter);   //G
                        ptr_Pointer_0_Temp[i_baseIndex] = (byte)(i_counter_B / i_counter);   //B
                    }
                }
                //
                bmp_TempBitmap.UnlockBits(bd_BitmapData_Temp);
                bmp_OrigImage.UnlockBits(bd_BitmapData_Original);
            }
            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }
        private void Median_Filter_Click(object sender, EventArgs e)
        {
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData_Temp = new BitmapData(), bd_BitmapData_Original = new BitmapData();
                byte* ptr_Pointer_0_Temp, ptr_Pointer_0_Original;

                bd_BitmapData_Temp = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                bd_BitmapData_Original = bmp_OrigImage.LockBits(new Rectangle(0, 0, bmp_OrigImage.Width, bmp_OrigImage.Height), ImageLockMode.ReadWrite, bmp_OrigImage.PixelFormat);

                ptr_Pointer_0_Temp = (byte*)bd_BitmapData_Temp.Scan0;
                ptr_Pointer_0_Original = (byte*)bd_BitmapData_Original.Scan0;

                int i_stride = bd_BitmapData_Original.Stride,
                    i_height = bd_BitmapData_Original.Height,
                    i_width = bd_BitmapData_Original.Width;
                //
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_baseIndex = 0;
                        List<int> list_R = new List<int>(), list_G = new List<int>(), list_B = new List<int>();
                        //
                        for (int yi = y - 1; yi <= y + 1; yi++)
                        {
                            if (yi < 0 || yi == i_height) continue;
                            for (int xi = x - 1; xi <= x + 1; xi++)
                            {
                                if (xi < 0 || xi == i_width) continue;
                                i_baseIndex = yi * i_stride + xi * 4;

                                list_R.Add((int)ptr_Pointer_0_Original[i_baseIndex + 2]);    //Add R byte to list of R
                                list_G.Add((int)ptr_Pointer_0_Original[i_baseIndex + 1]);    //Add G byte to list of G
                                list_B.Add((int)ptr_Pointer_0_Original[i_baseIndex]);        //Add B byte to list of B
                            }
                        }
                        i_baseIndex = y * i_stride + x * 4;

                        list_R.Sort();
                        list_G.Sort();
                        list_B.Sort();

                        int i_medianRValue = 0, i_medianGValue = 0, i_medianBValue = 0, i_elementCounts = list_R.Count;


                        if (i_elementCounts % 2 == 0)
                        {
                            //even elements
                            i_medianRValue = (list_R[(i_elementCounts / 2) - 1] + list_R[(i_elementCounts / 2)]) / 2;
                            i_medianGValue = (list_G[(i_elementCounts / 2) - 1] + list_G[(i_elementCounts / 2)]) / 2;
                            i_medianBValue = (list_B[(i_elementCounts / 2) - 1] + list_B[(i_elementCounts / 2)]) / 2;
                        }
                        else
                        {
                            //odd elements
                            i_medianRValue = list_R[(i_elementCounts / 2)];
                            i_medianGValue = list_G[(i_elementCounts / 2)];
                            i_medianBValue = list_B[(i_elementCounts / 2)];
                        }
                        ptr_Pointer_0_Temp[i_baseIndex + 2] = (byte)i_medianRValue;   //R
                        ptr_Pointer_0_Temp[i_baseIndex + 1] = (byte)i_medianGValue;   //G
                        ptr_Pointer_0_Temp[i_baseIndex] = (byte)i_medianBValue;   //B
                    }
                }
                //
                bmp_TempBitmap.UnlockBits(bd_BitmapData_Temp);
                bmp_OrigImage.UnlockBits(bd_BitmapData_Original);
            }
            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }

        /*Edge detection (20181016...Find Bug_01:When doing "Space processing",
         *you should read pixel data from the original one then write data to the copy rather than
         *read and write on the same image recursively. 
         */
        private void Sobel_Click(object sender, EventArgs e)
        {
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData_Temp = new BitmapData(), bd_BitmapData_Original = new BitmapData();
                byte* ptr_Pointer_0_Temp, ptr_Pointer_0_Original;

                bd_BitmapData_Temp = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                bd_BitmapData_Original = bmp_OrigImage.LockBits(new Rectangle(0, 0, bmp_OrigImage.Width, bmp_OrigImage.Height), ImageLockMode.ReadWrite, bmp_OrigImage.PixelFormat);

                ptr_Pointer_0_Temp = (byte*)bd_BitmapData_Temp.Scan0;
                ptr_Pointer_0_Original = (byte*)bd_BitmapData_Original.Scan0;

                int i_stride = bd_BitmapData_Original.Stride,
                    i_height = bd_BitmapData_Original.Height,
                    i_width = bd_BitmapData_Original.Width;
                //
                int[] Vertical_WeightS = { -1,0,1,
                                           -2,0,2,
                                           -1,0,1},
                     Horizontal_WeightS = { -1,-2,-1,
                                              0,0,0,
                                              1,2,1};
                //
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_counter_R_Horizontal = 0, i_counter_G_Horizontal = 0, i_counter_B_Horizontal = 0,
                            i_counter_R_Vertical = 0, i_counter_G_Vertical = 0, i_counter_B_Vertical = 0,
                            i_baseIndex = 0;

                        //
                        for (int yi = y - 1; yi <= y + 1; yi++)
                        {
                            if (yi < 0 || yi >= i_height) continue;
                            for (int xi = x - 1; xi <= x + 1; xi++)
                            {
                                if (xi < 0 || xi >= i_width) continue;

                                i_baseIndex = yi * i_stride + xi * 4;
                                int i_horizontal_weight = Horizontal_WeightS[(yi - y + 1) * 3 + xi - x + 1],
                                    i_vertical_weight = Vertical_WeightS[(yi - y + 1) * 3 + xi - x + 1];

                                i_counter_R_Horizontal += (ptr_Pointer_0_Original[i_baseIndex + 2] * i_horizontal_weight);
                                i_counter_G_Horizontal += (ptr_Pointer_0_Original[i_baseIndex + 1] * i_horizontal_weight);
                                i_counter_B_Horizontal += (ptr_Pointer_0_Original[i_baseIndex] * i_horizontal_weight);

                                i_counter_R_Vertical += (ptr_Pointer_0_Original[i_baseIndex + 2] * i_vertical_weight);
                                i_counter_G_Vertical += (ptr_Pointer_0_Original[i_baseIndex + 1] * i_vertical_weight);
                                i_counter_B_Vertical += (ptr_Pointer_0_Original[i_baseIndex] * i_vertical_weight);
                            }
                        }
                        i_baseIndex = y * i_stride + x * 4;

                        double d_R_Horizontal = i_counter_R_Horizontal, d_R_Vertical = i_counter_R_Vertical,
                            d_G_Horizontal = i_counter_G_Horizontal, d_G_Vertical = i_counter_G_Vertical,
                            d_B_Horizontal = i_counter_B_Horizontal, d_B_Vertical = i_counter_B_Vertical;

                        int i_Result_R = (int)Math.Sqrt(Math.Pow(d_R_Horizontal, 2) + Math.Pow(d_R_Vertical, 2)),
                            i_Result_G = (int)Math.Sqrt(Math.Pow(d_G_Horizontal, 2) + Math.Pow(d_G_Vertical, 2)),
                            i_Result_B = (int)Math.Sqrt(Math.Pow(d_B_Horizontal, 2) + Math.Pow(d_B_Vertical, 2));

                        ptr_Pointer_0_Temp[i_baseIndex + 2] = (byte)(i_Result_R > 255 ? 255 : i_Result_R);   //R
                        ptr_Pointer_0_Temp[i_baseIndex + 1] = (byte)(i_Result_G > 255 ? 255 : i_Result_G);   //G
                        ptr_Pointer_0_Temp[i_baseIndex] = (byte)(i_Result_B > 255 ? 255 : i_Result_B);       //B
                    }
                }
                //
                bmp_TempBitmap.UnlockBits(bd_BitmapData_Temp);
                bmp_OrigImage.UnlockBits(bd_BitmapData_Original);
            }

            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }
        private void Laplacian_Click(object sender, EventArgs e)
        {
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData_Temp = new BitmapData(), bd_BitmapData_Original = new BitmapData();
                byte* ptr_Pointer_0_Temp, ptr_Pointer_0_Original;

                bd_BitmapData_Temp = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                bd_BitmapData_Original = bmp_OrigImage.LockBits(new Rectangle(0, 0, bmp_OrigImage.Width, bmp_OrigImage.Height), ImageLockMode.ReadWrite, bmp_OrigImage.PixelFormat);

                ptr_Pointer_0_Temp = (byte*)bd_BitmapData_Temp.Scan0;
                ptr_Pointer_0_Original = (byte*)bd_BitmapData_Original.Scan0;

                int i_stride = bd_BitmapData_Original.Stride,
                    i_height = bd_BitmapData_Original.Height,
                    i_width = bd_BitmapData_Original.Width;

                int[] WeightS = { -1,-1,-1,
                                -1,8,-1,
                                -1,-1,-1};
                //
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_counter_R = 0, i_counter_G = 0, i_counter_B = 0
                            , i_baseIndex = 0;
                        //
                        for (int yi = y - 1; yi <= y + 1; yi++)
                        {
                            if (yi < 0 || yi >= i_height) continue;
                            for (int xi = x - 1; xi <= x + 1; xi++)
                            {
                                if (xi < 0 || xi >= i_width) continue;
                                i_baseIndex = yi * i_stride + xi * 4;
                                int i_weight = WeightS[(yi - y + 1) * 3 + xi - x + 1];

                                i_counter_R += (ptr_Pointer_0_Original[i_baseIndex + 2] * i_weight);
                                i_counter_G += (ptr_Pointer_0_Original[i_baseIndex + 1] * i_weight);
                                i_counter_B += (ptr_Pointer_0_Original[i_baseIndex] * i_weight);
                            }
                        }
                        i_baseIndex = y * i_stride + x * 4;

                        if (i_counter_R > 255) i_counter_R = 255;
                        else if (i_counter_R < 0) i_counter_R = 0;

                        if (i_counter_G > 255) i_counter_G = 255;
                        else if (i_counter_G < 0) i_counter_G = 0;

                        if (i_counter_B > 255) i_counter_B = 255;
                        else if (i_counter_B < 0) i_counter_B = 0;

                        ptr_Pointer_0_Temp[i_baseIndex + 2] = (byte)i_counter_R;   //R
                        ptr_Pointer_0_Temp[i_baseIndex + 1] = (byte)i_counter_G;   //G
                        ptr_Pointer_0_Temp[i_baseIndex] = (byte)i_counter_B;   //B
                    }
                }
                //
                bmp_TempBitmap.UnlockBits(bd_BitmapData_Temp);
                bmp_OrigImage.UnlockBits(bd_BitmapData_Original);
            }

            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }
        private void Shape_Click(object sender, EventArgs e)
        {
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData_Temp = new BitmapData(), bd_BitmapData_Original = new BitmapData();
                byte* ptr_Pointer_0_Temp, ptr_Pointer_0_Original;

                bd_BitmapData_Temp = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                bd_BitmapData_Original = bmp_OrigImage.LockBits(new Rectangle(0, 0, bmp_OrigImage.Width, bmp_OrigImage.Height), ImageLockMode.ReadWrite, bmp_OrigImage.PixelFormat);

                ptr_Pointer_0_Temp = (byte*)bd_BitmapData_Temp.Scan0;
                ptr_Pointer_0_Original = (byte*)bd_BitmapData_Original.Scan0;

                int i_stride = bd_BitmapData_Original.Stride,
                    i_height = bd_BitmapData_Original.Height,
                    i_width = bd_BitmapData_Original.Width;

                int[] WeightS = { -1,-1,-1,
                                -1,8,-1,
                                -1,-1,-1};
                //
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_counter_R = 0, i_counter_G = 0, i_counter_B = 0
                            , i_baseIndex = 0;
                        //
                        for (int yi = y - 1; yi <= y + 1; yi++)
                        {
                            if (yi < 0 || yi >= i_height) continue;
                            for (int xi = x - 1; xi <= x + 1; xi++)
                            {
                                if (xi < 0 || xi >= i_width) continue;
                                i_baseIndex = yi * i_stride + xi * 4;
                                int i_weight = WeightS[(yi - y + 1) * 3 + xi - x + 1];

                                i_counter_R += (ptr_Pointer_0_Original[i_baseIndex + 2] * i_weight);
                                i_counter_G += (ptr_Pointer_0_Original[i_baseIndex + 1] * i_weight);
                                i_counter_B += (ptr_Pointer_0_Original[i_baseIndex] * i_weight);
                            }
                        }
                        i_baseIndex = y * i_stride + x * 4;

                        if (i_counter_R > 255) i_counter_R = 255;
                        else if ((i_counter_R + ptr_Pointer_0_Original[i_baseIndex + 2]) > 255) i_counter_R = 255;
                        else if ((i_counter_R + ptr_Pointer_0_Original[i_baseIndex + 2]) < 0) i_counter_R = 0;
                        else i_counter_R += ptr_Pointer_0_Original[i_baseIndex + 2];

                        if (i_counter_G > 255) i_counter_G = 255;
                        else if ((i_counter_G + ptr_Pointer_0_Original[i_baseIndex + 1]) > 255) i_counter_G = 255;
                        else if ((i_counter_G + ptr_Pointer_0_Original[i_baseIndex + 1]) < 0) i_counter_G = 0;
                        else i_counter_G += ptr_Pointer_0_Original[i_baseIndex + 1];

                        if (i_counter_B > 255) i_counter_B = 255;
                        else if ((i_counter_B + ptr_Pointer_0_Original[i_baseIndex]) > 255) i_counter_B = 255;
                        else if ((i_counter_B + ptr_Pointer_0_Original[i_baseIndex]) < 0) i_counter_B = 0;
                        else i_counter_B += ptr_Pointer_0_Original[i_baseIndex];

                        ptr_Pointer_0_Temp[i_baseIndex + 2] = (byte)i_counter_R;   //R
                        ptr_Pointer_0_Temp[i_baseIndex + 1] = (byte)i_counter_G;   //G
                        ptr_Pointer_0_Temp[i_baseIndex] = (byte)i_counter_B;   //B
                    }
                }
                //
                bmp_TempBitmap.UnlockBits(bd_BitmapData_Temp);
                bmp_OrigImage.UnlockBits(bd_BitmapData_Original);
            }
            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }
        private void Shape_Sobel_Click(object sender, EventArgs e)
        {
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData_Temp = new BitmapData(), bd_BitmapData_Original = new BitmapData();
                byte* ptr_Pointer_0_Temp, ptr_Pointer_0_Original;

                bd_BitmapData_Temp = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                bd_BitmapData_Original = bmp_OrigImage.LockBits(new Rectangle(0, 0, bmp_OrigImage.Width, bmp_OrigImage.Height), ImageLockMode.ReadWrite, bmp_OrigImage.PixelFormat);

                ptr_Pointer_0_Temp = (byte*)bd_BitmapData_Temp.Scan0;
                ptr_Pointer_0_Original = (byte*)bd_BitmapData_Original.Scan0;

                int i_stride = bd_BitmapData_Original.Stride,
                    i_height = bd_BitmapData_Original.Height,
                    i_width = bd_BitmapData_Original.Width;
                //
                int[] Vertical_WeightS = { -1,0,1,
                                           -2,0,2,
                                           -1,0,1},
                     Horizontal_WeightS = { -1,-2,-1,
                                              0,0,0,
                                              1,2,1};
                //
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_counter_R_Horizontal = 0, i_counter_G_Horizontal = 0, i_counter_B_Horizontal = 0,
                            i_counter_R_Vertical = 0, i_counter_G_Vertical = 0, i_counter_B_Vertical = 0,
                            i_baseIndex = 0;

                        //
                        for (int yi = y - 1; yi <= y + 1; yi++)
                        {
                            if (yi < 0 || yi >= i_height) continue;
                            for (int xi = x - 1; xi <= x + 1; xi++)
                            {
                                if (xi < 0 || xi >= i_width) continue;

                                i_baseIndex = yi * i_stride + xi * 4;
                                int i_horizontal_weight = Horizontal_WeightS[(yi - y + 1) * 3 + xi - x + 1],
                                    i_vertical_weight = Vertical_WeightS[(yi - y + 1) * 3 + xi - x + 1];

                                i_counter_R_Horizontal += (ptr_Pointer_0_Original[i_baseIndex + 2] * i_horizontal_weight);
                                i_counter_G_Horizontal += (ptr_Pointer_0_Original[i_baseIndex + 1] * i_horizontal_weight);
                                i_counter_B_Horizontal += (ptr_Pointer_0_Original[i_baseIndex] * i_horizontal_weight);

                                i_counter_R_Vertical += (ptr_Pointer_0_Original[i_baseIndex + 2] * i_vertical_weight);
                                i_counter_G_Vertical += (ptr_Pointer_0_Original[i_baseIndex + 1] * i_vertical_weight);
                                i_counter_B_Vertical += (ptr_Pointer_0_Original[i_baseIndex] * i_vertical_weight);
                            }
                        }
                        i_baseIndex = y * i_stride + x * 4;

                        double d_R_Horizontal = i_counter_R_Horizontal, d_R_Vertical = i_counter_R_Vertical,
                            d_G_Horizontal = i_counter_G_Horizontal, d_G_Vertical = i_counter_G_Vertical,
                            d_B_Horizontal = i_counter_B_Horizontal, d_B_Vertical = i_counter_B_Vertical;

                        int i_Result_R = (int)Math.Sqrt(Math.Pow(d_R_Horizontal, 2) + Math.Pow(d_R_Vertical, 2)),
                            i_Result_G = (int)Math.Sqrt(Math.Pow(d_G_Horizontal, 2) + Math.Pow(d_G_Vertical, 2)),
                            i_Result_B = (int)Math.Sqrt(Math.Pow(d_B_Horizontal, 2) + Math.Pow(d_B_Vertical, 2));

                        if (i_Result_R > 255) i_Result_R = 255;
                        else if ((i_Result_R + ptr_Pointer_0_Original[i_baseIndex + 2]) > 255) i_Result_R = 255;
                        else i_Result_R += ptr_Pointer_0_Original[i_baseIndex + 2];

                        if (i_Result_G > 255) i_Result_G = 255;
                        else if ((i_Result_G + ptr_Pointer_0_Original[i_baseIndex + 1]) > 255) i_Result_G = 255;
                        else i_Result_G += ptr_Pointer_0_Original[i_baseIndex + 1];

                        if (i_Result_B > 255) i_Result_B = 255;
                        else if ((i_Result_B + ptr_Pointer_0_Original[i_baseIndex]) > 255) i_Result_B = 255;
                        else i_Result_B += ptr_Pointer_0_Original[i_baseIndex];

                        ptr_Pointer_0_Temp[i_baseIndex + 2] = (byte)i_Result_R;   //R
                        ptr_Pointer_0_Temp[i_baseIndex + 1] = (byte)i_Result_G;   //G
                        ptr_Pointer_0_Temp[i_baseIndex] = (byte)i_Result_B;       //B
                    }
                }
                //
                bmp_TempBitmap.UnlockBits(bd_BitmapData_Temp);
                bmp_OrigImage.UnlockBits(bd_BitmapData_Original);
            }
            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }
        //historgram still have problems
        private void Histogram_Equalization_Click(object sender, EventArgs e)
        {
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData_Temp = new BitmapData();
                byte* ptr_Pointer_0_Temp;

                bd_BitmapData_Temp = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                
                ptr_Pointer_0_Temp = (byte*)bd_BitmapData_Temp.Scan0;

                int i_stride = bd_BitmapData_Temp.Stride,
                    i_height = bd_BitmapData_Temp.Height,
                    i_width = bd_BitmapData_Temp.Width;

                double d_pixelZ = bd_BitmapData_Temp.Height * bd_BitmapData_Temp.Width;

                double[] CountOfValue_R = new double[256], CountOfValue_G = new double[256], CountOfValue_B = new double[256];

                //Count the times of RGB value
                for (int y = 0; y < i_height; y++){
                    for (int x = 0; x < i_width; x++){
                        int i_baseIndex = y * i_stride + x * 4;
                        CountOfValue_R[(ptr_Pointer_0_Temp[i_baseIndex + 2])]++;
                        CountOfValue_G[(ptr_Pointer_0_Temp[i_baseIndex + 1])]++;
                        CountOfValue_B[(ptr_Pointer_0_Temp[i_baseIndex])]++;
                    }
                }
                //cda(Array)
                for (int i = 1; i < 256; i++) {
                    CountOfValue_R[i] += CountOfValue_R[i - 1];
                    CountOfValue_G[i] += CountOfValue_G[i - 1];
                    CountOfValue_B[i] += CountOfValue_B[i - 1];
                }
                //Since these array are cumulative distribution, the first non-zero value would be the minimum value of the array.
                double _d_cad_min_R = 0, _d_cad_min_G = 0, _d_cad_min_B = 0;
                int index_1st_n0_R = 256, index_1st_n0_G = 256, index_1st_n0_B = 256;

                for (int i_temp = 0; i_temp < 256; i_temp++)
                    if (CountOfValue_R[i_temp] > 0) { _d_cad_min_R = CountOfValue_R[i_temp]; index_1st_n0_R = i_temp; break; }

                for (int i_temp = 0; i_temp < 256; i_temp++)
                    if (CountOfValue_G[i_temp] > 0) { _d_cad_min_G = CountOfValue_G[i_temp]; index_1st_n0_G = i_temp; break; }

                for (int i_temp = 0; i_temp < 256; i_temp++)
                    if (CountOfValue_B[i_temp] > 0) { _d_cad_min_B = CountOfValue_B[i_temp]; index_1st_n0_B = i_temp; break; }
                //
                for (int i = index_1st_n0_R; i < 256; i++) CountOfValue_R[i] = ((CountOfValue_R[i] - _d_cad_min_R) / (d_pixelZ - _d_cad_min_R)) * 255;
                for (int i = index_1st_n0_G; i < 256; i++) CountOfValue_G[i] = ((CountOfValue_G[i] - _d_cad_min_G) / (d_pixelZ - _d_cad_min_G)) * 255;
                for (int i = index_1st_n0_B; i < 256; i++) CountOfValue_B[i] = ((CountOfValue_B[i] - _d_cad_min_B) / (d_pixelZ - _d_cad_min_B)) * 255;
                //
                for (int y = 0; y < i_height; y++){
                    for (int x = 0; x < i_width; x++){
                        int i_baseIndex = (y * i_stride + x * 4),
                            i_Value_R = ptr_Pointer_0_Temp[i_baseIndex + 2],
                            i_Value_G = ptr_Pointer_0_Temp[i_baseIndex + 1],
                            i_Value_B = ptr_Pointer_0_Temp[i_baseIndex];

                        i_Value_R = (int)(CountOfValue_R[i_Value_R]);
                        i_Value_G = (int)(CountOfValue_G[i_Value_G]);
                        i_Value_B = (int)(CountOfValue_B[i_Value_B]);

                        ptr_Pointer_0_Temp[i_baseIndex + 2] = (byte)i_Value_R;
                        ptr_Pointer_0_Temp[i_baseIndex + 1] = (byte)i_Value_G;
                        ptr_Pointer_0_Temp[i_baseIndex] = (byte)i_Value_B;
                    }
                }
                //
                bmp_TempBitmap.UnlockBits(bd_BitmapData_Temp);
            }
            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }
        private void Histogram_Equalization_Nega_Click(object sender, EventArgs e)
        {
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData_Temp = new BitmapData();
                byte* ptr_Pointer_0_Temp;

                bd_BitmapData_Temp = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);

                ptr_Pointer_0_Temp = (byte*)bd_BitmapData_Temp.Scan0;

                int i_stride = bd_BitmapData_Temp.Stride,
                    i_height = bd_BitmapData_Temp.Height,
                    i_width = bd_BitmapData_Temp.Width;

                double d_pixelZ = bd_BitmapData_Temp.Height * bd_BitmapData_Temp.Width;

                double[] CountOfValue_R = new double[256], CountOfValue_G = new double[256], CountOfValue_B = new double[256];

                //Negative proccess and count times of RBG value at same time
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_baseIndex = y * i_stride + x * 4,
                            i_Value_R_Nega = 255 - ptr_Pointer_0_Temp[i_baseIndex + 2],
                            i_Value_G_Nega = 255 - ptr_Pointer_0_Temp[i_baseIndex + 1],
                            i_Value_B_Nega = 255 - ptr_Pointer_0_Temp[i_baseIndex];

                        ptr_Pointer_0_Temp[i_baseIndex + 2] = (byte)(i_Value_R_Nega);
                        ptr_Pointer_0_Temp[i_baseIndex + 1] = (byte)(i_Value_G_Nega);
                        ptr_Pointer_0_Temp[i_baseIndex] = (byte)(i_Value_B_Nega);

                        CountOfValue_R[i_Value_R_Nega]++;
                        CountOfValue_G[i_Value_G_Nega]++;
                        CountOfValue_B[i_Value_B_Nega]++;
                    }
                }
                //cda(Array)
                for (int i = 1; i < 256; i++)
                {
                    CountOfValue_R[i] += CountOfValue_R[i - 1];
                    CountOfValue_G[i] += CountOfValue_G[i - 1];
                    CountOfValue_B[i] += CountOfValue_B[i - 1];
                }
                //Since these array are cumulative distribution, the first non-zero value would be the minimum value of the array.
                double _d_cad_min_R = 0, _d_cad_min_G = 0, _d_cad_min_B = 0;
                int index_1st_n0_R = 0, index_1st_n0_G = 0, index_1st_n0_B = 0, i_temp = 0;

                for (i_temp = 0; i_temp < 256; i_temp++)
                    if (CountOfValue_R[i_temp] > 0) { _d_cad_min_R = CountOfValue_R[i_temp]; break; }
                index_1st_n0_R = i_temp;

                for (i_temp = 0; i_temp < 256; i_temp++)
                    if (CountOfValue_G[i_temp] > 0) { _d_cad_min_G = CountOfValue_G[i_temp]; break; }
                index_1st_n0_G = i_temp;

                for (i_temp = 0; i_temp < 256; i_temp++)
                    if (CountOfValue_B[i_temp] > 0) { _d_cad_min_B = CountOfValue_B[i_temp]; break; }
                index_1st_n0_B = i_temp;
                //
                for (int i = index_1st_n0_R; i < 256; i++) CountOfValue_R[i] = ((CountOfValue_R[i] - _d_cad_min_R) / (d_pixelZ - _d_cad_min_R)) * 255;
                for (int i = index_1st_n0_G; i < 256; i++) CountOfValue_G[i] = ((CountOfValue_G[i] - _d_cad_min_G) / (d_pixelZ - _d_cad_min_G)) * 255;
                for (int i = index_1st_n0_B; i < 256; i++) CountOfValue_B[i] = ((CountOfValue_B[i] - _d_cad_min_B) / (d_pixelZ - _d_cad_min_B)) * 255;
                //
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_baseIndex = (y * i_stride + x * 4),
                            i_Value_R = ptr_Pointer_0_Temp[i_baseIndex + 2],
                            i_Value_G = ptr_Pointer_0_Temp[i_baseIndex + 1],
                            i_Value_B = ptr_Pointer_0_Temp[i_baseIndex];

                        i_Value_R = (int)(CountOfValue_R[i_Value_R]);
                        i_Value_G = (int)(CountOfValue_G[i_Value_G]);
                        i_Value_B = (int)(CountOfValue_B[i_Value_B]);

                        ptr_Pointer_0_Temp[i_baseIndex + 2] = (byte)i_Value_R;
                        ptr_Pointer_0_Temp[i_baseIndex + 1] = (byte)i_Value_G;
                        ptr_Pointer_0_Temp[i_baseIndex] = (byte)i_Value_B;
                    }
                }
                //
                bmp_TempBitmap.UnlockBits(bd_BitmapData_Temp);
            }
            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }
        //
        private void Negative_Click(object sender, EventArgs e)
        {
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData = new BitmapData();
                byte* ptr_Pointer_0;

                bd_BitmapData = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                ptr_Pointer_0 = (byte*)bd_BitmapData.Scan0;
                int i_stride = bd_BitmapData.Stride,
                    i_height = bd_BitmapData.Height,
                    i_width = bd_BitmapData.Width;
                //
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_baseIndex = y * i_stride + x * 4;

                        ptr_Pointer_0[i_baseIndex + 2] = (byte)(255 - ptr_Pointer_0[i_baseIndex + 2]);  //R
                        ptr_Pointer_0[i_baseIndex + 1] = (byte)(255 - ptr_Pointer_0[i_baseIndex + 1]);  //G
                        ptr_Pointer_0[i_baseIndex] = (byte)(255 - ptr_Pointer_0[i_baseIndex]);          //B
                    }
                }
                //
                bmp_TempBitmap.UnlockBits(bd_BitmapData);
            }
            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }
        private void K_Mean_Click(object sender, EventArgs e)
        {
            //Default number of groups is 5, split rounds is 3.
            int i_K = 5, i_SplitRounds = 3;

            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData = new BitmapData();
                byte* ptr_Pointer_0;

                bd_BitmapData = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                ptr_Pointer_0 = (byte*)bd_BitmapData.Scan0;
                int i_stride = bd_BitmapData.Stride,
                    i_height = bd_BitmapData.Height,
                    i_width = bd_BitmapData.Width;
                
                Random rng_RNG01 = new Random(Guid.NewGuid().GetHashCode());
                Group[] grp_Groups = new Group[i_K];

                //Initialize k groups with their own RGB vectors
                for (int i = 0; i < i_K; i++)
                {
                    grp_Groups[i] = new Group(rng_RNG01.Next() % 256, rng_RNG01.Next() % 256, rng_RNG01.Next() % 256);
                }

                for (int i = 0; i < i_SplitRounds; i++)
                {
                    bool b_GetSameRGBVertors = true;
                    //Clear all pixel locations
                    for (int i_temp = 0; i_temp < i_K; i_temp++) grp_Groups[i_temp].PixelLocations.Clear();

                    for (int y = 0; y < i_height; y++)
                    {
                        for (int x = 0; x < i_width; x++)
                        {
                            int i_baseIndex = y * i_stride + x * 4, i_shortestIndex = 0;
                            double d_R_Value = ptr_Pointer_0[i_baseIndex + 2], d_G_Value = ptr_Pointer_0[i_baseIndex + 1], d_B_Value = ptr_Pointer_0[i_baseIndex];

                            //count the length between this pixel's rgb vector and each group's rgb mean vectors
                            for (int j = 0; j < i_K; j++)
                            {
                                grp_Groups[j].boi = Math.Sqrt(
                                    Math.Pow((d_R_Value - grp_Groups[j].RGB_Vector[2]), 2)
                                    + Math.Pow((d_G_Value - grp_Groups[j].RGB_Vector[1]), 2)
                                    + Math.Pow((d_B_Value - grp_Groups[j].RGB_Vector[0]), 2)
                                );
                                if (grp_Groups[j].boi < grp_Groups[i_shortestIndex].boi) i_shortestIndex = j;
                            }
                            grp_Groups[i_shortestIndex].PixelLocations.Add(new int[2] { x, y });
                        }
                    }
                    //Splited in K groups

                    double[][] PassMeans = new double[i_K][];
                    for (int i_temp = 0; i_temp < i_K; i_temp++)
                    {
                        PassMeans[i_temp] = new double[3] { grp_Groups[i_temp].RGB_Vector[0], grp_Groups[i_temp].RGB_Vector[1], grp_Groups[i_temp].RGB_Vector[2] };
                    }

                    //Calculate new RGB vectors
                    for (int i_temp = 0; i_temp < i_K; i_temp++)
                    {
                        int i_Count_R = 0, i_Count_G = 0, i_Count_B = 0,
                            i_Count = grp_Groups[i_temp].PixelLocations.Count;

                        if (i_Count == 0) continue;

                        foreach (int[] _location in grp_Groups[i_temp].PixelLocations)
                        {
                            int i_baseIndex = _location[1] * i_stride + _location[0] * 4;
                            i_Count_R += ptr_Pointer_0[i_baseIndex + 2];
                            i_Count_G += ptr_Pointer_0[i_baseIndex + 1];
                            i_Count_B += ptr_Pointer_0[i_baseIndex];
                        }
                        grp_Groups[i_temp].RGB_Vector[2] = i_Count_R / i_Count;
                        grp_Groups[i_temp].RGB_Vector[1] = i_Count_G / i_Count;
                        grp_Groups[i_temp].RGB_Vector[0] = i_Count_B / i_Count;
                    }

                    //Check whether the new RGB vector = old RGB vector
                    for (int i_temp = 0; i_temp < i_K; i_temp++)
                    {
                        if (grp_Groups[i_temp].RGB_Vector[2] != PassMeans[i_temp][2]) { b_GetSameRGBVertors = false; break; }
                        else if (grp_Groups[i_temp].RGB_Vector[1] != PassMeans[i_temp][1]) { b_GetSameRGBVertors = false; break; }
                        else if (grp_Groups[i_temp].RGB_Vector[0] != PassMeans[i_temp][0]) { b_GetSameRGBVertors = false; break; }
                    }

                    if (b_GetSameRGBVertors) break;
                }
                //
                for (int i_temp = 0; i_temp < i_K; i_temp++)
                {
                    int i_Value_R = (int)(grp_Groups[i_temp].RGB_Vector[2]),
                        i_Value_G = (int)(grp_Groups[i_temp].RGB_Vector[1]),
                        i_Value_B = (int)(grp_Groups[i_temp].RGB_Vector[0]);

                    foreach (int[] _location in grp_Groups[i_temp].PixelLocations)
                    {
                        int i_baseIndex = _location[1] * i_stride + _location[0] * 4;
                        ptr_Pointer_0[i_baseIndex + 2] = (byte)i_Value_R;
                        ptr_Pointer_0[i_baseIndex + 1] = (byte)i_Value_G;
                        ptr_Pointer_0[i_baseIndex] = (byte)i_Value_B;
                    }
                }
                //
                bmp_TempBitmap.UnlockBits(bd_BitmapData);
            }
            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }
        private void Erosion_Click(object sender, EventArgs e)
        {
            Bitmap bmp_BinaryBitmap = new Bitmap(bmp_OrigImage);
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData_Temp = new BitmapData(),bd_BitmapData_Binary = new BitmapData(), bd_BitmapData_Original = new BitmapData();
                byte* ptr_Pointer_0_Temp, ptr_Pointer_0_Binary, ptr_Pointer_0_Original;

                bd_BitmapData_Temp = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                bd_BitmapData_Binary = bmp_BinaryBitmap.LockBits(new Rectangle(0, 0, bmp_BinaryBitmap.Width, bmp_BinaryBitmap.Height), ImageLockMode.ReadWrite, bmp_BinaryBitmap.PixelFormat);
                bd_BitmapData_Original = bmp_OrigImage.LockBits(new Rectangle(0, 0, bmp_OrigImage.Width, bmp_OrigImage.Height), ImageLockMode.ReadWrite, bmp_OrigImage.PixelFormat);

                ptr_Pointer_0_Temp = (byte*)bd_BitmapData_Temp.Scan0;
                ptr_Pointer_0_Binary = (byte*)bd_BitmapData_Binary.Scan0;
                ptr_Pointer_0_Original = (byte*)bd_BitmapData_Original.Scan0;

                int i_stride = bd_BitmapData_Original.Stride,
                    i_height = bd_BitmapData_Original.Height,
                    i_width = bd_BitmapData_Original.Width;

                int i_Mask_nxn = 3, i_difference = i_Mask_nxn / 2, i_Threshold = 144;
                int[][] Mask = new int[i_Mask_nxn][];
                //Initialize mask
                for (int i_temp_y = 0; i_temp_y < i_Mask_nxn; i_temp_y++)
                {
                    Mask[i_temp_y] = new int[i_Mask_nxn];
                    for (int i_temp_x = 0; i_temp_x < i_Mask_nxn; i_temp_x++) if ((i_temp_x == i_difference) ^ (i_temp_y == i_difference)) Mask[i_temp_y][i_temp_x] = 1;         
                }
                //Binarization
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_baseIndex = y * i_stride + x * 4, 
                            i_grayScale = (ptr_Pointer_0_Original[i_baseIndex + 2] + ptr_Pointer_0_Original[i_baseIndex + 1] + ptr_Pointer_0_Original[i_baseIndex]) / 3;
                        //Binarization
                        if (i_grayScale >= i_Threshold) ptr_Pointer_0_Binary[i_baseIndex + 2] = ptr_Pointer_0_Binary[i_baseIndex + 1] = ptr_Pointer_0_Binary[i_baseIndex] = 255;
                        else ptr_Pointer_0_Binary[i_baseIndex + 2] = ptr_Pointer_0_Binary[i_baseIndex + 1] = ptr_Pointer_0_Binary[i_baseIndex] = 0;
                    }
                }
                //Erosion
                for (int y = 1; y < i_height - i_difference; y++)
                {
                    for (int x = 1; x < i_width - i_difference; x++)
                    {
                        bool NeedErosion = false;
                        
                        //Mapping
                        for (int yi = y - i_difference; (yi <= y + i_difference) && (!NeedErosion); yi++)
                        {
                            if (yi < 0 || yi >= i_height) continue;
                            for (int xi = x - i_difference; xi <= x + i_difference; xi++)
                            {
                                if (xi < 0 || xi >= i_width) continue;
                                int i_baseIndex = yi * i_stride + xi * 4;

                                if ((Mask[(yi - y + 1)][xi - x + 1] == 1) && (ptr_Pointer_0_Binary[i_baseIndex] == 255))
                                {
                                    NeedErosion = true;
                                    i_baseIndex = y * i_stride + x * 4;
                                    ptr_Pointer_0_Temp[i_baseIndex + 2] = ptr_Pointer_0_Temp[i_baseIndex + 1] = ptr_Pointer_0_Temp[i_baseIndex] = 255;
                                    break;
                                }
                            }
                        }
                        //End of Mapping....
                        if (!NeedErosion) {
                            int i_baseIndex = y * i_stride + x * 4;
                            ptr_Pointer_0_Temp[i_baseIndex + 2] = ptr_Pointer_0_Binary[i_baseIndex + 2];
                            ptr_Pointer_0_Temp[i_baseIndex + 1] = ptr_Pointer_0_Binary[i_baseIndex + 1];
                            ptr_Pointer_0_Temp[i_baseIndex] = ptr_Pointer_0_Binary[i_baseIndex];
                        }
                    }
                }
                bmp_BinaryBitmap.UnlockBits(bd_BitmapData_Binary);
                bmp_TempBitmap.UnlockBits(bd_BitmapData_Temp);
                bmp_OrigImage.UnlockBits(bd_BitmapData_Original);
            }

            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }
        private void Dilation_Click(object sender, EventArgs e)
        {
            Bitmap bmp_BinaryBitmap = new Bitmap(bmp_OrigImage);
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData_Temp = new BitmapData(), bd_BitmapData_Binary = new BitmapData(), bd_BitmapData_Original = new BitmapData();
                byte* ptr_Pointer_0_Temp, ptr_Pointer_0_Binary, ptr_Pointer_0_Original;

                bd_BitmapData_Temp = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                bd_BitmapData_Binary = bmp_BinaryBitmap.LockBits(new Rectangle(0, 0, bmp_BinaryBitmap.Width, bmp_BinaryBitmap.Height), ImageLockMode.ReadWrite, bmp_BinaryBitmap.PixelFormat);
                bd_BitmapData_Original = bmp_OrigImage.LockBits(new Rectangle(0, 0, bmp_OrigImage.Width, bmp_OrigImage.Height), ImageLockMode.ReadWrite, bmp_OrigImage.PixelFormat);

                ptr_Pointer_0_Temp = (byte*)bd_BitmapData_Temp.Scan0;
                ptr_Pointer_0_Binary = (byte*)bd_BitmapData_Binary.Scan0;
                ptr_Pointer_0_Original = (byte*)bd_BitmapData_Original.Scan0;

                int i_stride = bd_BitmapData_Original.Stride,
                    i_height = bd_BitmapData_Original.Height,
                    i_width = bd_BitmapData_Original.Width;

                int i_Mask_nxn = 3, i_difference = i_Mask_nxn / 2, i_Threshold = 144;
                int[][] Mask = new int[i_Mask_nxn][];
                //Initialize mask
                for (int i_temp_y = 0; i_temp_y < i_Mask_nxn; i_temp_y++)
                {
                    Mask[i_temp_y] = new int[i_Mask_nxn];
                    for (int i_temp_x = 0; i_temp_x < i_Mask_nxn; i_temp_x++) if ((i_temp_x == i_difference) ^ (i_temp_y == i_difference)) Mask[i_temp_y][i_temp_x] = 1;
                }
                //Binarization
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_baseIndex = y * i_stride + x * 4,
                            i_grayScale = (ptr_Pointer_0_Original[i_baseIndex + 2] + ptr_Pointer_0_Original[i_baseIndex + 1] + ptr_Pointer_0_Original[i_baseIndex]) / 3;
                        //Binarization
                        if (i_grayScale >= i_Threshold) ptr_Pointer_0_Binary[i_baseIndex + 2] = ptr_Pointer_0_Binary[i_baseIndex + 1] = ptr_Pointer_0_Binary[i_baseIndex] = 255;
                        else ptr_Pointer_0_Binary[i_baseIndex + 2] = ptr_Pointer_0_Binary[i_baseIndex + 1] = ptr_Pointer_0_Binary[i_baseIndex] = 0;
                    }
                }
                //Dilation
                for (int y = 1; y < i_height - i_difference; y++)
                {
                    for (int x = 1; x < i_width - i_difference; x++)
                    {
                        bool NeedDilation = false;

                        //Mapping
                        for (int yi = y - i_difference; (yi <= y + i_difference) && (!NeedDilation); yi++)
                        {
                            if (yi < 0 || yi >= i_height) continue;
                            for (int xi = x - i_difference; xi <= x + i_difference; xi++)
                            {
                                if (xi < 0 || xi >= i_width) continue;
                                int i_baseIndex = yi * i_stride + xi * 4;

                                if ((Mask[(yi - y + 1)][xi - x + 1] == 1) && (ptr_Pointer_0_Binary[i_baseIndex] == 0))
                                {
                                    NeedDilation = true;
                                    i_baseIndex = y * i_stride + x * 4;
                                    ptr_Pointer_0_Temp[i_baseIndex + 2] = ptr_Pointer_0_Temp[i_baseIndex + 1] = ptr_Pointer_0_Temp[i_baseIndex] = 0;
                                    break;
                                }
                            }
                        }
                        //End of Mapping....
                        if (!NeedDilation)
                        {
                            int i_baseIndex = y * i_stride + x * 4;
                            ptr_Pointer_0_Temp[i_baseIndex + 2] = ptr_Pointer_0_Binary[i_baseIndex + 2];
                            ptr_Pointer_0_Temp[i_baseIndex + 1] = ptr_Pointer_0_Binary[i_baseIndex + 1];
                            ptr_Pointer_0_Temp[i_baseIndex] = ptr_Pointer_0_Binary[i_baseIndex];
                        }
                    }
                }
                bmp_BinaryBitmap.UnlockBits(bd_BitmapData_Binary);
                bmp_TempBitmap.UnlockBits(bd_BitmapData_Temp);
                bmp_OrigImage.UnlockBits(bd_BitmapData_Original);
            }

            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }
        private void Opening_Click(object sender, EventArgs e)
        {
            //Erosion First
            Bitmap bmp_BinaryBitmap = new Bitmap(bmp_OrigImage);
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            Bitmap bmp_UltimateBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData
                    bd_BitmapData_Ultimate = new BitmapData(), 
                    bd_BitmapData_Temp = new BitmapData(), 
                    bd_BitmapData_Binary = new BitmapData(), 
                    bd_BitmapData_Original = new BitmapData();

                byte* ptr_Pointer_0_Ultimate, ptr_Pointer_0_Temp, ptr_Pointer_0_Binary, ptr_Pointer_0_Original;

                bd_BitmapData_Ultimate = bmp_UltimateBitmap.LockBits(new Rectangle(0, 0, bmp_UltimateBitmap.Width, bmp_UltimateBitmap.Height), ImageLockMode.ReadWrite, bmp_UltimateBitmap.PixelFormat);
                bd_BitmapData_Temp = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                bd_BitmapData_Binary = bmp_BinaryBitmap.LockBits(new Rectangle(0, 0, bmp_BinaryBitmap.Width, bmp_BinaryBitmap.Height), ImageLockMode.ReadWrite, bmp_BinaryBitmap.PixelFormat);
                bd_BitmapData_Original = bmp_OrigImage.LockBits(new Rectangle(0, 0, bmp_OrigImage.Width, bmp_OrigImage.Height), ImageLockMode.ReadWrite, bmp_OrigImage.PixelFormat);

                ptr_Pointer_0_Ultimate = (byte*)bd_BitmapData_Ultimate.Scan0;
                ptr_Pointer_0_Temp = (byte*)bd_BitmapData_Temp.Scan0;
                ptr_Pointer_0_Binary = (byte*)bd_BitmapData_Binary.Scan0;
                ptr_Pointer_0_Original = (byte*)bd_BitmapData_Original.Scan0;

                int i_stride = bd_BitmapData_Original.Stride,
                    i_height = bd_BitmapData_Original.Height,
                    i_width = bd_BitmapData_Original.Width;

                int i_Mask_nxn = 3, i_difference = i_Mask_nxn / 2, i_Threshold = 144;
                int[][] Mask = new int[i_Mask_nxn][];
                //Initialize mask
                for (int i_temp_y = 0; i_temp_y < i_Mask_nxn; i_temp_y++)
                {
                    Mask[i_temp_y] = new int[i_Mask_nxn];
                    for (int i_temp_x = 0; i_temp_x < i_Mask_nxn; i_temp_x++) if ((i_temp_x == i_difference) ^ (i_temp_y == i_difference)) Mask[i_temp_y][i_temp_x] = 1;
                }
                //Binarization
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_baseIndex = y * i_stride + x * 4,
                            i_grayScale = (ptr_Pointer_0_Original[i_baseIndex + 2] + ptr_Pointer_0_Original[i_baseIndex + 1] + ptr_Pointer_0_Original[i_baseIndex]) / 3;
                        //Binarization
                        if (i_grayScale >= i_Threshold) ptr_Pointer_0_Binary[i_baseIndex + 2] = ptr_Pointer_0_Binary[i_baseIndex + 1] = ptr_Pointer_0_Binary[i_baseIndex] = 255;
                        else ptr_Pointer_0_Binary[i_baseIndex + 2] = ptr_Pointer_0_Binary[i_baseIndex + 1] = ptr_Pointer_0_Binary[i_baseIndex] = 0;
                    }
                }
                //Erosion
                for (int y = 1; y < i_height - i_difference; y++)
                {
                    for (int x = 1; x < i_width - i_difference; x++)
                    {
                        bool NeedErosion = false;

                        //Mapping
                        for (int yi = y - i_difference; (yi <= y + i_difference) && (!NeedErosion); yi++)
                        {
                            if (yi < 0 || yi >= i_height) continue;
                            for (int xi = x - i_difference; xi <= x + i_difference; xi++)
                            {
                                if (xi < 0 || xi >= i_width) continue;
                                int i_baseIndex = yi * i_stride + xi * 4;

                                if ((Mask[(yi - y + 1)][xi - x + 1] == 1) && (ptr_Pointer_0_Binary[i_baseIndex] == 255))
                                {
                                    NeedErosion = true;
                                    i_baseIndex = y * i_stride + x * 4;
                                    ptr_Pointer_0_Temp[i_baseIndex + 2] = ptr_Pointer_0_Temp[i_baseIndex + 1] = ptr_Pointer_0_Temp[i_baseIndex] = 255;
                                    break;
                                }
                            }
                        }
                        //End of Mapping....
                        if (!NeedErosion)
                        {
                            int i_baseIndex = y * i_stride + x * 4;
                            ptr_Pointer_0_Temp[i_baseIndex + 2] = ptr_Pointer_0_Binary[i_baseIndex + 2];
                            ptr_Pointer_0_Temp[i_baseIndex + 1] = ptr_Pointer_0_Binary[i_baseIndex + 1];
                            ptr_Pointer_0_Temp[i_baseIndex] = ptr_Pointer_0_Binary[i_baseIndex];
                        }
                    }
                }
                //Then Dilation Last
                for (int y = 1; y < i_height - i_difference; y++)
                {
                    for (int x = 1; x < i_width - i_difference; x++)
                    {
                        bool NeedDilation = false;

                        //Mapping
                        for (int yi = y - i_difference; (yi <= y + i_difference) && (!NeedDilation); yi++)
                        {
                            if (yi < 0 || yi >= i_height) continue;
                            for (int xi = x - i_difference; xi <= x + i_difference; xi++)
                            {
                                if (xi < 0 || xi >= i_width) continue;
                                int i_baseIndex = yi * i_stride + xi * 4;

                                if ((Mask[(yi - y + 1)][xi - x + 1] == 1) && (ptr_Pointer_0_Temp[i_baseIndex] == 0))
                                {
                                    NeedDilation = true;
                                    i_baseIndex = y * i_stride + x * 4;
                                    ptr_Pointer_0_Ultimate[i_baseIndex + 2] = ptr_Pointer_0_Ultimate[i_baseIndex + 1] = ptr_Pointer_0_Ultimate[i_baseIndex] = 0;
                                    break;
                                }
                            }
                        }
                        //End of Mapping....
                        if (!NeedDilation)
                        {
                            int i_baseIndex = y * i_stride + x * 4;
                            ptr_Pointer_0_Ultimate[i_baseIndex + 2] = ptr_Pointer_0_Temp[i_baseIndex + 2];
                            ptr_Pointer_0_Ultimate[i_baseIndex + 1] = ptr_Pointer_0_Temp[i_baseIndex + 1];
                            ptr_Pointer_0_Ultimate[i_baseIndex] = ptr_Pointer_0_Temp[i_baseIndex];
                        }
                    }
                }

                bmp_UltimateBitmap.UnlockBits(bd_BitmapData_Ultimate);
                bmp_BinaryBitmap.UnlockBits(bd_BitmapData_Binary);
                bmp_TempBitmap.UnlockBits(bd_BitmapData_Temp);
                bmp_OrigImage.UnlockBits(bd_BitmapData_Original);
            }

            DisplayZone.Image = bmp_UltimateBitmap;
            Histogram_R.LoadData(bmp_UltimateBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_UltimateBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_UltimateBitmap, 'B');
            Histogram_B.ShowData();
        }
        private void Closing_Click(object sender, EventArgs e)
        {
            //Dilation First
            Bitmap bmp_BinaryBitmap = new Bitmap(bmp_OrigImage);
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            Bitmap bmp_UltimateBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData
                    bd_BitmapData_Ultimate = new BitmapData(),
                    bd_BitmapData_Temp = new BitmapData(),
                    bd_BitmapData_Binary = new BitmapData(),
                    bd_BitmapData_Original = new BitmapData();

                byte* ptr_Pointer_0_Ultimate, ptr_Pointer_0_Temp, ptr_Pointer_0_Binary, ptr_Pointer_0_Original;

                bd_BitmapData_Ultimate = bmp_UltimateBitmap.LockBits(new Rectangle(0, 0, bmp_UltimateBitmap.Width, bmp_UltimateBitmap.Height), ImageLockMode.ReadWrite, bmp_UltimateBitmap.PixelFormat);
                bd_BitmapData_Temp = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                bd_BitmapData_Binary = bmp_BinaryBitmap.LockBits(new Rectangle(0, 0, bmp_BinaryBitmap.Width, bmp_BinaryBitmap.Height), ImageLockMode.ReadWrite, bmp_BinaryBitmap.PixelFormat);
                bd_BitmapData_Original = bmp_OrigImage.LockBits(new Rectangle(0, 0, bmp_OrigImage.Width, bmp_OrigImage.Height), ImageLockMode.ReadWrite, bmp_OrigImage.PixelFormat);

                ptr_Pointer_0_Ultimate = (byte*)bd_BitmapData_Ultimate.Scan0;
                ptr_Pointer_0_Temp = (byte*)bd_BitmapData_Temp.Scan0;
                ptr_Pointer_0_Binary = (byte*)bd_BitmapData_Binary.Scan0;
                ptr_Pointer_0_Original = (byte*)bd_BitmapData_Original.Scan0;

                int i_stride = bd_BitmapData_Original.Stride,
                    i_height = bd_BitmapData_Original.Height,
                    i_width = bd_BitmapData_Original.Width;

                int i_Mask_nxn = 3, i_difference = i_Mask_nxn / 2, i_Threshold = 144;
                int[][] Mask = new int[i_Mask_nxn][];
                //Initialize mask
                for (int i_temp_y = 0; i_temp_y < i_Mask_nxn; i_temp_y++)
                {
                    Mask[i_temp_y] = new int[i_Mask_nxn];
                    for (int i_temp_x = 0; i_temp_x < i_Mask_nxn; i_temp_x++) if ((i_temp_x == i_difference) ^ (i_temp_y == i_difference)) Mask[i_temp_y][i_temp_x] = 1;
                }
                //Binarization
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_baseIndex = y * i_stride + x * 4,
                            i_grayScale = (ptr_Pointer_0_Original[i_baseIndex + 2] + ptr_Pointer_0_Original[i_baseIndex + 1] + ptr_Pointer_0_Original[i_baseIndex]) / 3;
                        //Binarization
                        if (i_grayScale >= i_Threshold) ptr_Pointer_0_Binary[i_baseIndex + 2] = ptr_Pointer_0_Binary[i_baseIndex + 1] = ptr_Pointer_0_Binary[i_baseIndex] = 255;
                        else ptr_Pointer_0_Binary[i_baseIndex + 2] = ptr_Pointer_0_Binary[i_baseIndex + 1] = ptr_Pointer_0_Binary[i_baseIndex] = 0;
                    }
                }
                //Dilation
                for (int y = 1; y < i_height - i_difference; y++)
                {
                    for (int x = 1; x < i_width - i_difference; x++)
                    {
                        bool NeedDilation = false;

                        //Mapping
                        for (int yi = y - i_difference; (yi <= y + i_difference) && (!NeedDilation); yi++)
                        {
                            if (yi < 0 || yi >= i_height) continue;
                            for (int xi = x - i_difference; xi <= x + i_difference; xi++)
                            {
                                if (xi < 0 || xi >= i_width) continue;
                                int i_baseIndex = yi * i_stride + xi * 4;

                                if ((Mask[(yi - y + 1)][xi - x + 1] == 1) && (ptr_Pointer_0_Binary[i_baseIndex] == 0))
                                {
                                    NeedDilation = true;
                                    i_baseIndex = y * i_stride + x * 4;
                                    ptr_Pointer_0_Temp[i_baseIndex + 2] = ptr_Pointer_0_Temp[i_baseIndex + 1] = ptr_Pointer_0_Temp[i_baseIndex] = 0;
                                    break;
                                }
                            }
                        }
                        //End of Mapping....
                        if (!NeedDilation)
                        {
                            int i_baseIndex = y * i_stride + x * 4;
                            ptr_Pointer_0_Temp[i_baseIndex + 2] = ptr_Pointer_0_Binary[i_baseIndex + 2];
                            ptr_Pointer_0_Temp[i_baseIndex + 1] = ptr_Pointer_0_Binary[i_baseIndex + 1];
                            ptr_Pointer_0_Temp[i_baseIndex] = ptr_Pointer_0_Binary[i_baseIndex];
                        }
                    }
                }
                //Then Erosion Last
                for (int y = 1; y < i_height - i_difference; y++)
                {
                    for (int x = 1; x < i_width - i_difference; x++)
                    {
                        bool NeedErosion = false;

                        //Mapping
                        for (int yi = y - i_difference; (yi <= y + i_difference) && (!NeedErosion); yi++)
                        {
                            if (yi < 0 || yi >= i_height) continue;
                            for (int xi = x - i_difference; xi <= x + i_difference; xi++)
                            {
                                if (xi < 0 || xi >= i_width) continue;
                                int i_baseIndex = yi * i_stride + xi * 4;

                                if ((Mask[(yi - y + 1)][xi - x + 1] == 1) && (ptr_Pointer_0_Temp[i_baseIndex] == 255))
                                {
                                    NeedErosion = true;
                                    i_baseIndex = y * i_stride + x * 4;
                                    ptr_Pointer_0_Ultimate[i_baseIndex + 2] = ptr_Pointer_0_Ultimate[i_baseIndex + 1] = ptr_Pointer_0_Ultimate[i_baseIndex] = 255;
                                    break;
                                }
                            }
                        }
                        //End of Mapping....
                        if (!NeedErosion)
                        {
                            int i_baseIndex = y * i_stride + x * 4;
                            ptr_Pointer_0_Ultimate[i_baseIndex + 2] = ptr_Pointer_0_Temp[i_baseIndex + 2];
                            ptr_Pointer_0_Ultimate[i_baseIndex + 1] = ptr_Pointer_0_Temp[i_baseIndex + 1];
                            ptr_Pointer_0_Ultimate[i_baseIndex] = ptr_Pointer_0_Temp[i_baseIndex];
                        }
                    }
                }

                bmp_UltimateBitmap.UnlockBits(bd_BitmapData_Ultimate);
                bmp_BinaryBitmap.UnlockBits(bd_BitmapData_Binary);
                bmp_TempBitmap.UnlockBits(bd_BitmapData_Temp);
                bmp_OrigImage.UnlockBits(bd_BitmapData_Original);
            }

            DisplayZone.Image = bmp_UltimateBitmap;
            Histogram_R.LoadData(bmp_UltimateBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_UltimateBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_UltimateBitmap, 'B');
            Histogram_B.ShowData();
        }

        private void Gamma_Click(object sender, EventArgs e)
        {
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData = new BitmapData();
                byte* ptr_Pointer_0;

                bd_BitmapData = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                ptr_Pointer_0 = (byte*)bd_BitmapData.Scan0;

                int i_stride = bd_BitmapData.Stride,
                    i_height = bd_BitmapData.Height,
                    i_width = bd_BitmapData.Width;

                double 
                    Gamma = 0.5, 
                    exp = (1 / Gamma);

                //
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_baseIndex = y * i_stride + x * 4;

                        ptr_Pointer_0[i_baseIndex + 2] = (byte)(int)(Math.Pow((((double)ptr_Pointer_0[i_baseIndex + 2] + 0.5) / 256), exp) * 256 - 0.5);
                        ptr_Pointer_0[i_baseIndex + 1] = (byte)(int)(Math.Pow((((double)ptr_Pointer_0[i_baseIndex + 1] + 0.5) / 256), exp) * 256 - 0.5);
                        ptr_Pointer_0[i_baseIndex] = (byte)(int)(Math.Pow((((double)ptr_Pointer_0[i_baseIndex] + 0.5) / 256), exp) * 256 - 0.5);
                    }
                }
                //
                bmp_TempBitmap.UnlockBits(bd_BitmapData);
            }
            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }
        private void HOGU_Click(object sender, EventArgs e)
        {
            Bitmap bmp_TempBitmap = new Bitmap(bmp_OrigImage), bmp_GrayBitmap = new Bitmap(bmp_OrigImage);
            unsafe
            {
                BitmapData bd_BitmapData_Temp = new BitmapData(), bd_BitmapData_Gray = new BitmapData(), bd_BitmapData_Original = new BitmapData();
                byte* ptr_Pointer_0_Temp, ptr_Pointer_0_Gray, ptr_Pointer_0_Original;

                bd_BitmapData_Temp = bmp_TempBitmap.LockBits(new Rectangle(0, 0, bmp_TempBitmap.Width, bmp_TempBitmap.Height), ImageLockMode.ReadWrite, bmp_TempBitmap.PixelFormat);
                bd_BitmapData_Gray = bmp_GrayBitmap.LockBits(new Rectangle(0, 0, bmp_GrayBitmap.Width, bmp_GrayBitmap.Height), ImageLockMode.ReadWrite, bmp_GrayBitmap.PixelFormat);
                bd_BitmapData_Original = bmp_OrigImage.LockBits(new Rectangle(0, 0, bmp_OrigImage.Width, bmp_OrigImage.Height), ImageLockMode.ReadWrite, bmp_OrigImage.PixelFormat);

                ptr_Pointer_0_Temp = (byte*)bd_BitmapData_Temp.Scan0;
                ptr_Pointer_0_Gray = (byte*)bd_BitmapData_Gray.Scan0;
                ptr_Pointer_0_Original = (byte*)bd_BitmapData_Original.Scan0;

                int i_stride = bd_BitmapData_Original.Stride,
                    i_height = bd_BitmapData_Original.Height,
                    i_width = bd_BitmapData_Original.Width;
                //
                int[] Vertical_WeightS = { -1,0,1,
                                           -1,0,1,
                                           -1,0,1},
                     Horizontal_WeightS = { -1,-1,-1,
                                              0,0,0,
                                              1,1,1};

                int[] HO_Theta = new int[9];
                double d_pixelZ = (i_width - 2) * (i_height - 2);
                double[][] ThetaArray = new double[i_height][];
                for (int i = 0; i < i_height; i++) ThetaArray[i] = new double[i_width];

                //Gray Scale
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_baseIndex = y * i_stride + x * 4,
                            i_grayScaleValue =
                            (int)((double)ptr_Pointer_0_Original[i_baseIndex + 2] * 0.299
                            + (double)ptr_Pointer_0_Original[i_baseIndex + 1] * 0.587
                            + (double)ptr_Pointer_0_Original[i_baseIndex] * 0.114);

                        ptr_Pointer_0_Gray[i_baseIndex + 2] = ptr_Pointer_0_Gray[i_baseIndex + 1] = ptr_Pointer_0_Gray[i_baseIndex] = (byte)i_grayScaleValue;
                    }
                }
                //Gamma
                double
                   Gamma = 0.5,
                   exp = (1 / Gamma);
                for (int y = 0; y < i_height; y++)
                {
                    for (int x = 0; x < i_width; x++)
                    {
                        int i_baseIndex = y * i_stride + x * 4;

                        ptr_Pointer_0_Gray[i_baseIndex + 2] = (byte)(int)(Math.Pow((((double)ptr_Pointer_0_Gray[i_baseIndex + 2] + 0.5) / 256), exp) * 256 - 0.5);
                        ptr_Pointer_0_Gray[i_baseIndex + 1] = (byte)(int)(Math.Pow((((double)ptr_Pointer_0_Gray[i_baseIndex + 1] + 0.5) / 256), exp) * 256 - 0.5);
                        ptr_Pointer_0_Gray[i_baseIndex] = (byte)(int)(Math.Pow((((double)ptr_Pointer_0_Gray[i_baseIndex] + 0.5) / 256), exp) * 256 - 0.5);
                    }
                }
                //Get thetas
                for (int y = 1; y < i_height - 1; y++)
                {
                    for (int x = 1; x < i_width - 1; x++)
                    {
                        int i_counter_Horizontal = 0,
                            i_counter_Vertical = 0,
                            i_baseIndex = 0;

                        //Mapping
                        for (int yi = y - 1; yi <= y + 1; yi++)
                        {
                            if (yi < 0 || yi >= i_height) continue;
                            for (int xi = x - 1; xi <= x + 1; xi++)
                            {
                                if (xi < 0 || xi >= i_width) continue;

                                i_baseIndex = yi * i_stride + xi * 4;
                                int i_horizontal_weight = Horizontal_WeightS[(yi - y + 1) * 3 + xi - x + 1],
                                    i_vertical_weight = Vertical_WeightS[(yi - y + 1) * 3 + xi - x + 1];

                                i_counter_Horizontal += (ptr_Pointer_0_Gray[i_baseIndex] * i_horizontal_weight);

                                i_counter_Vertical += (ptr_Pointer_0_Gray[i_baseIndex] * i_vertical_weight);
                            }
                        }
                        //End of Mapping

                        if (i_counter_Horizontal == 0)
                        {
                            if (i_counter_Vertical > 0) ThetaArray[y][x] = 90;
                            else if (i_counter_Vertical == 0) ThetaArray[y][x] = 0;
                            else ThetaArray[y][x] = -90;
                        }
                        else ThetaArray[y][x] = Math.Atan((double)i_counter_Vertical / (double)i_counter_Horizontal) / Math.PI * 180;
                    }
                }
                //End off Get thetas

                //uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu

                //count number of theta's
                for (int y = 1; y < i_height - 1; y++)
                    for (int x = 1; x < i_width - 1; x++) HO_Theta[((int)(ThetaArray[y][x] + 90) / 20) % 9]++;

                //cda                
                for (int i_temp = 1; i_temp < 9; i_temp++)
                    HO_Theta[i_temp] += HO_Theta[i_temp - 1];

                //find the minimum(first non-zero) value
                int _index_1st_n0 = 9, _i_cda_min = 0;
                for (int i_temp = 0; i_temp < 9; i_temp++)
                    if (HO_Theta[i_temp] > 0) { _i_cda_min = HO_Theta[i_temp]; _index_1st_n0 = i_temp; break; }

                for (int i_temp = _index_1st_n0; i_temp < 9; i_temp++)
                    HO_Theta[i_temp] = (int)(((double)(HO_Theta[i_temp] - _i_cda_min) / (double)(d_pixelZ - _i_cda_min)) * 255);

                //Final process
                for (int y = 1; y < i_height - 1; y++)
                {
                    for (int x = 1; x < i_width - 1; x++)
                    {
                        int i_baseIndex = y * i_stride + x * 4;
                        ptr_Pointer_0_Temp[i_baseIndex + 2] = ptr_Pointer_0_Temp[i_baseIndex + 1] = ptr_Pointer_0_Temp[i_baseIndex] = (byte)HO_Theta[((int)(ThetaArray[y][x] + 90) / 20) % 9];
                    }
                }
                //
                bmp_TempBitmap.UnlockBits(bd_BitmapData_Temp);
                bmp_GrayBitmap.UnlockBits(bd_BitmapData_Gray);
                bmp_OrigImage.UnlockBits(bd_BitmapData_Original);
            }

            DisplayZone.Image = bmp_TempBitmap;
            Histogram_R.LoadData(bmp_TempBitmap, 'R');
            Histogram_R.ShowData();
            Histogram_G.LoadData(bmp_TempBitmap, 'G');
            Histogram_G.ShowData();
            Histogram_B.LoadData(bmp_TempBitmap, 'B');
            Histogram_B.ShowData();
        }
        //Not important stuff
        private void ImageProcessMachine_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                g.DrawRectangle(new Pen(Color.FromArgb(100, 100, 100), 1), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //HOGU
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            HOGU.BackColor = Color.Moccasin;
        }
        private void pictureBox1_MouseLeave_1(object sender, EventArgs e)
        {
            HOGU.BackColor = Color.Transparent;
        }
        private void HOGU_MouseDown(object sender, MouseEventArgs e)
        {
            HOGU.BackColor = Color.LightCoral;
        }
        private void HOGU_MouseUp(object sender, MouseEventArgs e)
        {
            HOGU.BackColor = Color.Transparent;
        }
        private void HOGU_MouseMove(object sender, MouseEventArgs e)
        {
            HOGU.BackColor = Color.Moccasin;
        }
    }
}
public class Group
{
    //member variable
    public double[] RGB_Vector = new double[3];             //This group's location in N dimension
    public double boi = 0;                                  //Used to store not important values
    public List<int[]> PixelLocations = new List<int[]>();  //To record which pixel belong this group

    public Group(double _r = 0, double _g = 0, double _b = 0)
    {
        RGB_Vector[2] = _r;
        RGB_Vector[1] = _g;
        RGB_Vector[0] = _b;
    }
}