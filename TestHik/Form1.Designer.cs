namespace TestHik
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.btn_NVR = new System.Windows.Forms.Button();
            this.btn_DVR_V30 = new System.Windows.Forms.Button();
            this.btn_DVR_V40 = new System.Windows.Forms.Button();
            this.textBox_Ch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_GetConfig = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.timerAutoOpen = new System.Windows.Forms.Timer(this.components);
            this.textBoxLastFrame = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.txtRepCh = new System.Windows.Forms.TextBox();
            this.txtRepOre = new System.Windows.Forms.TextBox();
            this.txtRepMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRepPause = new System.Windows.Forms.Button();
            this.btnRepFF = new System.Windows.Forms.Button();
            this.btnRepImgF = new System.Windows.Forms.Button();
            this.btnRepRevert = new System.Windows.Forms.Button();
            this.btnRepBack = new System.Windows.Forms.Button();
            this.btnRepImgB = new System.Windows.Forms.Button();
            this.btnRepRec = new System.Windows.Forms.Button();
            this.btnRepSnap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(238, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(238, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "Init SDK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(363, 56);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 36);
            this.button3.TabIndex = 2;
            this.button3.Text = "Logout";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(363, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 33);
            this.button4.TabIndex = 3;
            this.button4.Text = "Cleanup SDK";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(238, 102);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(113, 33);
            this.button5.TabIndex = 4;
            this.button5.Text = "Open Video";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(363, 102);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(113, 33);
            this.button6.TabIndex = 5;
            this.button6.Text = "Close Video";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.Location = new System.Drawing.Point(12, 222);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(467, 306);
            this.textBox2.TabIndex = 7;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(15, 56);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(90, 25);
            this.button7.TabIndex = 8;
            this.button7.Text = "Start Listener";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(110, 56);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(89, 25);
            this.button8.TabIndex = 9;
            this.button8.Text = "Stop Listener";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button9.Location = new System.Drawing.Point(365, 571);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(114, 23);
            this.button9.TabIndex = 10;
            this.button9.Text = "Clear board";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BackgroundImage = global::TestHik.Properties.Resources.CAVI_square;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(501, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(630, 471);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(91, 20);
            this.textBox1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "DVR\'s IP && port:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(111, 109);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(52, 20);
            this.textBox3.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Local Listener IP && port:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(15, 35);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(90, 20);
            this.textBox4.TabIndex = 16;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(110, 35);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(52, 20);
            this.textBox5.TabIndex = 18;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(12, 193);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(65, 23);
            this.button10.TabIndex = 19;
            this.button10.Text = "DS7600";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // btn_NVR
            // 
            this.btn_NVR.Location = new System.Drawing.Point(82, 193);
            this.btn_NVR.Name = "btn_NVR";
            this.btn_NVR.Size = new System.Drawing.Size(64, 23);
            this.btn_NVR.TabIndex = 20;
            this.btn_NVR.Text = "NVR";
            this.btn_NVR.UseVisualStyleBackColor = true;
            this.btn_NVR.Click += new System.EventHandler(this.btn_NVR_Click);
            // 
            // btn_DVR_V30
            // 
            this.btn_DVR_V30.Location = new System.Drawing.Point(12, 149);
            this.btn_DVR_V30.Name = "btn_DVR_V30";
            this.btn_DVR_V30.Size = new System.Drawing.Size(65, 23);
            this.btn_DVR_V30.TabIndex = 20;
            this.btn_DVR_V30.Text = "DVR_V30";
            this.btn_DVR_V30.UseVisualStyleBackColor = true;
            this.btn_DVR_V30.Click += new System.EventHandler(this.btn_DVR_V30_Click);
            // 
            // btn_DVR_V40
            // 
            this.btn_DVR_V40.Location = new System.Drawing.Point(12, 172);
            this.btn_DVR_V40.Name = "btn_DVR_V40";
            this.btn_DVR_V40.Size = new System.Drawing.Size(65, 23);
            this.btn_DVR_V40.TabIndex = 20;
            this.btn_DVR_V40.Text = "DVR_V40";
            this.btn_DVR_V40.UseVisualStyleBackColor = true;
            this.btn_DVR_V40.Click += new System.EventHandler(this.btn_DVR_V40_Click);
            // 
            // textBox_Ch
            // 
            this.textBox_Ch.Location = new System.Drawing.Point(175, 109);
            this.textBox_Ch.Name = "textBox_Ch";
            this.textBox_Ch.Size = new System.Drawing.Size(44, 20);
            this.textBox_Ch.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Channel:";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 575);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(105, 17);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "pause messages";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btn_GetConfig
            // 
            this.btn_GetConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_GetConfig.Location = new System.Drawing.Point(501, 571);
            this.btn_GetConfig.Name = "btn_GetConfig";
            this.btn_GetConfig.Size = new System.Drawing.Size(75, 23);
            this.btn_GetConfig.TabIndex = 22;
            this.btn_GetConfig.Text = "Get Config";
            this.btn_GetConfig.UseVisualStyleBackColor = true;
            this.btn_GetConfig.Click += new System.EventHandler(this.btn_GetConfig_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(82, 149);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(64, 23);
            this.button11.TabIndex = 23;
            this.button11.Text = "CONT1";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(82, 172);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(64, 23);
            this.button12.TabIndex = 23;
            this.button12.Text = "CONT2";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(1023, 575);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(108, 17);
            this.checkBox2.TabIndex = 24;
            this.checkBox2.Text = "Auto Open/Close";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // timerAutoOpen
            // 
            this.timerAutoOpen.Interval = 4000;
            this.timerAutoOpen.Tick += new System.EventHandler(this.timerAutoOpen_Tick);
            // 
            // textBoxLastFrame
            // 
            this.textBoxLastFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxLastFrame.Enabled = false;
            this.textBoxLastFrame.Location = new System.Drawing.Point(12, 534);
            this.textBoxLastFrame.Name = "textBoxLastFrame";
            this.textBoxLastFrame.Size = new System.Drawing.Size(467, 20);
            this.textBoxLastFrame.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Equipments:";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(152, 193);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(47, 23);
            this.button13.TabIndex = 26;
            this.button13.Text = "Tribrid";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button14.Location = new System.Drawing.Point(583, 571);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 27;
            this.button14.Text = "Save stream";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(363, 164);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(111, 33);
            this.button15.TabIndex = 28;
            this.button15.Text = "Instant Replay";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // txtRepCh
            // 
            this.txtRepCh.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepCh.Location = new System.Drawing.Point(282, 146);
            this.txtRepCh.Name = "txtRepCh";
            this.txtRepCh.Size = new System.Drawing.Size(28, 13);
            this.txtRepCh.TabIndex = 29;
            this.txtRepCh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRepCh.TextChanged += new System.EventHandler(this.txtRepCh_TextChanged);
            // 
            // txtRepOre
            // 
            this.txtRepOre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepOre.Location = new System.Drawing.Point(282, 200);
            this.txtRepOre.Name = "txtRepOre";
            this.txtRepOre.Size = new System.Drawing.Size(28, 13);
            this.txtRepOre.TabIndex = 30;
            this.txtRepOre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRepOre.TextChanged += new System.EventHandler(this.txtRepOre_TextChanged);
            // 
            // txtRepMin
            // 
            this.txtRepMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepMin.Location = new System.Drawing.Point(282, 172);
            this.txtRepMin.Name = "txtRepMin";
            this.txtRepMin.Size = new System.Drawing.Size(28, 13);
            this.txtRepMin.TabIndex = 31;
            this.txtRepMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRepMin.TextChanged += new System.EventHandler(this.txtRepMin_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Replay channel:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "acum :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(316, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "minute";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(316, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "ore";
            // 
            // btnRepPause
            // 
            this.btnRepPause.Location = new System.Drawing.Point(821, 497);
            this.btnRepPause.Name = "btnRepPause";
            this.btnRepPause.Size = new System.Drawing.Size(45, 22);
            this.btnRepPause.TabIndex = 37;
            this.btnRepPause.Text = "Pause";
            this.btnRepPause.UseVisualStyleBackColor = true;
            this.btnRepPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnRepFF
            // 
            this.btnRepFF.Location = new System.Drawing.Point(749, 497);
            this.btnRepFF.Name = "btnRepFF";
            this.btnRepFF.Size = new System.Drawing.Size(40, 22);
            this.btnRepFF.TabIndex = 38;
            this.btnRepFF.Text = ">>";
            this.btnRepFF.UseVisualStyleBackColor = true;
            this.btnRepFF.Click += new System.EventHandler(this.btnRepFF_Click);
            // 
            // btnRepImgF
            // 
            this.btnRepImgF.Location = new System.Drawing.Point(961, 497);
            this.btnRepImgF.Name = "btnRepImgF";
            this.btnRepImgF.Size = new System.Drawing.Size(55, 22);
            this.btnRepImgF.TabIndex = 39;
            this.btnRepImgF.Text = "> img";
            this.btnRepImgF.UseVisualStyleBackColor = true;
            this.btnRepImgF.Click += new System.EventHandler(this.btnRepImgF_Click);
            // 
            // btnRepRevert
            // 
            this.btnRepRevert.Location = new System.Drawing.Point(703, 497);
            this.btnRepRevert.Name = "btnRepRevert";
            this.btnRepRevert.Size = new System.Drawing.Size(40, 22);
            this.btnRepRevert.TabIndex = 40;
            this.btnRepRevert.Text = "<";
            this.btnRepRevert.UseVisualStyleBackColor = true;
            this.btnRepRevert.Click += new System.EventHandler(this.btnRepRevert_Click);
            // 
            // btnRepBack
            // 
            this.btnRepBack.Location = new System.Drawing.Point(1086, 497);
            this.btnRepBack.Name = "btnRepBack";
            this.btnRepBack.Size = new System.Drawing.Size(45, 22);
            this.btnRepBack.TabIndex = 41;
            this.btnRepBack.Text = "X";
            this.btnRepBack.UseVisualStyleBackColor = true;
            this.btnRepBack.Click += new System.EventHandler(this.btnRepBack_Click);
            // 
            // btnRepImgB
            // 
            this.btnRepImgB.Location = new System.Drawing.Point(900, 497);
            this.btnRepImgB.Name = "btnRepImgB";
            this.btnRepImgB.Size = new System.Drawing.Size(55, 22);
            this.btnRepImgB.TabIndex = 42;
            this.btnRepImgB.Text = "< img";
            this.btnRepImgB.UseVisualStyleBackColor = true;
            this.btnRepImgB.Click += new System.EventHandler(this.btnRepImgB_Click);
            // 
            // btnRepRec
            // 
            this.btnRepRec.Location = new System.Drawing.Point(501, 497);
            this.btnRepRec.Name = "btnRepRec";
            this.btnRepRec.Size = new System.Drawing.Size(70, 22);
            this.btnRepRec.TabIndex = 43;
            this.btnRepRec.Text = "Record";
            this.btnRepRec.UseVisualStyleBackColor = true;
            this.btnRepRec.Click += new System.EventHandler(this.btnRepRec_Click);
            // 
            // btnRepSnap
            // 
            this.btnRepSnap.Location = new System.Drawing.Point(577, 497);
            this.btnRepSnap.Name = "btnRepSnap";
            this.btnRepSnap.Size = new System.Drawing.Size(51, 22);
            this.btnRepSnap.TabIndex = 44;
            this.btnRepSnap.Text = "Snap";
            this.btnRepSnap.UseVisualStyleBackColor = true;
            this.btnRepSnap.Click += new System.EventHandler(this.btnRepSnap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1143, 606);
            this.Controls.Add(this.btnRepSnap);
            this.Controls.Add(this.btnRepRec);
            this.Controls.Add(this.btnRepImgB);
            this.Controls.Add(this.btnRepBack);
            this.Controls.Add(this.btnRepRevert);
            this.Controls.Add(this.btnRepImgF);
            this.Controls.Add(this.btnRepFF);
            this.Controls.Add(this.btnRepPause);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRepMin);
            this.Controls.Add(this.txtRepOre);
            this.Controls.Add(this.txtRepCh);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.textBoxLastFrame);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.btn_GetConfig);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btn_DVR_V40);
            this.Controls.Add(this.btn_DVR_V30);
            this.Controls.Add(this.btn_NVR);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox_Ch);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btn_NVR;
        private System.Windows.Forms.Button btn_DVR_V30;
        private System.Windows.Forms.Button btn_DVR_V40;
        private System.Windows.Forms.TextBox textBox_Ch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btn_GetConfig;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Timer timerAutoOpen;
        private System.Windows.Forms.TextBox textBoxLastFrame;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.TextBox txtRepCh;
        private System.Windows.Forms.TextBox txtRepOre;
        private System.Windows.Forms.TextBox txtRepMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRepPause;
        private System.Windows.Forms.Button btnRepFF;
        private System.Windows.Forms.Button btnRepImgF;
        private System.Windows.Forms.Button btnRepRevert;
        private System.Windows.Forms.Button btnRepBack;
        private System.Windows.Forms.Button btnRepImgB;
        private System.Windows.Forms.Button btnRepRec;
        private System.Windows.Forms.Button btnRepSnap;
    }
}

