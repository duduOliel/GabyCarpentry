﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GabyCarpenter.Data;

namespace GabyCarpenter.Migrations
{
    [DbContext(typeof(GabyCarpenterContext))]
    [Migration("20161020211107_orders")]
    partial class orders
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

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.OrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SheepingAddress");

                    b.Property<string>("clientName");

                    b.Property<int?>("orderdItemId");

                    b.Property<string>("phoneNumber");

                    b.Property<int>("status");

                    b.HasKey("Id");

                    b.HasIndex("orderdItemId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.SavedImage", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content");

                    b.Property<string>("ContentType")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("FileName")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int?>("itemId");

                    b.HasKey("FileId");

                    b.HasIndex("itemId");

                    b.ToTable("images");
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

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.OrderModel", b =>
                {
                    b.HasOne("GabyCarpenter.Models.Carpentry.ItemModel", "orderdItem")
                        .WithMany()
                        .HasForeignKey("orderdItemId");
                });

            modelBuilder.Entity("GabyCarpenter.Models.Carpentry.SavedImage", b =>
                {
                    b.HasOne("GabyCarpenter.Models.Carpentry.ItemModel", "item")
                        .WithMany("Image")
                        .HasForeignKey("itemId");
                });
        }
    }
}
