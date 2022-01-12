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
            comboBoxRotation.Items.Add(0);
            comboBoxRotation.Items.Add(90);
            comboBoxRotation.Items.Add(180);
            comboBoxRotation.Items.Add(270);
        }
        public void SetLabel( BarcodeLabel label )
        {
            m_label = label;
            textBoxName.Text = label.Name;
            textBoxX.Text = label.Location.X.ToString();
            textBoxY.Text = label.Location.Y.ToString();
            radioButton39.Checked = label.BARCODE_TYPE == 0;
            radioButton128.Checked = label.BARCODE_TYPE == 1;
            m_label.BARCODE_TYPE = label.BARCODE_TYPE;
            radioButton128.Checked = label.BARCODE_TYPE == 1;
            radioButton39.Checked = label.BARCODE_TYPE == 0;
            m_label.BARCODE_HEIGHT = label.BARCODE_HEIGHT;
            m_label.NARROW_BAR_WIDTH = label.NARROW_BAR_WIDTH;
            m_label.WIDE_BAR_WIDTH = label.WIDE_BAR_WIDTH;

            m_font = label.Font;
            if ( label.Angle == 0 )
            {
                comboBoxRotation.SelectedIndex = 0;
            }
            else if ( label.Angle == 90 )
            {
                comboBoxRotation.SelectedIndex = 1;
            }
            else if ( label.Angle == 180 )
            {
                comboBoxRotation.SelectedIndex = 2;
            }
            else if ( label.Angle == 270 )
            {
                comboBoxRotation.SelectedIndex = 3;
            }
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
            m_label.Angle = PropUtil.GetIdxToAngle(comboBoxRotation.SelectedIndex);
            if (radioButton39.Checked)
                m_label.BARCODE_TYPE = 0;
            else
                m_label.BARCODE_TYPE = 1;
            int value = 0;
            int.TryParse(textBoxBarcodeHeight.Text, out value);
            m_label.BARCODE_HEIGHT = value;
            int.TryParse(textBoxNarrowBarWidth.Text, out value);
            m_label.NARROW_BAR_WIDTH = value;
            int.TryParse(textBoxWideBarWidth.Text, out value);
            m_label.WIDE_BAR_WIDTH = value;

            Close();
        }
       
        private void textBoxFontSize_Click(object sender, EventArgs e)
        {
        }
    }
}
