﻿using System.Net;
using System.Net.Mail;

namespace CondominioApp.Identidade.Api.Email
{
    public class SmtpSendBlue : SmtpClient
    {
        public SmtpSendBlue()
            : base("smtp-relay.sendinblue.com", 587)
        {
            Credentials = new NetworkCredential("portaltechdog@gmail.com", "Ys05HpFrPJyMt1dW");
        }
    }
}