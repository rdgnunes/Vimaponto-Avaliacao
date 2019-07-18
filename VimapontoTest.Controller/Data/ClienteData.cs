using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimapontoTest.Model;
using System.Data;
using System.Data.SqlClient;

namespace VimapontoTest.Controller.Data
{
    public class ClienteData : AppGlobal
    {
        public List<Cliente> ListarTodos()
        {
            var oClientes = new List<Cliente>();
            sQuery = "SELECT ClienteId, Nome, Morada, Contato " +
                     "FROM Cliente ";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Cliente");

            DataTable dtTable = dsGlobal.Tables[0];
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Cliente oCliente = new Cliente();
                oCliente.ClienteId = int.Parse(dtTable.Rows[i]["ClienteId"].ToString());
                oCliente.Nome = dtTable.Rows[i]["Nome"].ToString();
                oCliente.Morada = dtTable.Rows[i]["Morada"].ToString();
                oCliente.Contatos = dtTable.Rows[i]["Contatos"].ToString();
                oClientes.Add(oCliente);
            }
            return oClientes;
        }

        public Cliente CarregarPorId(int pClienteId)
        {
            sQuery = "SELECT ClienteId, Nome, Morada, Contato " +
                     "FROM Cliente " +
                     "WHERE ClienteId = '" + pClienteId.ToString() + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Cliente");

            DataTable dtTable = dsGlobal.Tables[0];
            Cliente oCliente = new Cliente();
            if (dtTable.Rows.Count > 0)
            {
                oCliente.ClienteId = int.Parse(dtTable.Rows[0]["ClienteId"].ToString());
                oCliente.Nome = dtTable.Rows[0]["Nome"].ToString();
                oCliente.Morada = dtTable.Rows[0]["Morada"].ToString();
                oCliente.Contatos = dtTable.Rows[0]["Contatos"].ToString();
            }
            return oCliente;
        }

        public void Inserir(Cliente oCliente)
        {
            sQuery = "INSERT INTO Cliente (Nome, Morada, Contato) " +
                     "VALUES ('" + oCliente.Nome + "','" + oCliente.Morada + "','" + oCliente.Contatos + "')";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Cliente");
        }

        public void Alterar(Cliente oCliente)
        {
            sQuery = "UPDATE Cliente " +
                     "SET Nome = '" + oCliente.Nome + "' " +
                     ", Morada = '" + oCliente.Morada + "' " +
                     ", Contato = '" + oCliente.Contatos + "' " +
                     "WHERE ClienteId = '" + oCliente.ClienteId + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Cliente");
        }

        public void Excluir(Cliente oCliente)
        {
            sQuery = "DELETE Cliente " +
                     "WHERE ClienteId = '" + oCliente.ClienteId + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Cliente");
        }

    }
}
