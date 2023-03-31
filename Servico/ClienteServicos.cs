using CadastroCliente.Data;
using System;
using CadastroCliente.Servicos.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroCliente.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Servicos
{
    public class ClienteServicos : IClienteServicos
    {
        private readonly DbClienteContext _dbContext;
        public ClienteServicos(DbClienteContext dbContex)
        {
            _dbContext = dbContex;
        }
        #region ListarClientePorId
        public async Task<Cliente> ListarClientesPorId(int id)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.CodCliente == id);
        }
        #endregion

        #region ListarCliente
        public async Task<List<Cliente>> ListarCliente()
        {
            return await _dbContext.Clientes.ToListAsync();
        }
        #endregion

        #region InserirCliente
        public async Task<Cliente> InserirClientes(Cliente cliente)
        {

            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }
        #endregion

        #region EditarCliente
        public async Task<Cliente> EditarClientes(Cliente cliente, int id)
        {

            Cliente clienteModel = await ListarClientesPorId(id);
            if (clienteModel == null)
            {
                throw new Exception($"Usuário para  o ID: {id} não foi encontrado");

            }
            clienteModel.NomeCliente = cliente.NomeCliente;
            clienteModel.CnpjCliente = cliente.CnpjCliente;
            clienteModel.EnderecoCliente = cliente.EnderecoCliente;
            clienteModel.TelefoneCliente = cliente.TelefoneCliente;

            _dbContext.Clientes.Update(clienteModel);
            await _dbContext.SaveChangesAsync();

            return clienteModel;

        }
        #endregion

        #region RemoverCliente
        public async Task<bool> RemoverClientes(int id)
        {
            Cliente clienteModel = await ListarClientesPorId(id);

            if (clienteModel == null)
            {
                throw new Exception($"Usuário para  o ID: {id} não foi encontrado");

            }
            _dbContext.Clientes.Remove(clienteModel);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        public void ValidarCnpj(Cliente clienteModel)
        {
            foreach (Cliente cnpj in _dbContext.Clientes)
            {
                if (cnpj.CnpjCliente == clienteModel.CnpjCliente)
                {
                    throw new Exception("Cnpj duplicado, por favor insira cnpj diferente");
                }
            }
        }
    }

}


