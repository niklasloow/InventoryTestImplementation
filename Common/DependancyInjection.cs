using Common.AutomapperProfiles;
using Common.Models;
using Common.StorageRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    public static class DependencyInjectionCommon
    {
        public static void AddCommonInjection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBaseStorageRepository<InventoryListDto>, FileStorageBaseRepository<InventoryListDto>>(sp
                => new FileStorageBaseRepository<InventoryListDto>(FileNameConstants.Inventory));

            serviceCollection.AddScoped<IBaseStorageRepository<InventoryListDto>, FileStorageBaseRepository<InventoryListDto>>(sp
                => new FileStorageBaseRepository<InventoryListDto>(FileNameConstants.Products));
            serviceCollection.AddAutoMapper(typeof(ArticleInventoryProfile));
        }

    }

    public static class FileNameConstants
    {
        public static string Inventory => "inventory";
        public static string Products => "products";
    }
}
