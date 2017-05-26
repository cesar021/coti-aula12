namespace Projeto.DAL.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Projeto.DAL.DataSource.Conexao>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //permitir remover elementos da base de dados..
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Projeto.DAL.DataSource.Conexao context)
        {
            //carga inicial na tabela de Estoque..
            context.Estoque.AddOrUpdate(
            new Estoque()
            {
                IdEstoque = 1,
                Nome = "Informatica",
                Descricao = "Produtos de Informatica"
            },

            new Estoque()
            {
                IdEstoque = 2,
                Nome = "Eletronicos",
                Descricao = "Produtos Eletronicos"
            },
            new Estoque()
            {
                IdEstoque = 3,
                Nome = "Games",
                Descricao = "Jogos e Consoles"
            }
            );

        }
    }
}
