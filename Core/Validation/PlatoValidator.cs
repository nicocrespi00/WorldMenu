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
    public class PlatoValidator : AbstractValidator<PlatoDto>
    {
        public PlatoValidator()
        {
            RuleFor(ingrediente => ingrediente.Nombre).NotEmpty().WithMessage("El nombre del plato no puede estar vacío");
        }

    }
}
