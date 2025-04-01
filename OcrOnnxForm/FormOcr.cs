﻿using Emgu.CV;
using Emgu.CV.CvEnum;
using OcrLiteLib;
using System;

using System.IO;
using System.Windows.Forms;

namespace BaiPiaoOcrOnnxCs
{
    public partial class FormOcr : Form
    {
        private OcrLite ocrEngin;

        public FormOcr()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            modelsTextBox.Text = Path.Combine(appPath, "models");
        }

        private void initBtn_Click(object sender, EventArgs e)
        {

            string modelsDir = modelsTextBox.Text;
            string detPath = modelsDir + "\\" + detNameTextBox.Text;
            string rec1Path = modelsDir + "\\" + recNameTextBox.Text;
            string rec2Path = @"C:\Users\Public\micr_dataset\micr_rec_250313.onnx";
            string keys1Path = modelsDir + "\\" + keysNameTextBox.Text;
            string keys2Path = @"C:\Users\Public\micr_dataset\micr_dict.txt";
            bool isDetExists = File.Exists(detPath);
            if (!isDetExists)
            {
                MessageBox.Show("模型文件不存在:" + detPath);
            }
            bool isRec1Exists = File.Exists(rec1Path);
            if (!isRec1Exists)
            {
                MessageBox.Show("模型文件不存在:" + rec1Path);
            }
            bool isRec2Exists = File.Exists(rec2Path);
            if (!isRec2Exists)
            {
                MessageBox.Show("模型文件不存在:" + rec2Path);
            }
            bool isKeys1Exists = File.Exists(keys1Path);
            if (!isKeys1Exists)
            {
                MessageBox.Show("Keys文件不存在:" + keys1Path);
            }
            bool isKeys2Exists = File.Exists(keys2Path);
            if (!isKeys2Exists)
            {
                MessageBox.Show("Keys文件不存在:" + keys2Path);
            }
            if (isDetExists  && isRec1Exists && isRec2Exists && isKeys1Exists && isKeys2Exists)
            {
                ocrEngin = new OcrLite();
                ocrEngin.InitModels(detPath, rec1Path, rec2Path, keys1Path, keys2Path,(int)numThreadNumeric.Value);
            }
            else
            {
                MessageBox.Show("初始化失败，请确认模型文件夹和文件后，重新初始化！");
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Multiselect = false;
                dlg.Filter = "(*.JPG,*.PNG,*.JPEG,*.BMP,*.GIF)|*.JPG;*.PNG;*.JPEG;*.BMP;*.GIF|All files(*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dlg.FileName))
                {
                    pathTextBox.Text = dlg.FileName;
                    Mat src = CvInvoke.Imread(dlg.FileName, ImreadModes.Color);
                    pictureBox.Image = src.ToBitmap();
                }
            }
        }

        private void modelsBtn_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.SelectedPath = Environment.CurrentDirectory + "\\models";
                if (dlg.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dlg.SelectedPath))
                {
                    modelsTextBox.Text = dlg.SelectedPath;
                }
            }
        }
        Mat targetImg;


        private void detectBtn_Click(object sender, EventArgs e)
        {
            if (ocrEngin == null)
            {
                MessageBox.Show("未初始化，无法执行!");
                return;
            }
            
            int padding = (int)paddingNumeric.Value;
            int imgResize = (int)imgResizeNumeric.Value;
            float boxScoreThresh = (float)boxScoreThreshNumeric.Value;
            float boxThresh = (float)boxThreshNumeric.Value;
            float unClipRatio = (float)unClipRatioNumeric.Value;
            bool doAngle = doAngleCheckBox.Checked;
            bool mostAngle = mostAngleCheckBox.Checked;
            OcrResult ocrResult = ocrEngin.Detect(targetImg, padding, imgResize, boxScoreThresh, boxThresh, unClipRatio);
            ocrResultTextBox.Text = ocrResult.ToString();
            strRestTextBox.Text = ocrResult.StrRes;
            pictureBox.Image = ocrResult.BoxImg.ToBitmap();
        }

        private void partImgCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ocrEngin.isPartImg = partImgCheckBox.Checked;
        }

        private void debugCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ocrEngin.isDebugImg = debugCheckBox.Checked;
        }
        private void modelsTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
