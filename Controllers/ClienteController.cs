using CadastroCliente.Models;
using CadastroCliente.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServicos _clienteServico;

        public ClienteController(IClienteServicos clienteServico)
        {
            _clienteServico = clienteServico;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> ListarCliente()
        {
            List<Cliente> cliente = await _clienteServico.ListarCliente();
            return Ok(cliente);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> ListarClientePorId(int id)
        {
            Cliente cliente = await _clienteServico.ListarClientesPorId(id);
            return Ok(cliente);
        }
        [HttpPost]
        public async Task<ActionResult<Cliente>> InserirClientes([FromBody] Cliente clienteModel)
        {
            Cliente cliente = await _clienteServico.InserirClientes(clienteModel);
            return Ok(cliente);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> EditarClientes([FromBody] Cliente clienteModel, int id)
        {

            clienteModel.CodCliente = id;
            Cliente cliente = await _clienteServico.EditarClientes(clienteModel,id);
            return Ok(cliente);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> RemoverCliente(int id)
        {
            bool apagado = await _clienteServico.RemoverClientes(id);
            return Ok(apagado);
        }
    }
}
