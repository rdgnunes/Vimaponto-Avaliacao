using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimapontoTest.Model
{
    public class Relatorio
    {
        public int DocumentoId { get; set; }
        public string DescricaoDoc { get; set; }
        public DateTime DataAlteracao { get; set; }

        public int Ordem { get; set; }
        public string DescricaoArtigo { get; set; }
        public DateTime DataEntrega { get; set; }
        public Double Valor { get; set; }
        public int Quantidade { get; set; }
        public Double Total { get; set; }

        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Contato { get; set; }

        public Relatorio(int pDocumentoId, string pDescricaoDoc, DateTime pDataAlteracao, int? pOrdem, string pDescricaoArtigo, 
                         DateTime? pDataEntrega, Double? pValor, int? pQuantidade, Double? pTotal, string pNome, string pMorada, 
                         string pContato)
        {
            DocumentoId = pDocumentoId;
            DescricaoDoc = pDescricaoDoc;
            DataAlteracao = pDataAlteracao;
            Nome = pNome;
            Morada = pMorada;
            Contato = pContato;
            
            if (pOrdem.HasValue)
            {
                Ordem = pOrdem.Value;
            }

            if ( !string.IsNullOrEmpty( pDescricaoArtigo))
            {
                DescricaoArtigo = pDescricaoArtigo;
            }

            if (pDataEntrega.HasValue)
            {
                DataEntrega = pDataEntrega.Value;
            }

            if (pValor.HasValue)
            {
                Valor = pValor.Value;
            }

            if (pQuantidade.HasValue)
            {
                Quantidade = pQuantidade.Value;
            }

            if (pTotal.HasValue)
            {
                Total = pTotal.Value;
            }
        }
    }
}
