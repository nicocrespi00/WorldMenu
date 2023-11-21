using AutoMapper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BackendWM.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class IngredienteController : ControllerBase
    {
        private readonly IngredienteServicio _servicio;

        public IngredienteController(IngredienteServicio servicio)
        {
            this._servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<IngredienteDto>>> GetIngredientes()
        {
            List<IngredienteDto> ingredientesDto = await _servicio.GetIngredientes();

            return Ok(ingredientesDto);
        }

        [HttpGet]
        public async Task<ActionResult<List<IngredienteDto>>> GetIngrediente(int id)
        {
            IngredienteDto ingredienteDto = await _servicio.GetIngrediente(id);

            return Ok(ingredienteDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(IngredienteDto ingredienteDto)
        {
            try
            {
                await _servicio.CreateIngrediente(ingredienteDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo un error al crear el ingrediente: " + ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Edit(IngredienteDto ingredienteDto)
        {
            try
            {
                await _servicio.EditIngrediente(ingredienteDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo un error al editar el ingrediente: " + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _servicio.DeleteIngrediente(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo un error al eliminar el ingrediente: " + ex.Message);
            }
        }
    }
}