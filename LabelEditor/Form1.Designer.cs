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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonMakeText = new System.Windows.Forms.Button();
            this.button1DBarcode = new System.Windows.Forms.Button();
            this.buttonQRCode = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.불러오기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다른이름으로저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelPixel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelinch = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMMSize = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonLabelSetting = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxPrinter = new System.Windows.Forms.ListBox();
            this.buttonRefreshPrinter = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDateTime = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listViewControl = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonEditJson = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(212, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 707);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Location = new System.Drawing.Point(212, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1069, 680);
            this.panel2.TabIndex = 0;
            this.panel2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel2_Scroll);
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // buttonMakeText
            // 
            this.buttonMakeText.Location = new System.Drawing.Point(677, 27);
            this.buttonMakeText.Name = "buttonMakeText";
            this.buttonMakeText.Size = new System.Drawing.Size(75, 52);
            this.buttonMakeText.TabIndex = 1;
            this.buttonMakeText.Tag = "0";
            this.buttonMakeText.Text = "Text";
            this.buttonMakeText.UseVisualStyleBackColor = true;
            this.buttonMakeText.Click += new System.EventHandler(this.OnButtonClickedMakeControl);
            // 
            // button1DBarcode
            // 
            this.button1DBarcode.Location = new System.Drawing.Point(830, 27);
            this.button1DBarcode.Name = "button1DBarcode";
            this.button1DBarcode.Size = new System.Drawing.Size(75, 52);
            this.button1DBarcode.TabIndex = 2;
            this.button1DBarcode.Tag = "2";
            this.button1DBarcode.Text = "1DBarcode";
            this.button1DBarcode.UseVisualStyleBackColor = true;
            this.button1DBarcode.Click += new System.EventHandler(this.OnButtonClickedMakeControl);
            // 
            // buttonQRCode
            // 
            this.buttonQRCode.Location = new System.Drawing.Point(754, 27);
            this.buttonQRCode.Name = "buttonQRCode";
            this.buttonQRCode.Size = new System.Drawing.Size(75, 52);
            this.buttonQRCode.TabIndex = 3;
            this.buttonQRCode.Tag = "1";
            this.buttonQRCode.Text = "QRCode";
            this.buttonQRCode.UseVisualStyleBackColor = true;
            this.buttonQRCode.Click += new System.EventHandler(this.OnButtonClickedMakeControl);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.정보ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1298, 24);
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
            this.groupBox1.Controls.Add(this.labelPixel);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.labelinch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelMMSize);
            this.groupBox1.Controls.Add(this.labelWidth);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 113);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Label Size";
            // 
            // labelPixel
            // 
            this.labelPixel.AutoSize = true;
            this.labelPixel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPixel.Location = new System.Drawing.Point(84, 76);
            this.labelPixel.Name = "labelPixel";
            this.labelPixel.Size = new System.Drawing.Size(60, 21);
            this.labelPixel.TabIndex = 7;
            this.labelPixel.Text = "Height";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(6, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 21);
            this.label11.TabIndex = 6;
            this.label11.Text = "Pixel";
            // 
            // labelinch
            // 
            this.labelinch.AutoSize = true;
            this.labelinch.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelinch.Location = new System.Drawing.Point(84, 51);
            this.labelinch.Name = "labelinch";
            this.labelinch.Size = new System.Drawing.Size(60, 21);
            this.labelinch.TabIndex = 5;
            this.labelinch.Text = "Height";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inch";
            // 
            // labelMMSize
            // 
            this.labelMMSize.AutoSize = true;
            this.labelMMSize.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMMSize.Location = new System.Drawing.Point(84, 25);
            this.labelMMSize.Name = "labelMMSize";
            this.labelMMSize.Size = new System.Drawing.Size(60, 21);
            this.labelMMSize.TabIndex = 3;
            this.labelMMSize.Text = "Height";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelWidth.Location = new System.Drawing.Point(6, 26);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(75, 21);
            this.labelWidth.TabIndex = 1;
            this.labelWidth.Text = "MM Size";
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(291, 27);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 52);
            this.buttonPrint.TabIndex = 8;
            this.buttonPrint.Text = "프린트";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(369, 27);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 52);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "저장하기";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(446, 27);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 52);
            this.buttonLoad.TabIndex = 10;
            this.buttonLoad.Text = "불러오기";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonLabelSetting
            // 
            this.buttonLabelSetting.Location = new System.Drawing.Point(212, 27);
            this.buttonLabelSetting.Name = "buttonLabelSetting";
            this.buttonLabelSetting.Size = new System.Drawing.Size(75, 52);
            this.buttonLabelSetting.TabIndex = 11;
            this.buttonLabelSetting.Text = "라벨설정창";
            this.buttonLabelSetting.UseVisualStyleBackColor = true;
            this.buttonLabelSetting.Click += new System.EventHandler(this.buttonLabelSetting_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(17, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "Field List";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(17, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Printer List";
            // 
            // listBoxPrinter
            // 
            this.listBoxPrinter.FormattingEnabled = true;
            this.listBoxPrinter.ItemHeight = 12;
            this.listBoxPrinter.Location = new System.Drawing.Point(22, 168);
            this.listBoxPrinter.Name = "listBoxPrinter";
            this.listBoxPrinter.Size = new System.Drawing.Size(157, 88);
            this.listBoxPrinter.TabIndex = 13;
            this.listBoxPrinter.DoubleClick += new System.EventHandler(this.listBoxPrinter_DoubleClick);
            // 
            // buttonRefreshPrinter
            // 
            this.buttonRefreshPrinter.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonRefreshPrinter.Location = new System.Drawing.Point(108, 142);
            this.buttonRefreshPrinter.Name = "buttonRefreshPrinter";
            this.buttonRefreshPrinter.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshPrinter.TabIndex = 15;
            this.buttonRefreshPrinter.Text = "Refresh";
            this.buttonRefreshPrinter.UseVisualStyleBackColor = true;
            this.buttonRefreshPrinter.Click += new System.EventHandler(this.buttonRefreshPrinter_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(599, 27);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 52);
            this.buttonClear.TabIndex = 16;
            this.buttonClear.Tag = "0";
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonDateTime
            // 
            this.buttonDateTime.Location = new System.Drawing.Point(907, 27);
            this.buttonDateTime.Name = "buttonDateTime";
            this.buttonDateTime.Size = new System.Drawing.Size(75, 52);
            this.buttonDateTime.TabIndex = 17;
            this.buttonDateTime.Tag = "3";
            this.buttonDateTime.Text = "DateTime";
            this.buttonDateTime.UseVisualStyleBackColor = true;
            this.buttonDateTime.Click += new System.EventHandler(this.OnButtonClickedMakeControl);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1006, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "label4";
            // 
            // listViewControl
            // 
            this.listViewControl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewControl.HideSelection = false;
            this.listViewControl.Location = new System.Drawing.Point(21, 287);
            this.listViewControl.Name = "listViewControl";
            this.listViewControl.Size = new System.Drawing.Size(177, 276);
            this.listViewControl.TabIndex = 19;
            this.listViewControl.UseCompatibleStateImageBehavior = false;
            this.listViewControl.View = System.Windows.Forms.View.Details;
            this.listViewControl.SelectedIndexChanged += new System.EventHandler(this.listViewControl_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 80;
            // 
            // buttonEditJson
            // 
            this.buttonEditJson.Location = new System.Drawing.Point(523, 27);
            this.buttonEditJson.Name = "buttonEditJson";
            this.buttonEditJson.Size = new System.Drawing.Size(75, 52);
            this.buttonEditJson.TabIndex = 19;
            this.buttonEditJson.Text = "파일편집";
            this.buttonEditJson.UseVisualStyleBackColor = true;
            this.buttonEditJson.Click += new System.EventHandler(this.buttonEditJson_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 831);
            this.Controls.Add(this.listViewControl);
            this.Controls.Add(this.buttonEditJson);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonDateTime);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonRefreshPrinter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxPrinter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonLabelSetting);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonQRCode);
            this.Controls.Add(this.button1DBarcode);
            this.Controls.Add(this.buttonMakeText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "LabelDesigner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonMakeText;
        private System.Windows.Forms.Button button1DBarcode;
        private System.Windows.Forms.Button buttonQRCode;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 불러오기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장하기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다른이름으로저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정보ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelMMSize;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label label1;
        private Canvas canvas1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Label labelPixel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelinch;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonLabelSetting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxPrinter;
        private System.Windows.Forms.Button buttonRefreshPrinter;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonDateTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listViewControl;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonEditJson;
    }
}

