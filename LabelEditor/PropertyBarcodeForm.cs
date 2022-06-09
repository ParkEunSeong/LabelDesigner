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
        private Barcode m_label;
        private Font m_font;
        public PropertyBarcodeForm()
        {
            InitializeComponent();
            for ( int i = 0; i <= 20; i++ )
            {
                comboBoxFill.Items.Add(i);
            }
        }
        public void SetLabel(Barcode label )
        {
            m_label = label;
            textBoxName.Text = label.Name;
            textBoxX.Text = label.Location.X.ToString();
            textBoxY.Text = label.Location.Y.ToString();
            textBoxWidth.Text = label.Width.ToString();
            textBoxHeight.Text = label.Height.ToString();
            radioButton128.Checked = label.code39 == 1;
            radioButton39.Checked = label.code39 == 0;
            m_font = label.Font;
            textBoxPadding.Text = label.Padding.ToString();
            comboBoxRotation.Items.Add(0);
            comboBoxRotation.Items.Add(90);
            comboBoxRotation.Items.Add(180);
            comboBoxRotation.Items.Add(270);
            checkBoxFont.Checked = label.font ? true : false;
            comboBoxFill.SelectedIndex = label.Length;
            if (label.Angle == 0)
            {
                comboBoxRotation.SelectedIndex = 0;
            }
            else if (label.Angle == 90)
            {
                comboBoxRotation.SelectedIndex = 1;
            }
            else if (label.Angle == 180)
            {
                comboBoxRotation.SelectedIndex = 2;
            }
            else if (label.Angle == 270)
            {
                comboBoxRotation.SelectedIndex = 3;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            int.TryParse(textBoxX.Text, out x);
            int.TryParse(textBoxY.Text, out y);
            int padding = 0;
            int.TryParse(textBoxPadding.Text, out padding);
            m_label.Location = new Point(x, y);
            m_label.Font = m_font;
            m_label.Name = textBoxName.Text;
            m_label.Padding = padding;
            if (radioButton39.Checked)
                m_label.code39 = 0;
            else
                m_label.code39 = 1;
            int value = 0;
            
            int.TryParse(textBoxWidth.Text, out value);
            m_label.Width = value;
            int.TryParse(textBoxHeight.Text, out value);
            m_label.Height = value;
            m_label.Angle = PropUtil.GetIdxToAngle(comboBoxRotation.SelectedIndex);

            m_label.font = checkBoxFont.Checked ? true : false;
            m_label.Length = comboBoxFill.SelectedIndex;
            Close();
        }
       
        private void textBoxFontSize_Click(object sender, EventArgs e)
        {
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if ( MessageBox.Show($"{m_label.Name} 을 삭제하시겠습니까?", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes )
            {
                
            }
        }
    }
}
