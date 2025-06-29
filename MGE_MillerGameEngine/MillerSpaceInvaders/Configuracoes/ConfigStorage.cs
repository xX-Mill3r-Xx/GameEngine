using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using MillerSpaceInvaders.Enumeradores;
using System.IO;

namespace MillerSpaceInvaders.Configuracoes
{
    public static class ConfigStorage
    {
        #region Static Properties

        private static readonly string _caminhoArquivo = "configuracoes.json";

        #endregion

        public static void Salvar()
        {
            var json = JsonSerializer.Serialize(new
            {
                Dificuldade = ConfiguracoesDoJogo.Dificuldade.ToString()
            });

            File.WriteAllText(_caminhoArquivo, json);
        }

        public static void Carregar()
        {
            if (!File.Exists(_caminhoArquivo))
                return;

            var json = File.ReadAllText(_caminhoArquivo);

            try
            {
                var objeto = JsonSerializer.Deserialize<ConfiguracaoSalva>(json);
                if (Enum.TryParse<ENivelDificuldade>(objeto.Dificuldade, out var nivel))
                    ConfiguracoesDoJogo.Dificuldade = nivel;
            }
            catch
            {

            }
        }

        private class ConfiguracaoSalva 
        {
            #region Properties
            public string Dificuldade { get; set; }
            #endregion
        }
    }
}
