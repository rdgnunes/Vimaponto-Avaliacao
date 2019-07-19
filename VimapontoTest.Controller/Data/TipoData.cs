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
    public class TipoData : AppGlobal
    {
        public List<Tipo> ListarTodos()
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "SELECT TipoId, Descricao " +
                                  "FROM Tipo ";
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Tipo");
            }

            dtTable = dsGlobal.Tables["Tipo"];
            var oTipos = new List<Tipo>();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Tipo oTipo = new Tipo();
                oTipo.TipoId = int.Parse(dtTable.Rows[i]["TipoId"].ToString());
                oTipo.Descricao = dtTable.Rows[i]["Descricao"].ToString();
                oTipos.Add(oTipo);
            }
            return oTipos;
        }

        public Tipo CarregarPorId(int pTipoId)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("SELECT TipoId, Descricao " +
                                                "FROM Tipo " +
                                                "WHERE TipoId = '{0}'", pTipoId.ToString());
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Tipo");
            }

            dtTable = dsGlobal.Tables["Tipo"];
            Tipo oTipo = new Tipo();
            if (dtTable.Rows.Count > 0)
            {
                oTipo.TipoId = int.Parse(dtTable.Rows[0]["TipoId"].ToString());
                oTipo.Descricao = dtTable.Rows[0]["Descricao"].ToString();
            }
            return oTipo;
        }

        public void Inserir(Tipo oTipo)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("INSERT INTO Tipo (Descricao) " +
                                                "VALUES('{0}'",  oTipo.Descricao);
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Tipo");
            }
        }

        public void Alterar(Tipo oTipo)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("UPDATE Tipo SET Descricao = '{0}' " +
                                                "WHERE TipoId = '{1}' ", oTipo.Descricao, oTipo.TipoId);
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Tipo");
            }
        }

        public void Excluir(Tipo oTipo)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("DELETE Tipo " +
                                                "WHERE TipoId = '{0}' ", oTipo.TipoId);
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Tipo");
            }
        }
    }
}
