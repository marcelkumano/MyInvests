using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInvests.DataEntities.MyInvests2.Fundos;

namespace MyInvests.DataAccess.Mappings.Fundos
{
    public class PosicaoFundoMap : EntityTypeConfiguration<PosicaoFundo>
    {
        public PosicaoFundoMap()
        {
            ToTable("TBINV_FUND_POSI");

            HasKey(x => new { x.IdFundo, x.DataReferencia });

            Property(x => x.IdFundo).HasColumnName("ID_FUND").IsRequired();
            Property(x => x.DataReferencia).HasColumnName("DAT_REF").IsRequired();
            Property(x => x.ValorPorCota).HasColumnName("VLR_COTA").IsRequired().HasPrecision(20, 10);

            HasRequired(x => x.Fundo).WithMany().HasForeignKey(x => x.IdFundo);
        }
    }
}
