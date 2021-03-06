﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microting.eFormDashboardBase.Infrastructure.Data;

namespace Microting.eFormDashboardBase.Migrations
{
    [DbContext(typeof(eFormDashboardPnDbContext))]
    partial class eFormDashboardPnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginConfigurationValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpdatedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowState")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginConfigurationValues");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginConfigurationValueVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpdatedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowState")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginConfigurationValueVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpdatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowState")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("PluginGroupPermissions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermissionVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("PluginGroupPermissionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpdatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowState")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginGroupPermissionVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("PermissionName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpdatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowState")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginPermissions");
                });

            modelBuilder.Entity("Microting.eFormDashboardBase.Infrastructure.Data.Entities.Dashboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateFrom")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateTo")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250) CHARACTER SET utf8mb4")
                        .HasMaxLength(250);

                    b.Property<int?>("TagId")
                        .HasColumnType("int");

                    b.Property<bool>("Today")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpdatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowState")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int>("eFormId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Dashboards");
                });

            modelBuilder.Entity("Microting.eFormDashboardBase.Infrastructure.Data.Entities.DashboardItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("CalculateAverage")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ChartType")
                        .HasColumnType("int");

                    b.Property<bool>("CompareEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("DashboardId")
                        .HasColumnType("int");

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<int?>("FilterFieldId")
                        .HasColumnType("int");

                    b.Property<int?>("FilterFieldOptionId")
                        .HasColumnType("int");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpdatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowState")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DashboardId");

                    b.ToTable("DashboardItems");
                });

            modelBuilder.Entity("Microting.eFormDashboardBase.Infrastructure.Data.Entities.DashboardItemCompare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("DashboardItemId")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int?>("TagId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpdatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowState")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DashboardItemId");

                    b.ToTable("DashboardItemCompares");
                });

            modelBuilder.Entity("Microting.eFormDashboardBase.Infrastructure.Data.Entities.DashboardItemCompareVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("DashboardItemCompareId")
                        .HasColumnType("int");

                    b.Property<int>("DashboardItemId")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int?>("TagId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpdatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowState")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("DashboardItemCompareVersions");
                });

            modelBuilder.Entity("Microting.eFormDashboardBase.Infrastructure.Data.Entities.DashboardItemIgnoredFieldValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("DashboardItemId")
                        .HasColumnType("int");

                    b.Property<int>("FieldOptionId")
                        .HasColumnType("int");

                    b.Property<string>("FieldValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpdatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowState")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DashboardItemId");

                    b.ToTable("DashboardItemIgnoredFieldValues");
                });

            modelBuilder.Entity("Microting.eFormDashboardBase.Infrastructure.Data.Entities.DashboardItemIgnoredFieldValueVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("DashboardItemId")
                        .HasColumnType("int");

                    b.Property<int>("DashboardItemIgnoredFieldValueId")
                        .HasColumnType("int");

                    b.Property<int>("FieldOptionId")
                        .HasColumnType("int");

                    b.Property<string>("FieldValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpdatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowState")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("DashboardItemIgnoredFieldValueVersions");
                });

            modelBuilder.Entity("Microting.eFormDashboardBase.Infrastructure.Data.Entities.DashboardItemVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("CalculateAverage")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ChartType")
                        .HasColumnType("int");

                    b.Property<bool>("CompareEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("DashboardItemId")
                        .HasColumnType("int");

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<int?>("FilterFieldId")
                        .HasColumnType("int");

                    b.Property<int?>("FilterFieldOptionId")
                        .HasColumnType("int");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpdatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowState")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DashboardItemId");

                    b.ToTable("DashboardItemVersions");
                });

            modelBuilder.Entity("Microting.eFormDashboardBase.Infrastructure.Data.Entities.DashboardVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("DashboardId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateFrom")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateTo")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250) CHARACTER SET utf8mb4")
                        .HasMaxLength(250);

                    b.Property<int?>("TagId")
                        .HasColumnType("int");

                    b.Property<bool>("Today")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpdatedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowState")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int>("eFormId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DashboardId");

                    b.ToTable("DashboardVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermission", b =>
                {
                    b.HasOne("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginPermission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microting.eFormDashboardBase.Infrastructure.Data.Entities.DashboardItem", b =>
                {
                    b.HasOne("Microting.eFormDashboardBase.Infrastructure.Data.Entities.Dashboard", "Dashboard")
                        .WithMany("DashboardItems")
                        .HasForeignKey("DashboardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microting.eFormDashboardBase.Infrastructure.Data.Entities.DashboardItemCompare", b =>
                {
                    b.HasOne("Microting.eFormDashboardBase.Infrastructure.Data.Entities.DashboardItem", "DashboardItem")
                        .WithMany("CompareLocationsTags")
                        .HasForeignKey("DashboardItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microting.eFormDashboardBase.Infrastructure.Data.Entities.DashboardItemIgnoredFieldValue", b =>
                {
                    b.HasOne("Microting.eFormDashboardBase.Infrastructure.Data.Entities.DashboardItem", "DashboardItem")
                        .WithMany("IgnoredFieldValues")
                        .HasForeignKey("DashboardItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microting.eFormDashboardBase.Infrastructure.Data.Entities.DashboardItemVersion", b =>
                {
                    b.HasOne("Microting.eFormDashboardBase.Infrastructure.Data.Entities.DashboardItem", "DashboardItem")
                        .WithMany()
                        .HasForeignKey("DashboardItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microting.eFormDashboardBase.Infrastructure.Data.Entities.DashboardVersion", b =>
                {
                    b.HasOne("Microting.eFormDashboardBase.Infrastructure.Data.Entities.Dashboard", "Dashboard")
                        .WithMany()
                        .HasForeignKey("DashboardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
