﻿using AutoMapper;
using BackendWM.Entities;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapper
{
    public class IngredienteMapper : Profile
    {
        public IngredienteMapper()
        {
            CreateMap<Ingrediente, IngredienteDto>().ReverseMap();
        }
    }
}
