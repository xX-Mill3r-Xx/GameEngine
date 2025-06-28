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
        #region Static Properties

        private static Image _playerImage;
        private static Image _inimigoImage;
        private static Image _projetilImage;

        #endregion

        public static Image PlayerImage
        {
            get
            {
                if (_playerImage == null)
                {
                    try
                    {
                        _playerImage = Properties.Resources.player;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
                return _playerImage;
            }
        }

        public static Image InimigoImage
        {
            get
            {
                if (_inimigoImage == null)
                {
                    try
                    {
                        _inimigoImage = Properties.Resources.inimigo;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
                return _inimigoImage;
            }
        }

        public static Image ProjetilImage
        {
            get
            {
                if (_projetilImage == null)
                {
                    try
                    {
                        _projetilImage = Properties.Resources.projetil;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
                return _projetilImage;
            }
        }

        public static void DesenharJogo(PaintEventArgs e, MovimentacaoPlayer movimentoPlayer)
        {
            try
            {
                e.Graphics.Clear(Color.Black);

                if (PlayerImage != null)
                {
                    Rectangle playerRect = new Rectangle(
                    movimentoPlayer._xPos,
                    movimentoPlayer._yPos,
                    (int)EMedidasEntidade.LARGURA,
                    (int)EMedidasEntidade.ALTURA
                    );

                    e.Graphics.DrawImage(PlayerImage, playerRect);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Red, new Rectangle(
                    movimentoPlayer._xPos,
                    movimentoPlayer._yPos,
                    (int)EMedidasEntidade.LARGURA,
                    (int)EMedidasEntidade.ALTURA
                    ));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Mensagens.ErroDeRender(ex),
                    Mensagens.Erro, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DesenharInimigo(Graphics g, int x, int y)
        {
            try
            {
                if (InimigoImage != null)
                {
                    Rectangle inimigoRect = new Rectangle(
                        x, y,
                        (int)EMedidasEntidade.LARGURA,
                        (int)EMedidasEntidade.ALTURA
                        );
                    g.DrawImage(InimigoImage, inimigoRect);
                }
                else
                {
                    g.FillRectangle(Brushes.Green, new Rectangle(
                        x, y,
                        (int)EMedidasEntidade.LARGURA,
                        (int)EMedidasEntidade.ALTURA
                        ));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Mensagens.ErroDeRender(ex),
                    Mensagens.Erro, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DesenharProjetil(Graphics g, int x, int y)
        {
            try
            {
                if (ProjetilImage != null)
                {
                    Rectangle projectilRect = new Rectangle(
                        x, y,
                        (int)EMedidasProjeteis.LARGURA,
                        (int)EMedidasProjeteis.ALTURA
                        );
                    g.DrawImage(ProjetilImage, projectilRect);
                }
                else
                {
                    g.FillRectangle(Brushes.Yellow, new Rectangle(
                        x, y,
                        (int)EMedidasProjeteis.LARGURA,
                        (int)EMedidasProjeteis.ALTURA
                        ));
                }
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

        public static void LimparRecursos()
        {
            _playerImage?.Dispose();
            _inimigoImage?.Dispose();
            _projetilImage?.Dispose();

            _playerImage = null;
            _inimigoImage = null;
            _projetilImage = null;
        }
    }
}
