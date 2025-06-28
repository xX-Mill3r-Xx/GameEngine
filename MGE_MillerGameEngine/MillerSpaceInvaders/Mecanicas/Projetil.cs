using MillerSpaceInvaders.Enumeradores;
using System.Drawing;

namespace MillerSpaceInvaders.Mecanicas
{
    public class Projetil
    {
        #region Properties

        public int _xPos { get; set; }
        public int _yPos { get; set; }
        private int _velocidade = 10;

        #endregion

        public Projetil(int spawnX, int spawnY)
        {
            _xPos = spawnX;
            _yPos = spawnY;
        }

        public void Atualizar()
        {
            _yPos -= _velocidade;
        }

        public bool ForaDaTela(int alturaTela)
        {
            return _yPos < alturaTela;
        }

        public void Desenhar(Graphics g)
        {
            g.FillRectangle(Brushes.Yellow,
                new Rectangle(_xPos, _yPos,
                (int)EMedidasProjeteis.LARGURA,
                (int)EMedidasProjeteis.ALTURA));
        }
    }
}
