using Microsoft.EntityFrameworkCore;
using NemoStore.Core.Entities;
using NemoStore.EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NemoStore.EFCoreOracle
{
    public class NemoStoreOraContext : NemoStoreDbContext
    {
        public NemoStoreOraContext(DbContextOptions<NemoStoreDbContext> options)
            : base(options)
        {

        }

        //配置数据库映射
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("NETCORE");
            base.OnModelCreating(modelBuilder);
        }

    }
}
