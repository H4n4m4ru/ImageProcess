namespace ImageProcess
{
    partial class ImageProcessMachine
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Dialog_loadImages = new System.Windows.Forms.OpenFileDialog();
            this.LoadImages = new System.Windows.Forms.Button();
            this.Gray_Scale_Average = new System.Windows.Forms.Button();
            this.Mean_Filter = new System.Windows.Forms.Button();
            this.Weighted_Filter = new System.Windows.Forms.Button();
            this.Median_Filter = new System.Windows.Forms.Button();
            this.SaveImages = new System.Windows.Forms.Button();
            this.Dialog_saveImages = new System.Windows.Forms.SaveFileDialog();
            this.Sobel = new System.Windows.Forms.Button();
            this.Laplacian = new System.Windows.Forms.Button();
            this.Shape_Laplacian = new System.Windows.Forms.Button();
            this.Shape_Sobel = new System.Windows.Forms.Button();
            this.Histogram_Equalization = new System.Windows.Forms.Button();
            this.Negative = new System.Windows.Forms.Button();
            this.Histogram_Equalization_Nega = new System.Windows.Forms.Button();
            this.K_Mean = new System.Windows.Forms.Button();
            this.Erosion = new System.Windows.Forms.Button();
            this.Dilation = new System.Windows.Forms.Button();
            this.Opening = new System.Windows.Forms.Button();
            this.Closing_process = new System.Windows.Forms.Button();
            this.HOGU = new System.Windows.Forms.PictureBox();
            this.DisplayZone_02 = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.PictureBox();
            this.DisplayZone = new System.Windows.Forms.PictureBox();
            this.Gamma = new System.Windows.Forms.Button();
            this.Histogram_B = new ImageProcess.HanaHistogram();
            this.Histogram_G = new ImageProcess.HanaHistogram();
            this.Histogram_R = new ImageProcess.HanaHistogram();
            ((System.ComponentModel.ISupportInitialize)(this.HOGU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayZone_02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayZone)).BeginInit();
            this.SuspendLayout();
            // 
            // Dialog_loadImages
            // 
            this.Dialog_loadImages.FileName = "openFileDialog1";
            // 
            // LoadImages
            // 
            this.LoadImages.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.LoadImages.FlatAppearance.BorderSize = 2;
            this.LoadImages.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.LoadImages.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOliveGreen;
            this.LoadImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadImages.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadImages.ForeColor = System.Drawing.Color.GreenYellow;
            this.LoadImages.Location = new System.Drawing.Point(909, 690);
            this.LoadImages.Name = "LoadImages";
            this.LoadImages.Size = new System.Drawing.Size(400, 25);
            this.LoadImages.TabIndex = 1;
            this.LoadImages.Text = "Load image";
            this.LoadImages.UseVisualStyleBackColor = true;
            this.LoadImages.Click += new System.EventHandler(this.LoadImages_Click);
            // 
            // Gray_Scale_Average
            // 
            this.Gray_Scale_Average.Enabled = false;
            this.Gray_Scale_Average.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.Gray_Scale_Average.FlatAppearance.BorderSize = 2;
            this.Gray_Scale_Average.FlatAppearance.MouseDownBackColor = System.Drawing.Color.GreenYellow;
            this.Gray_Scale_Average.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LavenderBlush;
            this.Gray_Scale_Average.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gray_Scale_Average.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gray_Scale_Average.ForeColor = System.Drawing.Color.Crimson;
            this.Gray_Scale_Average.Location = new System.Drawing.Point(908, 12);
            this.Gray_Scale_Average.Name = "Gray_Scale_Average";
            this.Gray_Scale_Average.Size = new System.Drawing.Size(75, 25);
            this.Gray_Scale_Average.TabIndex = 2;
            this.Gray_Scale_Average.Text = "Average";
            this.Gray_Scale_Average.UseVisualStyleBackColor = true;
            this.Gray_Scale_Average.Click += new System.EventHandler(this.Gray_Scale_Click);
            // 
            // Mean_Filter
            // 
            this.Mean_Filter.Enabled = false;
            this.Mean_Filter.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.Mean_Filter.FlatAppearance.BorderSize = 2;
            this.Mean_Filter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Fuchsia;
            this.Mean_Filter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite;
            this.Mean_Filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Mean_Filter.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mean_Filter.ForeColor = System.Drawing.Color.MediumPurple;
            this.Mean_Filter.Location = new System.Drawing.Point(989, 12);
            this.Mean_Filter.Name = "Mean_Filter";
            this.Mean_Filter.Size = new System.Drawing.Size(96, 25);
            this.Mean_Filter.TabIndex = 5;
            this.Mean_Filter.Text = "Mean Filter";
            this.Mean_Filter.UseVisualStyleBackColor = true;
            this.Mean_Filter.Click += new System.EventHandler(this.Mean_Filter_Click);
            // 
            // Weighted_Filter
            // 
            this.Weighted_Filter.Enabled = false;
            this.Weighted_Filter.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.Weighted_Filter.FlatAppearance.BorderSize = 2;
            this.Weighted_Filter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Fuchsia;
            this.Weighted_Filter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite;
            this.Weighted_Filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Weighted_Filter.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Weighted_Filter.ForeColor = System.Drawing.Color.MediumPurple;
            this.Weighted_Filter.Location = new System.Drawing.Point(1091, 12);
            this.Weighted_Filter.Name = "Weighted_Filter";
            this.Weighted_Filter.Size = new System.Drawing.Size(124, 25);
            this.Weighted_Filter.TabIndex = 7;
            this.Weighted_Filter.Text = "Weighted Filter";
            this.Weighted_Filter.UseVisualStyleBackColor = true;
            this.Weighted_Filter.Click += new System.EventHandler(this.Weighted_Filter_Click);
            // 
            // Median_Filter
            // 
            this.Median_Filter.Enabled = false;
            this.Median_Filter.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.Median_Filter.FlatAppearance.BorderSize = 2;
            this.Median_Filter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Fuchsia;
            this.Median_Filter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite;
            this.Median_Filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Median_Filter.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Median_Filter.ForeColor = System.Drawing.Color.MediumPurple;
            this.Median_Filter.Location = new System.Drawing.Point(1221, 12);
            this.Median_Filter.Name = "Median_Filter";
            this.Median_Filter.Size = new System.Drawing.Size(112, 24);
            this.Median_Filter.TabIndex = 8;
            this.Median_Filter.Text = "Median Filter";
            this.Median_Filter.UseVisualStyleBackColor = true;
            this.Median_Filter.Click += new System.EventHandler(this.Median_Filter_Click);
            // 
            // SaveImages
            // 
            this.SaveImages.Enabled = false;
            this.SaveImages.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.SaveImages.FlatAppearance.BorderSize = 2;
            this.SaveImages.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.SaveImages.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOliveGreen;
            this.SaveImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveImages.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveImages.ForeColor = System.Drawing.Color.GreenYellow;
            this.SaveImages.Location = new System.Drawing.Point(909, 724);
            this.SaveImages.Name = "SaveImages";
            this.SaveImages.Size = new System.Drawing.Size(400, 25);
            this.SaveImages.TabIndex = 9;
            this.SaveImages.Text = "Save image";
            this.SaveImages.UseVisualStyleBackColor = true;
            this.SaveImages.Click += new System.EventHandler(this.SaveImages_Click);
            // 
            // Sobel
            // 
            this.Sobel.Enabled = false;
            this.Sobel.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.Sobel.FlatAppearance.BorderSize = 2;
            this.Sobel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Navy;
            this.Sobel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PapayaWhip;
            this.Sobel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sobel.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sobel.ForeColor = System.Drawing.Color.Orange;
            this.Sobel.Location = new System.Drawing.Point(908, 43);
            this.Sobel.Name = "Sobel";
            this.Sobel.Size = new System.Drawing.Size(54, 25);
            this.Sobel.TabIndex = 10;
            this.Sobel.Text = "Sobel";
            this.Sobel.UseVisualStyleBackColor = true;
            this.Sobel.Click += new System.EventHandler(this.Sobel_Click);
            // 
            // Laplacian
            // 
            this.Laplacian.Enabled = false;
            this.Laplacian.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.Laplacian.FlatAppearance.BorderSize = 2;
            this.Laplacian.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Navy;
            this.Laplacian.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PapayaWhip;
            this.Laplacian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Laplacian.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Laplacian.ForeColor = System.Drawing.Color.Orange;
            this.Laplacian.Location = new System.Drawing.Point(968, 43);
            this.Laplacian.Name = "Laplacian";
            this.Laplacian.Size = new System.Drawing.Size(92, 25);
            this.Laplacian.TabIndex = 11;
            this.Laplacian.Text = "Laplacian";
            this.Laplacian.UseVisualStyleBackColor = true;
            this.Laplacian.Click += new System.EventHandler(this.Laplacian_Click);
            // 
            // Shape_Laplacian
            // 
            this.Shape_Laplacian.Enabled = false;
            this.Shape_Laplacian.FlatAppearance.BorderColor = System.Drawing.Color.MediumAquamarine;
            this.Shape_Laplacian.FlatAppearance.BorderSize = 2;
            this.Shape_Laplacian.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.Shape_Laplacian.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.Shape_Laplacian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Shape_Laplacian.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shape_Laplacian.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.Shape_Laplacian.Location = new System.Drawing.Point(1177, 43);
            this.Shape_Laplacian.Name = "Shape_Laplacian";
            this.Shape_Laplacian.Size = new System.Drawing.Size(131, 25);
            this.Shape_Laplacian.TabIndex = 12;
            this.Shape_Laplacian.Text = "Shape_Laplacian";
            this.Shape_Laplacian.UseVisualStyleBackColor = true;
            this.Shape_Laplacian.Click += new System.EventHandler(this.Shape_Click);
            // 
            // Shape_Sobel
            // 
            this.Shape_Sobel.Enabled = false;
            this.Shape_Sobel.FlatAppearance.BorderColor = System.Drawing.Color.MediumAquamarine;
            this.Shape_Sobel.FlatAppearance.BorderSize = 2;
            this.Shape_Sobel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.Shape_Sobel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.Shape_Sobel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Shape_Sobel.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shape_Sobel.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.Shape_Sobel.Location = new System.Drawing.Point(1066, 43);
            this.Shape_Sobel.Name = "Shape_Sobel";
            this.Shape_Sobel.Size = new System.Drawing.Size(107, 25);
            this.Shape_Sobel.TabIndex = 13;
            this.Shape_Sobel.Text = "Shape_Sobel";
            this.Shape_Sobel.UseVisualStyleBackColor = true;
            this.Shape_Sobel.Click += new System.EventHandler(this.Shape_Sobel_Click);
            // 
            // Histogram_Equalization
            // 
            this.Histogram_Equalization.Enabled = false;
            this.Histogram_Equalization.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.Histogram_Equalization.FlatAppearance.BorderSize = 2;
            this.Histogram_Equalization.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.Histogram_Equalization.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleVioletRed;
            this.Histogram_Equalization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Histogram_Equalization.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Histogram_Equalization.ForeColor = System.Drawing.Color.Pink;
            this.Histogram_Equalization.Location = new System.Drawing.Point(908, 74);
            this.Histogram_Equalization.Name = "Histogram_Equalization";
            this.Histogram_Equalization.Size = new System.Drawing.Size(189, 25);
            this.Histogram_Equalization.TabIndex = 15;
            this.Histogram_Equalization.Text = "Histogram_Equalization";
            this.Histogram_Equalization.UseVisualStyleBackColor = true;
            this.Histogram_Equalization.Click += new System.EventHandler(this.Histogram_Equalization_Click);
            // 
            // Negative
            // 
            this.Negative.Enabled = false;
            this.Negative.FlatAppearance.BorderColor = System.Drawing.SystemColors.ScrollBar;
            this.Negative.FlatAppearance.BorderSize = 2;
            this.Negative.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Negative.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Negative.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Negative.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Negative.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.Negative.Location = new System.Drawing.Point(908, 105);
            this.Negative.Name = "Negative";
            this.Negative.Size = new System.Drawing.Size(93, 25);
            this.Negative.TabIndex = 16;
            this.Negative.Text = "Negative";
            this.Negative.UseVisualStyleBackColor = true;
            this.Negative.Click += new System.EventHandler(this.Negative_Click);
            // 
            // Histogram_Equalization_Nega
            // 
            this.Histogram_Equalization_Nega.Enabled = false;
            this.Histogram_Equalization_Nega.FlatAppearance.BorderColor = System.Drawing.Color.Pink;
            this.Histogram_Equalization_Nega.FlatAppearance.BorderSize = 2;
            this.Histogram_Equalization_Nega.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.Histogram_Equalization_Nega.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleVioletRed;
            this.Histogram_Equalization_Nega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Histogram_Equalization_Nega.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Histogram_Equalization_Nega.ForeColor = System.Drawing.Color.Pink;
            this.Histogram_Equalization_Nega.Location = new System.Drawing.Point(1103, 74);
            this.Histogram_Equalization_Nega.Name = "Histogram_Equalization_Nega";
            this.Histogram_Equalization_Nega.Size = new System.Drawing.Size(206, 25);
            this.Histogram_Equalization_Nega.TabIndex = 17;
            this.Histogram_Equalization_Nega.Text = "Histogram Equalization(N)";
            this.Histogram_Equalization_Nega.UseVisualStyleBackColor = true;
            this.Histogram_Equalization_Nega.Click += new System.EventHandler(this.Histogram_Equalization_Nega_Click);
            // 
            // K_Mean
            // 
            this.K_Mean.Enabled = false;
            this.K_Mean.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
            this.K_Mean.FlatAppearance.BorderSize = 2;
            this.K_Mean.FlatAppearance.MouseDownBackColor = System.Drawing.Color.GreenYellow;
            this.K_Mean.FlatAppearance.MouseOverBackColor = System.Drawing.Color.HotPink;
            this.K_Mean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.K_Mean.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.K_Mean.ForeColor = System.Drawing.Color.Purple;
            this.K_Mean.Location = new System.Drawing.Point(1007, 105);
            this.K_Mean.Name = "K_Mean";
            this.K_Mean.Size = new System.Drawing.Size(78, 25);
            this.K_Mean.TabIndex = 18;
            this.K_Mean.Text = "K-Mean";
            this.K_Mean.UseVisualStyleBackColor = true;
            this.K_Mean.Click += new System.EventHandler(this.K_Mean_Click);
            // 
            // Erosion
            // 
            this.Erosion.Enabled = false;
            this.Erosion.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.Erosion.FlatAppearance.BorderSize = 2;
            this.Erosion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.Erosion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.Erosion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Erosion.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Erosion.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Erosion.Location = new System.Drawing.Point(1095, 105);
            this.Erosion.Name = "Erosion";
            this.Erosion.Size = new System.Drawing.Size(78, 25);
            this.Erosion.TabIndex = 19;
            this.Erosion.Text = "Erosion";
            this.Erosion.UseVisualStyleBackColor = true;
            this.Erosion.Click += new System.EventHandler(this.Erosion_Click);
            // 
            // Dilation
            // 
            this.Dilation.Enabled = false;
            this.Dilation.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.Dilation.FlatAppearance.BorderSize = 2;
            this.Dilation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.Dilation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.Dilation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Dilation.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dilation.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Dilation.Location = new System.Drawing.Point(1179, 105);
            this.Dilation.Name = "Dilation";
            this.Dilation.Size = new System.Drawing.Size(78, 25);
            this.Dilation.TabIndex = 20;
            this.Dilation.Text = "Dilation";
            this.Dilation.UseVisualStyleBackColor = true;
            this.Dilation.Click += new System.EventHandler(this.Dilation_Click);
            // 
            // Opening
            // 
            this.Opening.Enabled = false;
            this.Opening.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.Opening.FlatAppearance.BorderSize = 2;
            this.Opening.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.Opening.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.Opening.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Opening.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Opening.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Opening.Location = new System.Drawing.Point(908, 136);
            this.Opening.Name = "Opening";
            this.Opening.Size = new System.Drawing.Size(78, 25);
            this.Opening.TabIndex = 21;
            this.Opening.Text = "Opening";
            this.Opening.UseVisualStyleBackColor = true;
            this.Opening.Click += new System.EventHandler(this.Opening_Click);
            // 
            // Closing_process
            // 
            this.Closing_process.Enabled = false;
            this.Closing_process.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.Closing_process.FlatAppearance.BorderSize = 2;
            this.Closing_process.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.Closing_process.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.Closing_process.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Closing_process.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Closing_process.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Closing_process.Location = new System.Drawing.Point(992, 136);
            this.Closing_process.Name = "Closing_process";
            this.Closing_process.Size = new System.Drawing.Size(78, 25);
            this.Closing_process.TabIndex = 22;
            this.Closing_process.Text = "Closing";
            this.Closing_process.UseVisualStyleBackColor = true;
            this.Closing_process.Click += new System.EventHandler(this.Closing_Click);
            // 
            // HOGU
            // 
            this.HOGU.BackColor = System.Drawing.Color.Transparent;
            this.HOGU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HOGU.Enabled = false;
            this.HOGU.Image = global::ImageProcess.Properties.Resources.ac03549588dd016;
            this.HOGU.Location = new System.Drawing.Point(1266, 109);
            this.HOGU.Name = "HOGU";
            this.HOGU.Size = new System.Drawing.Size(47, 50);
            this.HOGU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HOGU.TabIndex = 23;
            this.HOGU.TabStop = false;
            this.HOGU.Click += new System.EventHandler(this.HOGU_Click);
            this.HOGU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HOGU_MouseDown);
            this.HOGU.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.HOGU.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave_1);
            this.HOGU.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HOGU_MouseMove);
            this.HOGU.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HOGU_MouseUp);
            // 
            // DisplayZone_02
            // 
            this.DisplayZone_02.BackColor = System.Drawing.Color.Transparent;
            this.DisplayZone_02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DisplayZone_02.Location = new System.Drawing.Point(12, 12);
            this.DisplayZone_02.Name = "DisplayZone_02";
            this.DisplayZone_02.Size = new System.Drawing.Size(441, 441);
            this.DisplayZone_02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DisplayZone_02.TabIndex = 14;
            this.DisplayZone_02.TabStop = false;
            // 
            // ExitButton
            // 
            this.ExitButton.Image = global::ImageProcess.Properties.Resources._5845cd230b2a3b54fdbaecf7;
            this.ExitButton.Location = new System.Drawing.Point(1314, 730);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(25, 25);
            this.ExitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ExitButton.TabIndex = 4;
            this.ExitButton.TabStop = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // DisplayZone
            // 
            this.DisplayZone.BackColor = System.Drawing.Color.Transparent;
            this.DisplayZone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DisplayZone.Location = new System.Drawing.Point(460, 12);
            this.DisplayZone.Name = "DisplayZone";
            this.DisplayZone.Size = new System.Drawing.Size(441, 441);
            this.DisplayZone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DisplayZone.TabIndex = 0;
            this.DisplayZone.TabStop = false;
            this.DisplayZone.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.DisplayZone.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.DisplayZone.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.DisplayZone.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Gamma
            // 
            this.Gamma.Enabled = false;
            this.Gamma.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.Gamma.FlatAppearance.BorderSize = 2;
            this.Gamma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.Gamma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.Gamma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gamma.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gamma.ForeColor = System.Drawing.Color.DarkOrange;
            this.Gamma.Location = new System.Drawing.Point(1076, 136);
            this.Gamma.Name = "Gamma";
            this.Gamma.Size = new System.Drawing.Size(78, 25);
            this.Gamma.TabIndex = 27;
            this.Gamma.Text = "Gamma";
            this.Gamma.UseVisualStyleBackColor = true;
            this.Gamma.Click += new System.EventHandler(this.Gamma_Click);
            // 
            // Histogram_B
            // 
            this.Histogram_B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.Histogram_B.Bar_Color = System.Drawing.Color.DarkSlateBlue;
            this.Histogram_B.Bar_Height = 270;
            this.Histogram_B.Bar_Space = 1;
            this.Histogram_B.Bar_Width = 1;
            this.Histogram_B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Histogram_B.BottomSpace = 10;
            this.Histogram_B.Enhance = 1D;
            this.Histogram_B.Interval = 0;
            this.Histogram_B.LeftSpace = 10;
            this.Histogram_B.Line_Color = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.Histogram_B.LineSize = 5;
            this.Histogram_B.Location = new System.Drawing.Point(611, 459);
            this.Histogram_B.Name = "Histogram_B";
            this.Histogram_B.RightSpace = 10;
            this.Histogram_B.Size = new System.Drawing.Size(290, 290);
            this.Histogram_B.TabIndex = 26;
            this.Histogram_B.Text_Color = System.Drawing.Color.White;
            this.Histogram_B.TextFont = new System.Drawing.Font("Arial", 8F);
            this.Histogram_B.TopSpace = 5;
            // 
            // Histogram_G
            // 
            this.Histogram_G.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.Histogram_G.Bar_Color = System.Drawing.Color.GreenYellow;
            this.Histogram_G.Bar_Height = 270;
            this.Histogram_G.Bar_Space = 1;
            this.Histogram_G.Bar_Width = 1;
            this.Histogram_G.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Histogram_G.BottomSpace = 10;
            this.Histogram_G.Enhance = 1D;
            this.Histogram_G.Interval = 0;
            this.Histogram_G.LeftSpace = 10;
            this.Histogram_G.Line_Color = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.Histogram_G.LineSize = 5;
            this.Histogram_G.Location = new System.Drawing.Point(311, 459);
            this.Histogram_G.Name = "Histogram_G";
            this.Histogram_G.RightSpace = 10;
            this.Histogram_G.Size = new System.Drawing.Size(290, 290);
            this.Histogram_G.TabIndex = 25;
            this.Histogram_G.Text_Color = System.Drawing.Color.White;
            this.Histogram_G.TextFont = new System.Drawing.Font("Arial", 8F);
            this.Histogram_G.TopSpace = 5;
            // 
            // Histogram_R
            // 
            this.Histogram_R.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.Histogram_R.Bar_Color = System.Drawing.Color.Crimson;
            this.Histogram_R.Bar_Height = 270;
            this.Histogram_R.Bar_Space = 1;
            this.Histogram_R.Bar_Width = 1;
            this.Histogram_R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Histogram_R.BottomSpace = 10;
            this.Histogram_R.Enhance = 1D;
            this.Histogram_R.Interval = 0;
            this.Histogram_R.LeftSpace = 10;
            this.Histogram_R.Line_Color = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.Histogram_R.LineSize = 5;
            this.Histogram_R.Location = new System.Drawing.Point(12, 459);
            this.Histogram_R.Name = "Histogram_R";
            this.Histogram_R.RightSpace = 10;
            this.Histogram_R.Size = new System.Drawing.Size(290, 290);
            this.Histogram_R.TabIndex = 24;
            this.Histogram_R.Text_Color = System.Drawing.Color.White;
            this.Histogram_R.TextFont = new System.Drawing.Font("Arial", 8F);
            this.Histogram_R.TopSpace = 5;
            // 
            // ImageProcessMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(1339, 753);
            this.Controls.Add(this.Gamma);
            this.Controls.Add(this.Histogram_B);
            this.Controls.Add(this.Histogram_G);
            this.Controls.Add(this.Histogram_R);
            this.Controls.Add(this.HOGU);
            this.Controls.Add(this.Closing_process);
            this.Controls.Add(this.Opening);
            this.Controls.Add(this.Dilation);
            this.Controls.Add(this.Erosion);
            this.Controls.Add(this.K_Mean);
            this.Controls.Add(this.Histogram_Equalization_Nega);
            this.Controls.Add(this.Negative);
            this.Controls.Add(this.Histogram_Equalization);
            this.Controls.Add(this.DisplayZone_02);
            this.Controls.Add(this.Shape_Sobel);
            this.Controls.Add(this.Shape_Laplacian);
            this.Controls.Add(this.Laplacian);
            this.Controls.Add(this.Sobel);
            this.Controls.Add(this.SaveImages);
            this.Controls.Add(this.Median_Filter);
            this.Controls.Add(this.Weighted_Filter);
            this.Controls.Add(this.Mean_Filter);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.Gray_Scale_Average);
            this.Controls.Add(this.LoadImages);
            this.Controls.Add(this.DisplayZone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImageProcessMachine";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageProcessMachine_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseLeave += new System.EventHandler(this.ImageProcessMachine_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageProcessMachine_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageProcessMachine_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.HOGU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayZone_02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayZone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DisplayZone;
        private System.Windows.Forms.OpenFileDialog Dialog_loadImages;
        private System.Windows.Forms.Button LoadImages;
        private System.Windows.Forms.Button Gray_Scale_Average;
        private System.Windows.Forms.PictureBox ExitButton;
        private System.Windows.Forms.Button Mean_Filter;
        private System.Windows.Forms.Button Weighted_Filter;
        private System.Windows.Forms.Button Median_Filter;
        private System.Windows.Forms.Button SaveImages;
        private System.Windows.Forms.SaveFileDialog Dialog_saveImages;
        private System.Windows.Forms.Button Sobel;
        private System.Windows.Forms.Button Laplacian;
        private System.Windows.Forms.Button Shape_Laplacian;
        private System.Windows.Forms.Button Shape_Sobel;
        private System.Windows.Forms.PictureBox DisplayZone_02;
        private System.Windows.Forms.Button Histogram_Equalization;
        private System.Windows.Forms.Button Negative;
        private System.Windows.Forms.Button Histogram_Equalization_Nega;
        private System.Windows.Forms.Button K_Mean;
        private System.Windows.Forms.Button Erosion;
        private System.Windows.Forms.Button Dilation;
        private System.Windows.Forms.Button Opening;
        private System.Windows.Forms.Button Closing_process;
        private System.Windows.Forms.PictureBox HOGU;
        private HanaHistogram Histogram_R;
        private HanaHistogram Histogram_G;
        private HanaHistogram Histogram_B;
        private System.Windows.Forms.Button Gamma;
    }
}

