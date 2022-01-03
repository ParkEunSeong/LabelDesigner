namespace LabelEditor
{
    partial class Form1
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonMakeText = new System.Windows.Forms.Button();
            this.button1DBarcode = new System.Windows.Forms.Button();
            this.buttonQRCode = new System.Windows.Forms.Button();
            this.listBoxCtrl = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.불러오기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다른이름으로저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxFontName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxBold = new System.Windows.Forms.CheckBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.textBoxFontSize = new System.Windows.Forms.TextBox();
            this.canvas1 = new LabelEditor.Canvas();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(212, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1189, 707);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.canvas1);
            this.panel2.Location = new System.Drawing.Point(212, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1186, 704);
            this.panel2.TabIndex = 0;
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // buttonMakeText
            // 
            this.buttonMakeText.Location = new System.Drawing.Point(212, 30);
            this.buttonMakeText.Name = "buttonMakeText";
            this.buttonMakeText.Size = new System.Drawing.Size(75, 52);
            this.buttonMakeText.TabIndex = 1;
            this.buttonMakeText.Text = "Text";
            this.buttonMakeText.UseVisualStyleBackColor = true;
            this.buttonMakeText.Click += new System.EventHandler(this.OnButtonClickedMakeControl);
            // 
            // button1DBarcode
            // 
            this.button1DBarcode.Location = new System.Drawing.Point(374, 30);
            this.button1DBarcode.Name = "button1DBarcode";
            this.button1DBarcode.Size = new System.Drawing.Size(75, 52);
            this.button1DBarcode.TabIndex = 2;
            this.button1DBarcode.Text = "1DBarcode";
            this.button1DBarcode.UseVisualStyleBackColor = true;
            this.button1DBarcode.Click += new System.EventHandler(this.OnButtonClickedMakeControl);
            // 
            // buttonQRCode
            // 
            this.buttonQRCode.Location = new System.Drawing.Point(293, 30);
            this.buttonQRCode.Name = "buttonQRCode";
            this.buttonQRCode.Size = new System.Drawing.Size(75, 52);
            this.buttonQRCode.TabIndex = 3;
            this.buttonQRCode.Text = "QRCode";
            this.buttonQRCode.UseVisualStyleBackColor = true;
            this.buttonQRCode.Click += new System.EventHandler(this.OnButtonClickedMakeControl);
            // 
            // listBoxCtrl
            // 
            this.listBoxCtrl.FormattingEnabled = true;
            this.listBoxCtrl.ItemHeight = 12;
            this.listBoxCtrl.Location = new System.Drawing.Point(12, 446);
            this.listBoxCtrl.Name = "listBoxCtrl";
            this.listBoxCtrl.Size = new System.Drawing.Size(194, 268);
            this.listBoxCtrl.TabIndex = 4;
            this.listBoxCtrl.SelectedIndexChanged += new System.EventHandler(this.listBoxCtrl_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.정보ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1413, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새파일ToolStripMenuItem,
            this.불러오기ToolStripMenuItem,
            this.저장하기ToolStripMenuItem,
            this.다른이름으로저장ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 새파일ToolStripMenuItem
            // 
            this.새파일ToolStripMenuItem.Name = "새파일ToolStripMenuItem";
            this.새파일ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.새파일ToolStripMenuItem.Text = "새 라벨";
            this.새파일ToolStripMenuItem.Click += new System.EventHandler(this.새파일ToolStripMenuItem_Click);
            // 
            // 불러오기ToolStripMenuItem
            // 
            this.불러오기ToolStripMenuItem.Name = "불러오기ToolStripMenuItem";
            this.불러오기ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.불러오기ToolStripMenuItem.Text = "불러오기";
            this.불러오기ToolStripMenuItem.Click += new System.EventHandler(this.불러오기ToolStripMenuItem_Click);
            // 
            // 저장하기ToolStripMenuItem
            // 
            this.저장하기ToolStripMenuItem.Name = "저장하기ToolStripMenuItem";
            this.저장하기ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.저장하기ToolStripMenuItem.Text = "저장하기";
            this.저장하기ToolStripMenuItem.Click += new System.EventHandler(this.저장하기ToolStripMenuItem_Click);
            // 
            // 다른이름으로저장ToolStripMenuItem
            // 
            this.다른이름으로저장ToolStripMenuItem.Name = "다른이름으로저장ToolStripMenuItem";
            this.다른이름으로저장ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.다른이름으로저장ToolStripMenuItem.Text = "다른이름으로저장";
            this.다른이름으로저장ToolStripMenuItem.Click += new System.EventHandler(this.다른이름으로저장ToolStripMenuItem_Click);
            // 
            // 정보ToolStripMenuItem
            // 
            this.정보ToolStripMenuItem.Name = "정보ToolStripMenuItem";
            this.정보ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.정보ToolStripMenuItem.Text = "정보";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelHeight);
            this.groupBox1.Controls.Add(this.labelWidth);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 154);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Label Size(mm)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(6, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inch";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelHeight.Location = new System.Drawing.Point(4, 54);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(60, 21);
            this.labelHeight.TabIndex = 3;
            this.labelHeight.Text = "Height";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelWidth.Location = new System.Drawing.Point(6, 26);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(54, 21);
            this.labelWidth.TabIndex = 1;
            this.labelWidth.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(89, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(10, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxBold);
            this.groupBox2.Controls.Add(this.textBoxFontName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxFontSize);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxY);
            this.groupBox2.Controls.Add(this.textBoxX);
            this.groupBox2.Controls.Add(this.textBoxName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(12, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 253);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(59, 23);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(132, 29);
            this.textBoxName.TabIndex = 5;
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(36, 55);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(33, 29);
            this.textBoxX.TabIndex = 6;
            this.textBoxX.TextChanged += new System.EventHandler(this.textBoxX_TextChanged);
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(111, 55);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(33, 29);
            this.textBoxY.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(93, 121);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(95, 29);
            this.textBox4.TabIndex = 11;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(93, 89);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(95, 29);
            this.textBox5.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(7, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(10, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 21);
            this.label6.TabIndex = 8;
            this.label6.Text = "Width";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(7, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "FontSize";
            // 
            // textBoxFontName
            // 
            this.textBoxFontName.Location = new System.Drawing.Point(93, 188);
            this.textBoxFontName.Name = "textBoxFontName";
            this.textBoxFontName.Size = new System.Drawing.Size(95, 29);
            this.textBoxFontName.TabIndex = 15;
            this.textBoxFontName.Click += new System.EventHandler(this.textBoxFont_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(7, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 21);
            this.label8.TabIndex = 14;
            this.label8.Text = "FontName";
            // 
            // checkBoxBold
            // 
            this.checkBoxBold.AutoSize = true;
            this.checkBoxBold.Location = new System.Drawing.Point(11, 222);
            this.checkBoxBold.Name = "checkBoxBold";
            this.checkBoxBold.Size = new System.Drawing.Size(62, 25);
            this.checkBoxBold.TabIndex = 16;
            this.checkBoxBold.Text = "Bold";
            this.checkBoxBold.UseVisualStyleBackColor = true;
            // 
            // textBoxFontSize
            // 
            this.textBoxFontSize.Location = new System.Drawing.Point(93, 155);
            this.textBoxFontSize.Name = "textBoxFontSize";
            this.textBoxFontSize.Size = new System.Drawing.Size(95, 29);
            this.textBoxFontSize.TabIndex = 13;
            // 
            // canvas1
            // 
            this.canvas1.BackColor = System.Drawing.SystemColors.Control;
            this.canvas1.Location = new System.Drawing.Point(297, 161);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(200, 100);
            this.canvas1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 807);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBoxCtrl);
            this.Controls.Add(this.buttonQRCode);
            this.Controls.Add(this.button1DBarcode);
            this.Controls.Add(this.buttonMakeText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "BIXOLON Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonMakeText;
        private System.Windows.Forms.Button button1DBarcode;
        private System.Windows.Forms.Button buttonQRCode;
        private System.Windows.Forms.ListBox listBoxCtrl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 불러오기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장하기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다른이름으로저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정보ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label label1;
        private Canvas canvas1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxBold;
        private System.Windows.Forms.TextBox textBoxFontName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.TextBox textBoxFontSize;
    }
}

