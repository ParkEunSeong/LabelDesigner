namespace LabelEditor
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtP_Height = new System.Windows.Forms.TextBox();
            this.txtP_Width = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtMargin_Y = new System.Windows.Forms.TextBox();
            this.txtMargin_X = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cmbDensity = new System.Windows.Forms.ComboBox();
            this.cmbSpeed = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rdoTt = new System.Windows.Forms.RadioButton();
            this.rdoDt = new System.Windows.Forms.RadioButton();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.rdoContinuous = new System.Windows.Forms.RadioButton();
            this.rdoBmark = new System.Windows.Forms.RadioButton();
            this.rdoGap = new System.Windows.Forms.RadioButton();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.rdoRewind = new System.Windows.Forms.RadioButton();
            this.rdoCut = new System.Windows.Forms.RadioButton();
            this.rdoTearOff = new System.Windows.Forms.RadioButton();
            this.lblDllVersion = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.rdoBottom2Top = new System.Windows.Forms.RadioButton();
            this.rdoTop2Bottom = new System.Windows.Forms.RadioButton();
            this.btnPrintSample = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.buttonDesign = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonRectangle = new System.Windows.Forms.RadioButton();
            this.radioButtonEllipse = new System.Windows.Forms.RadioButton();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtP_Height);
            this.groupBox7.Controls.Add(this.txtP_Width);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Location = new System.Drawing.Point(12, 39);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(170, 90);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Paper Size ( Unit : mm )";
            // 
            // txtP_Height
            // 
            this.txtP_Height.Location = new System.Drawing.Point(87, 58);
            this.txtP_Height.Name = "txtP_Height";
            this.txtP_Height.Size = new System.Drawing.Size(72, 21);
            this.txtP_Height.TabIndex = 11;
            this.txtP_Height.Text = "60";
            // 
            // txtP_Width
            // 
            this.txtP_Width.Location = new System.Drawing.Point(87, 27);
            this.txtP_Width.Name = "txtP_Width";
            this.txtP_Width.Size = new System.Drawing.Size(72, 21);
            this.txtP_Width.TabIndex = 10;
            this.txtP_Width.Text = "95";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Height";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Width";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtMargin_Y);
            this.groupBox8.Controls.Add(this.txtMargin_X);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.label12);
            this.groupBox8.Location = new System.Drawing.Point(188, 39);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(170, 90);
            this.groupBox8.TabIndex = 16;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Margin ( Unit : mm )";
            // 
            // txtMargin_Y
            // 
            this.txtMargin_Y.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMargin_Y.Location = new System.Drawing.Point(87, 58);
            this.txtMargin_Y.Name = "txtMargin_Y";
            this.txtMargin_Y.Size = new System.Drawing.Size(72, 21);
            this.txtMargin_Y.TabIndex = 11;
            // 
            // txtMargin_X
            // 
            this.txtMargin_X.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMargin_X.Location = new System.Drawing.Point(87, 27);
            this.txtMargin_X.Name = "txtMargin_X";
            this.txtMargin_X.Size = new System.Drawing.Size(72, 21);
            this.txtMargin_X.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Y margin";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "X margin";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cmbDensity);
            this.groupBox9.Controls.Add(this.cmbSpeed);
            this.groupBox9.Controls.Add(this.label14);
            this.groupBox9.Controls.Add(this.label15);
            this.groupBox9.Location = new System.Drawing.Point(10, 407);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(356, 79);
            this.groupBox9.TabIndex = 19;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Speed / Density";
            // 
            // cmbDensity
            // 
            this.cmbDensity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDensity.FormattingEnabled = true;
            this.cmbDensity.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbDensity.Location = new System.Drawing.Point(79, 52);
            this.cmbDensity.Name = "cmbDensity";
            this.cmbDensity.Size = new System.Drawing.Size(136, 21);
            this.cmbDensity.TabIndex = 15;
            // 
            // cmbSpeed
            // 
            this.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpeed.Enabled = false;
            this.cmbSpeed.FormattingEnabled = true;
            this.cmbSpeed.Items.AddRange(new object[] {
            "Printer Setting"});
            this.cmbSpeed.Location = new System.Drawing.Point(79, 20);
            this.cmbSpeed.Name = "cmbSpeed";
            this.cmbSpeed.Size = new System.Drawing.Size(136, 21);
            this.cmbSpeed.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Density";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Speed";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rdoTt);
            this.groupBox6.Controls.Add(this.rdoDt);
            this.groupBox6.Location = new System.Drawing.Point(188, 224);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(170, 96);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Media type";
            // 
            // rdoTt
            // 
            this.rdoTt.AutoSize = true;
            this.rdoTt.Location = new System.Drawing.Point(16, 57);
            this.rdoTt.Name = "rdoTt";
            this.rdoTt.Size = new System.Drawing.Size(121, 17);
            this.rdoTt.TabIndex = 1;
            this.rdoTt.Text = "Thermal transfer";
            this.rdoTt.UseVisualStyleBackColor = true;
            // 
            // rdoDt
            // 
            this.rdoDt.AutoSize = true;
            this.rdoDt.Checked = true;
            this.rdoDt.Location = new System.Drawing.Point(16, 29);
            this.rdoDt.Name = "rdoDt";
            this.rdoDt.Size = new System.Drawing.Size(107, 17);
            this.rdoDt.TabIndex = 0;
            this.rdoDt.TabStop = true;
            this.rdoDt.Text = "Direct thermal";
            this.rdoDt.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.rdoContinuous);
            this.groupBox10.Controls.Add(this.rdoBmark);
            this.groupBox10.Controls.Add(this.rdoGap);
            this.groupBox10.Location = new System.Drawing.Point(12, 311);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(170, 96);
            this.groupBox10.TabIndex = 22;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Sensor type";
            // 
            // rdoContinuous
            // 
            this.rdoContinuous.AutoSize = true;
            this.rdoContinuous.Location = new System.Drawing.Point(19, 68);
            this.rdoContinuous.Name = "rdoContinuous";
            this.rdoContinuous.Size = new System.Drawing.Size(89, 17);
            this.rdoContinuous.TabIndex = 2;
            this.rdoContinuous.Text = "Continuous";
            this.rdoContinuous.UseVisualStyleBackColor = true;
            // 
            // rdoBmark
            // 
            this.rdoBmark.AutoSize = true;
            this.rdoBmark.Location = new System.Drawing.Point(19, 45);
            this.rdoBmark.Name = "rdoBmark";
            this.rdoBmark.Size = new System.Drawing.Size(90, 17);
            this.rdoBmark.TabIndex = 1;
            this.rdoBmark.Text = "Black mark";
            this.rdoBmark.UseVisualStyleBackColor = true;
            // 
            // rdoGap
            // 
            this.rdoGap.AutoSize = true;
            this.rdoGap.Checked = true;
            this.rdoGap.Location = new System.Drawing.Point(19, 20);
            this.rdoGap.Name = "rdoGap";
            this.rdoGap.Size = new System.Drawing.Size(48, 17);
            this.rdoGap.TabIndex = 0;
            this.rdoGap.TabStop = true;
            this.rdoGap.Text = "Gap";
            this.rdoGap.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.rdoRewind);
            this.groupBox11.Controls.Add(this.rdoCut);
            this.groupBox11.Controls.Add(this.rdoTearOff);
            this.groupBox11.Location = new System.Drawing.Point(193, 319);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(170, 84);
            this.groupBox11.TabIndex = 23;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Operation Mode";
            // 
            // rdoRewind
            // 
            this.rdoRewind.AutoSize = true;
            this.rdoRewind.Location = new System.Drawing.Point(19, 63);
            this.rdoRewind.Name = "rdoRewind";
            this.rdoRewind.Size = new System.Drawing.Size(78, 17);
            this.rdoRewind.TabIndex = 2;
            this.rdoRewind.Text = "Rewinder";
            this.rdoRewind.UseVisualStyleBackColor = true;
            // 
            // rdoCut
            // 
            this.rdoCut.AutoSize = true;
            this.rdoCut.Location = new System.Drawing.Point(19, 41);
            this.rdoCut.Name = "rdoCut";
            this.rdoCut.Size = new System.Drawing.Size(45, 17);
            this.rdoCut.TabIndex = 1;
            this.rdoCut.Text = "Cut";
            this.rdoCut.UseVisualStyleBackColor = true;
            // 
            // rdoTearOff
            // 
            this.rdoTearOff.AutoSize = true;
            this.rdoTearOff.Checked = true;
            this.rdoTearOff.Location = new System.Drawing.Point(19, 19);
            this.rdoTearOff.Name = "rdoTearOff";
            this.rdoTearOff.Size = new System.Drawing.Size(72, 17);
            this.rdoTearOff.TabIndex = 0;
            this.rdoTearOff.TabStop = true;
            this.rdoTearOff.Text = "Tear-Off";
            this.rdoTearOff.UseVisualStyleBackColor = true;
            // 
            // lblDllVersion
            // 
            this.lblDllVersion.Location = new System.Drawing.Point(112, 15);
            this.lblDllVersion.Name = "lblDllVersion";
            this.lblDllVersion.Size = new System.Drawing.Size(139, 13);
            this.lblDllVersion.TabIndex = 25;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.rdoBottom2Top);
            this.groupBox12.Controls.Add(this.rdoTop2Bottom);
            this.groupBox12.Location = new System.Drawing.Point(12, 224);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(170, 84);
            this.groupBox12.TabIndex = 26;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Print Direction";
            // 
            // rdoBottom2Top
            // 
            this.rdoBottom2Top.AutoSize = true;
            this.rdoBottom2Top.Checked = true;
            this.rdoBottom2Top.Location = new System.Drawing.Point(14, 55);
            this.rdoBottom2Top.Name = "rdoBottom2Top";
            this.rdoBottom2Top.Size = new System.Drawing.Size(103, 17);
            this.rdoBottom2Top.TabIndex = 0;
            this.rdoBottom2Top.TabStop = true;
            this.rdoBottom2Top.Text = "Bottom to top";
            this.rdoBottom2Top.UseVisualStyleBackColor = true;
            // 
            // rdoTop2Bottom
            // 
            this.rdoTop2Bottom.AutoSize = true;
            this.rdoTop2Bottom.Location = new System.Drawing.Point(14, 29);
            this.rdoTop2Bottom.Name = "rdoTop2Bottom";
            this.rdoTop2Bottom.Size = new System.Drawing.Size(104, 17);
            this.rdoTop2Bottom.TabIndex = 0;
            this.rdoTop2Bottom.Text = "Top to bottom";
            this.rdoTop2Bottom.UseVisualStyleBackColor = true;
            // 
            // btnPrintSample
            // 
            this.btnPrintSample.Location = new System.Drawing.Point(276, 492);
            this.btnPrintSample.Name = "btnPrintSample";
            this.btnPrintSample.Size = new System.Drawing.Size(93, 41);
            this.btnPrintSample.TabIndex = 29;
            this.btnPrintSample.Text = "Print sample label";
            this.btnPrintSample.UseVisualStyleBackColor = true;
            this.btnPrintSample.Click += new System.EventHandler(this.btnPrintSample_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "FileName:";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(83, 9);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(117, 21);
            this.textBoxFileName.TabIndex = 12;
            // 
            // buttonDesign
            // 
            this.buttonDesign.Location = new System.Drawing.Point(13, 492);
            this.buttonDesign.Name = "buttonDesign";
            this.buttonDesign.Size = new System.Drawing.Size(91, 41);
            this.buttonDesign.TabIndex = 30;
            this.buttonDesign.Text = "편집하기";
            this.buttonDesign.UseVisualStyleBackColor = true;
            this.buttonDesign.Click += new System.EventHandler(this.buttonDesign_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(148, 492);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(91, 41);
            this.buttonLoad.TabIndex = 31;
            this.buttonLoad.Text = "불러오기";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonEllipse);
            this.groupBox1.Controls.Add(this.radioButtonRectangle);
            this.groupBox1.Location = new System.Drawing.Point(12, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 90);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paper border";
            // 
            // radioButtonRectangle
            // 
            this.radioButtonRectangle.AutoSize = true;
            this.radioButtonRectangle.Checked = true;
            this.radioButtonRectangle.Location = new System.Drawing.Point(13, 24);
            this.radioButtonRectangle.Name = "radioButtonRectangle";
            this.radioButtonRectangle.Size = new System.Drawing.Size(81, 17);
            this.radioButtonRectangle.TabIndex = 1;
            this.radioButtonRectangle.TabStop = true;
            this.radioButtonRectangle.Text = "Rectangle";
            this.radioButtonRectangle.UseVisualStyleBackColor = true;
            // 
            // radioButtonEllipse
            // 
            this.radioButtonEllipse.AutoSize = true;
            this.radioButtonEllipse.Location = new System.Drawing.Point(14, 56);
            this.radioButtonEllipse.Name = "radioButtonEllipse";
            this.radioButtonEllipse.Size = new System.Drawing.Size(61, 17);
            this.radioButtonEllipse.TabIndex = 2;
            this.radioButtonEllipse.Text = "Ellipse";
            this.radioButtonEllipse.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 543);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonDesign);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPrintSample);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.lblDllVersion);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.Text = "Sample program (C#)";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtP_Height;
        private System.Windows.Forms.TextBox txtP_Width;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtMargin_Y;
        private System.Windows.Forms.TextBox txtMargin_X;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ComboBox cmbDensity;
        private System.Windows.Forms.ComboBox cmbSpeed;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdoTt;
        private System.Windows.Forms.RadioButton rdoDt;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.RadioButton rdoContinuous;
        private System.Windows.Forms.RadioButton rdoBmark;
        private System.Windows.Forms.RadioButton rdoGap;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label lblDllVersion;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.RadioButton rdoBottom2Top;
        private System.Windows.Forms.RadioButton rdoTop2Bottom;
        private System.Windows.Forms.Button btnPrintSample;
        private System.Windows.Forms.RadioButton rdoCut;
        private System.Windows.Forms.RadioButton rdoTearOff;
        private System.Windows.Forms.RadioButton rdoRewind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button buttonDesign;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonEllipse;
        private System.Windows.Forms.RadioButton radioButtonRectangle;
    }
}

