namespace Temp_BE.Domain.DTOs
{
    public class ProductItemDto
    {
        public int Stt { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Unit { get; set; } = "Cái";
        public string Note { get; set; } = string.Empty;
        public bool IsBold { get; set; } = false;
    }

    public class ProductReportDto
    {
        public string Title { get; set; } = "BÁO CÁO DANH SÁCH SẢN PHẨM";
        public string CompanyName { get; set; } = "TỔNG CÔNG TY THƯƠNG MẠI";
        public string DepartmentName { get; set; } = "CHI NHÁNH MIỀN BẮC";
        public int Quarter { get; set; } = (DateTime.Now.Month - 1) / 3 + 1;
        public int Year { get; set; } = DateTime.Now.Year;
        public string ReportDate { get; set; } = $"Ngày {DateTime.Now:dd} tháng {DateTime.Now:MM} năm {DateTime.Now:yyyy}";
        public string Creator { get; set; } = "Người lập biểu";
        public string ChiefAccountant { get; set; } = "Kế toán trưởng";
        public string Director { get; set; } = "Thủ trưởng đơn vị";
        public List<ProductItemDto> Products { get; set; } = new();

        public static ProductReportDto CreateSample()
        {
            return new ProductReportDto
            {
                Products = new List<ProductItemDto>()
            };
        }
    }
}
