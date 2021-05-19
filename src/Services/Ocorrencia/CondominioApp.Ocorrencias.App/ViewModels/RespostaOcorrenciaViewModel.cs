﻿using System;

namespace CondominioApp.Ocorrencias.App.Models
{
  public class RespostaOcorrenciaViewModel
    {
        public Guid Id { get; set; }

        public string DataDeCadastro { get; set; }

        public string DataDeAlteracao { get; set; }

        public bool Lixeira { get; set; }

        public string Descricao { get; set; }

        public string TipoAutor { get; set; }

        public Guid MoradorIdFuncionarioId { get; set; }

        public string NomeUsuario { get; set; }

        public string FotoUsuarioUrl { get; set; }

        public bool Visto { get; set; }

        public string FotoUrl { get; set; }
    }
}
