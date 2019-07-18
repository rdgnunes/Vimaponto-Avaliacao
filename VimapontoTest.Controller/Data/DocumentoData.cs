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
            var oDocumentos = new List<Documento>();
            sQuery = "SELECT DocumentoId, TipoId, ClienteId, Descricao, DataAlteracao " +
                     "FROM Documento ";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Documento");

            DataTable dtTable = dsGlobal.Tables[0];
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Documento oDocumento = new Documento(new Tipo(), new Cliente());
                oDocumento.DocumentoId = int.Parse(dtTable.Rows[i]["DocumentoId"].ToString());
                oDocumento.ObjTipo = new TipoData().CarregarPorId(int.Parse(dtTable.Rows[i]["TipoId"].ToString()));
                oDocumento.ObjCliente = new ClienteData().CarregarPorId(int.Parse(dtTable.Rows[i]["ClienteId"].ToString()));
                oDocumento.Descricao = dtTable.Rows[i]["Descricao"].ToString();
                oDocumento.DataAlteracao = DateTime.Parse(dtTable.Rows[i]["Descricao"].ToString());
                oDocumentos.Add(oDocumento);
            }
            return oDocumentos;
        }

        public Documento CarregarPorId(int pDocumentoId)
        {
            sQuery = "SELECT DocumentoId, TipoId, ClienteId, Descricao, DataAlteracao " +
                     "FROM Documento " +
                     "WHERE DocumentoId = '" + pDocumentoId.ToString() + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Documento");

            DataTable dtTable = dsGlobal.Tables[0];
            Documento oDocumento = new Documento(new Tipo(), new Cliente());

            if (dtTable.Rows.Count > 0)
            {
                oDocumento.DocumentoId = int.Parse(dtTable.Rows[0]["DocumentoId"].ToString());
                oDocumento.ObjTipo = new TipoData().CarregarPorId(int.Parse(dtTable.Rows[0]["TipoId"].ToString()));
                oDocumento.ObjCliente = new ClienteData().CarregarPorId(int.Parse(dtTable.Rows[0]["ClienteId"].ToString()));
                oDocumento.Descricao = dtTable.Rows[0]["Descricao"].ToString();
                oDocumento.DataAlteracao = DateTime.Parse(dtTable.Rows[0]["Descricao"].ToString());
            }
            return oDocumento;
        }

        public void Inserir(Documento oDocumento)
        {
            sQuery = "INSERT INTO Documento (TipoId, ClienteId, Descricao, DataAlteracao) " +
                     "VALUES ('" + oDocumento.ObjTipo.TipoId.ToString() + "', '" + oDocumento.ObjCliente.ClienteId.ToString() + "', "+
                              "'" + oDocumento.Descricao + "', '" + oDocumento.DataAlteracao.ToString(formatoDataBD) + "')";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Documento");
        }

        public void Alterar(Documento oDocumento)
        {
            sQuery = "UPDATE Documento " +
                     "SET TipoId = '" + oDocumento.ObjTipo.TipoId.ToString() + "' " +
                     ", ClienteId = '" + oDocumento.ObjCliente.ClienteId.ToString() + "' " +
                     ", Descricao = '" + oDocumento.Descricao + "' " +
                     ", DataAlteracao = '" + oDocumento.DataAlteracao.ToString(formatoDataBD) + "' " +
                     "WHERE DocumentoId = '" + oDocumento.DocumentoId + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Documento");
        }

        public void Excluir(Documento oDocumento)
        {
            sQuery = "DELETE Documento " +
                     "WHERE DocumentoId = '" + oDocumento.DocumentoId + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Documento");
        }

    }
}
