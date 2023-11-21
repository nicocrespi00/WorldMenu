using AutoMapper;
using BackendWM.Data;
using BackendWM.Entities;
using Core.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class IngredienteServicio
    {
        private readonly IMapper _mapper;
        private readonly WorldMenuContext _context;
        private readonly IValidator<IngredienteDto> _validator;

        public IngredienteServicio(IMapper mapper, WorldMenuContext context, IValidator<IngredienteDto> validator)
        {
            this._mapper = mapper;
            this._context = context;
            this._validator = validator;
        }

        public async Task<List<IngredienteDto>> GetIngredientes()
        {
            List<Ingrediente> ingredientes = await _context.Ingrediente.ToListAsync();

            List<IngredienteDto> ingredientesDto = _mapper.Map<List<IngredienteDto>>(ingredientes);

            return ingredientesDto;
        }

        public async Task<IngredienteDto> GetIngrediente(int id)
        {
            Ingrediente? ingrediente = await _context.Ingrediente.Where(rec => rec.Id == id).FirstOrDefaultAsync();

            IngredienteDto ingredienteDto = _mapper.Map<IngredienteDto>(ingrediente);

            return ingredienteDto;
        }

        public async Task CreateIngrediente(IngredienteDto ingredienteDto)
        {
            Ingrediente ingrediente = new Ingrediente();

            var validationResult = await _validator.ValidateAsync(ingredienteDto);

            if (validationResult.IsValid)
            {
                ingrediente = _mapper.Map<Ingrediente>(ingredienteDto);

                await _context.AddAsync(ingrediente);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Se produjo un error al crear el ingrediente: " + validationResult.Errors);
            }
        }

        public async Task EditIngrediente(IngredienteDto ingredienteDto)
        {
            Ingrediente ingrediente = await _context.Ingrediente.FindAsync(ingredienteDto.Id);

            var validationResult = await _validator.ValidateAsync(ingredienteDto);

            if (validationResult.IsValid)
            {
                _mapper.Map(ingredienteDto, ingrediente);

                _context.Update(ingrediente);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Se produjo un error al editar el ingrediente: " + validationResult.Errors);
            }
        }

        public async Task DeleteIngrediente(int id)
        {
            Ingrediente? ingrediente = await _context.Ingrediente.Where(rec => rec.Id == id).FirstOrDefaultAsync();

            if(ingrediente != null)
            {
                List<PlatoIngrediente> platoIngredientes = await _context.PlatoIngrediente.Where(rec => rec.IngredienteId == id).ToListAsync();

                if (platoIngredientes != null && platoIngredientes.Count > 0)
                {
                    foreach (PlatoIngrediente platoIngrediente in platoIngredientes)
                    {
                        _context.Remove(platoIngrediente);
                    }
                }

                _context.Remove(ingrediente);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Se produjo un error al eliminar el ingrediente");
            }
        }
    }
}
