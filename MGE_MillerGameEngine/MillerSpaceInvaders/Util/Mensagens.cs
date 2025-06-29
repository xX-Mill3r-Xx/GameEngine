using MillerSpaceInvaders.Mecanicas;
using System;

namespace MillerSpaceInvaders.Util
{
    public static class Mensagens
    {
        public static string Erro => "Erro";
        public static string GameOver => "Game Over!";
        public static string Sucesso => "Sucesso";
        public static string ConfiguracaoSalva => "Configurações salva com sucesso!";
        public static string PauseGame => "Jogo pausado, ESC para continuar.";
        public static string Pause => "Pause";

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

        public static string InformaVidaPlayer(MovimentacaoPlayer player)
        {
            var msg = $"Vida: {player._vida}";
            return msg;
        }

        public static string InformaPontuacao(int pontuacao)
        {
            var msg = $"Pontuação: {pontuacao}";
            return msg;
        }
    }
}
