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
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.rdoBottom2Top = new System.Windows.Forms.RadioButton();
            this.rdoTop2Bottom = new System.Windows.Forms.RadioButton();
            this.btnPrintSample = new System.Windows.Forms.Button();
            this.buttonDesign = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonEllipse = new System.Windows.Forms.RadioButton();
            this.radioButtonRectangle = new System.Windows.Forms.RadioButton();
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
            this.groupBox7.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(15, 14);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox7.Size = new System.Drawing.Size(219, 145);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Paper Size ( Unit : mm )";
            // 
            // txtP_Height
            // 
            this.txtP_Height.Location = new System.Drawing.Point(112, 94);
            this.txtP_Height.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtP_Height.Name = "txtP_Height";
            this.txtP_Height.Size = new System.Drawing.Size(91, 29);
            this.txtP_Height.TabIndex = 11;
            this.txtP_Height.Text = "60";
            // 
            // txtP_Width
            // 
            this.txtP_Width.Location = new System.Drawing.Point(112, 44);
            this.txtP_Width.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtP_Width.Name = "txtP_Width";
            this.txtP_Width.Size = new System.Drawing.Size(91, 29);
            this.txtP_Width.TabIndex = 10;
            this.txtP_Width.Text = "95";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Height";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 45);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "Width";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtMargin_Y);
            this.groupBox8.Controls.Add(this.txtMargin_X);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.label12);
            this.groupBox8.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(242, 14);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox8.Size = new System.Drawing.Size(219, 145);
            this.groupBox8.TabIndex = 16;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Margin ( Unit : mm )";
            // 
            // txtMargin_Y
            // 
            this.txtMargin_Y.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMargin_Y.Location = new System.Drawing.Point(112, 94);
            this.txtMargin_Y.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMargin_Y.Name = "txtMargin_Y";
            this.txtMargin_Y.Size = new System.Drawing.Size(91, 29);
            this.txtMargin_Y.TabIndex = 11;
            // 
            // txtMargin_X
            // 
            this.txtMargin_X.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMargin_X.Location = new System.Drawing.Point(112, 44);
            this.txtMargin_X.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMargin_X.Name = "txtMargin_X";
            this.txtMargin_X.Size = new System.Drawing.Size(91, 29);
            this.txtMargin_X.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 94);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 21);
            this.label11.TabIndex = 9;
            this.label11.Text = "Y margin";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 45);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 21);
            this.label12.TabIndex = 8;
            this.label12.Text = "X margin";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cmbDensity);
            this.groupBox9.Controls.Add(this.cmbSpeed);
            this.groupBox9.Controls.Add(this.label14);
            this.groupBox9.Controls.Add(this.label15);
            this.groupBox9.Location = new System.Drawing.Point(240, 454);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox9.Size = new System.Drawing.Size(219, 128);
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
            this.cmbDensity.Location = new System.Drawing.Point(102, 84);
            this.cmbDensity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbDensity.Name = "cmbDensity";
            this.cmbDensity.Size = new System.Drawing.Size(101, 29);
            this.cmbDensity.TabIndex = 15;
            // 
            // cmbSpeed
            // 
            this.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpeed.Enabled = false;
            this.cmbSpeed.FormattingEnabled = true;
            this.cmbSpeed.Items.AddRange(new object[] {
            "Printer Setting"});
            this.cmbSpeed.Location = new System.Drawing.Point(102, 32);
            this.cmbSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSpeed.Name = "cmbSpeed";
            this.cmbSpeed.Size = new System.Drawing.Size(101, 29);
            this.cmbSpeed.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 90);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 21);
            this.label14.TabIndex = 7;
            this.label14.Text = "Density";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 39);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 21);
            this.label15.TabIndex = 6;
            this.label15.Text = "Speed";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rdoTt);
            this.groupBox6.Controls.Add(this.rdoDt);
            this.groupBox6.Location = new System.Drawing.Point(240, 160);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Size = new System.Drawing.Size(219, 155);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Media type";
            // 
            // rdoTt
            // 
            this.rdoTt.AutoSize = true;
            this.rdoTt.Location = new System.Drawing.Point(21, 92);
            this.rdoTt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoTt.Name = "rdoTt";
            this.rdoTt.Size = new System.Drawing.Size(149, 25);
            this.rdoTt.TabIndex = 1;
            this.rdoTt.Text = "Thermal transfer";
            this.rdoTt.UseVisualStyleBackColor = true;
            // 
            // rdoDt
            // 
            this.rdoDt.AutoSize = true;
            this.rdoDt.Checked = true;
            this.rdoDt.Location = new System.Drawing.Point(21, 47);
            this.rdoDt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoDt.Name = "rdoDt";
            this.rdoDt.Size = new System.Drawing.Size(134, 25);
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
            this.groupBox10.Location = new System.Drawing.Point(15, 443);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox10.Size = new System.Drawing.Size(219, 155);
            this.groupBox10.TabIndex = 22;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Sensor type";
            // 
            // rdoContinuous
            // 
            this.rdoContinuous.AutoSize = true;
            this.rdoContinuous.Location = new System.Drawing.Point(24, 110);
            this.rdoContinuous.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoContinuous.Name = "rdoContinuous";
            this.rdoContinuous.Size = new System.Drawing.Size(111, 25);
            this.rdoContinuous.TabIndex = 2;
            this.rdoContinuous.Text = "Continuous";
            this.rdoContinuous.UseVisualStyleBackColor = true;
            // 
            // rdoBmark
            // 
            this.rdoBmark.AutoSize = true;
            this.rdoBmark.Location = new System.Drawing.Point(24, 73);
            this.rdoBmark.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoBmark.Name = "rdoBmark";
            this.rdoBmark.Size = new System.Drawing.Size(107, 25);
            this.rdoBmark.TabIndex = 1;
            this.rdoBmark.Text = "Black mark";
            this.rdoBmark.UseVisualStyleBackColor = true;
            // 
            // rdoGap
            // 
            this.rdoGap.AutoSize = true;
            this.rdoGap.Checked = true;
            this.rdoGap.Location = new System.Drawing.Point(24, 32);
            this.rdoGap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoGap.Name = "rdoGap";
            this.rdoGap.Size = new System.Drawing.Size(57, 25);
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
            this.groupBox11.Location = new System.Drawing.Point(240, 315);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox11.Size = new System.Drawing.Size(219, 136);
            this.groupBox11.TabIndex = 23;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Operation Mode";
            // 
            // rdoRewind
            // 
            this.rdoRewind.AutoSize = true;
            this.rdoRewind.Location = new System.Drawing.Point(24, 102);
            this.rdoRewind.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoRewind.Name = "rdoRewind";
            this.rdoRewind.Size = new System.Drawing.Size(97, 25);
            this.rdoRewind.TabIndex = 2;
            this.rdoRewind.Text = "Rewinder";
            this.rdoRewind.UseVisualStyleBackColor = true;
            // 
            // rdoCut
            // 
            this.rdoCut.AutoSize = true;
            this.rdoCut.Location = new System.Drawing.Point(24, 66);
            this.rdoCut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoCut.Name = "rdoCut";
            this.rdoCut.Size = new System.Drawing.Size(53, 25);
            this.rdoCut.TabIndex = 1;
            this.rdoCut.Text = "Cut";
            this.rdoCut.UseVisualStyleBackColor = true;
            // 
            // rdoTearOff
            // 
            this.rdoTearOff.AutoSize = true;
            this.rdoTearOff.Checked = true;
            this.rdoTearOff.Location = new System.Drawing.Point(24, 31);
            this.rdoTearOff.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoTearOff.Name = "rdoTearOff";
            this.rdoTearOff.Size = new System.Drawing.Size(89, 25);
            this.rdoTearOff.TabIndex = 0;
            this.rdoTearOff.TabStop = true;
            this.rdoTearOff.Text = "Tear-Off";
            this.rdoTearOff.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.rdoBottom2Top);
            this.groupBox12.Controls.Add(this.rdoTop2Bottom);
            this.groupBox12.Location = new System.Drawing.Point(15, 306);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox12.Size = new System.Drawing.Size(219, 136);
            this.groupBox12.TabIndex = 26;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Print Direction";
            // 
            // rdoBottom2Top
            // 
            this.rdoBottom2Top.AutoSize = true;
            this.rdoBottom2Top.Checked = true;
            this.rdoBottom2Top.Location = new System.Drawing.Point(18, 89);
            this.rdoBottom2Top.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoBottom2Top.Name = "rdoBottom2Top";
            this.rdoBottom2Top.Size = new System.Drawing.Size(137, 25);
            this.rdoBottom2Top.TabIndex = 0;
            this.rdoBottom2Top.TabStop = true;
            this.rdoBottom2Top.Text = "Bottom to top";
            this.rdoBottom2Top.UseVisualStyleBackColor = true;
            // 
            // rdoTop2Bottom
            // 
            this.rdoTop2Bottom.AutoSize = true;
            this.rdoTop2Bottom.Location = new System.Drawing.Point(18, 47);
            this.rdoTop2Bottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoTop2Bottom.Name = "rdoTop2Bottom";
            this.rdoTop2Bottom.Size = new System.Drawing.Size(141, 25);
            this.rdoTop2Bottom.TabIndex = 0;
            this.rdoTop2Bottom.Text = "Top to bottom";
            this.rdoTop2Bottom.UseVisualStyleBackColor = true;
            // 
            // btnPrintSample
            // 
            this.btnPrintSample.Location = new System.Drawing.Point(354, 592);
            this.btnPrintSample.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrintSample.Name = "btnPrintSample";
            this.btnPrintSample.Size = new System.Drawing.Size(120, 73);
            this.btnPrintSample.TabIndex = 29;
            this.btnPrintSample.Text = "Print sample label";
            this.btnPrintSample.UseVisualStyleBackColor = true;
            this.btnPrintSample.Visible = false;
            this.btnPrintSample.Click += new System.EventHandler(this.btnPrintSample_Click);
            // 
            // buttonDesign
            // 
            this.buttonDesign.Location = new System.Drawing.Point(169, 608);
            this.buttonDesign.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDesign.Name = "buttonDesign";
            this.buttonDesign.Size = new System.Drawing.Size(117, 66);
            this.buttonDesign.TabIndex = 30;
            this.buttonDesign.Text = "편집하기";
            this.buttonDesign.UseVisualStyleBackColor = true;
            this.buttonDesign.Click += new System.EventHandler(this.buttonDesign_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonEllipse);
            this.groupBox1.Controls.Add(this.radioButtonRectangle);
            this.groupBox1.Location = new System.Drawing.Point(13, 160);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(219, 145);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paper border";
            // 
            // radioButtonEllipse
            // 
            this.radioButtonEllipse.AutoSize = true;
            this.radioButtonEllipse.Location = new System.Drawing.Point(18, 90);
            this.radioButtonEllipse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonEllipse.Name = "radioButtonEllipse";
            this.radioButtonEllipse.Size = new System.Drawing.Size(74, 25);
            this.radioButtonEllipse.TabIndex = 2;
            this.radioButtonEllipse.Text = "Ellipse";
            this.radioButtonEllipse.UseVisualStyleBackColor = true;
            // 
            // radioButtonRectangle
            // 
            this.radioButtonRectangle.AutoSize = true;
            this.radioButtonRectangle.Checked = true;
            this.radioButtonRectangle.Location = new System.Drawing.Point(17, 39);
            this.radioButtonRectangle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonRectangle.Name = "radioButtonRectangle";
            this.radioButtonRectangle.Size = new System.Drawing.Size(101, 25);
            this.radioButtonRectangle.TabIndex = 1;
            this.radioButtonRectangle.TabStop = true;
            this.radioButtonRectangle.Text = "Rectangle";
            this.radioButtonRectangle.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 688);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDesign);
            this.Controls.Add(this.btnPrintSample);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
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
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.RadioButton rdoBottom2Top;
        private System.Windows.Forms.RadioButton rdoTop2Bottom;
        private System.Windows.Forms.Button btnPrintSample;
        private System.Windows.Forms.RadioButton rdoCut;
        private System.Windows.Forms.RadioButton rdoTearOff;
        private System.Windows.Forms.RadioButton rdoRewind;
        private System.Windows.Forms.Button buttonDesign;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonEllipse;
        private System.Windows.Forms.RadioButton radioButtonRectangle;
    }
}

