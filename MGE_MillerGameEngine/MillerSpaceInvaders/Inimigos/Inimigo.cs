using MillerSpaceInvaders.Enumeradores;
using MillerSpaceInvaders.Mecanicas;
using System;
using System.Drawing;

namespace MillerSpaceInvaders.Inimigos
{
    public class Inimigo
    {
        #region Properties

        public int _xPos { get; set; }
        public int _yPos { get; set; }
        private int _velocidade;
        private MovimentacaoPlayer _player;

        #endregion

        public Inimigo(int spawnX, int spawnY, int velocidade, MovimentacaoPlayer player)
        {
            _xPos = spawnX;
            _yPos = spawnY;
            _velocidade = velocidade;
            _player = player;
        }

        public void Atualizar()
        {
            int deltaX = _player._xPos - _xPos;
            int deltaY = _player._yPos - _yPos;
            double distancia = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            if (distancia > 0)
            {
                _xPos += (int)(_velocidade * (deltaX / distancia));
                _yPos += (int)(_velocidade * (deltaY / distancia));
            }
        }

        public bool DetectaColisao()
        {
            Rectangle inimigoRect = new Rectangle(_xPos, _yPos,
                (int)EMedidasEntidade.LARGURA, (int)EMedidasEntidade.ALTURA);

            Rectangle playerRect = new Rectangle(_player._xPos, _player._yPos,
                (int)EMedidasEntidade.LARGURA, (int)EMedidasEntidade.ALTURA);

            return inimigoRect.IntersectsWith(playerRect);
        }

        public void Desenhar(Graphics g)
        {
            g.FillRectangle(Brushes.Blue, new Rectangle(_xPos, _yPos,
                (int)EMedidasEntidade.LARGURA, (int)EMedidasEntidade.ALTURA));
        }
    }
}
