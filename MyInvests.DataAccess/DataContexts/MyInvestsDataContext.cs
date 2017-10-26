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

            modelBuilder.Configurations.Add(new Mappings.Fundos.FundoMap());
            modelBuilder.Configurations.Add(new Mappings.Fundos.InvestimentoMap());
            modelBuilder.Configurations.Add(new Mappings.Fundos.PosicaoFundoMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DataEntities.MyInvests.InvestimentoRendaFixa> InvestimentoRendaFixa { get; set; }

        public DbSet<DataEntities.MyInvests.CategoriaInvestimento> CategoriasInvestimento { get; set; }

        public DbSet<DataEntities.MyInvests.InvestimentoRendaFixaPosicao> InvestimentoRendaFixaPosicao { get; set; }

        public DbSet<DataEntities.MyInvests2.Fundos.Fundo> Fundos { get; set; }

        public DbSet<DataEntities.MyInvests2.Fundos.Investimento> FundosInvestimento { get; set; }

        public DbSet<DataEntities.MyInvests2.Fundos.PosicaoFundo> FundosPosicao { get; set; }

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
        }
    }
}
