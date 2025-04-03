namespace BaiPiaoOcrOnnxCs
{
    partial class FormOcr
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.modelsTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.modelsBtn = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.openBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numThreadNumeric = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.detNameTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.recNameTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.keysNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.boxThreshNumeric = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.unClipRatioNumeric = new System.Windows.Forms.NumericUpDown();
            this.doAngleCheckBox = new System.Windows.Forms.CheckBox();
            this.mostAngleCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imgResizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.paddingNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.boxScoreThreshNumeric = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.strRestTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.partImgCheckBox = new System.Windows.Forms.CheckBox();
            this.debugCheckBox = new System.Windows.Forms.CheckBox();
            this.detectBtn = new System.Windows.Forms.Button();
            this.initBtn = new System.Windows.Forms.Button();
            this.ocrResultTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreadNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxThreshNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unClipRatioNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgResizeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddingNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxScoreThreshNumeric)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 228);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "ImgFile";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel2.Controls.Add(this.modelsTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.modelsBtn, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.pathTextBox, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.openBtn, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.numThreadNumeric, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.detNameTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.recNameTextBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.keysNameTextBox, 1, 4);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(19, 15);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(900, 264);
            this.tableLayoutPanel2.TabIndex = 14;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // modelsTextBox
            // 
            this.modelsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modelsTextBox.Location = new System.Drawing.Point(137, 4);
            this.modelsTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.modelsTextBox.Name = "modelsTextBox";
            this.modelsTextBox.Size = new System.Drawing.Size(652, 25);
            this.modelsTextBox.TabIndex = 1;
            this.modelsTextBox.TextChanged += new System.EventHandler(this.modelsTextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Models";
            // 
            // modelsBtn
            // 
            this.modelsBtn.Location = new System.Drawing.Point(797, 4);
            this.modelsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.modelsBtn.Name = "modelsBtn";
            this.modelsBtn.Size = new System.Drawing.Size(99, 29);
            this.modelsBtn.TabIndex = 2;
            this.modelsBtn.Text = "Models";
            this.modelsBtn.UseVisualStyleBackColor = true;
            this.modelsBtn.Click += new System.EventHandler(this.modelsBtn_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathTextBox.Location = new System.Drawing.Point(137, 232);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(652, 25);
            this.pathTextBox.TabIndex = 6;
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(797, 232);
            this.openBtn.Margin = new System.Windows.Forms.Padding(4);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(99, 29);
            this.openBtn.TabIndex = 0;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 190);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "numThread";
            // 
            // numThreadNumeric
            // 
            this.numThreadNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numThreadNumeric.Location = new System.Drawing.Point(137, 194);
            this.numThreadNumeric.Margin = new System.Windows.Forms.Padding(4);
            this.numThreadNumeric.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numThreadNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThreadNumeric.Name = "numThreadNumeric";
            this.numThreadNumeric.Size = new System.Drawing.Size(652, 25);
            this.numThreadNumeric.TabIndex = 4;
            this.numThreadNumeric.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "det";
            // 
            // detNameTextBox
            // 
            this.detNameTextBox.Location = new System.Drawing.Point(137, 42);
            this.detNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.detNameTextBox.Name = "detNameTextBox";
            this.detNameTextBox.Size = new System.Drawing.Size(651, 25);
            this.detNameTextBox.TabIndex = 12;
            this.detNameTextBox.Text = "ch_PP-OCRv3_det_infer.onnx";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 114);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 15);
            this.label11.TabIndex = 15;
            this.label11.Text = "rec";
            // 
            // recNameTextBox
            // 
            this.recNameTextBox.Location = new System.Drawing.Point(137, 118);
            this.recNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.recNameTextBox.Name = "recNameTextBox";
            this.recNameTextBox.Size = new System.Drawing.Size(651, 25);
            this.recNameTextBox.TabIndex = 16;
            this.recNameTextBox.Text = "num_rec_250312.onnx";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 152);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 15);
            this.label12.TabIndex = 17;
            this.label12.Text = "keys";
            // 
            // keysNameTextBox
            // 
            this.keysNameTextBox.Location = new System.Drawing.Point(137, 156);
            this.keysNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.keysNameTextBox.Name = "keysNameTextBox";
            this.keysNameTextBox.Size = new System.Drawing.Size(651, 25);
            this.keysNameTextBox.TabIndex = 18;
            this.keysNameTextBox.Text = "num_dict.txt";
            this.keysNameTextBox.TextChanged += new System.EventHandler(this.keysNameTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "boxThresh";
            // 
            // boxThreshNumeric
            // 
            this.boxThreshNumeric.DecimalPlaces = 3;
            this.boxThreshNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.boxThreshNumeric.Location = new System.Drawing.Point(115, 126);
            this.boxThreshNumeric.Margin = new System.Windows.Forms.Padding(4);
            this.boxThreshNumeric.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.boxThreshNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.boxThreshNumeric.Name = "boxThreshNumeric";
            this.boxThreshNumeric.Size = new System.Drawing.Size(99, 25);
            this.boxThreshNumeric.TabIndex = 15;
            this.boxThreshNumeric.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 162);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "unClipRatio";
            // 
            // unClipRatioNumeric
            // 
            this.unClipRatioNumeric.DecimalPlaces = 1;
            this.unClipRatioNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.unClipRatioNumeric.Location = new System.Drawing.Point(115, 166);
            this.unClipRatioNumeric.Margin = new System.Windows.Forms.Padding(4);
            this.unClipRatioNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.unClipRatioNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.unClipRatioNumeric.Name = "unClipRatioNumeric";
            this.unClipRatioNumeric.Size = new System.Drawing.Size(99, 25);
            this.unClipRatioNumeric.TabIndex = 22;
            this.unClipRatioNumeric.Value = new decimal(new int[] {
            16,
            0,
            0,
            65536});
            // 
            // doAngleCheckBox
            // 
            this.doAngleCheckBox.AutoSize = true;
            this.doAngleCheckBox.Checked = true;
            this.doAngleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doAngleCheckBox.Location = new System.Drawing.Point(6, 206);
            this.doAngleCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.doAngleCheckBox.Name = "doAngleCheckBox";
            this.doAngleCheckBox.Size = new System.Drawing.Size(82, 19);
            this.doAngleCheckBox.TabIndex = 26;
            this.doAngleCheckBox.Text = "doAngle";
            this.doAngleCheckBox.UseVisualStyleBackColor = true;
            // 
            // mostAngleCheckBox
            // 
            this.mostAngleCheckBox.AutoSize = true;
            this.mostAngleCheckBox.Location = new System.Drawing.Point(115, 206);
            this.mostAngleCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.mostAngleCheckBox.Name = "mostAngleCheckBox";
            this.mostAngleCheckBox.Size = new System.Drawing.Size(97, 19);
            this.mostAngleCheckBox.TabIndex = 27;
            this.mostAngleCheckBox.Text = "mostAngle";
            this.mostAngleCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 30);
            this.label4.TabIndex = 12;
            this.label4.Text = "boxScoreThresh";
            // 
            // imgResizeNumeric
            // 
            this.imgResizeNumeric.Location = new System.Drawing.Point(115, 46);
            this.imgResizeNumeric.Margin = new System.Windows.Forms.Padding(4);
            this.imgResizeNumeric.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.imgResizeNumeric.Name = "imgResizeNumeric";
            this.imgResizeNumeric.Size = new System.Drawing.Size(99, 25);
            this.imgResizeNumeric.TabIndex = 10;
            this.imgResizeNumeric.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "maxSideLen";
            // 
            // paddingNumeric
            // 
            this.paddingNumeric.Location = new System.Drawing.Point(115, 6);
            this.paddingNumeric.Margin = new System.Windows.Forms.Padding(4);
            this.paddingNumeric.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.paddingNumeric.Name = "paddingNumeric";
            this.paddingNumeric.Size = new System.Drawing.Size(99, 25);
            this.paddingNumeric.TabIndex = 7;
            this.paddingNumeric.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "padding";
            // 
            // boxScoreThreshNumeric
            // 
            this.boxScoreThreshNumeric.DecimalPlaces = 3;
            this.boxScoreThreshNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.boxScoreThreshNumeric.Location = new System.Drawing.Point(115, 86);
            this.boxScoreThreshNumeric.Margin = new System.Windows.Forms.Padding(4);
            this.boxScoreThreshNumeric.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.boxScoreThreshNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.boxScoreThreshNumeric.Name = "boxScoreThreshNumeric";
            this.boxScoreThreshNumeric.Size = new System.Drawing.Size(99, 25);
            this.boxScoreThreshNumeric.TabIndex = 13;
            this.boxScoreThreshNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 227F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.pictureBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.strRestTextBox, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(19, 286);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1009, 335);
            this.tableLayoutPanel3.TabIndex = 16;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(231, 4);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(383, 324);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // strRestTextBox
            // 
            this.strRestTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.strRestTextBox.Location = new System.Drawing.Point(622, 4);
            this.strRestTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.strRestTextBox.Multiline = true;
            this.strRestTextBox.Name = "strRestTextBox";
            this.strRestTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.strRestTextBox.Size = new System.Drawing.Size(383, 324);
            this.strRestTextBox.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tableLayoutPanel1.Controls.Add(this.boxScoreThreshNumeric, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.imgResizeNumeric, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.paddingNumeric, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.boxThreshNumeric, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.unClipRatioNumeric, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.doAngleCheckBox, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.mostAngleCheckBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.partImgCheckBox, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.debugCheckBox, 1, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(219, 325);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // partImgCheckBox
            // 
            this.partImgCheckBox.AutoSize = true;
            this.partImgCheckBox.Location = new System.Drawing.Point(6, 246);
            this.partImgCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.partImgCheckBox.Name = "partImgCheckBox";
            this.partImgCheckBox.Size = new System.Drawing.Size(77, 19);
            this.partImgCheckBox.TabIndex = 28;
            this.partImgCheckBox.Text = "PartImg";
            this.partImgCheckBox.UseVisualStyleBackColor = true;
            this.partImgCheckBox.CheckedChanged += new System.EventHandler(this.partImgCheckBox_CheckedChanged);
            // 
            // debugCheckBox
            // 
            this.debugCheckBox.AutoSize = true;
            this.debugCheckBox.Location = new System.Drawing.Point(115, 246);
            this.debugCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.debugCheckBox.Name = "debugCheckBox";
            this.debugCheckBox.Size = new System.Drawing.Size(93, 19);
            this.debugCheckBox.TabIndex = 29;
            this.debugCheckBox.Text = "DebugImg";
            this.debugCheckBox.UseVisualStyleBackColor = true;
            this.debugCheckBox.CheckedChanged += new System.EventHandler(this.debugCheckBox_CheckedChanged);
            // 
            // detectBtn
            // 
            this.detectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.detectBtn.Location = new System.Drawing.Point(929, 15);
            this.detectBtn.Margin = new System.Windows.Forms.Padding(4);
            this.detectBtn.Name = "detectBtn";
            this.detectBtn.Size = new System.Drawing.Size(99, 142);
            this.detectBtn.TabIndex = 12;
            this.detectBtn.Text = "Detect";
            this.detectBtn.UseVisualStyleBackColor = true;
            this.detectBtn.Click += new System.EventHandler(this.detectBtn_Click);
            // 
            // initBtn
            // 
            this.initBtn.Location = new System.Drawing.Point(929, 165);
            this.initBtn.Margin = new System.Windows.Forms.Padding(4);
            this.initBtn.Name = "initBtn";
            this.initBtn.Size = new System.Drawing.Size(99, 114);
            this.initBtn.TabIndex = 15;
            this.initBtn.Text = "重新初始化";
            this.initBtn.UseVisualStyleBackColor = true;
            this.initBtn.Click += new System.EventHandler(this.initBtn_Click);
            // 
            // ocrResultTextBox
            // 
            this.ocrResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ocrResultTextBox.Font = new System.Drawing.Font("SimSun", 9F);
            this.ocrResultTextBox.Location = new System.Drawing.Point(19, 629);
            this.ocrResultTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ocrResultTextBox.Multiline = true;
            this.ocrResultTextBox.Name = "ocrResultTextBox";
            this.ocrResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ocrResultTextBox.Size = new System.Drawing.Size(1008, 306);
            this.ocrResultTextBox.TabIndex = 13;
            // 
            // FormOcr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 951);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.detectBtn);
            this.Controls.Add(this.initBtn);
            this.Controls.Add(this.ocrResultTextBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormOcr";
            this.Text = "RapidOcrOnnxCs v1.2.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreadNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxThreshNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unClipRatioNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgResizeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddingNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxScoreThreshNumeric)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox modelsTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button modelsBtn;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numThreadNumeric;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox detNameTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox recNameTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox keysNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown boxThreshNumeric;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown unClipRatioNumeric;
        private System.Windows.Forms.CheckBox doAngleCheckBox;
        private System.Windows.Forms.CheckBox mostAngleCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown imgResizeNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown paddingNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown boxScoreThreshNumeric;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox strRestTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox partImgCheckBox;
        private System.Windows.Forms.CheckBox debugCheckBox;
        private System.Windows.Forms.Button detectBtn;
        private System.Windows.Forms.Button initBtn;
        private System.Windows.Forms.TextBox ocrResultTextBox;
    }
}

