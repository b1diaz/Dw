using DigitalWare.DataAccess.Repository;
using DigitalWare.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Services
{
    public class ClienteServices
    {
        #region --------------- Inyeccion de dependencias  --------------
        private readonly IRepository<Cliente> _ClienteRepository;
        public ClienteServices(IRepository<Cliente> ClienteRepository)
        {
            this._ClienteRepository = ClienteRepository;
        }
        #endregion

        #region --------------- GET -------------------
        public async Task<List<Cliente>> GetAll()
        {
            var Clientes = await this._ClienteRepository.Query().ToListAsync();

            return Clientes;
        }

        public async Task<Cliente> Get(long ClienteId)
        {
            var Cliente = await this._ClienteRepository.Query().FirstOrDefaultAsync(x => x.Id == ClienteId);

            return Cliente;
        }

        #endregion

        #region --------------- POST -----------------
        public async Task Create(Cliente Cliente)
        {
            try
            {
                await this._ClienteRepository.AddAsync(Cliente);
                this._ClienteRepository.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region --------------- UPDATE ------------------
        public async Task Update(Cliente Cliente)
        {
            try
            {
                var ClienteAnterior = await this._ClienteRepository.Query().FirstOrDefaultAsync(x => x.Id == Cliente.Id);

                ClienteAnterior.Nombre = Cliente.Nombre;
                ClienteAnterior.Apellido = Cliente.Apellido;
                ClienteAnterior.Edad = Cliente.Edad;
                ClienteAnterior.Cedula = Cliente.Cedula;
                ClienteAnterior.Actualizado = new DateTime().Date;


                this._ClienteRepository.Update(ClienteAnterior);
                this._ClienteRepository.SaveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region --------------- DELETE ------------------
        public async Task Delete(long ClienteId)
        {
            var Cliente = await this._ClienteRepository.Query().FirstOrDefaultAsync(x => x.Id == ClienteId);
            this._ClienteRepository.Remove(Cliente);
            this._ClienteRepository.SaveChange();

        }
        #endregion

    }
}
