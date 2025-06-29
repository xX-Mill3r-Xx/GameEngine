using MillerSpaceInvaders.Configuracoes;
using MillerSpaceInvaders.Util;
using System;
using System.Windows.Forms;

namespace MillerSpaceInvaders.UI
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ConfiguracoesDoJogo.Dificuldade = cbDificuldade.SelectedItem.ToString();
            MessageBox.Show(Mensagens.ConfiguracaoSalva,
                Mensagens.Sucesso, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
