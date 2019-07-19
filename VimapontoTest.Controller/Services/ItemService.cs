using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimapontoTest.Model;
using VimapontoTest.Controller.Data;
using System.Globalization;

namespace VimapontoTest.Controller.Services
{
    public class ItemService
    {
        public List<Item> ListarTodosPorDocumento(Documento pDocumento)
        {
            return new ItemData().ListarTodosPorDocumento(pDocumento);
        }

        public Item CarregarPorId(Item pItem)
        {
            return new ItemData().CarregarPorId(pItem.ObjDocumento.DocumentoId, pItem.ObjArtigo.ArtigoId);
        }

        public String Inserir(Item pItem)
        {
            Documento oDocumento = new DocumentoService().CarregarPorId(pItem.ObjDocumento.DocumentoId);
            if (String.IsNullOrEmpty(oDocumento.Descricao))
                return "Documento Inválido";

            Artigo oArtigo = new ArtigoService().CarregarPorId(pItem.ObjArtigo.ArtigoId);
            if (String.IsNullOrEmpty(oArtigo.Codigo))
                return "Artigo Inválido";

            DateTime dateValue;
            if (!DateTime.TryParseExact(pItem.DataEntrega.ToString(), "dd/MM/yyyy", new CultureInfo("pt-PT"), DateTimeStyles.None, out dateValue))
                return "Data de Entrega Inválida";

            new ItemData().Inserir(pItem);
            return "Item cadastrado com sucesso!";
        }

        public String Alterar(Item pItem)
        {
            Documento oDocumento = new DocumentoService().CarregarPorId(pItem.ObjDocumento.DocumentoId);
            if (String.IsNullOrEmpty(oDocumento.Descricao))
                return "Documento Inválido";

            Artigo oArtigo = new ArtigoService().CarregarPorId(pItem.ObjArtigo.ArtigoId);
            if (String.IsNullOrEmpty(oArtigo.Codigo))
                return "Artigo Inválido";

            new ItemData().Alterar(pItem);
            return "Item alterado com sucesso!";
        }

        public String Deletar(Item pItem)
        {
            Documento oDocumento = new DocumentoService().CarregarPorId(pItem.ObjDocumento.DocumentoId);
            if (String.IsNullOrEmpty(oDocumento.Descricao))
                return "Documento Inválido";

            Artigo oArtigo = new ArtigoService().CarregarPorId(pItem.ObjArtigo.ArtigoId);
            if (String.IsNullOrEmpty(oArtigo.Codigo))
                return "Artigo Inválido";

            new ItemData().Excluir(pItem);
            return "Item excluido com sucesso!";
        }
    }
}
