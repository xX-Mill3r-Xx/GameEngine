using MillerSpaceInvaders.Enumeradores;
using MillerSpaceInvaders.Mecanicas;
using MillerSpaceInvaders.Util;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MillerSpaceInvaders.Render
{
    public static class PropiedadesDetela
    {
        #region Static Properties

        private static Image _playerImage;
        private static Image _inimigoImage;
        private static Image _projetilImage;
        private static Image _backGroundImage;
        private static Random _starRandom = new Random(42);

        #endregion

        public static Image BackGroundImage
        {
            get
            {
                if (_backGroundImage == null)
                {
                    try
                    {
                        _backGroundImage = Properties.Resources.background;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
                return _backGroundImage;
            }
        }

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
                //e.Graphics.Clear(Color.DarkBlue);

                //DesenharFundoDeTelaGradiente(e.Graphics, e.ClipRectangle);

                //DesenharFundoImagem(e.Graphics, e.ClipRectangle);

                DesenharFundoEstrelas(e.Graphics, e.ClipRectangle);

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
            _backGroundImage?.Dispose();

            _playerImage = null;
            _inimigoImage = null;
            _projetilImage = null;
            _backGroundImage = null;
        }

        private static void DesenharFundoDeTelaGradiente(Graphics g, Rectangle area)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                area,
                Color.DarkBlue,
                Color.Black,
                LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, area);
            }
        }

        private static void DesenharFundoImagem(Graphics g, Rectangle area)
        {
            if (BackGroundImage != null)
            {
                g.DrawImage(BackGroundImage, area);
            }
            else
            {
                g.Clear(Color.Black);
            }
        }

        private static void DesenharFundoEstrelas(Graphics g, Rectangle area)
        {
            g.Clear(Color.Black);

            Brush starBrush = Brushes.White;
            int numeroEstrelas = 100;

            _starRandom = new Random(42);

            for (int i = 0; i < numeroEstrelas; i++)
            {
                int x = _starRandom.Next(0, area.Width);
                int y = _starRandom.Next(0, area.Height);
                int tamanho = _starRandom.Next(1, 3);

                g.FillEllipse(starBrush, x,y, tamanho, tamanho);
            }
        }
    }
}
