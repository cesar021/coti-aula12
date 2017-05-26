using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Estoque
    {
        public int IdEstoque { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        #region Relacionamentos
        public virtual ICollection<Produto> Produtos { get; set; }
        #endregion
    }
}
