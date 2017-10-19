using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInvests.DataEntities.MyInvests;

namespace MyInvests.DataAccess.Mappings
{
    public class InvestimentoRendaFixaMap : EntityTypeConfiguration<InvestimentoRendaFixa>
    {
        public InvestimentoRendaFixaMap()
        {
            ToTable("TBINV_RendaFixa");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Nome).HasColumnName("NOM_INVE").HasMaxLength(60).IsRequired();
            Property(x => x.DataCompra).HasColumnName("DAT_COPR").IsRequired();

            Property(x => x.DataVencimento).HasColumnName("DAT_VENC").IsOptional();
            Property(x => x.ValorCompra).HasColumnName("VLR_COPR").IsRequired();
            Property(x => x.Unidades).HasColumnName("QTDE_UNID").IsRequired();


            Property(x => x.IdCategoria).HasColumnName("ID_CATE_INVE");

            //DEFINIR UMA FK NAO NULA
            HasRequired(x => x.Categoria).WithMany().HasForeignKey(x => x.IdCategoria);

        }


    }
}
