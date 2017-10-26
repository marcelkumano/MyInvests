using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInvests.DataEntities.MyInvests2.Fundos;

namespace MyInvests.DataAccess.Mappings.Fundos
{
    public class InvestimentoMap : EntityTypeConfiguration<Investimento>
    {
        public InvestimentoMap()
        {
            ToTable("TBINV_FUND_INVE");

            HasKey(x => new { x.IdFundo, x.DataCompra });  

            Property(x => x.IdFundo).HasColumnName("ID_FUND").IsRequired();
            Property(x => x.DataCompra).HasColumnName("DAT_COMPR").IsRequired();
            Property(x => x.QuantidadeCotas).HasColumnName("QTD_COTA").IsRequired().HasPrecision(20, 10);
            Property(x => x.ValorIR).HasColumnName("VLR_IR").IsRequired();
            Property(x => x.ValorCompraCota).HasColumnName("VLR_COMPR_COTA").IsRequired().HasPrecision(20, 10);

            HasRequired(x => x.Fundo).WithMany().HasForeignKey(x => x.IdFundo);
        }
    }
}
