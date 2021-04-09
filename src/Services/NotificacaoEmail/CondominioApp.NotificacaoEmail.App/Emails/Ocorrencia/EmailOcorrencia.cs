﻿using CondominioApp.NotificacaoEmail.App.DTO;
using CondominioApp.NotificacaoEmail.App.Service;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominioApp.NotificacaoEmail.Api.Email
{
    public class EmailOcorrencia : ServicoDeEmail
    {   
        private OcorrenciaDTO _ocorrencia;        
        private string _logoCondominioApp = "https://condominioappstorage.blob.core.windows.net/condominioapp/Uploads/usuario/572d0886-11c4-4fb3-b806-0d7cf6695bc8.png";

        public EmailOcorrencia(OcorrenciaDTO ocorrencia)
        {
            _ocorrencia = ocorrencia;           

            var conteudo = SubstituirValores();

            ConstruirEmail(_ocorrencia.Titulo, conteudo);
        }

        public override string SubstituirValores()
        {
            var CaminhoDoHtml = "wwwroot\\Emails\\Ocorrencia\\ocorrencia.html";

            var conteudoDoHtmlDoEmail = File.ReadAllText(CaminhoDoHtml);

            if (string.IsNullOrEmpty(_ocorrencia.LogoDoCondominio) || _ocorrencia.LogoDoCondominio == "https://i.imgur.com/gxXxUm7.png")
                _ocorrencia.LogoDoCondominio = _logoCondominioApp;

            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_titulo_", _ocorrencia.Titulo);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_nomeCondominio_", _ocorrencia.NomeCondominio);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_descricao_", _ocorrencia.Descricao);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_nomeMorador_", _ocorrencia.NomeMorador);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_unidadeMorador_", _ocorrencia.UnidadeDescricao);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_statusPrivacidade_", _ocorrencia.StatusPrivacidade);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_statusOcorrencia_", _ocorrencia.StatusOcorrencia);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_dataCadastro_", _ocorrencia.DataDeCadastro);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_logoCondominio_", _ocorrencia.LogoDoCondominio);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_logoCondominioApp_", _logoCondominioApp);
            conteudoDoHtmlDoEmail = conteudoDoHtmlDoEmail.Replace("_foto_", RetornaFotoHtml());

            return conteudoDoHtmlDoEmail;
        }

        private string RetornaFotoHtml()
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(_ocorrencia.Foto))
                return sb.ToString();

            var html =$@"<br /><br /><table cellpadding = ""0"" cellspacing = ""0"" width = ""100%"" role = ""presentation"" style = ""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                            <tr style = ""border-collapse:collapse"">
                                <td align=""center"" style=""padding: 0; Margin: 0; font - size:0px"">
                                    <img class=""adapt - img"" src = ""{_ocorrencia.Foto}"" alt style = ""display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic"" width = ""100%"">
                                </td>
                            </tr>
                          </table>";

            sb.Append(html);

            sb.Append("<br />");

            return sb.ToString();
        }

        public override async Task EnviarEmail()
        {
            if (_ocorrencia.ListaDeEmails.Count() == 0)
                return;

            foreach (var email in _ocorrencia.ListaDeEmails)
            {
                _Email.Bcc.Add(email);                
            }      
            
            await Task.Run(() => base.Send(_Email));
        }
    }
}