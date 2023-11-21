using AutoMapper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BackendWM.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PlatoController : ControllerBase
    {
        private readonly PlatoServicio _servicio;

        public PlatoController(PlatoServicio servicio)
        {
            this._servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlatoDto>>> GetPlatos()
        {
            List<PlatoDto> PlatosDto = await _servicio.GetPlatos();

            return Ok(PlatosDto);
        }

        [HttpGet]
        public async Task<ActionResult<List<PlatoDto>>> GetPlato(int id)
        {
            PlatoDto platoDto = await _servicio.GetPlato(id);

            platoDto.IngredientePlatoSeleccionados = await _servicio.GetIngredientes(id);

            return Ok(platoDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PlatoDto platoDto)
        {
            try
            {
                await _servicio.CreatePlato(platoDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo un error al crear el Plato: " + ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Edit(PlatoDto platoDto)
        {
            try
            {
                await _servicio.EditPlato(platoDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo un error al editar el Plato: " + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _servicio.DeletePlato(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo un error al eliminar el Plato: " + ex.Message);
            }
        }
    }
}