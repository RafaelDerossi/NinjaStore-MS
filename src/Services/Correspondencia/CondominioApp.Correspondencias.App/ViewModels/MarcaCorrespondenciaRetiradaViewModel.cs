﻿using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Correspondencias.App.ViewModels
{
   public class MarcaCorrespondenciaRetiradaViewModel
    {
        public Guid Id { get; set; }

        public string NomeRetirante { get; set; }

        public Guid UsuarioId { get; set; }

        public string NomeUsuario { get; set; }

        public string Observacao { get; set; }    
    }
}
