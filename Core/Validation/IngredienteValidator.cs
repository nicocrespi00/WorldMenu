using BackendWM.Entities;
using Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validation
{
    public class IngredienteValidator : AbstractValidator<IngredienteDto>
    {
        public IngredienteValidator()
        {
            RuleFor(ingrediente => ingrediente.Nombre).NotEmpty().WithMessage("El nombre del ingrediente no puede estar vacío");
        }

    }
}
