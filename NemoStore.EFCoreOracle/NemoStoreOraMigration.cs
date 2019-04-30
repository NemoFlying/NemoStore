using Microsoft.EntityFrameworkCore;
using NemoStore.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NemoStore.EFCoreOracle
{
    public class NemoStoreOraMigration : NemoStoreDbMigration
    {

        public NemoStoreOraMigration(NemoStoreDbContext dbContext) :
            base(dbContext)
        {
        }

        //自动迁移数据库
        public override void AutoMigration()
        {
            //获取所有迁移文件
            var allMigrations = dbContext.Database.GetMigrations().ToList();
            //迁移文件没有应该手动使用 Add-Migration 创建
            //可否通过代码进行创建呢？？？？？？？？？？？？？？？？？？？？？？
            var appliedMigrations = dbContext.Database.GetAppliedMigrations().ToList();
            if (allMigrations.Count() - appliedMigrations.Count() > 0)  //表示有新的迁移
            {
                dbContext.Database.Migrate();
            }
            //进行DB 初始化数据
            base.Seed();
        }
    }
}
