using DigitalWare.DataAccess.Repository;
using DigitalWare.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Services
{
    public class FacturaServices
    {
        #region --------------- Inyeccion de dependencias  --------------
        private readonly IRepository<Factura> _FacturaRepository;
        public FacturaServices(IRepository<Factura> FacturaRepository)
        {
            this._FacturaRepository = FacturaRepository;
        }
        #endregion

        #region --------------- GET -------------------
        public async Task<List<Factura>> GetAll()
        {
            var Facturas = await this._FacturaRepository.Query().ToListAsync();

            return Facturas;
        }

        public async Task<Factura> Get(long FacturaId)
        {
            var Factura = await this._FacturaRepository.Query().FirstOrDefaultAsync(x => x.Id == FacturaId);

            return Factura;
        }

        #endregion

        #region --------------- POST -----------------
        public async Task Create(Factura Factura)
        {
            try
            {
               // var productosFacturas = Factura.ProductosFacturas;
                await this._FacturaRepository.AddAsync(Factura);

                foreach (var item in Factura.ProductosFacturas)
                {
                    item.FacturaId = Factura.Id;
                }

                this._FacturaRepository.Update(Factura);

                this._FacturaRepository.SaveChange();

                var res = Factura;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region --------------- UPDATE ------------------
        public async Task Update(Factura Factura)
        {
            try
            {
                var FacturaAnterior = await this._FacturaRepository.Query().FirstOrDefaultAsync(x => x.Id == Factura.Id);

                FacturaAnterior.VendedorId = Factura.VendedorId;
                FacturaAnterior.ClienteId = Factura.ClienteId;
                FacturaAnterior.Actualizado = new DateTime().Date;
                FacturaAnterior.ProductosFacturas = Factura.ProductosFacturas;
                FacturaAnterior.Actualizado = new DateTime().Date;

                this._FacturaRepository.Update(FacturaAnterior);
                this._FacturaRepository.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region --------------- DELETE ------------------
        public async Task Delete(long FacturaId)
        {
            var Factura = await this._FacturaRepository.Query().FirstOrDefaultAsync(x => x.Id == FacturaId);
            this._FacturaRepository.Remove(Factura);
            this._FacturaRepository.SaveChange();

        }
        #endregion
    }
}
