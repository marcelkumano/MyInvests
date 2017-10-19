using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInvests.DataEntities.MyInvests;

namespace MyInvests.DataAccess.Mappings
{
    public class CategoriaInvestimentoMap : EntityTypeConfiguration<CategoriaInvestimento>
    {
        public CategoriaInvestimentoMap()
        {
            ToTable("TBINV_CategoriaInvestimentos");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("ID");
            Property(x => x.Nome).HasColumnName("NOM_INVE").HasMaxLength(60).IsRequired();
        }
    }
}
