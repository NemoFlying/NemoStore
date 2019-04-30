using Microsoft.EntityFrameworkCore;
using NemoStore.EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NemoStore.EFCoreSql
{
    public class NemoStoreSqlContext : NemoStoreDbContext
    {
        public NemoStoreSqlContext(DbContextOptions<NemoStoreDbContext> options)
            : base(options)
        {

        }

        //配置数据库映射
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
