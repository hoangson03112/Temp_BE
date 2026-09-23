using Microsoft.Extensions.DependencyInjection;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Application.Services;

namespace Temp_BE.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IDanhMucService, DanhMucService>();
        services.AddScoped<ISanPhamService, SanPhamService>();
        services.AddScoped<IDonHangService, DonHangService>();
        services.AddScoped<IDanhGiaService, DanhGiaService>();

        return services;
    }
}