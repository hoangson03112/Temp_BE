using Temp_BE.Api.Application.Interface.Repositories;
using Temp_BE.Api.Infrastructure.Persistence.Repositories;
using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Infrastructure.Persistence.Repositories;
using Temp_BE.Infrastructure.Renderer;

namespace Temp_BE.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ISanPhamRepository, SanPhamRepository>();
        services.AddScoped<IDanhGiaRepository, DanhGiaRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IDanhMucRepository, DanhMucRepository>();
        services.AddScoped<IDonHangRepository, DonHangRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IDevExpressReportRenderer, DevExpressReportRenderer>();
        return services;
    }
}