﻿using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class ApagarVisitaCommand : VisitaCommand
    {
        public ApagarVisitaCommand(Guid id)
        {
            Id = id;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new ApagarVisitaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class ApagarVisitaCommandValidation : VisitaValidation<ApagarVisitaCommand>
        {
            public ApagarVisitaCommandValidation()
            {
                ValidateId();
            }
        }

    }
}
