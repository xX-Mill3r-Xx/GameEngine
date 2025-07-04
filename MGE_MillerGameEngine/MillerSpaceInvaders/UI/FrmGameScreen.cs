﻿using MillerSpaceInvaders.Configuracoes;
using MillerSpaceInvaders.Enumeradores;
using MillerSpaceInvaders.Inimigos;
using MillerSpaceInvaders.Mecanicas;
using MillerSpaceInvaders.Render;
using MillerSpaceInvaders.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MillerSpaceInvaders
{
    public partial class Form1 : Form
    {
        #region Properties

        private MovimentacaoPlayer _movimento;
        private List<Inimigo> _inimigos;
        private List<Projetil> _projeteis;
        private Random _rndSpawnInimigos;
        private int _pontuacao = 0;
        private bool _jogoPausado = false;

        #endregion

        #region Constructors

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;

            ConfigurarPictureBox();

            _movimento = new MovimentacaoPlayer((int)EPosicaoStart.X, (int)EPosicaoStart.Y);
            _inimigos = new List<Inimigo>();
            _projeteis = new List<Projetil>();
            _rndSpawnInimigos = new Random();

            tTemporizador.Enabled = true;
            tTemporizador.Interval = 16;
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigStorage.Carregar();
        }

        private void ConfigurarPictureBox()
        {
            typeof(PictureBox).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, pbTela, new object[] { true });

            pbTela.BackColor = Color.Black;
            pbTela.Paint += pbTela_Paint;
        }

        private void GameOver()
        {
            try
            {
                tTemporizador.Enabled = false;
                var result = MessageBox.Show(Mensagens.MensagemDegameOver(_pontuacao),
                    Mensagens.GameOver, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    ReiniciarGame();
                else
                    Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    Mensagens.Erro, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReiniciarGame()
        {
            _movimento = new MovimentacaoPlayer((int)EPosicaoStart.X, (int)EPosicaoStart.Y);
            _inimigos.Clear();
            _projeteis.Clear();
            _pontuacao = 0;
            tTemporizador.Enabled = true;
        }

        private void AdicionarPontuacao(int pontuacao)
        {
            _pontuacao += pontuacao;
        }

        private void SpawnarInimigos()
        {
            int spawnX = _rndSpawnInimigos.Next(0, pbTela.Width - 50);
            _inimigos.Add(new Inimigo(spawnX, 0, _movimento));
        }

        private void tTemporizador_Tick(object sender, EventArgs e)
        {
            if (_jogoPausado)
                return;

            if (!tTemporizador.Enabled)
                return;

            _movimento.AtualizarMovimento(pbTela.Width, pbTela.Height);

            for (int i = _projeteis.Count - 1; i >= 0; i--)
            {
                _projeteis[i].Atualizar();
                if (_projeteis[i].ForaDaTela(pbTela.Height))
                    _projeteis.RemoveAt(i);
            }

            for (int i = _inimigos.Count - 1; i >= 0; i--)
            {
                _inimigos[i].Atualizar();
                if (_inimigos[i].DetectaColisao())
                {
                    _movimento.ReceberHit(ObterDano());
                    _inimigos.RemoveAt(i);

                    if (_movimento._vida == 0)
                    {
                        GameOver();
                        return;
                    }
                }

                for (int j = _projeteis.Count - 1; j >= 0; j--)
                {
                    Rectangle inimigoRect = new Rectangle(_inimigos[i]._xPos, _inimigos[i]._yPos,
                        (int)EMedidasEntidade.LARGURA, (int)EMedidasEntidade.ALTURA);

                    Rectangle projetilrect = new Rectangle(_projeteis[j]._xPos, _projeteis[j]._yPos,
                        (int)EMedidasProjeteis.LARGURA, (int)EMedidasProjeteis.ALTURA);

                    if (inimigoRect.IntersectsWith(projetilrect))
                    {
                        _inimigos.RemoveAt(i);
                        _projeteis.RemoveAt(j);
                        AdicionarPontuacao(10);
                        break;
                    }
                }
            }

            if (_rndSpawnInimigos.Next(0, 100) < 5)
                SpawnarInimigos();

            pbTela.Invalidate();
        }

        private int ObterDano()
        {
            switch (ConfiguracoesDoJogo.Dificuldade)
            {
                case ENivelDificuldade.Facil: return 5;
                case ENivelDificuldade.Medio: return 10;
                case ENivelDificuldade.Dificil: return 20;
                default: return 10;
            }
        }

        private void pbTela_Paint(object sender, PaintEventArgs e)
        {
            PropiedadesDetela.DesenharJogo(e, _movimento);

            foreach (var inimigo in _inimigos)
            {
                inimigo.Desenhar(e.Graphics);
            }

            foreach (var projetil in _projeteis)
            {
                projetil.Desenhar(e.Graphics);
            }

            Font fonte = PropiedadesDetela.FonteDaTela(9);
            e.Graphics.DrawString(Mensagens.InformaVidaPlayer(_movimento), fonte, Brushes.Red, 10, 9);
            e.Graphics.DrawString(Mensagens.InformaPontuacao(_pontuacao), fonte, Brushes.White, 480, 9);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_jogoPausado)
            {
                _movimento.PressionarTecla(e);
                if (e.KeyCode == Keys.Enter)
                    _projeteis.Add(new Projetil(_movimento._xPos + 20, _movimento._yPos));
            }

            if (e.KeyCode == Keys.Escape)
            {
                _jogoPausado = !_jogoPausado;
                if (_jogoPausado)
                {
                    MessageBox.Show(Mensagens.PauseGame ,
                        Mensagens.Pause, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tTemporizador.Stop();
                }
                else
                {
                    tTemporizador.Start();
                }
                pbTela.Invalidate();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!_jogoPausado)
            {
                _movimento.SoltarTecla(e);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            PropiedadesDetela.LimparRecursos();
            pbTela.BackgroundImage?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
