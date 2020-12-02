﻿using CondominioApp.Enquetes.App.Aplication.Commands.Validations;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
   public class RemoverEnqueteCommand : EnqueteCommand
    {

        public RemoverEnqueteCommand(Guid enqueteId)
        {
            Id = enqueteId;           
        }


        public override bool EstaValido()
        {
            ValidationResult = new RemoverEnqueteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RemoverEnqueteCommandValidation : EnqueteValidation<RemoverEnqueteCommand>
        {
            public RemoverEnqueteCommandValidation()
            {
                ValidateId();                         
            }
        }

    }
}
