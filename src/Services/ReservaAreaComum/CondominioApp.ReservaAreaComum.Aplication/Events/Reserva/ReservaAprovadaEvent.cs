﻿using System;

namespace CondominioApp.ReservaAreaComum.Aplication.Events
{
   public class ReservaAprovadaEvent : ReservaEvent
    {

        public ReservaAprovadaEvent
            (Guid reservaId, string justificativa)
        {            
            Id = reservaId;
            Justificativa = justificativa;
        }

    }
}
