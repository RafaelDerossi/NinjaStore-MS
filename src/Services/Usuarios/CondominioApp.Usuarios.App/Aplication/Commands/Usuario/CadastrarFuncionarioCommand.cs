﻿using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class CadastrarFuncionarioCommand : UsuarioCommand
    {
        public CadastrarFuncionarioCommand(Guid usuarioId, string nome, string sobrenome, string email,
            Guid condominioId, string nomeCondominio, string foto, string nomeOriginal, string rg = null,
            string cpf = null, string cel = null, string tel = null, string atribuicao = null, string funcao = null,
            string logradouro = null, string complemento = null, string numeroEndereco = null,
            string cep = null, string bairro = null, string cidade = null, string estado = null,
            DateTime? dataNascimento = null, Permissao permissao = Permissao.USUARIO)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;
            Rg = rg;
            DataNascimento = dataNascimento;
            
            Permissao = permissao;

            CondominioId = condominioId;
            NomeCondominio = nomeCondominio;            

            Atribuicao = atribuicao;
            Funcao = funcao;
            Proprietario = false;
            Principal = false;

            SetCpf(cpf);
            SetCelular(cel);
            SetTelefone(tel);
            SetEmail(email);
            SetFoto(foto, nomeOriginal);
            SetEndereco(logradouro, complemento, numeroEndereco, cep, bairro, cidade, estado);
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarFuncionarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarFuncionarioCommandValidation : UsuarioValidation<CadastrarFuncionarioCommand>
        {
            public CadastrarFuncionarioCommandValidation()
            {
                ValidateId();
                ValidateCondominioId();
                ValidateNome();
                ValidateSobrenome();
                ValidateEmail();
                ValidateAtribuicao();
                ValidateFuncao();
            }
        }

    }
}