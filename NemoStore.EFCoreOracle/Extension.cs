using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NemoStore.EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NemoStore.EFCoreOracle
{
    public static class Extension
    {
        public static IServiceCollection AddOraDbContext(this IServiceCollection service, string ConnectString)
        {
            var optionBuilder = new DbContextOptionsBuilder<NemoStoreDbContext>();
            optionBuilder.UseOracle(ConnectString);
            service.AddScoped(factory => optionBuilder.Options);

            //注册为NemoStoreDbContext服务
            service.AddDbContext<NemoStoreDbContext, NemoStoreOraContext>();

            //注册自动迁移类
            service.AddScoped<NemoStoreDbMigration, NemoStoreOraMigration>();

            //service.AddScoped<TContext>(container=>(TContext)container.GetService<NemoStoreOraContext>())


            return service;
        }
    }
}
