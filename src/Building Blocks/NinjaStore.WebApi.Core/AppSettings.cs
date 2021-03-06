namespace NinjaStore.WebApi.Core
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
        public string LinkConfirmacaoDeCadastro { get; set; }
        public string LinkCompleteCadastro { get; set; }
        public string LinkRedefinirSenha { get; set; }
        public string UrlNinjaStoreClienteApi { get; set; }        
    }
}