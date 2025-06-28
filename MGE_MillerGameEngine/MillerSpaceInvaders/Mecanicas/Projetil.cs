using MillerSpaceInvaders.Enumeradores;
using MillerSpaceInvaders.Render;
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
            return _yPos < 0;
        }

        public void Desenhar(Graphics g)
        {
            PropiedadesDetela.DesenharProjetil(g, _xPos, _yPos);
        }
    }
}
