
namespace LabelPrintingServer
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
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.listBoxClient = new System.Windows.Forms.ListBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 12;
            this.listBoxLog.Location = new System.Drawing.Point(12, 143);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(494, 100);
            this.listBoxLog.TabIndex = 0;
            // 
            // listBoxClient
            // 
            this.listBoxClient.FormattingEnabled = true;
            this.listBoxClient.ItemHeight = 12;
            this.listBoxClient.Location = new System.Drawing.Point(12, 12);
            this.listBoxClient.Name = "listBoxClient";
            this.listBoxClient.Size = new System.Drawing.Size(120, 124);
            this.listBoxClient.TabIndex = 1;
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(314, 52);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(0, 12);
            this.labelServer.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 254);
            this.Controls.Add(this.labelServer);
            this.Controls.Add(this.listBoxClient);
            this.Controls.Add(this.listBoxLog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.ListBox listBoxClient;
        private System.Windows.Forms.Label labelServer;
    }
}

