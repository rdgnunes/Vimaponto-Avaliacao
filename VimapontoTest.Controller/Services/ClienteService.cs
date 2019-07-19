using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VimapontoTest.Model;
using VimapontoTest.Controller.Data;

namespace VimapontoTest.Controller.Services
{
    public class ClienteService
    {
        public List<Cliente> ListarTodos()
        {
            return new ClienteData().ListarTodos();
        }

        public Cliente CarregarPorId(int pClienteId)
        {
            return new ClienteData().CarregarPorId(pClienteId);
        }

        public String Inserir(Cliente pCliente)
        {
            if (String.IsNullOrEmpty(pCliente.Nome))
                return "Nome Vazio";

            if (String.IsNullOrEmpty(pCliente.Morada))
                return "Morada Vazia";

            if (String.IsNullOrEmpty(pCliente.Contato))
                return "Contato Vazio";

            new ClienteData().Inserir(pCliente);
            return "Cliente cadastrado com sucesso!";
        }

        public String Alterar(Cliente pCliente)
        {
            if (pCliente.ClienteId == 0)
                return "Id Inválido";

            new ClienteData().Alterar(pCliente);
            return "Cliente alterado com sucesso!";
        }

        public String Deletar(Cliente pCliente)
        {
            if (pCliente.ClienteId == 0)
                return "Id Inválido";

            new ClienteData().Excluir(pCliente);
            return "Cliente excluido com sucesso!";
        }

    }
}
