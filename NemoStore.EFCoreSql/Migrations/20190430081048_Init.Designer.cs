﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NemoStore.EFCoreSql;

namespace NemoStore.EFCoreSql.Migrations
{
    [DbContext(typeof(NemoStoreSqlContext))]
    [Migration("20190430081048_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NemoStore.Core.Entities.Customer", b =>
                {
                    b.Property<string>("WeiXinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("WEIXINID")
                        .HasMaxLength(100);

                    b.Property<string>("HeadImgUrl")
                        .HasColumnName("HEADIMGURL")
                        .HasMaxLength(500);

                    b.HasKey("WeiXinId");

                    b.ToTable("CUSTOMER");
                });
#pragma warning restore 612, 618
        }
    }
}
