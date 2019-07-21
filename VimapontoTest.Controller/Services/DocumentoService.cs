using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimapontoTest.Model;
using VimapontoTest.Controller.Data;

namespace VimapontoTest.Controller.Services
{
    public class DocumentoService
    {
        public List<Documento> ListarTodos()
        {
            return new DocumentoData().ListarTodos();
        }

        public Documento CarregarPorId(int pDocumentoId)
        {
            Documento oDocumento = new DocumentoData().CarregarPorId(pDocumentoId);
            oDocumento.Itens = new ItemService().ListarTodosPorDocumento(oDocumento);
            return oDocumento;
        }

        public String Inserir(Documento pDocumento)
        {
            Tipo oTipo = new TipoService().CarregarPorId(pDocumento.ObjTipo.TipoId);
            if (String.IsNullOrEmpty(oTipo.Descricao))
                return "Tipo Documento Inválido";

            Cliente oCliente = new ClienteService().CarregarPorId(pDocumento.ObjCliente.ClienteId);
            if (String.IsNullOrEmpty(oCliente.Nome))
                return "Cliente do Documento Inválido";

            if (String.IsNullOrEmpty(pDocumento.Descricao))
                return "Descricao Vazia";

            new DocumentoData().Inserir(pDocumento);
            return "Documento cadastrado com sucesso!";
        }

        public String Alterar(Documento pDocumento)
        {
            if (pDocumento.DocumentoId == 0)
                return "Id Inválido";

            new ItemService().DeletarTodosPorDocumentoId(pDocumento.DocumentoId);

            for (int i = 0; i < pDocumento.Itens.Count ; i++)
            {
                new ItemService().Inserir(pDocumento.Itens[i]);
            }

            new DocumentoData().Alterar(pDocumento);
            return "Documento alterado com sucesso!";
        }

        public String Deletar(Documento pDocumento)
        {
            if (pDocumento.DocumentoId == 0)
                return "Id Inválido";

            new ItemService().DeletarTodosPorDocumentoId(pDocumento.DocumentoId);
            new DocumentoData().Excluir(pDocumento);
            return "Documento excluido com sucesso!";
        }

    }
}
