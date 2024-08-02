using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplodingAtoms
{
    public partial class rules : Form
    {
        public rules()
        {
            InitializeComponent();
        }

        private void rules_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rules.ActiveForm.Dispose();
        }
    }
}
