using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalWare.Models;
using DigitalWare.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        #region --------------- Inyeccion de dependencias  --------------
        private readonly FacturaServices _FacturaService;
        public FacturaController(FacturaServices FacturaServices)
        {
            this._FacturaService = FacturaServices;
        }
        #endregion

        [HttpGet("facturas")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var items = await _FacturaService.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [HttpGet("factura/{FacturaId}")]
        public async Task<IActionResult> Get(long FacturaId)
        {
            try
            {
                var item = await _FacturaService.Get(FacturaId);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpPost("crear")]
        public async Task<IActionResult> Post(Factura Factura)
        {
            try
            {
                await _FacturaService.Create(Factura);
                return Ok(Factura);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> Update(Factura Factura)
        {
            try
            {
                await _FacturaService.Update(Factura);
                return Ok("Factura actualizada correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("Eliminar/{FacturaId}")]
        public async Task<IActionResult> Delete(long FacturaId)
        {
            try
            {
                await _FacturaService.Delete(FacturaId);
                return Ok("Factura Eliminada correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}
