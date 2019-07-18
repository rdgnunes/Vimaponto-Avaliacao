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
            var oTipos = new List<Tipo>();
            sQuery = "SELECT TipoId, Descricao " +
                     "FROM Tipo ";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Tipo");

            DataTable dtTable = dsGlobal.Tables[0];
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
            sQuery = "SELECT TipoId, Descricao " +
                     "FROM Tipo " +
                     "WHERE TipoId = '" + pTipoId.ToString() + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Tipo");

            DataTable dtTable = dsGlobal.Tables[0];
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
            sQuery = "INSERT INTO Tipo (Descricao) " +
                     "VALUES ('" + oTipo.Descricao + "')";

            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Tipo");
        }

        public void Alterar(Tipo oTipo)
        {
            sQuery = "UPDATE Tipo " +
                     "SET Descricao = '" + oTipo.Descricao + "' " +
                     "WHERE TipoId = '" + oTipo.TipoId + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Tipo");
        }

        public void Excluir(Tipo oTipo)
        {
            sQuery = "DELETE Tipo " +
                     "WHERE TipoId = '" + oTipo.TipoId + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Tipo");
        }
    }
}
