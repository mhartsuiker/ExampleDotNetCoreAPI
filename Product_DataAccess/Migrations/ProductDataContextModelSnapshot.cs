﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Product.DataAccess;
using System;

namespace Product.DataAccess.Migrations
{
    [DbContext(typeof(ProductDataContext))]
    partial class ProductDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Product.Contracts.DataTypes.Item", b =>
                {
                    b.Property<Guid>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("DescriptionItemDescriptionId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("PriceItemPriceId");

                    b.HasKey("ItemId");

                    b.HasIndex("DescriptionItemDescriptionId");

                    b.HasIndex("PriceItemPriceId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Product.Contracts.DataTypes.ItemDescription", b =>
                {
                    b.Property<Guid>("ItemDescriptionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LongText");

                    b.Property<string>("ShortText")
                        .IsRequired();

                    b.HasKey("ItemDescriptionId");

                    b.ToTable("ItemDescription");
                });

            modelBuilder.Entity("Product.Contracts.DataTypes.ItemPrice", b =>
                {
                    b.Property<Guid>("ItemPriceId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Value");

                    b.HasKey("ItemPriceId");

                    b.ToTable("ItemPrice");
                });

            modelBuilder.Entity("Product.Contracts.DataTypes.Item", b =>
                {
                    b.HasOne("Product.Contracts.DataTypes.ItemDescription", "Description")
                        .WithMany()
                        .HasForeignKey("DescriptionItemDescriptionId");

                    b.HasOne("Product.Contracts.DataTypes.ItemPrice", "Price")
                        .WithMany()
                        .HasForeignKey("PriceItemPriceId");
                });
#pragma warning restore 612, 618
        }
    }
}
