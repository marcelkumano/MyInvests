using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInvests.DataEntities.MyInvests;

namespace MyInvests.DataAccess.Mappings
{
    public class InvestimentoRendaFixaPosicaoMap : EntityTypeConfiguration<InvestimentoRendaFixaPosicao>
    {
        public InvestimentoRendaFixaPosicaoMap()
        {
            ToTable("TBINV_RendaFixaPosicao");

            HasKey(x => x.Id);  

            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdInvestimento).HasColumnName("ID_INVE");
            Property(x => x.DataReferencia).HasColumnName("DAT_REF");
            Property(x => x.ValorAtual).HasColumnName("VLR_ATUA").IsRequired();
            Property(x => x.ValorPorUnidade).HasColumnName("VLR_POR_UNID").IsRequired();
            Property(x => x.ValorIR).HasColumnName("VALOR_IR").IsRequired();
            Property(x => x.TaxaIR).HasColumnName("TAXA_IR").IsRequired().HasPrecision(18, 3);
            Property(x => x.DataAtualizacao).HasColumnName("DAT_ATUI").IsRequired();

            HasRequired(x => x.Investimento).WithMany().HasForeignKey(x => x.IdInvestimento);
        }
    }
}
