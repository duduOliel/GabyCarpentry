using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GabyCarpenter.Data;

namespace GabyCarpenter.Migrations
{
    [DbContext(typeof(GabyCarpenterContext))]
    [Migration("20161005204101_CreateTables1")]
    partial class CreateTables1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.ItemModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("color");

                    b.Property<float>("depth");

                    b.Property<string>("description")
                        .HasAnnotation("MaxLength", 600);

                    b.Property<float>("height");

                    b.Property<byte[]>("images");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("price");

                    b.Property<float>("width");

                    b.HasKey("id");

                    b.ToTable("items");
                });

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.Tag", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ItemModelid");

                    b.Property<string>("text");

                    b.HasKey("id");

                    b.HasIndex("ItemModelid");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Models.Carpentry.Part", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<int?>("ItemModelid");

                    b.Property<int>("amountInInvetory");

                    b.Property<string>("partNumber");

                    b.Property<int>("price");

                    b.Property<string>("provider");

                    b.HasKey("id");

                    b.HasIndex("ItemModelid");

                    b.ToTable("parts");
                });

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.Tag", b =>
                {
                    b.HasOne("GabyCarpenter.Models.Carpentry.ItemModel")
                        .WithMany("tags")
                        .HasForeignKey("ItemModelid");
                });

            modelBuilder.Entity("Models.Carpentry.Part", b =>
                {
                    b.HasOne("GabyCarpenter.Models.Carpentry.ItemModel")
                        .WithMany("parts")
                        .HasForeignKey("ItemModelid");
                });
        }
    }
}
