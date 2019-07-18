using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VimapontoTest.Model;
using VimapontoTest.Controller.Data;

namespace VimapontoTest.Controller.Services
{
    public class TipoService
    {
        public List<Tipo> ListarTodos()
        {
            return new TipoData().ListarTodos();
        }

        public Tipo CarregarPorId(int pTipoId)
        {
            return new TipoData().CarregarPorId(pTipoId);
        }

        public String Inserir(Tipo pTipo)
        {
            if (String.IsNullOrEmpty(pTipo.Descricao))
                return "Descricao Vazia";

            new TipoData().Inserir(pTipo);
            return "Tipo cadastrado com sucesso!";
        }

        public String Alterar(Tipo pTipo)
        {
            if (pTipo.TipoId != 0)
                return "Id Inválido";

            new TipoData().Alterar(pTipo);
            return "Tipo alterado com sucesso!";
        }

        public String Deletar(Tipo pTipo)
        {
            if (pTipo.TipoId != 0)
                return "Id Inválido";

            new TipoData().Excluir(pTipo);
            return "Tipo excluido com sucesso!";
        }

    }
}
