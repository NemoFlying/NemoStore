using Microsoft.EntityFrameworkCore;
using NemoStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NemoStore.EFCore
{
    public abstract class NemoStoreDbContext :DbContext
    {
        public NemoStoreDbContext(DbContextOptions<NemoStoreDbContext> options)
            : base(options)
        {
            //this.
        }

        //定义数据库表
        public DbSet<Customer> Customer { get; set; }






    }
}
