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

        public List<Documento> Listar(int? TipoId, int? ClienteId)
        {
            return new DocumentoData().Listar(TipoId, ClienteId);
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

            pDocumento.DocumentoId = new DocumentoData().Inserir(pDocumento);

            if (pDocumento.DocumentoId == 0)
                return "Id do Documento inválido!";

            for (int i = 0; i < pDocumento.Itens.Count; i++)
            {
                pDocumento.Itens[i].ObjDocumento.DocumentoId = pDocumento.DocumentoId;
                new ItemService().Inserir(pDocumento.Itens[i]);
            }
            return "Documento cadastrado com sucesso!";
        }

        public String Alterar(Documento pDocumento)
        {
            if (pDocumento.DocumentoId == 0)
                return "Id Inválido";

            new ItemService().DeletarTodosPorDocumentoId(pDocumento.DocumentoId);

            for (int i = 0; i < pDocumento.Itens.Count; i++)
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

        public List<Relatorio> GetRelatorioDocumento(int pDocumentoId)
        {
            var result = new List<Relatorio>();
            Documento oDocumento = new DocumentoData().CarregarPorId(pDocumentoId);
            oDocumento.Itens = new ItemService().ListarTodosPorDocumento(oDocumento);

            if (oDocumento.Itens.Count > 0)
            {
                Double total = 0;
                for (int i = 0; i < oDocumento.Itens.Count; i++)
                {
                    total = oDocumento.Itens[i].Valor * oDocumento.Itens[i].Quantidade;
                    result.Add(new Relatorio(oDocumento.DocumentoId, oDocumento.Descricao, oDocumento.DataAlteracao, oDocumento.Itens[i].Ordem,
                                             oDocumento.Itens[i].ObjArtigo.Descricao, oDocumento.Itens[i].DataEntrega, oDocumento.Itens[i].Valor, oDocumento.Itens[i].Quantidade, total,
                                             oDocumento.ObjCliente.Nome, oDocumento.ObjCliente.Morada, oDocumento.ObjCliente.Contato));
                }
            }
            else
            {
                result.Add(new Relatorio(oDocumento.DocumentoId, oDocumento.Descricao, oDocumento.DataAlteracao, null,
                                         null, null, null, null, null, oDocumento.ObjCliente.Nome, oDocumento.ObjCliente.Morada, 
                                         oDocumento.ObjCliente.Contato));
            }

            return result;
        }

    }
}
