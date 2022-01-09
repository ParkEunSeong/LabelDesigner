namespace DigitalProduction.Forms
{
	partial class BarcodeLabel
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		//this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // RotatedLabel
            // 
            this.Name = "RotatedLabel";
            this.Size = new System.Drawing.Size(84, 26);
            this.Resize += new System.EventHandler(this.RotatedLabel_Resize);
            this.ResumeLayout(false);

		}

		#endregion

	}
}