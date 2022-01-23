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
    public partial class PropertyBarcodeForm : Form
    {
        private int angle = 0;
        private BarcodeLabel m_label;
        private Font m_font;
        public PropertyBarcodeForm()
        {
            InitializeComponent();
        }
        public void SetLabel( BarcodeLabel label )
        {
            m_label = label;
            textBoxName.Text = label.Name;
            textBoxX.Text = label.Location.X.ToString();
            textBoxY.Text = label.Location.Y.ToString();
            textBoxWidth.Text = label.Width.ToString();
            textBoxHeight.Text = label.Height.ToString();
            radioButton39.Checked = label.BARCODE_TYPE == 0;
            radioButton128.Checked = label.BARCODE_TYPE == 1;
            m_label.BARCODE_TYPE = label.BARCODE_TYPE;
            radioButton128.Checked = label.BARCODE_TYPE == 1;
            radioButton39.Checked = label.BARCODE_TYPE == 0;
            m_font = label.Font;
       
        }

        private void comboBoxRotation_SelectedIndexChanged(object sender, EventArgs e)
        {
              
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            int.TryParse(textBoxX.Text, out x);
            int.TryParse(textBoxY.Text, out y);
            
            m_label.Location = new Point(x, y);
            m_label.Font = m_font;
            m_label.Name = textBoxName.Text;

            if (radioButton39.Checked)
                m_label.BARCODE_TYPE = 0;
            else
                m_label.BARCODE_TYPE = 1;
            int value = 0;
            int.TryParse(textBoxWidth.Text, out value);
            m_label.Width = value;
            int.TryParse(textBoxHeight.Text, out value);
            m_label.Height = value;

            
       

            Close();
        }
       
        private void textBoxFontSize_Click(object sender, EventArgs e)
        {
        }
    }
}
