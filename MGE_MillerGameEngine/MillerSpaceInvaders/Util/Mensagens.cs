using System;

namespace MillerSpaceInvaders.Util
{
    public static class Mensagens
    {
        public static string Erro => "Erro";
        public static string GameOver => "Game Over!";

        public static string ErroDeExecucao(Exception ex)
        {
            var msg = $"Erro de execução: {ex.Message}";
            return msg;
        }

        public static string ErroDeRender(Exception ex)
        {
            var msg = $"Erro ao tentar renderizar a tela: {ex.Message}";
            return msg;
        }

        public static string MensagemDegameOver(int pontuacao)
        {
            var msg = $"Game Over! Sua Pontuação: {pontuacao}\nDeseja reiniciar?";
            return msg;
        }
    }
}
