﻿namespace SampleProgram
{
    partial class frmSample
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
            this.label7 = new System.Windows.Forms.Label();
            this.rdoIF_Lan = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbLPT_Port = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoIF_Bluetooth = new System.Windows.Forms.RadioButton();
            this.rdoIF_Usb = new System.Windows.Forms.RadioButton();
            this.rdoIF_Parallel = new System.Windows.Forms.RadioButton();
            this.rdoIF_Serial = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSerial_Stopbits = new System.Windows.Forms.ComboBox();
            this.cmbSerial_Parity = new System.Windows.Forms.ComboBox();
            this.cmbSerial_Databits = new System.Windows.Forms.ComboBox();
            this.cmbSerial_Baudrate = new System.Windows.Forms.ComboBox();
            this.cmbSerial_Port = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNet_IPAddr = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNet_PortNum = new System.Windows.Forms.TextBox();
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
            this.label16 = new System.Windows.Forms.Label();
            this.lblDllVersion = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.rdoBottom2Top = new System.Windows.Forms.RadioButton();
            this.rdoTop2Bottom = new System.Windows.Forms.RadioButton();
            this.btnPrintSample = new System.Windows.Forms.Button();
            this.btnPrinterStatus = new System.Windows.Forms.Button();
            this.btnDirectIO = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Stop bits";
            // 
            // rdoIF_Lan
            // 
            this.rdoIF_Lan.AutoSize = true;
            this.rdoIF_Lan.Location = new System.Drawing.Point(13, 56);
            this.rdoIF_Lan.Name = "rdoIF_Lan";
            this.rdoIF_Lan.Size = new System.Drawing.Size(72, 17);
            this.rdoIF_Lan.TabIndex = 3;
            this.rdoIF_Lan.Text = "Network";
            this.rdoIF_Lan.UseVisualStyleBackColor = true;
            this.rdoIF_Lan.CheckedChanged += new System.EventHandler(this.rdoIF_Lan_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Parity";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbLPT_Port);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(10, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(217, 58);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parallel";
            // 
            // cmbLPT_Port
            // 
            this.cmbLPT_Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLPT_Port.Enabled = false;
            this.cmbLPT_Port.FormattingEnabled = true;
            this.cmbLPT_Port.Items.AddRange(new object[] {
            "LPT1",
            "LPT2",
            "LPT3",
            "LPT4",
            "LPT5"});
            this.cmbLPT_Port.Location = new System.Drawing.Point(89, 22);
            this.cmbLPT_Port.Name = "cmbLPT_Port";
            this.cmbLPT_Port.Size = new System.Drawing.Size(118, 21);
            this.cmbLPT_Port.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Data bits";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoIF_Bluetooth);
            this.groupBox1.Controls.Add(this.rdoIF_Lan);
            this.groupBox1.Controls.Add(this.rdoIF_Usb);
            this.groupBox1.Controls.Add(this.rdoIF_Parallel);
            this.groupBox1.Controls.Add(this.rdoIF_Serial);
            this.groupBox1.Location = new System.Drawing.Point(10, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 89);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Interface type";
            // 
            // rdoIF_Bluetooth
            // 
            this.rdoIF_Bluetooth.AutoSize = true;
            this.rdoIF_Bluetooth.Location = new System.Drawing.Point(94, 56);
            this.rdoIF_Bluetooth.Name = "rdoIF_Bluetooth";
            this.rdoIF_Bluetooth.Size = new System.Drawing.Size(79, 17);
            this.rdoIF_Bluetooth.TabIndex = 3;
            this.rdoIF_Bluetooth.Text = "Bluetooth";
            this.rdoIF_Bluetooth.UseVisualStyleBackColor = true;
            this.rdoIF_Bluetooth.CheckedChanged += new System.EventHandler(this.rdoIF_Bluetooth_CheckedChanged);
            // 
            // rdoIF_Usb
            // 
            this.rdoIF_Usb.AutoSize = true;
            this.rdoIF_Usb.Checked = true;
            this.rdoIF_Usb.Location = new System.Drawing.Point(178, 28);
            this.rdoIF_Usb.Name = "rdoIF_Usb";
            this.rdoIF_Usb.Size = new System.Drawing.Size(49, 17);
            this.rdoIF_Usb.TabIndex = 2;
            this.rdoIF_Usb.TabStop = true;
            this.rdoIF_Usb.Text = "USB";
            this.rdoIF_Usb.UseVisualStyleBackColor = true;
            this.rdoIF_Usb.CheckedChanged += new System.EventHandler(this.rdoIF_Usb_CheckedChanged);
            // 
            // rdoIF_Parallel
            // 
            this.rdoIF_Parallel.AutoSize = true;
            this.rdoIF_Parallel.Location = new System.Drawing.Point(94, 28);
            this.rdoIF_Parallel.Name = "rdoIF_Parallel";
            this.rdoIF_Parallel.Size = new System.Drawing.Size(67, 17);
            this.rdoIF_Parallel.TabIndex = 1;
            this.rdoIF_Parallel.Text = "Parallel";
            this.rdoIF_Parallel.UseVisualStyleBackColor = true;
            this.rdoIF_Parallel.CheckedChanged += new System.EventHandler(this.rdoIF_Parallel_CheckedChanged);
            // 
            // rdoIF_Serial
            // 
            this.rdoIF_Serial.AutoSize = true;
            this.rdoIF_Serial.Location = new System.Drawing.Point(13, 28);
            this.rdoIF_Serial.Name = "rdoIF_Serial";
            this.rdoIF_Serial.Size = new System.Drawing.Size(58, 17);
            this.rdoIF_Serial.TabIndex = 0;
            this.rdoIF_Serial.Text = "Serial";
            this.rdoIF_Serial.UseVisualStyleBackColor = true;
            this.rdoIF_Serial.CheckedChanged += new System.EventHandler(this.rdoIF_Serial_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.cmbSerial_Stopbits);
            this.groupBox4.Controls.Add(this.cmbSerial_Parity);
            this.groupBox4.Controls.Add(this.cmbSerial_Databits);
            this.groupBox4.Controls.Add(this.cmbSerial_Baudrate);
            this.groupBox4.Controls.Add(this.cmbSerial_Port);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(10, 88);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(217, 180);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Serial";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Baud-rate";
            // 
            // cmbSerial_Stopbits
            // 
            this.cmbSerial_Stopbits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerial_Stopbits.Enabled = false;
            this.cmbSerial_Stopbits.FormattingEnabled = true;
            this.cmbSerial_Stopbits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cmbSerial_Stopbits.Location = new System.Drawing.Point(89, 148);
            this.cmbSerial_Stopbits.Name = "cmbSerial_Stopbits";
            this.cmbSerial_Stopbits.Size = new System.Drawing.Size(118, 21);
            this.cmbSerial_Stopbits.TabIndex = 5;
            // 
            // cmbSerial_Parity
            // 
            this.cmbSerial_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerial_Parity.Enabled = false;
            this.cmbSerial_Parity.FormattingEnabled = true;
            this.cmbSerial_Parity.Items.AddRange(new object[] {
            "NONE",
            "ODD",
            "EVEN"});
            this.cmbSerial_Parity.Location = new System.Drawing.Point(89, 116);
            this.cmbSerial_Parity.Name = "cmbSerial_Parity";
            this.cmbSerial_Parity.Size = new System.Drawing.Size(118, 21);
            this.cmbSerial_Parity.TabIndex = 4;
            // 
            // cmbSerial_Databits
            // 
            this.cmbSerial_Databits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerial_Databits.Enabled = false;
            this.cmbSerial_Databits.FormattingEnabled = true;
            this.cmbSerial_Databits.Items.AddRange(new object[] {
            "7",
            "8"});
            this.cmbSerial_Databits.Location = new System.Drawing.Point(89, 85);
            this.cmbSerial_Databits.Name = "cmbSerial_Databits";
            this.cmbSerial_Databits.Size = new System.Drawing.Size(118, 21);
            this.cmbSerial_Databits.TabIndex = 3;
            // 
            // cmbSerial_Baudrate
            // 
            this.cmbSerial_Baudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerial_Baudrate.Enabled = false;
            this.cmbSerial_Baudrate.FormattingEnabled = true;
            this.cmbSerial_Baudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbSerial_Baudrate.Location = new System.Drawing.Point(89, 55);
            this.cmbSerial_Baudrate.Name = "cmbSerial_Baudrate";
            this.cmbSerial_Baudrate.Size = new System.Drawing.Size(118, 21);
            this.cmbSerial_Baudrate.TabIndex = 2;
            // 
            // cmbSerial_Port
            // 
            this.cmbSerial_Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerial_Port.Enabled = false;
            this.cmbSerial_Port.FormattingEnabled = true;
            this.cmbSerial_Port.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20"});
            this.cmbSerial_Port.Location = new System.Drawing.Point(89, 23);
            this.cmbSerial_Port.Name = "cmbSerial_Port";
            this.cmbSerial_Port.Size = new System.Drawing.Size(118, 21);
            this.cmbSerial_Port.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Port";
            // 
            // txtNet_IPAddr
            // 
            this.txtNet_IPAddr.Enabled = false;
            this.txtNet_IPAddr.Location = new System.Drawing.Point(89, 20);
            this.txtNet_IPAddr.Name = "txtNet_IPAddr";
            this.txtNet_IPAddr.Size = new System.Drawing.Size(118, 21);
            this.txtNet_IPAddr.TabIndex = 0;
            this.txtNet_IPAddr.Text = "192.168.1.1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(10, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 368);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Communication setting";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtNet_PortNum);
            this.groupBox5.Controls.Add(this.txtNet_IPAddr);
            this.groupBox5.Location = new System.Drawing.Point(10, 272);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(217, 81);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Network";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Port";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "IP";
            // 
            // txtNet_PortNum
            // 
            this.txtNet_PortNum.Enabled = false;
            this.txtNet_PortNum.Location = new System.Drawing.Point(89, 46);
            this.txtNet_PortNum.Name = "txtNet_PortNum";
            this.txtNet_PortNum.Size = new System.Drawing.Size(118, 21);
            this.txtNet_PortNum.TabIndex = 1;
            this.txtNet_PortNum.Text = "9100";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtP_Height);
            this.groupBox7.Controls.Add(this.txtP_Width);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Location = new System.Drawing.Point(266, 39);
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
            // 
            // txtP_Width
            // 
            this.txtP_Width.Location = new System.Drawing.Point(87, 27);
            this.txtP_Width.Name = "txtP_Width";
            this.txtP_Width.Size = new System.Drawing.Size(72, 21);
            this.txtP_Width.TabIndex = 10;
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
            this.groupBox8.Location = new System.Drawing.Point(452, 39);
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
            this.groupBox9.Location = new System.Drawing.Point(266, 245);
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
            this.groupBox6.Location = new System.Drawing.Point(266, 141);
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
            this.groupBox10.Location = new System.Drawing.Point(452, 141);
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
            this.groupBox11.Location = new System.Drawing.Point(452, 330);
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
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "SDK Version : ";
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
            this.groupBox12.Location = new System.Drawing.Point(266, 330);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(170, 84);
            this.groupBox12.TabIndex = 26;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Print Direction";
            // 
            // rdoBottom2Top
            // 
            this.rdoBottom2Top.AutoSize = true;
            this.rdoBottom2Top.Location = new System.Drawing.Point(14, 55);
            this.rdoBottom2Top.Name = "rdoBottom2Top";
            this.rdoBottom2Top.Size = new System.Drawing.Size(103, 17);
            this.rdoBottom2Top.TabIndex = 0;
            this.rdoBottom2Top.Text = "Bottom to top";
            this.rdoBottom2Top.UseVisualStyleBackColor = true;
            // 
            // rdoTop2Bottom
            // 
            this.rdoTop2Bottom.AutoSize = true;
            this.rdoTop2Bottom.Checked = true;
            this.rdoTop2Bottom.Location = new System.Drawing.Point(14, 29);
            this.rdoTop2Bottom.Name = "rdoTop2Bottom";
            this.rdoTop2Bottom.Size = new System.Drawing.Size(104, 17);
            this.rdoTop2Bottom.TabIndex = 0;
            this.rdoTop2Bottom.TabStop = true;
            this.rdoTop2Bottom.Text = "Top to bottom";
            this.rdoTop2Bottom.UseVisualStyleBackColor = true;
            // 
            // btnPrintSample
            // 
            this.btnPrintSample.Location = new System.Drawing.Point(266, 468);
            this.btnPrintSample.Name = "btnPrintSample";
            this.btnPrintSample.Size = new System.Drawing.Size(356, 41);
            this.btnPrintSample.TabIndex = 29;
            this.btnPrintSample.Text = "Print sample label";
            this.btnPrintSample.UseVisualStyleBackColor = true;
            this.btnPrintSample.Click += new System.EventHandler(this.btnPrintSample_Click);
            // 
            // btnPrinterStatus
            // 
            this.btnPrinterStatus.Location = new System.Drawing.Point(266, 422);
            this.btnPrinterStatus.Name = "btnPrinterStatus";
            this.btnPrinterStatus.Size = new System.Drawing.Size(170, 41);
            this.btnPrinterStatus.TabIndex = 30;
            this.btnPrinterStatus.Text = "Check Status";
            this.btnPrinterStatus.UseVisualStyleBackColor = true;
            this.btnPrinterStatus.Click += new System.EventHandler(this.btnPrinterStatus_Click);
            // 
            // btnDirectIO
            // 
            this.btnDirectIO.Location = new System.Drawing.Point(452, 422);
            this.btnDirectIO.Name = "btnDirectIO";
            this.btnDirectIO.Size = new System.Drawing.Size(170, 41);
            this.btnDirectIO.TabIndex = 30;
            this.btnDirectIO.Text = "Direct IO";
            this.btnDirectIO.UseVisualStyleBackColor = true;
            this.btnDirectIO.Click += new System.EventHandler(this.btnDirectIO_Click);
            // 
            // frmSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 535);
            this.Controls.Add(this.btnDirectIO);
            this.Controls.Add(this.btnPrinterStatus);
            this.Controls.Add(this.btnPrintSample);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.lblDllVersion);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmSample";
            this.Text = "Sample program (C#)";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdoIF_Lan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbLPT_Port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoIF_Usb;
        private System.Windows.Forms.RadioButton rdoIF_Parallel;
        private System.Windows.Forms.RadioButton rdoIF_Serial;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSerial_Stopbits;
        private System.Windows.Forms.ComboBox cmbSerial_Parity;
        private System.Windows.Forms.ComboBox cmbSerial_Databits;
        private System.Windows.Forms.ComboBox cmbSerial_Baudrate;
        private System.Windows.Forms.ComboBox cmbSerial_Port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNet_IPAddr;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNet_PortNum;
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
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblDllVersion;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.RadioButton rdoBottom2Top;
        private System.Windows.Forms.RadioButton rdoTop2Bottom;
        private System.Windows.Forms.Button btnPrintSample;
        private System.Windows.Forms.Button btnPrinterStatus;
        private System.Windows.Forms.Button btnDirectIO;
        private System.Windows.Forms.RadioButton rdoIF_Bluetooth;
        private System.Windows.Forms.RadioButton rdoCut;
        private System.Windows.Forms.RadioButton rdoTearOff;
        private System.Windows.Forms.RadioButton rdoRewind;
    }
}

