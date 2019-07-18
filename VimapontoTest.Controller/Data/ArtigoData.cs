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
            var oArtigos = new List<Artigo>();
            sQuery = "SELECT ArtigoId, Codigo, Descricao, Valor " +
                     "FROM Artigo ";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Artigo");

            DataTable dtTable = dsGlobal.Tables[0];
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
            sQuery = "SELECT ArtigoId, Codigo, Descricao, Valor " +
                     "FROM Artigo " +
                     "WHERE ArtigoId = '" + pArtigoId.ToString() + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Artigo");

            DataTable dtTable = dsGlobal.Tables[0];
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
            sQuery = "INSERT INTO Artigo (Codigo, Descricao, Valor) " +
                     "VALUES ('" + oArtigo.Codigo + "','" + oArtigo.Descricao + "','" + oArtigo.Valor + "')";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Artigo");
        }

        public void Alterar(Artigo oArtigo)
        {
            sQuery = "UPDATE Artigo " +
                     "SET Codigo = '" + oArtigo.Codigo + "' " +
                     ", Descricao = '" + oArtigo.Descricao + "' " +
                     ", Valor = '" + oArtigo.Valor + "' " +
                     "WHERE ArtigoId = '" + oArtigo.ArtigoId + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Artigo");
        }

        public void Excluir(Artigo oArtigo)
        {
            sQuery = "DELETE Artigo " +
                     "WHERE ArtigoId = '" + oArtigo.ArtigoId + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Artigo");
        }

    }
}
