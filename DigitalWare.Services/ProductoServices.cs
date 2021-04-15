using DigitalWare.DataAccess.Repository;
using DigitalWare.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Services
{
    public class ProductoServices
    {
        #region --------------- Inyeccion de dependencias  --------------
        private readonly IRepository<Producto> _ProductoRepository;
        public ProductoServices(IRepository<Producto> ProductoRepository)
        {
            this._ProductoRepository = ProductoRepository;
        }
        #endregion

        #region --------------- GET -------------------
        public async Task<List<Producto>> GetAll()
        {
            var Productos = await this._ProductoRepository.Query().ToListAsync();

            return Productos;
        }

        public async Task<Producto> Get(long ProductoId)
        {
            var Producto = await this._ProductoRepository.Query().FirstOrDefaultAsync(x => x.Id == ProductoId);

            return Producto;
        }

        #endregion

        #region --------------- POST -----------------
        public async Task Create(Producto Producto)
        {
            try
            {
                await this._ProductoRepository.AddAsync(Producto);
                this._ProductoRepository.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region --------------- UPDATE ------------------
        public async Task Update(Producto Producto)
        {
            try
            {
                var ProductoAnterior = await this._ProductoRepository.Query().FirstOrDefaultAsync(x => x.Id == Producto.Id);

                ProductoAnterior.Nombre = Producto.Nombre;
                ProductoAnterior.Precio = Producto.Precio;
                ProductoAnterior.StockMinimo = Producto.StockMinimo;
                ProductoAnterior.ProductosFacturas = Producto.ProductosFacturas;
                ProductoAnterior.Actualizado = new DateTime().Date;

                this._ProductoRepository.Update(ProductoAnterior);
                this._ProductoRepository.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region --------------- DELETE ------------------
        public async Task Delete(long ProductoId)
        {
            var Producto = await this._ProductoRepository.Query().FirstOrDefaultAsync(x => x.Id == ProductoId);
            this._ProductoRepository.Remove(Producto);
            this._ProductoRepository.SaveChange();

        }
        #endregion
    }
}
