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
            this.buttonDesign = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonHorizontal = new System.Windows.Forms.RadioButton();
            this.radioButtonVertical = new System.Windows.Forms.RadioButton();
            this.groupBox7.SuspendLayout();
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
            this.groupBox7.Text = "용지 크기 ( 단위 : mm )";
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
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "높이";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 45);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "넓이";
            // 
            // buttonDesign
            // 
            this.buttonDesign.Location = new System.Drawing.Point(168, 169);
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
            this.groupBox1.Controls.Add(this.radioButtonHorizontal);
            this.groupBox1.Controls.Add(this.radioButtonVertical);
            this.groupBox1.Location = new System.Drawing.Point(244, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(219, 145);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "페이지 방향";
            // 
            // radioButtonHorizontal
            // 
            this.radioButtonHorizontal.AutoSize = true;
            this.radioButtonHorizontal.Location = new System.Drawing.Point(18, 90);
            this.radioButtonHorizontal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonHorizontal.Name = "radioButtonHorizontal";
            this.radioButtonHorizontal.Size = new System.Drawing.Size(60, 25);
            this.radioButtonHorizontal.TabIndex = 2;
            this.radioButtonHorizontal.Text = "가로";
            this.radioButtonHorizontal.UseVisualStyleBackColor = true;
            // 
            // radioButtonVertical
            // 
            this.radioButtonVertical.AutoSize = true;
            this.radioButtonVertical.Checked = true;
            this.radioButtonVertical.Location = new System.Drawing.Point(17, 47);
            this.radioButtonVertical.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonVertical.Name = "radioButtonVertical";
            this.radioButtonVertical.Size = new System.Drawing.Size(60, 25);
            this.radioButtonVertical.TabIndex = 1;
            this.radioButtonVertical.TabStop = true;
            this.radioButtonVertical.Text = "세로";
            this.radioButtonVertical.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 269);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDesign);
            this.Controls.Add(this.groupBox7);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
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
        private System.Windows.Forms.Button buttonDesign;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonHorizontal;
        private System.Windows.Forms.RadioButton radioButtonVertical;
    }
}

