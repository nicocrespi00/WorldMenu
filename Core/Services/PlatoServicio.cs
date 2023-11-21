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
    public class PlatoServicio
    {
        private readonly IMapper _mapper;
        private readonly WorldMenuContext _context;
        private readonly IValidator<PlatoDto> _validator;

        public PlatoServicio(IMapper mapper, WorldMenuContext context, IValidator<PlatoDto> validator)
        {
            this._mapper = mapper;
            this._context = context;
            this._validator = validator;
        }

        public async Task<List<PlatoDto>> GetPlatos()
        {
            List<Plato> platos = await _context.Plato.ToListAsync();

            List<PlatoDto> platosDto = _mapper.Map<List<PlatoDto>>(platos);

            foreach (var platoDto in platosDto)
            {

                platoDto.Ingrediente_Nombre = await CargarIngredientes(platoDto.Id);
            }

            return platosDto;
        }

        public async Task<PlatoDto> GetPlato(int id)
        {
            Plato? plato = await _context.Plato.Where(rec => rec.Id == id).FirstOrDefaultAsync();

            PlatoDto platoDto = _mapper.Map<PlatoDto>(plato);

            platoDto.Ingrediente_Nombre = await CargarIngredientes(plato.Id);

            return platoDto;
        }

        public async Task CreatePlato(PlatoDto platoDto)
        {
            Plato plato = new Plato();

            var validationResult = await _validator.ValidateAsync(platoDto);

            if (validationResult.IsValid)
            {
                plato = _mapper.Map<Plato>(platoDto);

                await _context.AddAsync(plato);

                await _context.SaveChangesAsync();

                await CrearPlatoIngrediente(platoDto, plato);
            }
            else
            {
                throw new Exception("Se produjo un error al crear el Plato: " + validationResult.Errors);
            }
        }

        public async Task CrearPlatoIngrediente(PlatoDto platoDto, Plato plato)
        {
            if (platoDto.IngredientePlatoSeleccionados != null && platoDto.IngredientePlatoSeleccionados.Count > 0)
            {
                foreach (var item in platoDto.IngredientePlatoSeleccionados)
                {
                    if (item.Seleccionado == true)
                    {
                        PlatoIngrediente ingredientePlatoDto = new PlatoIngrediente();
                        ingredientePlatoDto.IngredienteId = item.Idingrediente;
                        ingredientePlatoDto.PlatoId = plato.Id;
                        await _context.AddAsync(ingredientePlatoDto); 
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }

        public async Task EditPlato(PlatoDto platoDto)
        {
            Plato Plato = await _context.Plato.FindAsync(platoDto.Id);

            var validationResult = await _validator.ValidateAsync(platoDto);

            if (validationResult.IsValid)
            {
                await EditarPlatoIngrediente(platoDto.IngredientePlatoSeleccionados, platoDto.Id);

                _mapper.Map(platoDto, Plato);

                _context.Update(Plato);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Se produjo un error al editar el Plato: " + validationResult.Errors);
            }
        }

        private async Task EditarPlatoIngrediente(List<IngredientePlatoDto> ingredientePlatoDto, int id)
        {
            List<PlatoIngrediente> platoIngrediente = await _context.PlatoIngrediente.Where(rec => rec.PlatoId == id).ToListAsync();

            if (platoIngrediente != null && platoIngrediente.Count() > 0)
            {
                var idsNoSeleccionados = ingredientePlatoDto.Where(rec => !rec.Seleccionado).Select(rec => rec.Idingrediente);
                var itemsParaBorrar = platoIngrediente.Where(rec => idsNoSeleccionados.Contains(rec.IngredienteId));
                itemsParaBorrar.ToList().ForEach(rec => _context.Remove(rec));

                await _context.SaveChangesAsync();
            }

            for (int i = 0; i < ingredientePlatoDto.Count; i++)
            {
                if (ingredientePlatoDto[i].Seleccionado)
                {
                    bool existe = await _context.PlatoIngrediente.AnyAsync<PlatoIngrediente>(rec => rec.IngredienteId == ingredientePlatoDto[i].Idingrediente && rec.PlatoId == id);
                    if (existe)
                    {
                        continue;
                    }
                    else
                    {
                        PlatoIngrediente platoIngrediente1 = new PlatoIngrediente();
                        platoIngrediente1.IngredienteId = ingredientePlatoDto[i].Idingrediente;
                        platoIngrediente1.PlatoId = id;
                        await _context.AddAsync(platoIngrediente1);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeletePlato(int id)
        {
            Plato? plato = await _context.Plato.Where(rec => rec.Id == id).FirstOrDefaultAsync();

            if(plato != null)
            {
                List<PlatoIngrediente> platoIngredientes = await _context.PlatoIngrediente.Where(rec => rec.PlatoId == id).ToListAsync();

                if (platoIngredientes != null && platoIngredientes.Count > 0)
                {
                    foreach (PlatoIngrediente platoIngrediente in platoIngredientes)
                    {
                        _context.Remove(platoIngrediente);
                    }
                }

                _context.Remove(plato);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Se produjo un error al eliminar el Plato");
            }
        }

        public async Task<List<IngredientePlatoDto>> GetIngredientes(int? id)
        {
            List<IngredientePlatoDto> ingredientesPlatoDto = new List<IngredientePlatoDto>();

            List<Ingrediente> ingredientes = await _context.Ingrediente.ToListAsync();

            if (ingredientes != null && ingredientes.Any())
            {
                foreach (var item in ingredientes)
                {
                    IngredientePlatoDto ingredientePlatoDto = new IngredientePlatoDto();
                    ingredientePlatoDto.Idingrediente = item.Id;
                    ingredientePlatoDto.Seleccionado = false;
                    ingredientePlatoDto.Nombre = item.Nombre;
                    ingredientesPlatoDto.Add(ingredientePlatoDto);
                }

                if (id != null && id > 0)
                {
                    List<PlatoIngrediente> platoIngredientes = await _context.PlatoIngrediente.Where(rec => rec.PlatoId == id).ToListAsync();

                    if (platoIngredientes != null && platoIngredientes.Count > 0)
                    {
                        for (int i = 0; i < platoIngredientes.Count; i++)
                        {
                            for (int v = 0; v < ingredientesPlatoDto.Count; v++)
                            {
                                if (ingredientesPlatoDto[v].Idingrediente == platoIngredientes[i].IngredienteId)
                                {
                                    ingredientesPlatoDto[v].Seleccionado = true;
                                }
                            }
                        }
                    }
                }
            }

            return ingredientesPlatoDto;
        }

        private async Task<string?> CargarIngredientes(int id)
        {
            string ingredientes_Nombres = "";

            List<PlatoIngrediente> ingredientesPlato = await _context.PlatoIngrediente.Where(rec => rec.PlatoId == id).Include(rec => rec.Ingrediente).ToListAsync();

            if (ingredientesPlato != null && ingredientesPlato.Count > 0)
            {
                ingredientes_Nombres = $"{ingredientesPlato[0].Ingrediente.Nombre}";

                foreach (PlatoIngrediente ingredientePlato in ingredientesPlato)
                {
                    if (ingredientesPlato[0] == ingredientePlato)
                    {
                        continue;
                    }
                    else
                    {
                        ingredientes_Nombres = $"{ingredientes_Nombres}, {ingredientePlato.Ingrediente.Nombre}";
                    }
                }
            }

            return ingredientes_Nombres;
        }
    }
}
