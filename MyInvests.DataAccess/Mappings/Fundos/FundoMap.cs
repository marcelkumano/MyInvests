using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInvests.DataEntities.MyInvests2.Fundos;

namespace MyInvests.DataAccess.Mappings.Fundos
{
    public class FundoMap : EntityTypeConfiguration<Fundo>
    {
        public FundoMap()
        {
            ToTable("TBINV_FUND");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("ID_FUND").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Nome).HasColumnName("NOM_FUND").HasMaxLength(200).IsRequired();
            Property(x => x.DescricaoTipo).HasColumnName("DESC_TIPO").HasMaxLength(200).IsRequired();
            Property(x => x.DataAtualizacao).HasColumnName("DAT_ATUI").IsRequired();

        }


    }
}
