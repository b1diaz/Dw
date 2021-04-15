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
    public class ProductoController : ControllerBase
    {
        #region --------------- Inyeccion de dependencias  --------------
        private readonly ProductoServices _ProductoService;
        public ProductoController(ProductoServices ProductoServices)
        {
            this._ProductoService = ProductoServices;
        }
        #endregion

        [HttpGet("productos")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var items = await _ProductoService.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("producto")]
        public async Task<IActionResult> Get(long ProductoId)
        {
            try
            {
                var items = await _ProductoService.Get(ProductoId);
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpPost("crear")]
        public async Task<IActionResult> Post(Producto Producto)
        {
            try
            {
                await _ProductoService.Create(Producto);
                return Ok(Producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> Update(Producto Producto)
        {
            try
            {
                await _ProductoService.Update(Producto);
                return Ok("Producto actualizado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("Eliminar")]
        public async Task<IActionResult> Delete(long ProductoId)
        {
            try
            {
                await _ProductoService.Delete(ProductoId);
                return Ok("Producto Eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
