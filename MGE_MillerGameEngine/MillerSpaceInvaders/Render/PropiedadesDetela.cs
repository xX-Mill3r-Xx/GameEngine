using MillerSpaceInvaders.Enumeradores;
using MillerSpaceInvaders.Mecanicas;
using MillerSpaceInvaders.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MillerSpaceInvaders.Render
{
    public static class PropiedadesDetela
    {
        public static void DesenharJogo(PaintEventArgs e, MovimentacaoPlayer movimentoPlayer)
        {
            try
            {
                e.Graphics.Clear(Color.Black);
                e.Graphics.FillRectangle(Brushes.Red, new Rectangle(movimentoPlayer._xPos,
                    movimentoPlayer._yPos,
                    (int)EMedidasEntidade.LARGURA,
                    (int)EMedidasEntidade.ALTURA));
            }
            catch (Exception ex)
            {
                MessageBox.Show(Mensagens.ErroDeRender(ex),
                    Mensagens.Erro, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static Font FonteDaTela(int tamanho)
        {
            Font fonte = new Font("CONSOLAS", tamanho);
            return fonte;
        }
    }
}
