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
            var oItems = new List<Item>();
            sQuery = "SELECT DocumentoId, ArtigoId, Quantidade, DataEntrega, Valor " +
                     "FROM Item " +
                     "WHERE DocumentoId = '" + pDocumento.DocumentoId.ToString() + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Item");

            DataTable dtTable = dsGlobal.Tables[0];
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                Item oItem = new Item(pDocumento, new Artigo());                
                oItem.ObjDocumento = new DocumentoData().CarregarPorId(int.Parse(dtTable.Rows[i]["DocumentoId"].ToString()));
                oItem.ObjArtigo = new ArtigoData().CarregarPorId(int.Parse(dtTable.Rows[i]["ArtigoId"].ToString()));
                oItem.Quantidade = int.Parse(dtTable.Rows[i]["Quantidade"].ToString());
                oItem.DataEntrega = DateTime.Parse(dtTable.Rows[i]["DataEntrega"].ToString());
                oItem.Valor = double.Parse(dtTable.Rows[i]["Valor"].ToString());
                oItems.Add(oItem);
            }
            return oItems;
        }
        
        public Item CarregarPorId(int pDocumentoId, int pArtigoId)
        {
            sQuery = "SELECT DocumentoId, ArtigoId, Quantidade, DataEntrega, Valor " +
                     "FROM Item " +
                     "WHERE pDocumentoId = '" + pDocumentoId.ToString() + "'" +
                     "AND   pArtigoId = '" + pArtigoId.ToString() + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Item");

            DataTable dtTable = dsGlobal.Tables[0];
            Item oItem = new Item(new Documento(new Tipo(), new Cliente()), new Artigo());

            if (dtTable.Rows.Count > 0)
            {
                oItem.ObjDocumento = new DocumentoData().CarregarPorId(int.Parse(dtTable.Rows[0]["DocumentoId"].ToString()));
                oItem.ObjArtigo = new ArtigoData().CarregarPorId(int.Parse(dtTable.Rows[0]["ArtigoId"].ToString()));
                oItem.Quantidade = int.Parse(dtTable.Rows[0]["Quantidade"].ToString());
                oItem.DataEntrega = DateTime.Parse(dtTable.Rows[0]["DataEntrega"].ToString());
                oItem.Valor = double.Parse(dtTable.Rows[0]["Valor"].ToString());
            }
            return oItem;
        }

        public void Inserir(Item oItem)
        {
            sQuery = "INSERT INTO Item (DocumentoId, ArtigoId, Quantidade, DataEntrega, Valor) " +
                     "VALUES ('" + oItem.ObjDocumento.DocumentoId.ToString() + "', '" + oItem.ObjArtigo.ArtigoId.ToString() + "', " +
                              "'" + oItem.Quantidade + "', '" + oItem.DataEntrega.ToString(formatoDataBD) + "', '" + oItem.Valor.ToString() + "')";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Item");
        }

        public void Alterar(Item oItem)
        {
            sQuery = "UPDATE Item " +
                     "SET Quantidade = '" + oItem.Quantidade.ToString() + "' " +
                     ", DataEntrega = '" + oItem.DataEntrega.ToString(formatoDataBD) + "' " +
                     ", Valor = '" + oItem.Valor + "' " +
                     "WHERE DocumentoId = '" + oItem.ObjDocumento.DocumentoId.ToString() + "'" +
                     "AND   ArtigoId = '" + oItem.ObjArtigo.ArtigoId.ToString() + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Item");
        }

        public void Excluir(Item oItem)
        {
            sQuery = "DELETE Item " +
                     "WHERE DocumentoId = '" + oItem.ObjDocumento.DocumentoId.ToString() + "'" +
                     "AND   ArtigoId = '" + oItem.ObjArtigo.ArtigoId.ToString() + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, conn);
            adapter.Fill(dsGlobal, "Item");
        }

    }
}