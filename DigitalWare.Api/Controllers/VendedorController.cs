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
    public class VendedorController : ControllerBase
    {
        #region --------------- Inyeccion de dependencias  --------------
        private readonly VendedorServices _VendedorService;
        public VendedorController(VendedorServices VendedorServices)
        {
            this._VendedorService = VendedorServices;
        }
        #endregion

        [HttpGet("vendedores")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var items = await _VendedorService.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet("vendedor")]
        public async Task<IActionResult> Get(long vendedorId)
        {
            try
            {
                var item = await _VendedorService.Get(vendedorId);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpPost("crear")]
        [HttpPost]
        public async Task<IActionResult> Post(Vendedor Vendedor)
        {
            try
            {
                await _VendedorService.Create(Vendedor);
                return Ok(Vendedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("actualizar")]
        [HttpPut]
        public async Task<IActionResult> Update(Vendedor Vendedor)
        {
            try
            {
                await _VendedorService.Update(Vendedor);
                return Ok("Vendedor actualizado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long VendedorId)
        {
            try
            {
                await _VendedorService.Delete(VendedorId);
                return Ok("Vendedor Eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
