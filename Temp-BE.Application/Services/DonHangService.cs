using Temp_BE.Application.Interface.Repositories;
using Temp_BE.Application.Interface.Services;
using Temp_BE.Domain.DTOs;

namespace Temp_BE.Application.Services
{
    public class DonHangService : IDonHangService
    {
        private readonly IDonHangRepository _donHangRepo;
        private readonly ISanPhamRepository _sanPhamRepo;

        public DonHangService(IDonHangRepository donHangRepo, ISanPhamRepository sanPhamRepo)
        {
            _donHangRepo = donHangRepo;
            _sanPhamRepo = sanPhamRepo;
        }

        public async Task<ApiResponse<DonHangDto>> CreateOrderAsync(long userId, CreateDonHangDto dto)
        {
            if (dto.ChiTiet == null || dto.ChiTiet.Count == 0)
            {
                return ApiResponse<DonHangDto>.Fail(400, "Đơn hàng phải có ít nhất 1 sản phẩm.");
            }

            var sanPhamList = new List<CreateChiTietDonHangDto>();
            foreach (var item in dto.ChiTiet)
            {
                var sp = await _sanPhamRepo.GetByMaSpAsync(item.MaSp);
                if (sp == null)
                {
                    return ApiResponse<DonHangDto>.Fail(404, $"Sản phẩm '{item.MaSp}' không tồn tại.");
                }
                if (item.SoLuong <= 0)
                {
                    return ApiResponse<DonHangDto>.Fail(400, $"Số lượng của sản phẩm '{sp.TenSp}' phải lớn hơn 0.");
                }

                sanPhamList.Add(new CreateChiTietDonHangDto
                {
                    MaSp = sp.MaSp,
                    SoLuong = item.SoLuong
                });
            }

            var createdOrder = await _donHangRepo.CreateOrderAsync(userId, dto, sanPhamList);
            return ApiResponse<DonHangDto>.Created(createdOrder, "Đặt hàng thành công!");
        }

        public async Task<ApiResponse<List<DonHangDto>>> GetMyOrdersAsync(long userId)
        {
            var list = await _donHangRepo.GetOrdersByUserAsync(userId);
            return ApiResponse<List<DonHangDto>>.Ok(list, "Lấy danh sách đơn hàng thành công.");
        }

        public async Task<ApiResponse<List<DonHangDto>>> GetAllOrdersAsync(int? trangThai)
        {
            var list = await _donHangRepo.GetAllOrdersAsync(trangThai);
            return ApiResponse<List<DonHangDto>>.Ok(list);
        }

        public async Task<ApiResponse<DonHangDto>> GetOrderByIdAsync(string maDh)
        {
            var item = await _donHangRepo.GetOrderByIdAsync(maDh);
            if (item == null) return ApiResponse<DonHangDto>.Fail(404, "Không tìm thấy đơn hàng.");
            return ApiResponse<DonHangDto>.Ok(item);
        }

        public async Task<ApiResponse<bool>> UpdateStatusAsync(string maDh, int trangThai)
        {
            var success = await _donHangRepo.UpdateStatusAsync(maDh, trangThai);
            if (!success) return ApiResponse<bool>.Fail(404, "Không tìm thấy đơn hàng để cập nhật.");
            return ApiResponse<bool>.Ok(true, "Cập nhật trạng thái đơn hàng thành công.");
        }


    }
}