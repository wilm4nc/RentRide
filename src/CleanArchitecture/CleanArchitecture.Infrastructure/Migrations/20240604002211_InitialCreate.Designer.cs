﻿// <auto-generated />
using System;
using CleanArchitecture.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240604002211_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CleanArchitecture.Domain.Alquileres.Alquiler", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("FechaCancelacion")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_cancelacion");

                    b.Property<DateTime?>("FechaCompletado")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_completado");

                    b.Property<DateTime?>("FechaConfirmacion")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_confirmacion");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_creacion");

                    b.Property<DateTime?>("FechaDenegacion")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_denegacion");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid?>("VehiculoId")
                        .HasColumnType("uuid")
                        .HasColumnName("vehiculo_id");

                    b.HasKey("Id")
                        .HasName("pk_alquileres");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_alquileres_user_id");

                    b.HasIndex("VehiculoId")
                        .HasDatabaseName("ix_alquileres_vehiculo_id");

                    b.ToTable("alquileres", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Permissions.Permission", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Nombre")
                        .HasColumnType("text")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("pk_permissions");

                    b.ToTable("permissions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "ReadUser"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "WriteUser"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "UpdateUser"
                        });
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Reviews.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("AlquilerId")
                        .HasColumnType("uuid")
                        .HasColumnName("alquiler_id");

                    b.Property<string>("Comentario")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("comentario");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_creacion");

                    b.Property<int?>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid?>("VehiculoId")
                        .HasColumnType("uuid")
                        .HasColumnName("vehiculo_id");

                    b.HasKey("Id")
                        .HasName("pk_reviews");

                    b.HasIndex("AlquilerId")
                        .HasDatabaseName("ix_reviews_alquiler_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_reviews_user_id");

                    b.HasIndex("VehiculoId")
                        .HasDatabaseName("ix_reviews_vehiculo_id");

                    b.ToTable("reviews", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Roles.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.ToTable("roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cliente"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Roles.RolePermission", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.Property<int>("PermissionId")
                        .HasColumnType("integer")
                        .HasColumnName("permission_id");

                    b.HasKey("RoleId", "PermissionId")
                        .HasName("pk_roles_permissions");

                    b.HasIndex("PermissionId")
                        .HasDatabaseName("ix_roles_permissions_permission_id");

                    b.ToTable("roles_permissions", (string)null);

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            PermissionId = 1
                        },
                        new
                        {
                            RoleId = 2,
                            PermissionId = 2
                        },
                        new
                        {
                            RoleId = 2,
                            PermissionId = 3
                        },
                        new
                        {
                            RoleId = 2,
                            PermissionId = 1
                        });
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Apellido")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("apellido");

                    b.Property<string>("Email")
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("nombre");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("password_hash");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Users.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("RoleId", "UserId")
                        .HasName("pk_users_roles");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_users_roles_user_id");

                    b.ToTable("users_roles", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Vehiculos.Vehiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int[]>("Accesorios")
                        .IsRequired()
                        .HasColumnType("integer[]")
                        .HasColumnName("accesorios");

                    b.Property<DateTime?>("FechaUltimaAlquiler")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_ultima_alquiler");

                    b.Property<string>("Modelo")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("modelo");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.Property<string>("Vin")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("vin");

                    b.HasKey("Id")
                        .HasName("pk_vehiculos");

                    b.ToTable("vehiculos", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Alquileres.Alquiler", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_alquileres_user_user_temp_id1");

                    b.HasOne("CleanArchitecture.Domain.Vehiculos.Vehiculo", null)
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .HasConstraintName("fk_alquileres_vehiculo_vehiculo_temp_id");

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Moneda", "Accesorios", b1 =>
                        {
                            b1.Property<Guid>("AlquilerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("numeric")
                                .HasColumnName("accesorios_monto");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("accesorios_tipo_moneda");

                            b1.HasKey("AlquilerId");

                            b1.ToTable("alquileres");

                            b1.WithOwner()
                                .HasForeignKey("AlquilerId")
                                .HasConstraintName("fk_alquileres_alquileres_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Moneda", "Mantenimiento", b1 =>
                        {
                            b1.Property<Guid>("AlquilerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("numeric")
                                .HasColumnName("mantenimiento_monto");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("mantenimiento_tipo_moneda");

                            b1.HasKey("AlquilerId");

                            b1.ToTable("alquileres");

                            b1.WithOwner()
                                .HasForeignKey("AlquilerId")
                                .HasConstraintName("fk_alquileres_alquileres_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Moneda", "PrecioPorPeriodo", b1 =>
                        {
                            b1.Property<Guid>("AlquilerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("numeric")
                                .HasColumnName("precio_por_periodo_monto");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("precio_por_periodo_tipo_moneda");

                            b1.HasKey("AlquilerId");

                            b1.ToTable("alquileres");

                            b1.WithOwner()
                                .HasForeignKey("AlquilerId")
                                .HasConstraintName("fk_alquileres_alquileres_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Moneda", "PrecioTotal", b1 =>
                        {
                            b1.Property<Guid>("AlquilerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("numeric")
                                .HasColumnName("precio_total_monto");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("precio_total_tipo_moneda");

                            b1.HasKey("AlquilerId");

                            b1.ToTable("alquileres");

                            b1.WithOwner()
                                .HasForeignKey("AlquilerId")
                                .HasConstraintName("fk_alquileres_alquileres_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Alquileres.DateRange", "Duracion", b1 =>
                        {
                            b1.Property<Guid>("AlquilerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<DateOnly>("Fin")
                                .HasColumnType("date")
                                .HasColumnName("duracion_fin");

                            b1.Property<DateOnly>("Inicio")
                                .HasColumnType("date")
                                .HasColumnName("duracion_inicio");

                            b1.HasKey("AlquilerId");

                            b1.ToTable("alquileres");

                            b1.WithOwner()
                                .HasForeignKey("AlquilerId")
                                .HasConstraintName("fk_alquileres_alquileres_id");
                        });

                    b.Navigation("Accesorios");

                    b.Navigation("Duracion");

                    b.Navigation("Mantenimiento");

                    b.Navigation("PrecioPorPeriodo");

                    b.Navigation("PrecioTotal");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Reviews.Review", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Alquileres.Alquiler", null)
                        .WithMany()
                        .HasForeignKey("AlquilerId")
                        .HasConstraintName("fk_reviews_alquileres_alquiler_id1");

                    b.HasOne("CleanArchitecture.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_reviews_user_user_temp_id1");

                    b.HasOne("CleanArchitecture.Domain.Vehiculos.Vehiculo", null)
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .HasConstraintName("fk_reviews_vehiculo_vehiculo_temp_id");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Roles.RolePermission", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Permissions.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_roles_permissions_permissions_permissions_id");

                    b.HasOne("CleanArchitecture.Domain.Roles.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_roles_permissions_roles_role_id");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Users.UserRole", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Roles.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_roles_roles_role_id");

                    b.HasOne("CleanArchitecture.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_roles_users_user_id1");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Vehiculos.Vehiculo", b =>
                {
                    b.OwnsOne("CleanArchitecture.Domain.Vehiculos.Direccion", "Direccion", b1 =>
                        {
                            b1.Property<Guid>("VehiculoId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Calle")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("direccion_calle");

                            b1.Property<string>("Ciudad")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("direccion_ciudad");

                            b1.Property<string>("Departamento")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("direccion_departamento");

                            b1.Property<string>("Pais")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("direccion_pais");

                            b1.Property<string>("Provincia")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("direccion_provincia");

                            b1.HasKey("VehiculoId");

                            b1.ToTable("vehiculos");

                            b1.WithOwner()
                                .HasForeignKey("VehiculoId")
                                .HasConstraintName("fk_vehiculos_vehiculos_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Moneda", "Mantenimiento", b1 =>
                        {
                            b1.Property<Guid>("VehiculoId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("numeric")
                                .HasColumnName("mantenimiento_monto");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("mantenimiento_tipo_moneda");

                            b1.HasKey("VehiculoId");

                            b1.ToTable("vehiculos");

                            b1.WithOwner()
                                .HasForeignKey("VehiculoId")
                                .HasConstraintName("fk_vehiculos_vehiculos_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Moneda", "Precio", b1 =>
                        {
                            b1.Property<Guid>("VehiculoId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("numeric")
                                .HasColumnName("precio_monto");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("precio_tipo_moneda");

                            b1.HasKey("VehiculoId");

                            b1.ToTable("vehiculos");

                            b1.WithOwner()
                                .HasForeignKey("VehiculoId")
                                .HasConstraintName("fk_vehiculos_vehiculos_id");
                        });

                    b.Navigation("Direccion");

                    b.Navigation("Mantenimiento");

                    b.Navigation("Precio");
                });
#pragma warning restore 612, 618
        }
    }
}
