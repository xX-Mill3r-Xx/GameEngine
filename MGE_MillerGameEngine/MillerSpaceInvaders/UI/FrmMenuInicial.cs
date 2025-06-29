using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MillerSpaceInvaders.UI
{
    public partial class FrmMenuInicial : Form
    {
        public FrmMenuInicial()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            var Start = new Form1();
            Start.ShowDialog();
            Hide();
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            var Config = new FrmConfig();
            Config.ShowDialog();
        }
    }
}
