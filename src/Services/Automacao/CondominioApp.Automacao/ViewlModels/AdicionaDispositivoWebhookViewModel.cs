﻿using System;

namespace CondominioApp.Automacao.ViewModel
{
   public class AdicionaDispositivoWebhookViewModel
    {   
        public string Nome { get; set; }        
        public string UrlLigar { get; set; }
        public string UrlDesligar { get; set; }
        public Guid CondominioId { get; set; }        
    }
}
