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
    public class DocumentoData : AppGlobal
    {
        public List<Documento> ListarTodos()
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "SELECT DocumentoId, TipoId, ClienteId, Descricao, DataAlteracao " +
                                  "FROM Documento";
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Documento");
            }

            dtTable = dsGlobal.Tables["Documento"];
            var oDocumentos = new List<Documento>();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Documento oDocumento = new Documento(new Tipo(), new Cliente());
                oDocumento.DocumentoId = int.Parse(dtTable.Rows[i]["DocumentoId"].ToString());
                oDocumento.ObjTipo = new TipoData().CarregarPorId(int.Parse(dtTable.Rows[i]["TipoId"].ToString()));
                oDocumento.ObjCliente = new ClienteData().CarregarPorId(int.Parse(dtTable.Rows[i]["ClienteId"].ToString()));
                oDocumento.Descricao = dtTable.Rows[i]["Descricao"].ToString();
                oDocumento.DataAlteracao = DateTime.Parse(dtTable.Rows[i]["DataAlteracao"].ToString());
                oDocumentos.Add(oDocumento);
            }
            return oDocumentos;
        }

        public Documento CarregarPorId(int pDocumentoId)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("SELECT DocumentoId, TipoId, ClienteId, Descricao, DataAlteracao " +
                                                "FROM Documento " +
                                                "WHERE DocumentoId = '{0}'", pDocumentoId.ToString());
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Documento");
            }

            dtTable = dsGlobal.Tables["Documento"];
            Documento oDocumento = new Documento(new Tipo(), new Cliente());

            if (dtTable.Rows.Count > 0)
            {
                oDocumento.DocumentoId = int.Parse(dtTable.Rows[0]["DocumentoId"].ToString());
                oDocumento.ObjTipo = new TipoData().CarregarPorId(int.Parse(dtTable.Rows[0]["TipoId"].ToString()));
                oDocumento.ObjCliente = new ClienteData().CarregarPorId(int.Parse(dtTable.Rows[0]["ClienteId"].ToString()));
                oDocumento.Descricao = dtTable.Rows[0]["Descricao"].ToString();
                oDocumento.DataAlteracao = DateTime.Parse(dtTable.Rows[0]["DataAlteracao"].ToString());
            }
            return oDocumento;
        }

        public void Inserir(Documento oDocumento)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("INSERT INTO Documento (TipoId, ClienteId, Descricao, DataAlteracao) " +
                                                "VALUES('{0}', '{1}', '{2}', '{3}') ",
                                                oDocumento.ObjTipo.TipoId.ToString(),
                                                oDocumento.ObjCliente.ClienteId.ToString(),
                                                oDocumento.Descricao,
                                                oDocumento.DataAlteracao.ToString(formatoDataBD));
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Documento");
            }
        }

        public void Alterar(Documento oDocumento)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("UPDATE Documento SET TipoId = '{0}', ClienteId = '{1}', Descricao = '{2}', DataAlteracao = '{3}' " +
                                                "WHERE DocumentoId = '{4}' ",
                                                oDocumento.ObjTipo.TipoId.ToString(),
                                                oDocumento.ObjCliente.ClienteId.ToString(),
                                                oDocumento.Descricao,
                                                oDocumento.DataAlteracao.ToString(formatoDataBD),
                                                oDocumento.DocumentoId);
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Documento");
            }
        }

        public void Excluir(Documento oDocumento)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("DELETE Documento " +
                                                "WHERE DocumentoId = '{0}' ", oDocumento.DocumentoId);
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Documento");
            }
        }
    }
}
