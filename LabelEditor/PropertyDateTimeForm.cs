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
    public partial class PropertyDateTimeForm : Form
    {
        private int angle = 0;
        private RotatedLabel m_label;
        private Font m_font;
        public PropertyDateTimeForm()
        {
            InitializeComponent();
            comboBoxRotation.Items.Add(0);
            comboBoxRotation.Items.Add(90);
            comboBoxRotation.Items.Add(180);
            comboBoxRotation.Items.Add(270);
            comboBoxFormat.Items.Add("");
            comboBoxFormat.Items.Add("yy-MM-dd HH:mm");
            comboBoxFormat.Items.Add("yyyy-MM-dd HH:mm");
            comboBoxFormat.Items.Add("yy년MM월dd일 HH시mm분");
            comboBoxFormat.Items.Add("yyyy년MM월dd일 HH시mm분");
            
        }
        public void SetLabel( RotatedLabel label )
        {
            m_label = label;
            textBoxName.Text = label.Name;
            textBoxX.Text = label.Location.X.ToString();
            textBoxY.Text = label.Location.Y.ToString();
            textBoxFontSize.Text = label.Font.Size.ToString();
            comboBoxFormat.SelectedIndex = label.m_dateTimeFormat;
            textBoxFontName.Text = label.Font.Name;
            checkBoxBold.Checked = label.Font.Bold;
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
            m_label.Name = textBoxName.Text;
            m_label.Text = m_label.Name;
            m_label.Location = new Point(x, y);
            m_label.Font = new Font(m_font.FontFamily, m_font.Size, checkBoxBold.Checked ? FontStyle.Bold : FontStyle.Regular);
            m_label.Angle = PropUtil.GetIdxToAngle(comboBoxRotation.SelectedIndex);
            m_label.Width = (int)(m_label.Text.Length * m_label.Font.Size);
            m_label.Height = (int)m_label.Font.Size * 2 ;
            m_label.m_dateTimeFormat = comboBoxFormat.SelectedIndex;
            Close();
        }
        private void textBoxFontSize_Click(object sender, EventArgs e)
        {
            if ( fontDialog1.ShowDialog() == DialogResult.OK )
            {
                var font = fontDialog1.Font;
                m_font = font;
                textBoxFontSize.Text = font.Size.ToString();
                textBoxFontName.Text = font.Name;
                checkBoxBold.Checked = font.Bold;
                
            }
        }
    }
}
