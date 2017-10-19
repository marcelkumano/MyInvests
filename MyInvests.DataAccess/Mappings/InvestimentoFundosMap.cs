using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInvests.DataEntities.MyInvests;

namespace MyInvests.DataAccess.Mappings
{
    public class InvestimentoFundosMap : EntityTypeConfiguration<InvestimentoFundos>
    {
        public InvestimentoFundosMap()
        {
            ToTable("TBINV_Fundos");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).HasColumnName("NOM_INVE").HasMaxLength(60).IsRequired();
            Property(x => x.IdFundoRico).HasColumnName("ID_FUND_RICO").IsRequired();
            Property(x => x.DataCompra).HasColumnName("DAT_COPR").IsRequired();

            Property(x => x.ValorCompra).HasColumnName("VLR_COPR").IsRequired();
            Property(x => x.Quotas).HasColumnName("QTDE_QUOT").IsRequired();
            Property(x => x.DataCadastro).HasColumnName("DAT_CADA").IsRequired();

        }


    }
}
