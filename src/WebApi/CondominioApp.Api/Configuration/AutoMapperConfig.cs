﻿using CondominioApp.Correspondencias.App.AutoMapper;
using CondominioApp.Enquetes.App.AutoMapper;
using CondominioApp.ReservaAreaComum.Aplication.AutoMapper;
using CondominioAppMarketplace.App.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CondominioApp.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void ConfigurarAutoMapper(this IServiceCollection services)
        {

            //Configuração AutoMapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToViewModelLoja());
                cfg.AddProfile(new ViewModelToEntityLoja());
                cfg.AddProfile(new EntityToViewModelEnquete());
                cfg.AddProfile(new EntityToViewModelCorrespondencia());
                cfg.AddProfile(new ViewModelToEntityComunicado());
                cfg.AddProfile(new EntityToViewModelComunicado());
                cfg.AddProfile(new ViewModelToEntityAreaComum());

                //cfg.AddProfile(new EntityToViewModelEstatistica());
                //cfg.AddProfile(new ViewModelToEntityEstatistica());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }              
    }  
}