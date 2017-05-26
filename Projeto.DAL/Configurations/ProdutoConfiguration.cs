using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.DAL.Configurations
{
    //classe de mapeamento para a entidade Produto
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        //construtor..
        public ProdutoConfiguration()
        {
            ToTable("TB_PRODUTO"); //nome da tabela..
                                   //chave primária..
            HasKey(p => p.IdProduto);
            //campos..
            Property(p => p.IdProduto)
            .HasColumnName("IDPRODUTO_PK") //nome da coluna..
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Nome)
                .HasColumnName("NOME") //nome da coluna..
                .HasMaxLength(50) //nvarchar(50)
                .IsRequired(); //not null

            Property(p => p.Preco)
                .HasColumnName("PRECO") //nome da coluna..
                .HasPrecision(18, 2) //decimal(18,2)
                .IsRequired(); //not null
            Property(p => p.Quantidade)
            .HasColumnName("QUANTIDADE") //nome da coluna..
            .IsRequired(); //not null

            Property(p => p.DataCadastro)
            .HasColumnName("DATACADASTRO") //nome da coluna..
            .IsRequired(); //not null

            Property(p => p.IdEstoque)
                .HasColumnName("IDESTOQUE_FK") //nome da coluna..
                .IsRequired(); //not null..


            #region Relacionamentos
            /*
            - Cada Produto Pertence obrigatoriamente a 1 Estoque
            - Estoque Possui Muitos Produtos
            - A chave estrangeira é o campo IdEstoque na entidade Produto
            */
            HasRequired(p => p.Estoque) //Produto TEM 1 Estoque
            .WithMany(e => e.Produtos) //Estoque TEM Muitos Produtos
            .HasForeignKey(p => p.IdEstoque); //Chave Estrangeira
            #endregion


        }

    }
}
