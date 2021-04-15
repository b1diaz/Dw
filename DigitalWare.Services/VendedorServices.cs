using DigitalWare.DataAccess.Repository;
using DigitalWare.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Services
{
    public class VendedorServices
    {
        #region --------------- Inyeccion de dependencias  --------------
        private readonly IRepository<Vendedor> _VendedorRepository;
        public VendedorServices(IRepository<Vendedor> VendedorRepository)
        {
            this._VendedorRepository = VendedorRepository;
        }
        #endregion

        #region --------------- GET -------------------
        public async Task<List<Vendedor>> GetAll()
        {
            var Vendedors = await this._VendedorRepository.Query().ToListAsync();

            return Vendedors;
        }

        public async Task<Vendedor> Get(long VendedorId)
        {
            var Vendedor = await this._VendedorRepository.Query().FirstOrDefaultAsync(x => x.Id == VendedorId);

            return Vendedor;
        }

        #endregion

        #region --------------- POST -----------------
        public async Task Create(Vendedor Vendedor)
        {
            try
            {
                await this._VendedorRepository.AddAsync(Vendedor);
                this._VendedorRepository.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region --------------- UPDATE ------------------
        public async Task Update(Vendedor Vendedor)
        {
            try
            {
                var VendedorAnterior = await this._VendedorRepository.Query().FirstOrDefaultAsync(x => x.Id == Vendedor.Id);

                VendedorAnterior.Nombre = Vendedor.Nombre;
                VendedorAnterior.Apellido = Vendedor.Apellido;
                VendedorAnterior.Cedula = Vendedor.Cedula;
                VendedorAnterior.Actualizado = new DateTime().Date;

                this._VendedorRepository.Update(VendedorAnterior);
                this._VendedorRepository.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region --------------- DELETE ------------------
        public async Task Delete(long VendedorId)
        {
            var Vendedor = await this._VendedorRepository.Query().FirstOrDefaultAsync(x => x.Id == VendedorId);
            this._VendedorRepository.Remove(Vendedor);
            this._VendedorRepository.SaveChange();

        }
        #endregion
    }
}
