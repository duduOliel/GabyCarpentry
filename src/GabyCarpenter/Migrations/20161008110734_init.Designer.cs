using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GabyCarpenter.Data;

namespace GabyCarpenter.Migrations
{
    [DbContext(typeof(GabyCarpenterContext))]
    [Migration("20161008110734_init")]
    partial class init
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

                    b.Property<byte[]>("Images");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("Price");

                    b.Property<float>("Width");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.Parts.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AmountInInvetory");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("IsInvenory");

                    b.Property<int?>("ItemModelId");

                    b.Property<float>("Length");

                    b.Property<string>("PartNumber");

                    b.Property<int>("PartPrice");

                    b.Property<string>("Provider");

                    b.Property<float>("Thickness");

                    b.Property<float>("Width");

                    b.HasKey("Id");

                    b.HasIndex("ItemModelId");

                    b.ToTable("Part");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Part");
                });

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ItemModelId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("ItemModelId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.Parts.Board", b =>
                {
                    b.HasBaseType("GabyCarpenter.Models.Carpentry.Parts.Part");

                    b.Property<int>("WoodType");

                    b.ToTable("Board");

                    b.HasDiscriminator().HasValue("Board");
                });

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.Parts.Hanger", b =>
                {
                    b.HasBaseType("GabyCarpenter.Models.Carpentry.Parts.Part");

                    b.Property<int>("Material");

                    b.ToTable("Hanger");

                    b.HasDiscriminator().HasValue("Hanger");
                });

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.Parts.Plate", b =>
                {
                    b.HasBaseType("GabyCarpenter.Models.Carpentry.Parts.Part");

                    b.Property<int>("PlateMaterial");

                    b.ToTable("Plate");

                    b.HasDiscriminator().HasValue("Plate");
                });

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.Parts.Part", b =>
                {
                    b.HasOne("GabyCarpenter.Models.Carpentry.ItemModel")
                        .WithMany("Parts")
                        .HasForeignKey("ItemModelId");
                });

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.Tag", b =>
                {
                    b.HasOne("GabyCarpenter.Models.Carpentry.ItemModel")
                        .WithMany("Tags")
                        .HasForeignKey("ItemModelId");
                });
        }
    }
}
