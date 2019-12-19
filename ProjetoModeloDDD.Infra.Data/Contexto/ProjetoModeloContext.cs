using ProjetoModeloDDD.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System;
using ProjetoModeloDDD.Infra.Data.EntityConfig;
namespace ProjetoModeloDDD.Infra.Data.Contexto
{
    public class ProjetoModeloContext : DbContext // tem que installatar o pacote entity Frameworks " Install-Package EntityFramework"
    {
        public ProjetoModeloContext() : base("ProjetoModeloDDD")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) //conversoes na tabela com entity
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Remove os Plurais criando automaticamente nas tabelas 
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); // não vai mais remover em cascata quando tiver relação um pra muitos
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); // não vai mais remover em cascata quando tiver relação muito pra muitos

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey()); // Quando a propriedade tiver o id no final, ela sera primary key da tabela

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar")); // converte todo string em varchar, se caso não for informado o tipo  

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100)); // tudo que é string tera tamanho maximo de 100 caracters, se caso não for informado o tamnaho 

            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
                
            }                        
            return base.SaveChanges();
        }
    
    }  
}
