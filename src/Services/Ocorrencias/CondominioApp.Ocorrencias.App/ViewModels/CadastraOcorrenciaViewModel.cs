﻿using System;

namespace CondominioApp.Ocorrencias.App.ViewModels
{
    public class CadastraOcorrenciaViewModel
    {        
        public string Descricao { get; set; }
        public string NomeOriginalFoto { get; set; }
        public string NomeFoto { get; set; }
        public bool Publica { get; set; }

        public Guid UnidadeId { get; set; }
        public Guid MoradorId { get; set; }                        
        
        public bool Panico { get; set; }       

    }
}
