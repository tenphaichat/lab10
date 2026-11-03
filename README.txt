================================================================================
BỘ MÔN CÔNG NGHỆ PHẦN MỀM - KHOA CÔNG NGHỆ THÔNG TIN - ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á
BÁO CÁO BÀI TẬP THỰC HÀNH LAB 10: DATAADAPTER, DATATABLE, DATASET VÀ DỮ LIỆU NGẮT KẾT NỐI
Học phần: Lập trình .NET (IT3212)
Sinh viên thực hiện: Phan Văn Thắng
Mã số sinh viên: 24002545
Lớp: IT3212
================================================================================

1. TỔNG QUAN VÀ HƯỚNG DẪN CẤU HÌNH MÔI TRƯỜNG
- Yêu cầu môi trường: Visual Studio 2022 hoặc .NET SDK (>= .NET 8 / .NET 9 hỗ trợ Windows Forms Desktop).
- Máy chủ CSDL: Microsoft SQL Server 2019/2022 hoặc SQL Server LocalDB: (localdb)\MSSQLLocalDB.
- CSDL sử dụng: QLSinhVien (Bảng SinhVien, Khoa).
- Cấu hình chuỗi kết nối tại tệp: lab10/App.config
  + Kết nối mặc định Windows Authentication:
      <add name="QLSinhVienConnection" 
           connectionString="Server=(localdb)\MSSQLLocalDB;Initial Catalog=QLSinhVien;Integrated Security=True;TrustServerCertificate=True;" />
  + Kết nối SQL Server Authentication (nếu cần):
      <add name="QLSinhVienSqlAuth" 
           connectionString="Server=(localdb)\MSSQLLocalDB;Initial Catalog=QLSinhVien;User Id=AppUser;Password=P@ssword123!;TrustServerCertificate=True;" />

2. HƯỚNG DẪN BIÊN DỊCH VÀ CHẠY DỰ ÁN
- Bước 1: Khởi tạo và kiểm tra CSDL QLSinhVien
  + Mở tệp Lab10_PrepareData.sql trong SSMS hoặc Azure Data Studio trên CSDL QLSinhVien.
  + Nhấn F5 (Execute) để kiểm tra các bảng Khoa và SinhVien.
- Bước 2: Biên dịch và chạy ứng dụng WinForms
  + Mở tệp solution: IT3212_Labs.sln bằng Visual Studio 2022 -> Nhấn F5 hoặc Ctrl+F5 để khởi chạy.
  + Hoặc chạy bằng dòng lệnh .NET CLI:
      cd lab10
      dotnet run --project lab10/Lab10_DisconnectedData.csproj

3. CẤU TRÚC VÀ TỔ CHỨC MÃ NGUỒN (KIẾN TRÚC MÔ HÌNH NGẮT KẾT NỐI ADO.NET)
- Solution: IT3212_Labs.sln
- Project: lab10/Lab10_DisconnectedData.csproj (.NET 9 Windows Forms)
- Tệp kịch bản CSDL: Lab10_PrepareData.sql
- Tầng DTO (Data Transfer Object) - Namespace: Lab10_DisconnectedData.DTO:
  + KhoaDTO.cs: Thực thể Khoa (MaKhoa, TenKhoa).
  + SinhVienDTO.cs: Thực thể SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email).
- Tầng DAL (Data Access Layer) - Namespace: Lab10_DisconnectedData.DAL:
  + DbConnectionFactory.cs: Nhà máy khởi tạo kết nối SqlConnection, đọc an toàn từ App.config.
  + DisconnectedDataDAL.cs: Đóng gói toàn bộ logic mô hình ngắt kết nối ADO.NET:
      * GetStudentTable(): Dùng SqlDataAdapter.Fill() nạp bảng SinhVien vào DataTable (Bài 1).
      * GetMasterDetailDataSet(): Nạp đồng thời Khoa và SinhVien vào DataSet và thiết lập DataRelation "FK_Khoa_SinhVien" (Bài 2 & 3).
      * CreateStudentAdapter(): Khởi tạo SqlDataAdapter và SqlCommandBuilder hỗ trợ cập nhật dữ liệu tự động 2 chiều (Bài 5).
      * CreateManualTable(): Tạo DataTable thủ công trong bộ nhớ với cột tính toán biểu thức (Expression Column) và cột phân loại (Bài 6).
      * CreateMergeSampleTables(): Khởi tạo 2 bảng dữ liệu mẫu có cấu trúc tương thích và khóa chính để minh họa phương thức Merge (Bài 10).
- Tầng GUI (Presentation Layer) - Namespace: Lab10_DisconnectedData.GUI:
  + frmMain.cs & frmMain.Designer.cs: Giao diện tabbed chuyên nghiệp, chia thành 7 Tab rõ ràng tương ứng 10 bài tập:
      * Tab 1: Bài 1 & 5 - SqlDataAdapter nạp dữ liệu và SqlCommandBuilder cập nhật tự động về CSDL.
      * Tab 2: Bài 2 & 3 - DataSet chứa nhiều bảng và quan hệ Master-Detail qua DataRelation (GetChildRows).
      * Tab 3: Bài 4 - Lọc và sắp xếp ngắt kết nối bằng DataView (RowFilter, Sort) không cần truy vấn lại CSDL.
      * Tab 4: Bài 6 - Tạo DataTable thủ công trong bộ nhớ và tính điểm tự động bằng Expression Column.
      * Tab 5: Bài 7 & 8 - Theo dõi DataRow.RowState (Added, Modified, Deleted, Unchanged) qua GetChanges(), minh họa AcceptChanges() và RejectChanges().
      * Tab 6: Bài 9 - Lưu và đọc DataSet ra tệp XML kèm Schema XSD (WriteXml và ReadXml ngắt kết nối).
      * Tab 7: Bài 10 - Hợp nhất hai DataTable từ hai nguồn khác nhau bằng phương thức Merge() xử lý trùng khóa chính.
  + ScreenshotCapture.cs: Tiện ích chụp màn hình tự động kết xuất ảnh giao diện sắc nét có khung cửa sổ chuẩn phục vụ làm báo cáo thực hành.

4. DANH SÁCH BÀI TẬP ĐÃ HOÀN THÀNH (10/10 BÀI)
* PHẦN 1: BÀI TẬP CÓ HƯỚNG DẪN (BÀI 1 - 5)
- Bài 1: Fill DataTable bằng SqlDataAdapter:
  + Khởi tạo SqlDataAdapter với câu truy vấn: "SELECT * FROM SinhVien ORDER BY MaSV".
  + Gọi phương thức adapter.Fill(table) tự động mở và đóng kết nối an toàn, gán nguồn dữ liệu cho DataGridView.
- Bài 2: DataSet chứa nhiều bảng:
  + Tạo đối tượng DataSet("QLSinhVien"), dùng SqlDataAdapter nạp đồng thời bảng Khoa và SinhVien với tên bảng rõ ràng.
  + Hiển thị độc lập trên các lưới dgvKhoa và dgvSinhVien.
- Bài 3: Thiết lập DataRelation Khoa - SinhVien (Master-Detail):
  + Tạo đối tượng DataRelation: new DataRelation("FK_Khoa_SinhVien", ds.Tables["Khoa"].Columns["MaKhoa"], ds.Tables["SinhVien"].Columns["MaKhoa"]).
  + Khi người dùng chọn một dòng Khoa trên dgvKhoa, gọi khoaRow.GetChildRows("FK_Khoa_SinhVien") để trích xuất danh sách sinh viên con trực thuộc và hiển thị lên lưới chi tiết.
- Bài 4: Lọc và sắp xếp bằng DataView:
  + Khởi tạo DataView từ DataTable SinhVien.
  + Thiết lập view.RowFilter = "MaKhoa = 'CNTT' AND DiemTB >= 7.0" và view.Sort = "DiemTB DESC, HoTen ASC".
  + Dữ liệu được lọc và sắp xếp hoàn toàn trong bộ nhớ RAM máy trạm, không gửi truy vấn lại máy chủ SQL Server.
- Bài 5: Cập nhật bằng SqlCommandBuilder:
  + Cho phép người dùng thêm, sửa, xóa trực tiếp trên DataGridView.
  + Sử dụng SqlCommandBuilder tự động sinh các câu lệnh INSERT, UPDATE, DELETE tương ứng dựa trên khóa chính MaSV.
  + Gọi adapter.Update(table) để ghi nhận thay đổi về CSDL và hiển thị thông báo số dòng bị ảnh hưởng.

* PHẦN 2: BÀI TẬP TỰ THỰC HIỆN (BÀI 6 - 10)
- Bài 6: Tạo DataTable thủ công trong bộ nhớ:
  + Tạo DataTable "BangDiemSinhVien" gồm các cột: MaSV, HoTen, DiemToan, DiemTin.
  + Thêm cột biểu thức: colDiemTB.Expression = "(DiemToan + DiemTin) / 2" tự động tính toán giá trị khi nhập điểm.
  + Bổ sung cột XepLoai phân loại học lực (Xuất sắc, Giỏi, Khá, Trung bình, Yếu) và thiết lập khóa chính cho bảng.
- Bài 7: Theo dõi RowState bằng GetChanges():
  + Theo dõi vòng đời trạng thái của từng dòng dữ liệu: DataRowState.Added, DataRowState.Modified, DataRowState.Deleted, DataRowState.Unchanged.
  + Gọi table.GetChanges() để trích xuất riêng các dòng có thay đổi và hiển thị chi tiết lên bảng theo dõi trước khi cập nhật.
- Bài 8: AcceptChanges và RejectChanges:
  + Nút AcceptChanges: Chấp nhận thay đổi cục bộ, chuyển tất cả RowState về Unchanged. Giải thích ảnh hưởng: sau khi gọi AcceptChanges(), phương thức adapter.Update() sẽ coi như không có thay đổi nào và không ghi được xuống CSDL.
  + Nút RejectChanges: Hoàn tác tất cả các thay đổi về trạng thái ban đầu kể từ lần nạp hoặc AcceptChanges cuối cùng.
- Bài 9: Lưu và đọc DataSet XML:
  + Sử dụng ds.WriteXml(path, XmlWriteMode.WriteSchema) để xuất toàn bộ dữ liệu kèm cấu trúc Schema XSD ra tệp XML.
  + Xóa trắng DataSet trong bộ nhớ, sau đó dùng ds.ReadXml(path, XmlReadMode.ReadSchema) khôi phục lại dữ liệu hoàn hảo mà không cần mở kết nối CSDL.
- Bài 10: Hợp nhất dữ liệu bằng Merge:
  + Tạo hai DataTable từ hai nguồn khác nhau có chung khóa chính MaSV.
  + Gọi table1.Merge(table2, preserveChanges: false, MissingSchemaAction.Add).
  + Xử lý cập nhật thông tin điểm mới nhất cho các sinh viên trùng khóa và bổ sung thêm các sinh viên mới vào bảng đích.

5. DỮ LIỆU KIỂM THỬ MẪU (TEST CASES)
- Trường hợp 1 (Bài 1): Mở Tab 1 -> Nhấn "Nạp dữ liệu" -> Lưới hiển thị toàn bộ 31 sinh viên được nạp qua SqlDataAdapter.
- Trường hợp 2 (Bài 2 & 3): Mở Tab 2 -> Click chọn dòng Khoa CNTT -> Lưới bên dưới tự động trích xuất các sinh viên CNTT qua GetChildRows().
- Trường hợp 3 (Bài 4): Mở Tab 3 -> Chọn Khoa CNTT, Điểm tối thiểu 7.0 -> Nhấn "Lọc (DataView)" -> DataView lọc tức thời các sinh viên thỏa mãn.
- Trường hợp 4 (Bài 5): Mở Tab 1 -> Sửa điểm sinh viên 24002545 trên lưới -> Nhấn "Lưu về CSDL" -> Hệ thống báo cập nhật thành công 1 thay đổi.
- Trường hợp 5 (Bài 6): Mở Tab 4 -> Bảng điểm hiển thị cột DiemTB tự động tính trung bình cộng của DiemToan và DiemTin.
- Trường hợp 6 (Bài 7 & 8): Mở Tab 5 -> Nhấn "Sửa dòng 1", "Thêm dòng mới" -> Nhấn "Kiểm tra RowState" -> Bảng log hiển thị rõ các dòng [Modified] và [Added]. Nhấn "RejectChanges" -> Toàn bộ dữ liệu được hoàn tác về ban đầu.
- Trường hợp 7 (Bài 9): Mở Tab 6 -> Nhấn "Ghi XML kèm Schema" -> Tệp XML hiển thị đầy đủ schema XSD và dữ liệu. Nhấn "Xóa bộ nhớ" -> Lưới trống. Nhấn "Đọc lại từ XML" -> Lưới khôi phục đầy đủ dữ liệu.
- Trường hợp 8 (Bài 10): Mở Tab 7 -> Nhấn "Hợp nhất (Merge)" -> Bảng kết quả hiển thị 6 sinh viên (SV002, SV003 cập nhật điểm mới; SV004, SV005 thêm mới).
================================================================================
