using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimapontoTest.Model
{
    public class Item 
    {
        public Documento ObjDocumento { get; set; }
        public Artigo ObjArtigo { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataEntrega { get; set; }
        public Double Valor { get; set; }
        public int Ordem { get; set; }

        public Item(Documento oDocumento, Artigo oArtigo) {
            ObjDocumento = oDocumento;
            ObjArtigo = oArtigo;
        }
    }
}
