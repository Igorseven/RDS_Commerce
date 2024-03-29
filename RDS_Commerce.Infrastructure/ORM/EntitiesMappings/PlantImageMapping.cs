﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.EntitiesMappings.Base;

namespace RDS_Commerce.Infrastructure.ORM.EntitiesMappings;
public  class PlantImageMapping : BaseMapping, IEntityTypeConfiguration<PlantImage>
{
    public void Configure(EntityTypeBuilder<PlantImage> builder)
    {
        builder.ToTable(nameof(PlantImage), Schema);

        builder.HasKey(f => f.Id);

        builder.Property(f => f.PlantId).HasColumnType("int").HasColumnName("plant_id");

        builder.Property(f => f.Id).HasColumnName("id_fileImage");

        builder.Property(f => f.MainImage).HasColumnType("bit")
               .HasColumnName("main_image").IsRequired(true);

        builder.Property(f => f.FileBytes).HasColumnType("varbinary(max)")
               .HasColumnName("file_bytes").IsRequired(true);

        builder.Property(f => f.FileName).HasColumnType("varchar(40)")
               .HasColumnName("file_name").IsUnicode(true).IsRequired(true);

        builder.Property(f => f.FileExtension).HasColumnType("varchar(10)")
               .HasColumnName("file_extension").IsUnicode(true).IsRequired(true);

        builder.Property(f => f.RegistrationDate).HasColumnType("datetime2")
               .HasColumnName("registration_date");
    }
}
