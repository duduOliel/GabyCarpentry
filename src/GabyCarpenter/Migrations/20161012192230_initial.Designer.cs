using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GabyCarpenter.Data;

namespace GabyCarpenter.Migrations
{
    [DbContext(typeof(GabyCarpenterContext))]
    [Migration("20161012192230_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.ItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<float>("Depth");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 600);

                    b.Property<float>("Height");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("Price");

                    b.Property<float>("Width");

                    b.Property<int>("amountInStock");

                    b.Property<int?>("supplierId");

                    b.Property<string>("tags");

                    b.HasKey("Id");

                    b.HasIndex("supplierId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.SavedImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName");

                    b.Property<int?>("ItemModelId");

                    b.HasKey("Id");

                    b.HasIndex("ItemModelId");

                    b.ToTable("SavedImage");
                });

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 300);

                    b.Property<string>("ContactPersonName");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNmber");

                    b.HasKey("Id");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.ItemModel", b =>
                {
                    b.HasOne("GabyCarpenter.Models.Carpentry.Supplier", "supplier")
                        .WithMany()
                        .HasForeignKey("supplierId");
                });

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.SavedImage", b =>
                {
                    b.HasOne("GabyCarpenter.Models.Carpentry.ItemModel")
                        .WithMany("Image")
                        .HasForeignKey("ItemModelId");
                });
        }
    }
}
