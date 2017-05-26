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
  
        //classe de mapeamento para a entidade Estoque
        public class EstoqueConfiguration : EntityTypeConfiguration<Estoque>
        {
            //construtor [ctor] + 2x[tab]
            public EstoqueConfiguration()
            {
                //mapeamento com LAMBDA..
                ToTable("TB_ESTOQUE"); //nome da tabela..
                                       //chave primária..
                HasKey(e => e.IdEstoque);
                //campos..
                 Property(e => e.IdEstoque)
                    .HasColumnName("IDESTOQUE_PK") //nome da coluna
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

                 Property(e => e.Nome)
                    .HasColumnName("NOME") //nome da coluna
                    .HasMaxLength(50) //nvarchar(50).IsRequired(); //not null
                    .HasMaxLength(50) //nvarchar(50)
                    .IsRequired(); //not null

                Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO") //nome da coluna
                    .HasMaxLength(250) //nvarchar(250)
                    .IsRequired(); //not null
        }
    }
}
