using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimapontoTest.Model
{
    public class Documento 
    {
        public int DocumentoId { get; set; }
        public Tipo ObjTipo { get; set; }
        public Cliente ObjCliente { get; set; }
        public String Descricao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public List<Item> Itens { get; set; }

        public Documento(Tipo oTipo, Cliente oCliente)
        {
            ObjTipo = oTipo;
            ObjCliente = oCliente;
        }
    }
}
