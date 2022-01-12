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
    public partial class SetFileNameForm : Form
    {
        public Action<string> OnApply;
        public SetFileNameForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnApply?.Invoke(textBox1.Text);
            Close();
        }
    }
}
