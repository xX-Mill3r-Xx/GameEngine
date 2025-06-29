using MillerSpaceInvaders.Util;
using System;
using System.Windows.Forms;

namespace MillerSpaceInvaders.Mecanicas
{
    public class MovimentacaoPlayer
    {
        #region Properties

        private bool _cima, _baixo, _esquerda, _direita;
        public int _xPos { get; set; }
        public int _yPos { get; set; }
        private int _velocidade = 5;
        public double _vida { get; set; }

        #endregion

        public MovimentacaoPlayer(int posXinicial, int posYinicial)
        {
            _xPos = posXinicial;
            _yPos = posYinicial;
            _vida = 100.0;
        }

        public void ReceberHit(int valor)
        {
            _vida -= valor;
            if(_vida < 0)
                _vida = 0;
        }

        public void PressionarTecla(KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.W)
                    _cima = true;
                if (e.KeyCode == Keys.S)
                    _baixo = true;
                if (e.KeyCode == Keys.A)
                    _esquerda = true;
                if (e.KeyCode == Keys.D)
                    _direita = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Mensagens.ErroDeExecucao(ex),
                    Mensagens.Erro, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SoltarTecla(KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.W)
                    _cima = false;
                if (e.KeyCode == Keys.S)
                    _baixo = false;
                if (e.KeyCode == Keys.A)
                    _esquerda = false;
                if (e.KeyCode == Keys.D)
                    _direita = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Mensagens.ErroDeExecucao(ex),
                    Mensagens.Erro, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AtualizarMovimento(int larguraTela, int alturaTela)
        {
            AtualizarVelocidadeMovimento();
            AtualizaPosicaoMovimento(larguraTela, alturaTela);
        }

        private void AtualizarVelocidadeMovimento()
        {
            if (_cima)
                _yPos -= _velocidade;
            if (_baixo)
                _yPos += _velocidade;
            if (_esquerda)
                _xPos -= _velocidade;
            if (_direita)
                _xPos += _velocidade;
        }

        private void AtualizaPosicaoMovimento(int larguraTela, int alturaTela)
        {
            if (_xPos < 0)
                _xPos = 0;
            if (_yPos < 0)
                _yPos = 0;
            if (_xPos > larguraTela - 50)
                _xPos = larguraTela - 50;
            if (_yPos > alturaTela - 50)
                _yPos = alturaTela - 50;
        }
    }
}
