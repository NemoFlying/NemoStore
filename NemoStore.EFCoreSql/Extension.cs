using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NemoStore.EFCore;

namespace NemoStore.EFCoreSql
{
    public static class Extension
    {
        public static IServiceCollection AddSqlDbContext(this IServiceCollection service, string ConnectString)
        {
            var optionBuilder = new DbContextOptionsBuilder<NemoStoreDbContext>();
            optionBuilder.UseSqlServer(ConnectString);
            service.AddScoped(factory => optionBuilder.Options);

            //注册为NemoStoreDbContext服务
            service.AddDbContext<NemoStoreDbContext,NemoStoreSqlContext>();             

            //注册自动迁移类
            service.AddScoped<NemoStoreDbMigration, NemoStoreSqlMigration>();
            return service;
        }
    }
}
