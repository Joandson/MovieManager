using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MovieManager.Core.Domain;
using MovieManager.ViewModels;

namespace MovieManager.App_Start
{
    public static class MappingProfile
    {
        public static void ConfigureUserMapping()
        {

            Mapper.Initialize(cfg =>
            {
                /* Custom Mapping will go here ex:Below */
                //cfg.CreateMap<Person, PersonViewModel>().ReverseMap();
                cfg.CreateMap<Filme, FilmeViewModel>().ReverseMap();
                cfg.CreateMap<Genero, GeneroViewModel>().ReverseMap();
            });
        }
    }
}