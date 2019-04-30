using NemoStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace NemoStore.EFCore
{
    public class NemoStoreDbMigration
    {
        public NemoStoreDbContext dbContext;

        public NemoStoreDbMigration(NemoStoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 主要通过继承靠子类实现该方法进行自动数据库迁移
        /// </summary>
        /// <param name="dbContext"></param>
        public virtual void AutoMigration()
        {

        }

        /// <summary>
        /// 初始化DB数据
        /// </summary>
        /// <param name="dbContext"></param>
        public void Seed()
        {
            if (dbContext.Customer.Any())
            {
                return;  //DB Has Been Seeded
            }
            var customer = new Customer()
            {
                WeiXinId = "1",
                HeadImgUrl = "http://www.baidu.com"
            };
            dbContext.Customer.Add(customer);
            dbContext.SaveChanges();
        }

        //public static void Initialize(NemoStoreDbContext dbContext)
        //{
        //    //判断是否已经创建数据库若没有这创建【粗暴】
        //    //dbContext.Database.EnsureCreated();

        //    //获取所有的Migrations
        //    var allMigrations = dbContext.Database.GetMigrations();



        //    //判断数据库值是否存在，若不存在初始化数据库
        //    if(dbContext.Customer.Any())
        //    {
        //        return;  //DB Has Been Seeded
        //    }
        //    var customer = new Customer()
        //    {
        //        WeiXinId = "1",
        //        HeadImgUrl = "http://www.baidu.com"
        //    };
        //    dbContext.Customer.Add(customer);
        //    dbContext.SaveChanges();

        //}
    }
}
