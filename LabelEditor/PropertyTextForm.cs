using DigitalProduction.Forms;
using LabelEditor.data;
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
    public partial class PropertyTextForm : Form
    {
        private int angle = 0;
        private RotatedLabel m_label;
        private Font m_font;
        public PropertyTextForm()
        {
            InitializeComponent();
            comboBoxRotation.Items.Add(0);
            comboBoxRotation.Items.Add(90);
            comboBoxRotation.Items.Add(180);
            comboBoxRotation.Items.Add(270);
        }
        public void SetLabel( RotatedLabel label )
        {
            m_label = label;
            textBoxName.Text = label.Name;
            textBoxX.Text = label.Location.X.ToString();
            textBoxY.Text = label.Location.Y.ToString();
            textBoxFontSize.Text = label.Font.Size.ToString();
            checkBoxFix.Checked = label.Fix;
            textBoxFontName.Text = label.Font.Name;
            checkBoxBold.Checked = label.Font.Bold;
            checkBoxArray.Checked = label.IsArray;
            textBoxSeparator.Text = label.Separator;
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

            checkBoxMultiple.Checked = label.Multiple;
            textBoxMultiple1.Text = label.m_multple[0].key;
            checkBoxFix1.Checked = label.m_multple[0].Fix;

            textBoxMultiple2.Text = label.m_multple[1].key;
            checkBoxFix2.Checked = label.m_multple[1].Fix;

            textBoxMultiple3.Text = label.m_multple[2].key;
            checkBoxFix3.Checked = label.m_multple[2].Fix;

            textBoxMultiple4.Text = label.m_multple[3].key;
            checkBoxFix4.Checked = label.m_multple[3].Fix;

            textBoxMultiple5.Text = label.m_multple[4].key;
            checkBoxFix5.Checked = label.m_multple[4].Fix;

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
            float font = 0;
            float.TryParse(textBoxFontSize.Text, out font);
            m_label.Name = textBoxName.Text;
            m_label.Text = m_label.Name;
            m_label.Location = new Point(x, y);
            m_label.Font = m_label.Font = new Font(textBoxFontName.Text, font, checkBoxBold.Checked ? FontStyle.Bold : FontStyle.Regular);
            m_label.Angle = PropUtil.GetIdxToAngle(comboBoxRotation.SelectedIndex);
            m_label.Width = (int)(m_label.Text.Length * m_label.Font.Size);
            m_label.Height = (int)m_label.Font.Size * 2 ;
            m_label.Fix = checkBoxFix.Checked;
            m_label.Multiple = checkBoxMultiple.Checked;
            m_label.IsArray = checkBoxArray.Checked;
            m_label.Separator = textBoxSeparator.Text;
            if ( checkBoxMultiple.Checked )
            {
                var list = new List<Text>();
                list.Add(new data.Text(textBoxMultiple1.Text, checkBoxFix1.Checked));
                list.Add(new data.Text(textBoxMultiple2.Text, checkBoxFix2.Checked));
                list.Add(new data.Text(textBoxMultiple3.Text, checkBoxFix3.Checked));
                list.Add(new data.Text(textBoxMultiple4.Text, checkBoxFix4.Checked));
                list.Add(new data.Text(textBoxMultiple5.Text, checkBoxFix5.Checked));
                m_label.m_multple = list;
            }
            Close();
        }
        private void textBoxFontSize_Click(object sender, EventArgs e)
        {
           
        }

        private void checkBoxMultiple_CheckedChanged(object sender, EventArgs e)
        {
            if ( checkBoxMultiple.Checked )
            {
                Size = new Size(453, 308);
            }
            else
            {
                Size = new Size(260, 308);
            }
        }

        private void checkBoxArray_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxArray.Checked)
                textBoxSeparator.Enabled = true;
            else
                textBoxSeparator.Enabled = false;
        }
    }
}
