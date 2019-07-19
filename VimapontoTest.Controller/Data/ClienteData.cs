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
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "SELECT ClienteId, Nome, Morada, Contato " +
                     "FROM Cliente ";
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Cliente");
            }

            dtTable = dsGlobal.Tables["Cliente"];
            var oClientes = new List<Cliente>();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Cliente oCliente = new Cliente();
                oCliente.ClienteId = int.Parse(dtTable.Rows[i]["ClienteId"].ToString());
                oCliente.Nome = dtTable.Rows[i]["Nome"].ToString();
                oCliente.Morada = dtTable.Rows[i]["Morada"].ToString();
                oCliente.Contato = dtTable.Rows[i]["Contato"].ToString();
                oClientes.Add(oCliente);
            }
            return oClientes;
        }

        public Cliente CarregarPorId(int pClienteId)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("SELECT ClienteId, Nome, Morada, Contato " +
                                                "FROM Cliente " +
                                                "WHERE ClienteId = '{0}'", pClienteId.ToString());
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Cliente");
            }

            dtTable = dsGlobal.Tables["Cliente"];
            Cliente oCliente = new Cliente();
            if (dtTable.Rows.Count > 0)
            {
                oCliente.ClienteId = int.Parse(dtTable.Rows[0]["ClienteId"].ToString());
                oCliente.Nome = dtTable.Rows[0]["Nome"].ToString();
                oCliente.Morada = dtTable.Rows[0]["Morada"].ToString();
                oCliente.Contato = dtTable.Rows[0]["Contato"].ToString();
            }
            return oCliente;
        }

        public void Inserir(Cliente oCliente)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("INSERT INTO Cliente (Nome, Morada, Contato) " +
                                                "VALUES('{0}', '{1}', '{2}') ", oCliente.Nome, oCliente.Morada, oCliente.Contato);
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Cliente");
            }
        }

        public void Alterar(Cliente oCliente)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("UPDATE Cliente SET Nome = '{0}', Morada = '{1}', Contato = '{2}' " +
                                                "WHERE ClienteId = '{3}' ", oCliente.Nome, oCliente.Morada, oCliente.Contato, oCliente.ClienteId);
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Cliente");
            }
        }

        public void Excluir(Cliente oCliente)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("DELETE Cliente " +
                                                "WHERE ClienteId = '{0}' ", oCliente.ClienteId);
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Cliente");
            }
        }
    }
}
