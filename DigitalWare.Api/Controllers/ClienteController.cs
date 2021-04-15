using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalWare.Models;
using DigitalWare.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        #region --------------- Inyeccion de dependencias  --------------
        private readonly ClienteServices _ClienteService;
        public ClienteController(ClienteServices ClienteServices)
        {
            this._ClienteService = ClienteServices;
        }
        #endregion

        [HttpGet("clientes")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var items = await _ClienteService.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("cliente/{ClienteId}")]
        public async Task<IActionResult> Get(long ClienteId)
        {
            try
            {
                var items = await _ClienteService.Get(ClienteId);
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Post(Cliente Cliente)
        {
            try
            {
                await _ClienteService.Create(Cliente);
                return Ok(Cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> Update(Cliente Cliente)
        {
            try
            {
                await _ClienteService.Update(Cliente);
                return Ok("Cliente actualizado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("Eliminar/{ClienteId}")]
        public async Task<IActionResult> Delete(long ClienteId)
        {
            try
            {
                await _ClienteService.Delete(ClienteId);
                return Ok("Cliente Eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}
