using Microsoft.Extensions.DependencyInjection;
using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Infrastructure.Persistence.Repositories;

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

        return services;
    }
}