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
    public class PaisServicio
    {
        private readonly IMapper _mapper;
        private readonly WorldMenuContext _context;
        private readonly IValidator<PaisDto> _validator;

        public PaisServicio(IMapper mapper, WorldMenuContext context, IValidator<PaisDto> validator)
        {
            this._mapper = mapper;
            this._context = context;
            this._validator = validator;
        }

        public async Task<List<PaisDto>> GetPaises()
        {
            List<Pais> paises = await _context.Pais.ToListAsync();

            List<PaisDto> paisesDto = _mapper.Map<List<PaisDto>>(paises);

            return paisesDto;
        }

        public async Task<PaisDto> GetPais(int id)
        {
            Pais? pais = await _context.Pais.Where(rec => rec.Id == id).FirstOrDefaultAsync();

            PaisDto paisDto = _mapper.Map<PaisDto>(pais);

            return paisDto;
        }

        public async Task CreatePais(PaisDto paisDto)
        {
            Pais pais = new Pais();

            var validationResult = await _validator.ValidateAsync(paisDto);

            if (validationResult.IsValid)
            {
                pais = _mapper.Map<Pais>(paisDto);

                await _context.AddAsync(pais);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Se produjo un error al crear el Pais: " + validationResult.Errors);
            }
        }

        public async Task EditPais(PaisDto paisDto)
        {
            Pais pais = await _context.Pais.FindAsync(paisDto.Id);

            var validationResult = await _validator.ValidateAsync(paisDto);

            if (validationResult.IsValid)
            {
                _mapper.Map(paisDto, pais);

                _context.Update(pais);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Se produjo un error al editar el Pais: " + validationResult.Errors);
            }
        }

        public async Task DeletePais(int id)
        {
            Pais? pais = await _context.Pais.Where(rec => rec.Id == id).FirstOrDefaultAsync();

            if(pais != null)
            {
                _context.Remove(pais);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Se produjo un error al eliminar el Pais");
            }
        }
    }
}
