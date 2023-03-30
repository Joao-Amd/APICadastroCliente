using CadastroCliente.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroCliente.Servicos.Interfaces
{
    public interface IClienteServicos
    {
        Task<List<Cliente>> ListarCliente();
        Task<Cliente> ListarClientesPorId(int id);
        Task<Cliente> InserirClientes(Cliente cliente);
        Task<Cliente> EditarClientes(Cliente cliente, int id);
        Task<bool> RemoverClientes(int id);
    }
}
