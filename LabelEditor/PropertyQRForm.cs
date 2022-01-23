using DigitalProduction.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelEditor
{
    public partial class PropertyQRForm : Form
    {
        private QRCode m_qrCode;
        public PropertyQRForm()
        {
            InitializeComponent();
    
        }
        public void SetQR( QRCode box)
        {
            m_qrCode = box;
            textBoxName.Text = box.Name;
            textBoxX.Text = box.Location.X.ToString();
            textBoxY.Text = box.Location.Y.ToString();
            textBoxWidth.Text = box.Width.ToString();
            textBoxHeight.Text = box.Height.ToString();

        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            int x, y;
            int.TryParse(textBoxX.Text, out x);
            int.TryParse(textBoxY.Text, out y);
            m_qrCode.Name = textBoxName.Text;

            m_qrCode.Location = new Point(x, y);
            int w, h;
            int.TryParse(textBoxWidth.Text, out w);
            int.TryParse(textBoxHeight.Text, out h);
            m_qrCode.Size = new Size(w, h);

            Close();
        }

        private void textBoxY_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
