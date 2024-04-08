using Conspiracao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conspiracao.Infra.Data.EntitiesConfiguration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.ValorUnitario).IsRequired();
            builder.Property(x => x.Desconto).IsRequired();
            builder.Property(x => x.DescricaoItem).HasMaxLength(100).IsRequired();

        }
    }
}
