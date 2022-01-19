﻿using AutoMapper;
using eLibrary.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.Mapping
{
    public class eLibraryProfile : Profile
    {
        public eLibraryProfile()
        {

            //Drzava
            CreateMap<Drzava, Model.Requests.Drzava.DrzavaInsertRequest>().ReverseMap();
            CreateMap<Drzava, Model.Drzava>().ReverseMap();
            //Grad
            CreateMap<Grad, Model.Requests.Grad.GradInsertRequest>().ReverseMap();
            CreateMap<Grad, Model.Grad>().ReverseMap();
            //Zanr
            CreateMap<Zanr, Model.Requests.Zanr.ZanrInsertRequest>().ReverseMap();
            CreateMap<Zanr, Model.Zanr>().ReverseMap();
            //Uloga
            CreateMap<Uloga, Model.Requests.Uloga.UlogaInsertRequest>().ReverseMap();
            CreateMap<Uloga, Model.Uloga>().ReverseMap();
            //Spol
            CreateMap<Spol, Model.Spol>().ReverseMap();
            //Pisac
            CreateMap<Pisac, Model.Requests.Pisac.PisacInsertRequest>().ReverseMap();
            CreateMap<Pisac, Model.Pisac>().ReverseMap();
            //Knjiga
            CreateMap<Knjiga, Model.Requests.Knjiga.KnjigaInsertRequest>().ReverseMap();
            CreateMap<Knjiga, Model.Knjiga>().ReverseMap();
            //Korisnik
            CreateMap<Korisnik, Model.Requests.Korisnik.KorisnikInsertRequest>().ReverseMap();
            CreateMap<Korisnik, Model.Korisnik>().ReverseMap();
        }
    }
}
