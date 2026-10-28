using Temp_BE.Api.Domain.DTOs;

namespace Temp_BE.Api.Infrastructure.Persistence
{
    public static class ReportMockData
    {
        public static List<Mau12Dto> GetMau12MockData()
        {
            return new List<Mau12Dto>
            {
                new Mau12Dto { TenCheDo = "I. Chế độ hưu trí", Stt = 1, HoVaTen = "Nguyễn Văn An", MaBhxh = "0123456789", LyDoGiam = "Nghỉ việc", NgayThangNamGiam = "15/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 1500000 },
                new Mau12Dto { TenCheDo = "I. Chế độ hưu trí", Stt = 2, HoVaTen = "Trần Thị Bình", MaBhxh = "0987654321", LyDoGiam = "Hết hạn hợp đồng", NgayThangNamGiam = "20/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 500000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "I. Chế độ hưu trí", Stt = 3, HoVaTen = "Phạm Văn Nam", MaBhxh = "0456123789", LyDoGiam = "Nghỉ hưu đúng tuổi", NgayThangNamGiam = "22/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 1200000, SoTienPhaiThuHoi = 200000 },
                new Mau12Dto { TenCheDo = "I. Chế độ hưu trí", Stt = 4, HoVaTen = "Nguyễn Thị Hoa", MaBhxh = "0112233445", LyDoGiam = "Chấm dứt hợp đồng", NgayThangNamGiam = "23/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 300000 },
                new Mau12Dto { TenCheDo = "I. Chế độ hưu trí", Stt = 5, HoVaTen = "Lê Văn Hùng", MaBhxh = "0223344556", LyDoGiam = "Nghỉ việc", NgayThangNamGiam = "24/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 400000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "I. Chế độ hưu trí", Stt = 6, HoVaTen = "Bùi Thị Lan", MaBhxh = "0334455667", LyDoGiam = "Chuyển công tác", NgayThangNamGiam = "25/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "I. Chế độ hưu trí", Stt = 7, HoVaTen = "Đỗ Văn Minh", MaBhxh = "0445566778", LyDoGiam = "Nghỉ việc", NgayThangNamGiam = "26/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 150000, SoTienPhaiThuHoi = 500000 },
                new Mau12Dto { TenCheDo = "I. Chế độ hưu trí", Stt = 8, HoVaTen = "Hoàng Văn Tuấn", MaBhxh = "0556677889", LyDoGiam = "Hết hạn hợp đồng", NgayThangNamGiam = "27/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 1000000 },
                new Mau12Dto { TenCheDo = "I. Chế độ hưu trí", Stt = 9, HoVaTen = "Ngô Thị Phượng", MaBhxh = "0667788990", LyDoGiam = "Nghỉ hưu sớm", NgayThangNamGiam = "28/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 2000000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "I. Chế độ hưu trí", Stt = 10, HoVaTen = "Vũ Văn Kiên", MaBhxh = "0778899001", LyDoGiam = "Nghỉ việc", NgayThangNamGiam = "29/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 0 },

                // --- II. Chế độ tử tuất (10 bản ghi) ---
                new Mau12Dto { TenCheDo = "II. Chế độ tử tuất", Stt = 1, HoVaTen = "Lê Hoàng Cường", MaBhxh = "0567891234", LyDoGiam = "Chấm dứt hợp đồng", NgayThangNamGiam = "25/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 100000, SoTienPhaiThuHoi = 2300000 },
                new Mau12Dto { TenCheDo = "II. Chế độ tử tuất", Stt = 2, HoVaTen = "Hoàng Thị Mai", MaBhxh = "0892345671", LyDoGiam = "Từ trần", NgayThangNamGiam = "26/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 2500000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "II. Chế độ tử tuất", Stt = 3, HoVaTen = "Trịnh Văn Quang", MaBhxh = "0901122334", LyDoGiam = "Từ trần", NgayThangNamGiam = "27/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 450000 },
                new Mau12Dto { TenCheDo = "II. Chế độ tử tuất", Stt = 4, HoVaTen = "Đinh Thị Thảo", MaBhxh = "0812233445", LyDoGiam = "Chấm dứt hợp đồng", NgayThangNamGiam = "28/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 300000, SoTienPhaiThuHoi = 150000 },
                new Mau12Dto { TenCheDo = "II. Chế độ tử tuất", Stt = 5, HoVaTen = "Bùi Văn Long", MaBhxh = "0723344556", LyDoGiam = "Nghỉ việc", NgayThangNamGiam = "29/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "II. Chế độ tử tuất", Stt = 6, HoVaTen = "Dương Thị Hồng", MaBhxh = "0634455667", LyDoGiam = "Từ trần", NgayThangNamGiam = "30/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 1200000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "II. Chế độ tử tuất", Stt = 7, HoVaTen = "Lương Thế Vinh", MaBhxh = "0545566778", LyDoGiam = "Từ trần", NgayThangNamGiam = "30/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 900000 },
                new Mau12Dto { TenCheDo = "II. Chế độ tử tuất", Stt = 8, HoVaTen = "Phùng Thị Dung", MaBhxh = "0456677889", LyDoGiam = "Chấm dứt hợp đồng", NgayThangNamGiam = "30/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 450000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "II. Chế độ tử tuất", Stt = 9, HoVaTen = "Hồ Ngọc Hà", MaBhxh = "0367788990", LyDoGiam = "Từ trần", NgayThangNamGiam = "30/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 1200000 },
                new Mau12Dto { TenCheDo = "II. Chế độ tử tuất", Stt = 10, HoVaTen = "Đặng Văn Ngữ", MaBhxh = "0278899001", LyDoGiam = "Nghỉ việc", NgayThangNamGiam = "30/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 300000, SoTienPhaiThuHoi = 300000 },

                // --- III. Trợ cấp thất nghiệp (10 bản ghi) ---
                new Mau12Dto { TenCheDo = "III. Trợ cấp thất nghiệp", Stt = 1, HoVaTen = "Vũ Đình Duy", MaBhxh = "0321654987", LyDoGiam = "Tìm được việc mới", NgayThangNamGiam = "28/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 850000 },
                new Mau12Dto { TenCheDo = "III. Trợ cấp thất nghiệp", Stt = 2, HoVaTen = "Lý Hải Nam", MaBhxh = "0432165987", LyDoGiam = "Hết hưởng trợ cấp", NgayThangNamGiam = "28/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 250000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "III. Trợ cấp thất nghiệp", Stt = 3, HoVaTen = "Mai Thị Ngọc", MaBhxh = "0543216987", LyDoGiam = "Tìm được việc mới", NgayThangNamGiam = "29/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 320000 },
                new Mau12Dto { TenCheDo = "III. Trợ cấp thất nghiệp", Stt = 4, HoVaTen = "Phan Văn Khoa", MaBhxh = "0654321987", LyDoGiam = "Chấm dứt hưởng BHTN", NgayThangNamGiam = "29/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 80000, SoTienPhaiThuHoi = 120000 },
                new Mau12Dto { TenCheDo = "III. Trợ cấp thất nghiệp", Stt = 5, HoVaTen = "Tạ Quang Bửu", MaBhxh = "0765432987", LyDoGiam = "Tìm được việc mới", NgayThangNamGiam = "30/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "III. Trợ cấp thất nghiệp", Stt = 6, HoVaTen = "Cao Thị Khánh", MaBhxh = "0876543987", LyDoGiam = "Hết thời hạn", NgayThangNamGiam = "30/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 540000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "III. Trợ cấp thất nghiệp", Stt = 7, HoVaTen = "Trương Tấn Phát", MaBhxh = "0987654123", LyDoGiam = "Tìm được việc mới", NgayThangNamGiam = "30/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 450000 },
                new Mau12Dto { TenCheDo = "III. Trợ cấp thất nghiệp", Stt = 8, HoVaTen = "Vương Thị Ngọc", MaBhxh = "0192837465", LyDoGiam = "Hết thời hạn", NgayThangNamGiam = "30/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 100000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "III. Trợ cấp thất nghiệp", Stt = 9, HoVaTen = "Dương Quốc Trung", MaBhxh = "0293847561", LyDoGiam = "Tìm được việc mới", NgayThangNamGiam = "30/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 250000 },
                new Mau12Dto { TenCheDo = "III. Trợ cấp thất nghiệp", Stt = 10, HoVaTen = "Lâm Thanh Vân", MaBhxh = "0394857612", LyDoGiam = "Chấm dứt hưởng BHTN", NgayThangNamGiam = "30/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 600000, SoTienPhaiThuHoi = 0 },

                // --- IV. Chế độ ốm đau (10 bản ghi) ---
                new Mau12Dto { TenCheDo = "IV. Chế độ ốm đau", Stt = 1, HoVaTen = "Chu Văn An", MaBhxh = "0111222333", LyDoGiam = "Nghỉ dài ngày", NgayThangNamGiam = "10/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 100000 },
                new Mau12Dto { TenCheDo = "IV. Chế độ ốm đau", Stt = 2, HoVaTen = "Phạm Quỳnh Nga", MaBhxh = "0222333444", LyDoGiam = "Nghỉ ốm đau", NgayThangNamGiam = "12/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 50000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "IV. Chế độ ốm đau", Stt = 3, HoVaTen = "Trần Đức Bo", MaBhxh = "0333444555", LyDoGiam = "Nghỉ ốm dài ngày", NgayThangNamGiam = "14/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 400000 },
                new Mau12Dto { TenCheDo = "IV. Chế độ ốm đau", Stt = 4, HoVaTen = "Lê Thị Mướp", MaBhxh = "0444555666", LyDoGiam = "Ốm đau thông thường", NgayThangNamGiam = "16/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 200000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "IV. Chế độ ốm đau", Stt = 5, HoVaTen = "Nguyễn Hồng Đăng", MaBhxh = "0555666777", LyDoGiam = "Nghỉ ốm dài ngày", NgayThangNamGiam = "18/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 150000 },
                new Mau12Dto { TenCheDo = "IV. Chế độ ốm đau", Stt = 6, HoVaTen = "Bùi Tiến Dũng", MaBhxh = "0666777888", LyDoGiam = "Nghỉ ốm", NgayThangNamGiam = "20/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 120000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "IV. Chế độ ốm đau", Stt = 7, HoVaTen = "Đỗ Hải Nam", MaBhxh = "0777888999", LyDoGiam = "Nghỉ dài ngày", NgayThangNamGiam = "22/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 500000 },
                new Mau12Dto { TenCheDo = "IV. Chế độ ốm đau", Stt = 8, HoVaTen = "Hà Anh Tuấn", MaBhxh = "0888999000", LyDoGiam = "Nghỉ ốm đau", NgayThangNamGiam = "24/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 300000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "IV. Chế độ ốm đau", Stt = 9, HoVaTen = "Nguyễn Thanh Bình", MaBhxh = "0999000111", LyDoGiam = "Nghỉ ốm dài ngày", NgayThangNamGiam = "26/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 200000 },
                new Mau12Dto { TenCheDo = "IV. Chế độ ốm đau", Stt = 10, HoVaTen = "Phạm Lịch", MaBhxh = "0101010101", LyDoGiam = "Ốm đau thông thường", NgayThangNamGiam = "28/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 150000, SoTienPhaiThuHoi = 0 },

                // --- V. Chế độ thai sản (10 bản ghi) ---
                new Mau12Dto { TenCheDo = "V. Chế độ thai sản", Stt = 1, HoVaTen = "Đinh Thị Trà My", MaBhxh = "0121212121", LyDoGiam = "Nghỉ sinh con", NgayThangNamGiam = "01/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "V. Chế độ thai sản", Stt = 2, HoVaTen = "Hoàng Thùy Linh", MaBhxh = "0232323232", LyDoGiam = "Nghỉ thai sản", NgayThangNamGiam = "05/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 1000000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "V. Chế độ thai sản", Stt = 3, HoVaTen = "Vũ Cát Tường", MaBhxh = "0343434343", LyDoGiam = "Nghỉ sinh con", NgayThangNamGiam = "08/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 500000 },
                new Mau12Dto { TenCheDo = "V. Chế độ thai sản", Stt = 4, HoVaTen = "Phạm Hương", MaBhxh = "0454545454", LyDoGiam = "Nghỉ thai sản", NgayThangNamGiam = "11/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 250000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "V. Chế độ thai sản", Stt = 5, HoVaTen = "Bảo Thy", MaBhxh = "0565656565", LyDoGiam = "Nghỉ sinh con", NgayThangNamGiam = "14/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "V. Chế độ thai sản", Stt = 6, HoVaTen = "Đông Nhi", MaBhxh = "0676767676", LyDoGiam = "Nghỉ thai sản", NgayThangNamGiam = "17/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 400000, SoTienPhaiThuHoi = 100000 },
                new Mau12Dto { TenCheDo = "V. Chế độ thai sản", Stt = 7, HoVaTen = "Bích Phương", MaBhxh = "0898989898", LyDoGiam = "Nghỉ thai sản", NgayThangNamGiam = "23/09/2026", DaChiTraHet = "30/09/2026", SoTienConPhaiTra = 800000, SoTienPhaiThuHoi = 0 },
                // --- VI. Chế độ tử tuất (10 bản ghi mới) ---
                new Mau12Dto { TenCheDo = "VI. Chế độ tử tuất", Stt = 1, HoVaTen = "Trần Đình Trọng", MaBhxh = "1122334455", LyDoGiam = "Người hưởng chết", NgayThangNamGiam = "01/10/2026", DaChiTraHet = "25/10/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 600000 },
                new Mau12Dto { TenCheDo = "VI. Chế độ tử tuất", Stt = 2, HoVaTen = "Bùi Thị Mai", MaBhxh = "2233445566", LyDoGiam = "Thân nhân hết tuổi hưởng trợ cấp", NgayThangNamGiam = "03/10/2026", DaChiTraHet = "25/10/2026", SoTienConPhaiTra = 250000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "VI. Chế độ tử tuất", Stt = 3, HoVaTen = "Nguyễn Văn Cường", MaBhxh = "3344556677", LyDoGiam = "Hết thời hạn hưởng tuất hàng tháng", NgayThangNamGiam = "06/10/2026", DaChiTraHet = "25/10/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 400000 },
                new Mau12Dto { TenCheDo = "VI. Chế độ tử tuất", Stt = 4, HoVaTen = "Lê Hoàng Yến", MaBhxh = "4455667788", LyDoGiam = "Thân nhân có thu nhập vượt quy định", NgayThangNamGiam = "09/10/2026", DaChiTraHet = "25/10/2026", SoTienConPhaiTra = 310000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "VI. Chế độ tử tuất", Stt = 5, HoVaTen = "Phạm Quốc Bảo", MaBhxh = "5566778899", LyDoGiam = "Người hưởng chết", NgayThangNamGiam = "12/10/2026", DaChiTraHet = "25/10/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 850000 },
                new Mau12Dto { TenCheDo = "VI. Chế độ tử tuất", Stt = 6, HoVaTen = "Đỗ Thu Hà", MaBhxh = "6677889900", LyDoGiam = "Hết thời hạn hưởng tuất hàng tháng", NgayThangNamGiam = "15/10/2026", DaChiTraHet = "25/10/2026", SoTienConPhaiTra = 190000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "VI. Chế độ tử tuất", Stt = 7, HoVaTen = "Vũ Minh Quân", MaBhxh = "7788990011", LyDoGiam = "Thân nhân hết tuổi hưởng trợ cấp", NgayThangNamGiam = "18/10/2026", DaChiTraHet = "25/10/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 300000 },
                new Mau12Dto { TenCheDo = "VI. Chế độ tử tuất", Stt = 8, HoVaTen = "Ngô Thanh Vân", MaBhxh = "8899001122", LyDoGiam = "Thân nhân có thu nhập vượt quy định", NgayThangNamGiam = "20/10/2026", DaChiTraHet = "25/10/2026", SoTienConPhaiTra = 520000, SoTienPhaiThuHoi = 0 },
                new Mau12Dto { TenCheDo = "VI. Chế độ tử tuất", Stt = 9, HoVaTen = "Hoàng Văn Nam", MaBhxh = "9900112233", LyDoGiam = "Người hưởng chết", NgayThangNamGiam = "22/10/2026", DaChiTraHet = "25/10/2026", SoTienConPhaiTra = 0, SoTienPhaiThuHoi = 450000 },
                new Mau12Dto { TenCheDo = "VI. Chế độ tử tuất", Stt = 10, HoVaTen = "Lý Kim Ngân", MaBhxh = "0011223344", LyDoGiam = "Hết thời hạn hưởng tuất hàng tháng", NgayThangNamGiam = "24/10/2026", DaChiTraHet = "25/10/2026", SoTienConPhaiTra = 270000, SoTienPhaiThuHoi = 0 },
            };
        }
    }
}
