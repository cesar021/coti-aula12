using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; //connectionstring..
using System.Data.Entity; //entityframework..
using System.Data.Entity.ModelConfiguration.Conventions;
using Projeto.Entities; //entidades
using Projeto.DAL.Configurations; //mapeamento..
using System.Data.Entity.ModelConfiguration;

namespace Projeto.DAL.DataSource
{
    //classe para conexão com o banco de dados..
    //1) A Classe de conexão deverá HERDAR DbContext
    public class Conexao : DbContext
    {
        /*
        Para que o DbContext possa conectar-se corretamente na base de dados
        é necessário que lhe seja informado a connectionstring
        Para que possamos 'enviar' o endereço da connectionstring para
        o DbContext, utilizaremos o construtor da classe
        */

        //2) Enviar para o DbContext a connectionString
        public Conexao()
        : base(ConfigurationManager.ConnectionStrings["aula12"].ConnectionString)
        {
            //padrão
        }
        //3) Sobrescrever o método OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*
            Configurar algumas preferencias do EntityFramework
            e também incluir as classes de mapeamento (Configuration)
            */
            modelBuilder.Configurations.Add(new EstoqueConfiguration());
            //mapeamento..
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            //mapeamento..
            //desabilitar as definições de delete cascade..
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //interpretar propriedades string como varchar no banco de dados
            //pois o default é nvarchar
            modelBuilder.Properties<string>()
            .Configure(c => c.HasColumnType("varchar"));
        }
        //Regra 4) Habilitar o uso do LAMBDA para as entidades (CRUD)..
        public DbSet<Estoque> Estoque { get; set; } //EstoqueDAL..
        public DbSet<Produto> Produto { get; set; } //ProdutoDAL..

    }
}
