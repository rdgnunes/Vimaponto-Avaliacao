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
    public class ArtigoData : AppGlobal
    {
        public List<Artigo> ListarTodos()
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "SELECT ArtigoId, Codigo, Descricao, Valor " +
                                  "FROM Artigo";
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Artigo");
            }

            dtTable = dsGlobal.Tables["Artigo"];
            var oArtigos = new List<Artigo>();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Artigo oArtigo = new Artigo();
                oArtigo.ArtigoId = int.Parse(dtTable.Rows[i]["ArtigoId"].ToString());
                oArtigo.Codigo = dtTable.Rows[i]["Codigo"].ToString();
                oArtigo.Descricao = dtTable.Rows[i]["Descricao"].ToString();
                oArtigo.Valor = Double.Parse(dtTable.Rows[i]["ArtigoId"].ToString());
                oArtigos.Add(oArtigo);
            }
            return oArtigos;
        }

        public Artigo CarregarPorId(int pArtigoId)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("SELECT ArtigoId, Codigo, Descricao, Valor " +
                                                "FROM Artigo " +
                                                "WHERE ArtigoId = '{0}'", pArtigoId.ToString());
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Artigo");
            }

            dtTable = dsGlobal.Tables["Artigo"];
            Artigo oArtigo = new Artigo();
            if (dtTable.Rows.Count > 0)
            {
                oArtigo.ArtigoId = int.Parse(dtTable.Rows[0]["ArtigoId"].ToString());
                oArtigo.Codigo = dtTable.Rows[0]["Codigo"].ToString();
                oArtigo.Descricao = dtTable.Rows[0]["Descricao"].ToString();
                oArtigo.Valor = Double.Parse(dtTable.Rows[0]["ArtigoId"].ToString());
            }
            return oArtigo;
        }

        public void Inserir(Artigo oArtigo)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("INSERT INTO Artigo (Codigo, Descricao, Valor) " +
                                                "VALUES('{0}', '{1}', '{2}') ", oArtigo.Codigo, oArtigo.Descricao, oArtigo.Valor);
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Artigo");
            }
        }

        public void Alterar(Artigo oArtigo)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("UPDATE Artigo SET Codigo = '{0}', Descricao = '{1}', Valor = '{2}' " +
                                                "WHERE ArtigoId = '{3}' ", oArtigo.Codigo, oArtigo.Descricao, oArtigo.Valor, oArtigo.ArtigoId);
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Artigo");
            }
        }

        public void Excluir(Artigo oArtigo)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("DELETE Artigo " +
                                                "WHERE ArtigoId = '{0}' ", oArtigo.ArtigoId);
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Artigo");
            }
        }
    }
}
