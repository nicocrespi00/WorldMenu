using AutoMapper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BackendWM.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PaisController : ControllerBase
    {
        private readonly PaisServicio _servicio;

        public PaisController(PaisServicio servicio)
        {
            this._servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaisDto>>> GetPaises()
        {
            List<PaisDto> paisDto = await _servicio.GetPaises();

            return Ok(paisDto);
        }

        [HttpGet]
        public async Task<ActionResult<List<PaisDto>>> GetPais(int id)
        {
            PaisDto paisDto = await _servicio.GetPais(id);

            return Ok(paisDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PaisDto paisDto)
        {
            try
            {
                await _servicio.CreatePais(paisDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo un error al crear el Pais: " + ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Edit(PaisDto paisDto)
        {
            try
            {
                await _servicio.EditPais(paisDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo un error al editar el Pais: " + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _servicio.DeletePais(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo un error al eliminar el Pais: " + ex.Message);
            }
        }
    }
}