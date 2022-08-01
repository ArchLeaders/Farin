using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarinResponceTool
{
    public partial class DialogPassword : Form
    {
        public string? Password { get; private set; } = null;
        public DialogPassword() => InitializeComponent();

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Password = PasswordBox.Text;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Password = null;
            Close();
        }

        private void PasswordBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                BtnOK_Click(null!, null!);
            }
        }
    }
}
