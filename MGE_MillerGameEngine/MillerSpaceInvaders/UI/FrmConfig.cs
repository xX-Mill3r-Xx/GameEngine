using MillerSpaceInvaders.Configuracoes;
using MillerSpaceInvaders.Enumeradores;
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

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            cbDificuldade.DataSource = Enum.GetValues(typeof(ENivelDificuldade));
            cbDificuldade.SelectedItem = ConfiguracoesDoJogo.Dificuldade;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ConfiguracoesDoJogo.Dificuldade = (ENivelDificuldade)cbDificuldade.SelectedItem;
            ConfigStorage.Salvar();

            MessageBox.Show(Mensagens.ConfiguracaoSalva,
                Mensagens.Sucesso, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
