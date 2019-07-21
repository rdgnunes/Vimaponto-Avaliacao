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
    public class ItemData : AppGlobal
    {
        public List<Item> ListarTodosPorDocumento(Documento pDocumento)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("SELECT DocumentoId, ArtigoId, Quantidade, DataEntrega, Valor, Ordem FROM Item " +
                                                "WHERE DocumentoId = '{0}' ORDER BY Ordem", pDocumento.DocumentoId.ToString());
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Item");
            }

            dtTable = dsGlobal.Tables["Item"];
            var oItems = new List<Item>();
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Item oItem = new Item(pDocumento, new Artigo());
                oItem.ObjDocumento = pDocumento;
                oItem.ObjArtigo = new ArtigoData().CarregarPorId(int.Parse(dtTable.Rows[i]["ArtigoId"].ToString()));
                oItem.Quantidade = int.Parse(dtTable.Rows[i]["Quantidade"].ToString());
                oItem.DataEntrega = DateTime.Parse(dtTable.Rows[i]["DataEntrega"].ToString());
                oItem.Valor = double.Parse(dtTable.Rows[i]["Valor"].ToString());
                oItem.Ordem = int.Parse(dtTable.Rows[i]["Ordem"].ToString());
                oItems.Add(oItem);
            }
            return oItems;
        }

        public Item CarregarPorId(int pDocumentoId, int pArtigoId)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("SELECT DocumentoId, ArtigoId, Quantidade, DataEntrega, Valor, Ordem " +
                                                "FROM Item " +
                                                "WHERE pDocumentoId = '{0}' AND pArtigoId = '{1}'", pDocumentoId.ToString(), pArtigoId.ToString());
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Item");
            }

            dtTable = dsGlobal.Tables["Item"];
            Item oItem = new Item(new Documento(new Tipo(), new Cliente()), new Artigo());

            if (dtTable.Rows.Count > 0)
            {
                oItem.ObjDocumento = new DocumentoData().CarregarPorId(int.Parse(dtTable.Rows[0]["DocumentoId"].ToString()));
                oItem.ObjArtigo = new ArtigoData().CarregarPorId(int.Parse(dtTable.Rows[0]["ArtigoId"].ToString()));
                oItem.Quantidade = int.Parse(dtTable.Rows[0]["Quantidade"].ToString());
                oItem.DataEntrega = DateTime.Parse(dtTable.Rows[0]["DataEntrega"].ToString());
                oItem.Valor = double.Parse(dtTable.Rows[0]["Valor"].ToString());
                oItem.Ordem = int.Parse(dtTable.Rows[0]["Ordem"].ToString());
            }
            return oItem;
        }

        public void Inserir(Item oItem)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("INSERT INTO Item (DocumentoId, ArtigoId, Quantidade, DataEntrega, Valor, Ordem) " +
                                                "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}') ", 
                                                oItem.ObjDocumento.DocumentoId.ToString(), 
                                                oItem.ObjArtigo.ArtigoId.ToString(),
                                                oItem.Quantidade, 
                                                oItem.DataEntrega.ToString("yyyyMMdd"), 
                                                oItem.Valor.ToString().Replace(".","").Replace(",","."),
                                                oItem.Ordem.ToString());
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Item");
            }
        }

        public void Alterar(Item oItem)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("UPDATE Item SET Quantidade = '{0}', DataEntrega = '{1}', Valor = '{2}', Ordem = '{3}' " +
                                                "WHERE DocumentoId = '{4}' AND ArtigoId = '{5}' ",
                                                oItem.Quantidade.ToString(),
                                                oItem.DataEntrega.ToString(formatoDataBD),
                                                oItem.Valor,
                                                oItem.Ordem,
                                                oItem.ObjDocumento.DocumentoId.ToString(),
                                                oItem.ObjArtigo.ArtigoId.ToString());
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Item");
            }
        }

        public void Excluir(Item oItem)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("DELETE Item " +
                                                "WHERE DocumentoId = '{0}' AND ArtigoId = '{1}'", 
                                                oItem.ObjDocumento.DocumentoId.ToString(),
                                                oItem.ObjArtigo.ArtigoId.ToString());
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Item");
            }
        }

        public void ExcluirTodosPorDocumentoId(int pDocumentoId)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = string.Format("DELETE Item " +
                                                "WHERE DocumentoId = '{0}' ", pDocumentoId.ToString());
                dtAdapter = new SqlDataAdapter(cmd.CommandText, DbConnection());
                dtAdapter.Fill(dsGlobal, "Item");
            }
        }
    }
}