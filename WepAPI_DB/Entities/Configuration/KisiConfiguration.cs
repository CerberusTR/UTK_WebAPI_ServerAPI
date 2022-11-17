using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WepAPI_DB.Entities.Configuration
{
    public class KisiConfiguration : IEntityTypeConfiguration<Kisi>
    {
        public void Configure(EntityTypeBuilder<Kisi> builder)
        {
            builder.Property(x => x.ID)
                .IsRequired()
                .UseIdentityColumn();
            builder.Property(x => x.TC)
                .IsRequired();
            builder.Property(x => x.Ad)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Soyad)
                .IsRequired()
                
                .HasMaxLength(50);
            builder.Property(x => x.DogumTarihi)
                .IsRequired();
            builder.Property(x => x.CinsiyetKisi)
                .IsRequired();
            builder.HasKey(x => x.ID);
            builder.HasIndex(x => x.TC)
               .IsUnique();


        }
    }
}
