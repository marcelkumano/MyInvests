using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyInvests.DataAccess.DataContexts
{
    public class MyInvestsDataContext : DbContext
    {
        /// <summary>
        /// Construtor do DataContext
        /// </summary>
        public MyInvestsDataContext(): base("MyInvests")
        {
            //Tipo de inicializção da Context, defini como validar o DB vs Model
            Database.SetInitializer<MyInvestsDataContext>(new CustomDevStoreDataContextInitializer());

            //Não carregar as propriedades filhas (dominios forein keys) automaticamente. Apenas quando solicitado
            Configuration.LazyLoadingEnabled = false;

            //Proxy é utilizado pelo entity para os mecanismos de LazyLaoad  e Tracking
            Configuration.ProxyCreationEnabled = false;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Retira a pluralização automática das palavras
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new Mappings.InvestimentoRendaFixaMap());
            modelBuilder.Configurations.Add(new Mappings.CategoriaInvestimentoMap());
            modelBuilder.Configurations.Add(new Mappings.InvestimentoRendaFixaPosicaoMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DataEntities.MyInvests.InvestimentoRendaFixa> InvestimentoRendaFixa { get; set; }

        public DbSet<DataEntities.MyInvests.CategoriaInvestimento> CategoriasInvestimento { get; set; }

        public DbSet<DataEntities.MyInvests.InvestimentoRendaFixaPosicao> InvestimentoRendaFixaPosicao { get; set; }

    }


    /// <summary>
    /// Tipos Defualt de Inicialização.
    ///    CreateDatabaseIfNotExists
    ///    DropCreateDatabaseWhenModelChanges
    ///    DropCreateDatabaseAlways
    /// </summary>
    public class DefaultDevStoreDataContextInitializer : DropCreateDatabaseIfModelChanges<MyInvestsDataContext>
    {
        protected override void Seed(MyInvestsDataContext context)
        {
            //context.Category.Add(new Domain.Category() { Id = 1, Title = "Informática" });
            //context.Category.Add(new Domain.Category() { Id = 2, Title = "Games" });
            //context.Category.Add(new Domain.Category() { Id = 3, Title = "Papelaria" });
            //context.SaveChanges();

            //context.Products.Add(new Domain.Product() { Id = 1, CategoryId = 1, IsActive = true, Title = "Produto 1" });
            //context.Products.Add(new Domain.Product() { Id = 2, CategoryId = 1, IsActive = true, Title = "Produto 2" });
            //context.Products.Add(new Domain.Product() { Id = 3, CategoryId = 1, IsActive = true, Title = "Produto 3" });
            //context.SaveChanges();

            base.Seed(context);
        }
    }

    public class CustomDevStoreDataContextInitializer : IDatabaseInitializer<MyInvestsDataContext>
    {
        public void InitializeDatabase(MyInvestsDataContext context)
        {
            if (context.Database.Exists())
            {
                if (!context.Database.CompatibleWithModel(true))
                {
                    context.Database.Delete();
                }
            }

            if (!context.Database.Exists())
            {
                context.Database.Create();
                this.Seed(context);
            }
        }

        protected void Seed(MyInvestsDataContext context)
        {
            context.CategoriasInvestimento.Add(new DataEntities.MyInvests.CategoriaInvestimento() { Id = 1, Nome = "Renda Fixa" });
            context.CategoriasInvestimento.Add(new DataEntities.MyInvests.CategoriaInvestimento() { Id = 2, Nome = "Fundos de Investimento" });

            context.SaveChanges();
        }
    }
}
