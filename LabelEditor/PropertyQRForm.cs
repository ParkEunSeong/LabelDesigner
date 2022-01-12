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
            comboBoxRotation.Items.Add(0);
            comboBoxRotation.Items.Add(90);
            comboBoxRotation.Items.Add(180);
            comboBoxRotation.Items.Add(270);
            for ( int i = 0; i < 9; i++ )
            {
                comboBoxQRSize.Items.Add(i+1);
            }
            comboBoxECCLevel.Items.Add("L-7");
            comboBoxECCLevel.Items.Add("M-15");
            comboBoxECCLevel.Items.Add("Q-25");
            comboBoxECCLevel.Items.Add("H-30");
        }
        public void SetQR( QRCode box)
        {
            m_qrCode = box;
            textBoxName.Text = box.Name;
            comboBoxECCLevel.SelectedIndex = box.ECC_LEVEL;
            comboBoxQRSize.SelectedIndex = box.QR_SIZE;
            comboBoxRotation.SelectedIndex = box.QR_ROTATION;
            textBoxX.Text = box.Location.X.ToString();
            textBoxY.Text = box.Location.Y.ToString();
            radioButtonModel1.Checked = box.QR_MODEL == 0;
            radioButtonModel2.Checked = box.QR_MODEL == 1;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            m_qrCode.ECC_LEVEL = comboBoxECCLevel.SelectedIndex;
            m_qrCode.QR_SIZE = comboBoxQRSize.SelectedIndex;
            m_qrCode.QR_ROTATION = comboBoxRotation.SelectedIndex;
            int x, y;
            int.TryParse(textBoxX.Text, out x);
            int.TryParse(textBoxY.Text, out y);
            m_qrCode.Location = new Point(x, y);
            Close();
        }
    }
}
