using System;

#nullable disable

namespace CadastroCliente.Models
{
    public partial class Cliente
    {
        public int CodCliente { get; set; }
        public string NomeCliente { get; set; }
        public string CnpjCliente { get; set; }
        public DateTime DataCadastroCliente { get; set; } = DateTime.Now;
        public string EnderecoCliente { get; set; }
        public string TelefoneCliente { get; set; }
    }
}
