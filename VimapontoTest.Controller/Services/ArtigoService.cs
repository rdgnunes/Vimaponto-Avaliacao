using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VimapontoTest.Model;
using VimapontoTest.Controller.Data;

namespace VimapontoTest.Controller.Services
{
    public class ArtigoService
    {
        public List<Artigo> ListarTodos()
        {
            return new ArtigoData().ListarTodos();
        }

        public Artigo CarregarPorId(int pArtigoId)
        {
            return new ArtigoData().CarregarPorId(pArtigoId);
        }

        public String Inserir(Artigo pArtigo)
        {
            if (String.IsNullOrEmpty(pArtigo.Codigo))
                return "Código Vazio";

            if (String.IsNullOrEmpty(pArtigo.Descricao))
                return "Descricao Vazia";

            if (String.IsNullOrEmpty(pArtigo.Valor.ToString()))
                return "Valor Vazio";

            new ArtigoData().Inserir(pArtigo);
            return "Artigo cadastrado com sucesso!";
        }

        public String Alterar(Artigo pArtigo)
        {
            if (pArtigo.ArtigoId != 0)
                return "Id Inválido";

            new ArtigoData().Alterar(pArtigo);
            return "Artigo alterado com sucesso!";
        }

        public String Deletar(Artigo pArtigo)
        {
            if (pArtigo.ArtigoId != 0)
                return "Id Inválido";

            new ArtigoData().Excluir(pArtigo);
            return "Artigo excluido com sucesso!";
        }

    }
}
