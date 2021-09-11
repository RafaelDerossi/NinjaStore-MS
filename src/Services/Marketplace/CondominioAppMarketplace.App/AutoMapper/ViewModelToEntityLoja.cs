﻿using AutoMapper;
using CondominioAppMarketplace.Domain.ValueObjects;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;

namespace CondominioAppMarketplace.App.AutoMapper
{
    public class ViewModelToEntityLoja : Profile
    {
        public ViewModelToEntityLoja()
        {
            CreateMap<VendedorViewModel, Vendedor>()
                    .ConstructUsing(vendedor => new Vendedor(vendedor.Nome, vendedor.ParceiroId, new Email(vendedor.EmailDoVendedor), new Cpf(vendedor.CpfDoVendedor), new Telefone(vendedor.TelefoneDoVendedor, vendedor.Whatsapp),
                                  new Endereco(vendedor.logradouro, vendedor.complemento, vendedor.numero, vendedor.cep, vendedor.bairro, vendedor.cidade, vendedor.estado)));


            CreateMap<ItemDeVendaViewModel, ItemDeVenda>()
                .ConstructUsing(itemDeVenda => new ItemDeVenda(itemDeVenda.PrecoDoProduto, itemDeVenda.PorcentagemDeDesconto, itemDeVenda.DataDeInicioDaExposicao, itemDeVenda.DataDeFinalDaExposicao,
                                        itemDeVenda.ProdutoId, itemDeVenda.VendedorId, itemDeVenda.ParceiroId));


            CreateMap<CampanhaNovaViewModel, Campanha>()
                .ConstructUsing(campanha => new Campanha(campanha.Titulo, campanha.Descricao, campanha.Banner, campanha.DataDeInicio, campanha.DataDeFim, campanha.Ativo, campanha.ItemDeVendaId));


            CreateMap<LeadNovoViewModel, Lead>()
                .ConstructUsing(lead => new Lead(lead.NomeDoCondominio, lead.NomeDoCliente, lead.Bloco, lead.Unidade, lead.Observacao,
                                        new Telefone(lead.TelefoneDoCliente, false), new Email(lead.EmailDoMorador), lead.ItemDeVendaId));
        }
    }
}
