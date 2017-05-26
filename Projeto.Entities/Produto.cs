using System;

namespace Projeto.Entities
{
    public  class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }
          public int IdEstoque { get; set; } //chave estrangeira

        #region Relacionamentos 

        public virtual Estoque Estoque { get; set; }
        
        #endregion
    }
}