using System;
using System.Data;
using System.Data.SqlClient;

namespace Lab10_DisconnectedData.DAL
{
    public class DisconnectedDataDAL
    {
        // -------------------------------------------------------------
        // BÀI 1: Nạp SinhVien vào DataTable bằng SqlDataAdapter
        // -------------------------------------------------------------
        public DataTable GetStudentTable()
        {
            DataTable table = new DataTable("SinhVien");
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM SinhVien ORDER BY MaSV", conn))
            {
                adapter.Fill(table);
            }
            return table;
        }

        // -------------------------------------------------------------
        // BÀI 2 & 3: DataSet chứa nhiều bảng & Thiết lập DataRelation
        // -------------------------------------------------------------
        public DataSet GetMasterDetailDataSet(out DataRelation relation)
        {
            DataSet ds = new DataSet("QLSinhVien");
            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                SqlDataAdapter daKhoa = new SqlDataAdapter("SELECT * FROM Khoa ORDER BY MaKhoa", conn);
                daKhoa.Fill(ds, "Khoa");

                SqlDataAdapter daSV = new SqlDataAdapter("SELECT * FROM SinhVien ORDER BY MaSV", conn);
                daSV.Fill(ds, "SinhVien");
            }

            // Thiết lập DataRelation Khoa - SinhVien (Bài 3)
            relation = new DataRelation(
                "FK_Khoa_SinhVien",
                ds.Tables["Khoa"].Columns["MaKhoa"],
                ds.Tables["SinhVien"].Columns["MaKhoa"],
                createConstraints: false); // Tránh ngoại lệ nếu có sinh viên mang mã khoa ngoài

            ds.Relations.Add(relation);
            return ds;
        }

        // -------------------------------------------------------------
        // BÀI 5: SqlDataAdapter kết hợp SqlCommandBuilder cập nhật CSDL
        // -------------------------------------------------------------
        public SqlDataAdapter CreateStudentAdapter(out DataTable table, out SqlCommandBuilder builder)
        {
            SqlConnection conn = DbConnectionFactory.Create();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email FROM SinhVien", conn);
            builder = new SqlCommandBuilder(adapter);
            table = new DataTable("SinhVien");
            adapter.Fill(table);

            // Thiết lập PrimaryKey cho DataTable để SqlCommandBuilder sinh lệnh UPDATE/DELETE chính xác
            DataColumn pkCol = table.Columns["MaSV"];
            if (pkCol != null)
            {
                table.PrimaryKey = new DataColumn[] { pkCol };
            }

            return adapter;
        }

        // -------------------------------------------------------------
        // BÀI 6: Tạo DataTable thủ công với cột biểu thức (Expression Column)
        // -------------------------------------------------------------
        public DataTable CreateManualTable()
        {
            DataTable dt = new DataTable("BangDiemSinhVien");

            // 1. Định nghĩa các cột cơ bản
            dt.Columns.Add(new DataColumn("MaSV", typeof(string)));
            dt.Columns.Add(new DataColumn("HoTen", typeof(string)));
            dt.Columns.Add(new DataColumn("DiemToan", typeof(decimal)));
            dt.Columns.Add(new DataColumn("DiemTin", typeof(decimal)));

            // 2. Cột tính toán bằng biểu thức (Expression Column)
            DataColumn colDiemTB = new DataColumn("DiemTB", typeof(decimal))
            {
                Expression = "(DiemToan + DiemTin) / 2"
            };
            dt.Columns.Add(colDiemTB);

            // 3. Cột xếp loại
            dt.Columns.Add(new DataColumn("XepLoai", typeof(string)));

            // Thiết lập khóa chính
            dt.PrimaryKey = new DataColumn[] { dt.Columns["MaSV"] };

            // 4. Thêm các dòng mẫu
            AddManualRow(dt, "24002545", "Phan Văn Thắng", 9.0m, 9.5m);
            AddManualRow(dt, "SV001", "Nguyễn Văn An", 8.0m, 8.5m);
            AddManualRow(dt, "SV002", "Trần Thị Bình", 7.0m, 7.5m);
            AddManualRow(dt, "SV003", "Lê Văn Cường", 6.5m, 6.0m);
            AddManualRow(dt, "SV004", "Phạm Hải Đăng", 8.5m, 8.0m);
            AddManualRow(dt, "SV008", "Vũ Quang Minh", 4.0m, 4.5m);
            AddManualRow(dt, "SV011", "Trịnh Đức Thắng", 3.5m, 4.0m);

            return dt;
        }

        private static void AddManualRow(DataTable dt, string maSV, string hoTen, decimal toan, decimal tin)
        {
            DataRow row = dt.NewRow();
            row["MaSV"] = maSV;
            row["HoTen"] = hoTen;
            row["DiemToan"] = toan;
            row["DiemTin"] = tin;

            // Xếp loại dựa trên điểm TB dự kiến
            decimal tb = (toan + tin) / 2m;
            string xepLoai = "Trung bình";
            if (tb >= 9.0m) xepLoai = "Xuất sắc";
            else if (tb >= 8.0m) xepLoai = "Giỏi";
            else if (tb >= 6.5m) xepLoai = "Khá";
            else if (tb >= 5.0m) xepLoai = "Trung bình";
            else xepLoai = "Yếu / Kém";

            row["XepLoai"] = xepLoai;
            dt.Rows.Add(row);
        }

        // -------------------------------------------------------------
        // BÀI 10: Chuẩn bị 2 DataTable mẫu để minh họa Merge
        // -------------------------------------------------------------
        public void CreateMergeSampleTables(out DataTable dtNguon1, out DataTable dtNguon2)
        {
            dtNguon1 = new DataTable("DanhSachChinhQuy");
            dtNguon1.Columns.Add("MaSV", typeof(string));
            dtNguon1.Columns.Add("HoTen", typeof(string));
            dtNguon1.Columns.Add("MaKhoa", typeof(string));
            dtNguon1.Columns.Add("DiemTB", typeof(decimal));
            dtNguon1.PrimaryKey = new DataColumn[] { dtNguon1.Columns["MaSV"] };

            dtNguon1.Rows.Add("24002545", "Phan Văn Thắng", "CNTT", 8.85m);
            dtNguon1.Rows.Add("SV001", "Nguyễn Văn An", "CNTT", 8.20m);
            dtNguon1.Rows.Add("SV002", "Trần Thị Bình", "CNTT", 7.40m);
            dtNguon1.Rows.Add("SV003", "Lê Văn Cường", "OTO", 6.80m);

            dtNguon2 = new DataTable("DanhSachBoSung");
            dtNguon2.Columns.Add("MaSV", typeof(string));
            dtNguon2.Columns.Add("HoTen", typeof(string));
            dtNguon2.Columns.Add("MaKhoa", typeof(string));
            dtNguon2.Columns.Add("DiemTB", typeof(decimal));
            dtNguon2.PrimaryKey = new DataColumn[] { dtNguon2.Columns["MaSV"] };

            // Trùng khóa SV002 và SV003 nhưng điểm cập nhật mới; cộng thêm SV004 và SV005 mới hoàn toàn
            dtNguon2.Rows.Add("SV002", "Trần Thị Bình (Đã phúc khảo)", "CNTT", 8.50m);
            dtNguon2.Rows.Add("SV003", "Lê Văn Cường (Đã học lại)", "OTO", 7.50m);
            dtNguon2.Rows.Add("SV004", "Phạm Hải Đăng", "KT", 8.00m);
            dtNguon2.Rows.Add("SV005", "Hoàng Hương Giang", "KT", 7.80m);
        }
    }
}
