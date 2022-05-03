
namespace LabelEditor
{
    partial class PropertyTextForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxMultiple = new System.Windows.Forms.CheckBox();
            this.checkBoxFix = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxRotation = new System.Windows.Forms.ComboBox();
            this.checkBoxBold = new System.Windows.Forms.CheckBox();
            this.textBoxFontName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxFontSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.textBoxMultiple1 = new System.Windows.Forms.TextBox();
            this.checkBoxFix1 = new System.Windows.Forms.CheckBox();
            this.checkBoxFix2 = new System.Windows.Forms.CheckBox();
            this.textBoxMultiple2 = new System.Windows.Forms.TextBox();
            this.checkBoxFix3 = new System.Windows.Forms.CheckBox();
            this.textBoxMultiple3 = new System.Windows.Forms.TextBox();
            this.checkBoxFix4 = new System.Windows.Forms.CheckBox();
            this.textBoxMultiple4 = new System.Windows.Forms.TextBox();
            this.checkBoxFix5 = new System.Windows.Forms.CheckBox();
            this.textBoxMultiple5 = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxMultiple);
            this.groupBox2.Controls.Add(this.checkBoxFix);
            this.groupBox2.Controls.Add(this.buttonSave);
            this.groupBox2.Controls.Add(this.comboBoxRotation);
            this.groupBox2.Controls.Add(this.checkBoxBold);
            this.groupBox2.Controls.Add(this.textBoxFontName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxFontSize);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBoxY);
            this.groupBox2.Controls.Add(this.textBoxX);
            this.groupBox2.Controls.Add(this.textBoxName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(12, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 264);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Text";
            // 
            // checkBoxMultiple
            // 
            this.checkBoxMultiple.AutoSize = true;
            this.checkBoxMultiple.Location = new System.Drawing.Point(64, 188);
            this.checkBoxMultiple.Name = "checkBoxMultiple";
            this.checkBoxMultiple.Size = new System.Drawing.Size(90, 25);
            this.checkBoxMultiple.TabIndex = 19;
            this.checkBoxMultiple.Text = "Multiple";
            this.checkBoxMultiple.UseVisualStyleBackColor = true;
            this.checkBoxMultiple.CheckedChanged += new System.EventHandler(this.checkBoxMultiple_CheckedChanged);
            // 
            // checkBoxFix
            // 
            this.checkBoxFix.AutoSize = true;
            this.checkBoxFix.Location = new System.Drawing.Point(10, 189);
            this.checkBoxFix.Name = "checkBoxFix";
            this.checkBoxFix.Size = new System.Drawing.Size(48, 25);
            this.checkBoxFix.TabIndex = 18;
            this.checkBoxFix.Text = "Fix";
            this.checkBoxFix.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonSave.Location = new System.Drawing.Point(59, 220);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 38);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "적용";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxRotation
            // 
            this.comboBoxRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRotation.FormattingEnabled = true;
            this.comboBoxRotation.Location = new System.Drawing.Point(10, 153);
            this.comboBoxRotation.Name = "comboBoxRotation";
            this.comboBoxRotation.Size = new System.Drawing.Size(121, 29);
            this.comboBoxRotation.TabIndex = 17;
            this.comboBoxRotation.SelectedIndexChanged += new System.EventHandler(this.comboBoxRotation_SelectedIndexChanged);
            // 
            // checkBoxBold
            // 
            this.checkBoxBold.AutoSize = true;
            this.checkBoxBold.Location = new System.Drawing.Point(135, 155);
            this.checkBoxBold.Name = "checkBoxBold";
            this.checkBoxBold.Size = new System.Drawing.Size(62, 25);
            this.checkBoxBold.TabIndex = 16;
            this.checkBoxBold.Text = "Bold";
            this.checkBoxBold.UseVisualStyleBackColor = true;
            this.checkBoxBold.Click += new System.EventHandler(this.textBoxFontSize_Click);
            // 
            // textBoxFontName
            // 
            this.textBoxFontName.Location = new System.Drawing.Point(102, 118);
            this.textBoxFontName.Name = "textBoxFontName";
            this.textBoxFontName.Size = new System.Drawing.Size(95, 29);
            this.textBoxFontName.TabIndex = 15;
            this.textBoxFontName.Click += new System.EventHandler(this.comboBoxRotation_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(10, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 21);
            this.label8.TabIndex = 14;
            this.label8.Text = "폰트 이름";
            this.label8.Click += new System.EventHandler(this.textBoxFontSize_Click);
            // 
            // textBoxFontSize
            // 
            this.textBoxFontSize.Location = new System.Drawing.Point(102, 87);
            this.textBoxFontSize.Name = "textBoxFontSize";
            this.textBoxFontSize.Size = new System.Drawing.Size(95, 29);
            this.textBoxFontSize.TabIndex = 13;
            this.textBoxFontSize.Click += new System.EventHandler(this.textBoxFontSize_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(10, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "폰트 크기";
            this.label7.Click += new System.EventHandler(this.textBoxFontSize_Click);
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(111, 55);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(50, 29);
            this.textBoxY.TabIndex = 7;
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(36, 55);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(47, 29);
            this.textBoxX.TabIndex = 6;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(59, 21);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(132, 29);
            this.textBoxName.TabIndex = 5;
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
            this.label4.Size = new System.Drawing.Size(26, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "키";
            // 
            // textBoxMultiple1
            // 
            this.textBoxMultiple1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxMultiple1.Location = new System.Drawing.Point(248, 21);
            this.textBoxMultiple1.Name = "textBoxMultiple1";
            this.textBoxMultiple1.Size = new System.Drawing.Size(132, 29);
            this.textBoxMultiple1.TabIndex = 20;
            // 
            // checkBoxFix1
            // 
            this.checkBoxFix1.AutoSize = true;
            this.checkBoxFix1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBoxFix1.Location = new System.Drawing.Point(386, 25);
            this.checkBoxFix1.Name = "checkBoxFix1";
            this.checkBoxFix1.Size = new System.Drawing.Size(48, 25);
            this.checkBoxFix1.TabIndex = 20;
            this.checkBoxFix1.Text = "Fix";
            this.checkBoxFix1.UseVisualStyleBackColor = true;
            // 
            // checkBoxFix2
            // 
            this.checkBoxFix2.AutoSize = true;
            this.checkBoxFix2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBoxFix2.Location = new System.Drawing.Point(386, 59);
            this.checkBoxFix2.Name = "checkBoxFix2";
            this.checkBoxFix2.Size = new System.Drawing.Size(48, 25);
            this.checkBoxFix2.TabIndex = 21;
            this.checkBoxFix2.Text = "Fix";
            this.checkBoxFix2.UseVisualStyleBackColor = true;
            // 
            // textBoxMultiple2
            // 
            this.textBoxMultiple2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxMultiple2.Location = new System.Drawing.Point(248, 55);
            this.textBoxMultiple2.Name = "textBoxMultiple2";
            this.textBoxMultiple2.Size = new System.Drawing.Size(132, 29);
            this.textBoxMultiple2.TabIndex = 22;
            // 
            // checkBoxFix3
            // 
            this.checkBoxFix3.AutoSize = true;
            this.checkBoxFix3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBoxFix3.Location = new System.Drawing.Point(386, 93);
            this.checkBoxFix3.Name = "checkBoxFix3";
            this.checkBoxFix3.Size = new System.Drawing.Size(48, 25);
            this.checkBoxFix3.TabIndex = 23;
            this.checkBoxFix3.Text = "Fix";
            this.checkBoxFix3.UseVisualStyleBackColor = true;
            // 
            // textBoxMultiple3
            // 
            this.textBoxMultiple3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxMultiple3.Location = new System.Drawing.Point(248, 89);
            this.textBoxMultiple3.Name = "textBoxMultiple3";
            this.textBoxMultiple3.Size = new System.Drawing.Size(132, 29);
            this.textBoxMultiple3.TabIndex = 24;
            // 
            // checkBoxFix4
            // 
            this.checkBoxFix4.AutoSize = true;
            this.checkBoxFix4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBoxFix4.Location = new System.Drawing.Point(386, 124);
            this.checkBoxFix4.Name = "checkBoxFix4";
            this.checkBoxFix4.Size = new System.Drawing.Size(48, 25);
            this.checkBoxFix4.TabIndex = 25;
            this.checkBoxFix4.Text = "Fix";
            this.checkBoxFix4.UseVisualStyleBackColor = true;
            // 
            // textBoxMultiple4
            // 
            this.textBoxMultiple4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxMultiple4.Location = new System.Drawing.Point(248, 120);
            this.textBoxMultiple4.Name = "textBoxMultiple4";
            this.textBoxMultiple4.Size = new System.Drawing.Size(132, 29);
            this.textBoxMultiple4.TabIndex = 26;
            // 
            // checkBoxFix5
            // 
            this.checkBoxFix5.AutoSize = true;
            this.checkBoxFix5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBoxFix5.Location = new System.Drawing.Point(386, 159);
            this.checkBoxFix5.Name = "checkBoxFix5";
            this.checkBoxFix5.Size = new System.Drawing.Size(48, 25);
            this.checkBoxFix5.TabIndex = 27;
            this.checkBoxFix5.Text = "Fix";
            this.checkBoxFix5.UseVisualStyleBackColor = true;
            // 
            // textBoxMultiple5
            // 
            this.textBoxMultiple5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxMultiple5.Location = new System.Drawing.Point(248, 155);
            this.textBoxMultiple5.Name = "textBoxMultiple5";
            this.textBoxMultiple5.Size = new System.Drawing.Size(132, 29);
            this.textBoxMultiple5.TabIndex = 28;
            // 
            // PropertyTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 269);
            this.Controls.Add(this.checkBoxFix5);
            this.Controls.Add(this.textBoxMultiple5);
            this.Controls.Add(this.checkBoxFix4);
            this.Controls.Add(this.textBoxMultiple4);
            this.Controls.Add(this.checkBoxFix3);
            this.Controls.Add(this.textBoxMultiple3);
            this.Controls.Add(this.checkBoxFix2);
            this.Controls.Add(this.textBoxMultiple2);
            this.Controls.Add(this.checkBoxFix1);
            this.Controls.Add(this.textBoxMultiple1);
            this.Controls.Add(this.groupBox2);
            this.Name = "PropertyTextForm";
            this.Text = "Text Property";
            this.TopMost = true;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxRotation;
        private System.Windows.Forms.CheckBox checkBoxBold;
        private System.Windows.Forms.TextBox textBoxFontName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxFontSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.CheckBox checkBoxFix;
        private System.Windows.Forms.CheckBox checkBoxMultiple;
        private System.Windows.Forms.TextBox textBoxMultiple1;
        private System.Windows.Forms.CheckBox checkBoxFix1;
        private System.Windows.Forms.CheckBox checkBoxFix2;
        private System.Windows.Forms.TextBox textBoxMultiple2;
        private System.Windows.Forms.CheckBox checkBoxFix3;
        private System.Windows.Forms.TextBox textBoxMultiple3;
        private System.Windows.Forms.CheckBox checkBoxFix4;
        private System.Windows.Forms.TextBox textBoxMultiple4;
        private System.Windows.Forms.CheckBox checkBoxFix5;
        private System.Windows.Forms.TextBox textBoxMultiple5;
    }
}