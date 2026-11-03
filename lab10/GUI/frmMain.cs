using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Lab10_DisconnectedData.DAL;

namespace Lab10_DisconnectedData.GUI
{
    public partial class frmMain : Form
    {
        private readonly DisconnectedDataDAL _dal = new DisconnectedDataDAL();

        // Bài 1 & 5
        private SqlDataAdapter _adapterBai1_5;
        private SqlCommandBuilder _builderBai1_5;
        private DataTable _tableBai1_5;

        // Bài 2 & 3
        private DataSet _dsMasterDetail;
        private DataRelation _relKhoaSV;

        // Bài 4
        private DataView _viewBai4;

        // Bài 6
        private DataTable _dtManual;

        // Bài 7 & 8
        private DataTable _tableBai7_8;

        // Bài 9
        private DataSet _dsXml;
        private string _xmlFilePath;

        // Bài 10
        private DataTable _dtMerge1;
        private DataTable _dtMerge2;

        public frmMain()
        {
            InitializeComponent();
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            this.Load += FrmMain_Load;

            // Tab 1: Bài 1 & 5
            btnBai1_NapData.Click += BtnBai1_NapData_Click;
            btnBai5_ThemDong.Click += BtnBai5_ThemDong_Click;
            btnBai5_XoaDong.Click += BtnBai5_XoaDong_Click;
            btnBai5_LuuCSDL.Click += BtnBai5_LuuCSDL_Click;

            // Tab 2: Bài 2 & 3
            btnBai2_NapDataSet.Click += BtnBai2_NapDataSet_Click;
            dgvKhoa.SelectionChanged += DgvKhoa_SelectionChanged;

            // Tab 3: Bài 4
            btnBai4_LocDataView.Click += BtnBai4_LocDataView_Click;
            btnBai4_HuyLoc.Click += BtnBai4_HuyLoc_Click;

            // Tab 4: Bài 6
            btnBai6_TaoTable.Click += BtnBai6_TaoTable_Click;

            // Tab 5: Bài 7 & 8
            btnBai7_SuaMau.Click += BtnBai7_SuaMau_Click;
            btnBai7_ThemMau.Click += BtnBai7_ThemMau_Click;
            btnBai7_XoaMau.Click += BtnBai7_XoaMau_Click;
            btnBai7_KiemTraRowState.Click += BtnBai7_KiemTraRowState_Click;
            btnBai8_AcceptChanges.Click += BtnBai8_AcceptChanges_Click;
            btnBai8_RejectChanges.Click += BtnBai8_RejectChanges_Click;

            // Tab 6: Bài 9
            btnBai9_GhiXml.Click += BtnBai9_GhiXml_Click;
            btnBai9_XoaBoNho.Click += BtnBai9_XoaBoNho_Click;
            btnBai9_DocXml.Click += BtnBai9_DocXml_Click;

            // Tab 7: Bài 10
            btnBai10_HopNhat.Click += BtnBai10_HopNhat_Click;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Nạp dữ liệu ban đầu cho các Tab
            LoadTabBai1_5();
            LoadTabBai2_3();
            LoadTabBai4();
            LoadTabBai6();
            LoadTabBai7_8();
            LoadTabBai9();
            LoadTabBai10();
        }

        // =============================================================
        // BÀI 1 & BÀI 5: SqlDataAdapter & SqlCommandBuilder
        // =============================================================
        public void LoadTabBai1_5()
        {
            try
            {
                _adapterBai1_5 = _dal.CreateStudentAdapter(out _tableBai1_5, out _builderBai1_5);
                dgvBai1_5.DataSource = _tableBai1_5;
                lblBai1_5Info.Text = $"✓ Đã nạp {_tableBai1_5.Rows.Count} sinh viên từ CSDL. Có thể sửa/xóa/thêm trực tiếp và bấm 'Lưu về CSDL'.";
                lblStatus.Text = $"Bài 1 & 5: Nạp thành công {_tableBai1_5.Rows.Count} dòng dữ liệu.";
            }
            catch (Exception ex)
            {
                lblBai1_5Info.Text = "Lỗi: " + ex.Message;
            }
        }

        private void BtnBai1_NapData_Click(object sender, EventArgs e)
        {
            LoadTabBai1_5();
        }

        private void BtnBai5_ThemDong_Click(object sender, EventArgs e)
        {
            if (_tableBai1_5 == null) return;

            string newMaSV = "SV" + (DateTime.Now.Ticks % 100000).ToString();
            DataRow row = _tableBai1_5.NewRow();
            row["MaSV"] = newMaSV;
            row["HoTen"] = "Sinh Viên Mới";
            row["NgaySinh"] = new DateTime(2005, 1, 1);
            row["GioiTinh"] = true;
            row["MaKhoa"] = "CNTT";
            row["DiemTB"] = 8.0m;
            row["Email"] = newMaSV.ToLower() + "@eaut.edu.vn";

            _tableBai1_5.Rows.Add(row);
            lblBai1_5Info.Text = $"✓ Đã thêm sinh viên mới: {newMaSV} (RowState: Added). Bấm 'Lưu về CSDL' để ghi xuống.";
        }

        private void BtnBai5_XoaDong_Click(object sender, EventArgs e)
        {
            if (dgvBai1_5.CurrentRow != null && !dgvBai1_5.CurrentRow.IsNewRow)
            {
                DataRowView drv = dgvBai1_5.CurrentRow.DataBoundItem as DataRowView;
                if (drv != null)
                {
                    string ma = drv["MaSV"].ToString();
                    drv.Row.Delete();
                    lblBai1_5Info.Text = $"✓ Đã đánh dấu xóa sinh viên: {ma} (RowState: Deleted). Bấm 'Lưu về CSDL' để xác nhận.";
                }
            }
        }

        public void SaveToDatabase()
        {
            try
            {
                dgvBai1_5.EndEdit();
                if (_adapterBai1_5 != null && _tableBai1_5 != null)
                {
                    int rows = _adapterBai1_5.Update(_tableBai1_5);
                    lblBai1_5Info.Text = $"✓ Thành công: Đã cập nhật {rows} thay đổi về CSDL qua SqlCommandBuilder.";
                    lblStatus.Text = $"Bài 5: Update thành công {rows} bản ghi.";
                }
            }
            catch (Exception ex)
            {
                lblBai1_5Info.Text = "Lỗi cập nhật CSDL: " + ex.Message;
            }
        }

        private void BtnBai5_LuuCSDL_Click(object sender, EventArgs e)
        {
            SaveToDatabase();
        }

        // =============================================================
        // BÀI 2 & BÀI 3: DataSet nhiều bảng & DataRelation (Master-Detail)
        // =============================================================
        public void LoadTabBai2_3()
        {
            try
            {
                _dsMasterDetail = _dal.GetMasterDetailDataSet(out _relKhoaSV);
                dgvKhoa.DataSource = _dsMasterDetail.Tables["Khoa"];
                lblStatus.Text = "Bài 2 & 3: Đã nạp DataSet 2 bảng (Khoa & SinhVien) và thiết lập DataRelation FK_Khoa_SinhVien.";

                if (dgvKhoa.Rows.Count > 0)
                {
                    dgvKhoa.Rows[0].Selected = true;
                    DgvKhoa_SelectionChanged(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                lblBai2_3Desc.Text = "Lỗi: " + ex.Message;
            }
        }

        private void BtnBai2_NapDataSet_Click(object sender, EventArgs e)
        {
            LoadTabBai2_3();
        }

        private void DgvKhoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhoa.CurrentRow == null || _dsMasterDetail == null) return;

            DataRowView drv = dgvKhoa.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            DataRow khoaRow = drv.Row;
            string maKhoa = khoaRow["MaKhoa"].ToString();
            string tenKhoa = khoaRow["TenKhoa"].ToString();

            // Trích xuất các dòng con thông qua DataRelation (Bài 3)
            DataRow[] childRows = khoaRow.GetChildRows(_relKhoaSV);

            // Clone cấu trúc bảng SinhVien và nạp các dòng con để hiển thị
            DataTable dtDetail = _dsMasterDetail.Tables["SinhVien"].Clone();
            foreach (DataRow r in childRows)
            {
                dtDetail.ImportRow(r);
            }

            dgvSinhVienTheoKhoa.DataSource = dtDetail;
            grpSinhVienTheoKhoa.Text = $"Danh sách sinh viên trực thuộc Khoa: {tenKhoa} ({maKhoa}) - Tổng số: {childRows.Length} sinh viên";
            lblStatus.Text = $"DataRelation: Khoa {maKhoa} có {childRows.Length} sinh viên trực thuộc.";
        }

        // =============================================================
        // BÀI 4: Lọc và Sắp xếp bằng DataView
        // =============================================================
        public void LoadTabBai4()
        {
            try
            {
                DataTable dtSV = _dal.GetStudentTable();
                _viewBai4 = new DataView(dtSV);
                dgvBai4.DataSource = _viewBai4;
                ApplyDataViewFilter();
            }
            catch (Exception ex)
            {
                lblBai4Status.Text = "Lỗi: " + ex.Message;
            }
        }

        public void ApplyDataViewFilter()
        {
            if (_viewBai4 == null) return;

            string maKhoa = cboBai4Khoa.SelectedItem?.ToString() ?? "";
            decimal minDiem = numBai4MinDiem.Value;

            string filter = $"DiemTB >= {minDiem.ToString(System.Globalization.CultureInfo.InvariantCulture)}";
            if (!string.IsNullOrEmpty(maKhoa) && !maKhoa.StartsWith("--"))
            {
                filter += $" AND MaKhoa = '{maKhoa.Replace("'", "''")}'";
            }

            string sort = "DiemTB DESC, HoTen ASC";
            switch (cboBai4Sort.SelectedIndex)
            {
                case 0: sort = "DiemTB DESC, HoTen ASC"; break;
                case 1: sort = "HoTen ASC"; break;
                case 2: sort = "MaSV ASC"; break;
                case 3: sort = "DiemTB ASC"; break;
            }

            _viewBai4.RowFilter = filter;
            _viewBai4.Sort = sort;

            lblBai4Status.Text = $"RowFilter: \"{filter}\" | Sort: \"{sort}\" | Kết quả: {_viewBai4.Count} sinh viên";
            lblStatus.Text = $"Bài 4: DataView lọc thành công {_viewBai4.Count} sinh viên (không truy vấn lại CSDL).";
        }

        private void BtnBai4_LocDataView_Click(object sender, EventArgs e)
        {
            ApplyDataViewFilter();
        }

        private void BtnBai4_HuyLoc_Click(object sender, EventArgs e)
        {
            cboBai4Khoa.SelectedIndex = 0;
            numBai4MinDiem.Value = 0m;
            cboBai4Sort.SelectedIndex = 0;
            ApplyDataViewFilter();
        }

        // =============================================================
        // BÀI 6: Tạo DataTable thủ công với Cột biểu thức (Expression)
        // =============================================================
        public void LoadTabBai6()
        {
            _dtManual = _dal.CreateManualTable();
            dgvBai6.DataSource = _dtManual;
            lblStatus.Text = "Bài 6: Khởi tạo thành công DataTable bộ nhớ với Expression Column (DiemTB = (Toan+Tin)/2).";
        }

        private void BtnBai6_TaoTable_Click(object sender, EventArgs e)
        {
            LoadTabBai6();
        }

        // =============================================================
        // BÀI 7 & BÀI 8: RowState, AcceptChanges & RejectChanges
        // =============================================================
        public void LoadTabBai7_8()
        {
            _tableBai7_8 = _dal.GetStudentTable();
            dgvBai7_8.DataSource = _tableBai7_8;
            AuditRowState();
        }

        private void BtnBai7_SuaMau_Click(object sender, EventArgs e)
        {
            if (_tableBai7_8 != null && _tableBai7_8.Rows.Count > 0)
            {
                _tableBai7_8.Rows[0]["DiemTB"] = 9.99m;
                _tableBai7_8.Rows[0]["HoTen"] = _tableBai7_8.Rows[0]["HoTen"] + " (Đã sửa điểm)";
                AuditRowState();
            }
        }

        private void BtnBai7_ThemMau_Click(object sender, EventArgs e)
        {
            if (_tableBai7_8 != null)
            {
                DataRow r = _tableBai7_8.NewRow();
                r["MaSV"] = "SV_NEW_" + (new Random()).Next(100, 999);
                r["HoTen"] = "Sinh Viên Thêm Mới";
                r["NgaySinh"] = new DateTime(2006, 5, 20);
                r["GioiTinh"] = true;
                r["MaKhoa"] = "CNTT";
                r["DiemTB"] = 8.5m;
                _tableBai7_8.Rows.Add(r);
                AuditRowState();
            }
        }

        private void BtnBai7_XoaMau_Click(object sender, EventArgs e)
        {
            if (_tableBai7_8 != null && _tableBai7_8.Rows.Count > 1)
            {
                _tableBai7_8.Rows[1].Delete();
                AuditRowState();
            }
        }

        public void AuditRowState()
        {
            if (_tableBai7_8 == null) return;

            lstRowStateLog.Items.Clear();
            DataTable changes = _tableBai7_8.GetChanges();

            if (changes == null || changes.Rows.Count == 0)
            {
                lstRowStateLog.Items.Add("• Trạng thái: Tất cả các dòng đều ở trạng thái [Unchanged] (Không có thay đổi nào).");
                lblStatus.Text = "RowState: Không có thay đổi (GetChanges() = null).";
                return;
            }

            lstRowStateLog.Items.Add($"=== PHÁT HIỆN {changes.Rows.Count} DÒNG CÓ THAY ĐỔI (GetChanges()) ===");

            foreach (DataRow row in _tableBai7_8.Rows)
            {
                DataRowState state = row.RowState;
                if (state == DataRowState.Deleted)
                {
                    string ma = row["MaSV", DataRowVersion.Original]?.ToString();
                    lstRowStateLog.Items.Add($"[-] RowState: [Deleted]  | MaSV: {ma} (Đã bị đánh dấu xóa)");
                }
                else if (state == DataRowState.Modified)
                {
                    string ma = row["MaSV"].ToString();
                    object oldVal = row["DiemTB", DataRowVersion.Original];
                    object newVal = row["DiemTB", DataRowVersion.Current];
                    lstRowStateLog.Items.Add($"[*] RowState: [Modified] | MaSV: {ma} | DiemTB cũ: {oldVal} -> mới: {newVal}");
                }
                else if (state == DataRowState.Added)
                {
                    string ma = row["MaSV"].ToString();
                    string ten = row["HoTen"].ToString();
                    lstRowStateLog.Items.Add($"[+] RowState: [Added]    | MaSV: {ma} | HoTen: {ten} (Dòng mới thêm)");
                }
            }

            lblStatus.Text = $"Bài 7: Phát hiện {changes.Rows.Count} dòng thay đổi qua GetChanges().";
        }

        private void BtnBai7_KiemTraRowState_Click(object sender, EventArgs e)
        {
            AuditRowState();
        }

        public void PerformAcceptChanges()
        {
            if (_tableBai7_8 != null)
            {
                _tableBai7_8.AcceptChanges();
                AuditRowState();
                lstRowStateLog.Items.Add(">>> ĐÃ GỌI AcceptChanges(): Tất cả RowState đã chuyển về [Unchanged].");
                lblStatus.Text = "Bài 8: Đã gọi AcceptChanges() cục bộ.";
            }
        }

        private void BtnBai8_AcceptChanges_Click(object sender, EventArgs e)
        {
            PerformAcceptChanges();
        }

        public void PerformRejectChanges()
        {
            if (_tableBai7_8 != null)
            {
                _tableBai7_8.RejectChanges();
                AuditRowState();
                lstRowStateLog.Items.Add(">>> ĐÃ GỌI RejectChanges(): Dữ liệu đã được hoàn tác về trạng thái ban đầu!");
                lblStatus.Text = "Bài 8: Đã gọi RejectChanges() hoàn tác dữ liệu.";
            }
        }

        private void BtnBai8_RejectChanges_Click(object sender, EventArgs e)
        {
            PerformRejectChanges();
        }

        // =============================================================
        // BÀI 9: Lưu và Đọc DataSet XML
        // =============================================================
        public void LoadTabBai9()
        {
            _xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "QLSinhVien_Lab10.xml");
            _dsXml = _dal.GetMasterDetailDataSet(out _);
            _dsXml.DataSetName = "QLSinhVien_Offline";
            dgvBai9Xml.DataSource = _dsXml.Tables["SinhVien"];
            lblStatus.Text = "Bài 9: Chuẩn bị DataSet nạp XML.";
        }

        public void ExportXmlWithSchema()
        {
            if (_dsXml == null) return;
            try
            {
                _dsXml.WriteXml(_xmlFilePath, XmlWriteMode.WriteSchema);
                if (File.Exists(_xmlFilePath))
                {
                    txtBai9Xml.Text = File.ReadAllText(_xmlFilePath);
                    lblBai9Info.Text = $"✓ Đã ghi DataSet ra tệp: {_xmlFilePath} kèm Schema XSD.";
                    lblStatus.Text = "Bài 9: WriteXml thành công kèm Schema.";
                }
            }
            catch (Exception ex)
            {
                txtBai9Xml.Text = "Lỗi ghi XML: " + ex.Message;
            }
        }

        public void ClearInMemoryDataSet()
        {
            if (_dsXml != null)
            {
                _dsXml.Clear();
                txtBai9Xml.Text = "[Đã xóa trắng dữ liệu trong bộ nhớ RAM]";
                lblBai9Info.Text = "⚠️ Dữ liệu bộ nhớ đã bị xóa trắng. Bấm 'Đọc lại từ XML' để khôi phục.";
                lblStatus.Text = "Bài 9: Đã xóa trắng DataSet trong bộ nhớ.";
            }
        }

        public void ImportXmlWithSchema()
        {
            try
            {
                if (File.Exists(_xmlFilePath))
                {
                    _dsXml = new DataSet();
                    _dsXml.ReadXml(_xmlFilePath, XmlReadMode.ReadSchema);
                    dgvBai9Xml.DataSource = _dsXml.Tables["SinhVien"];
                    txtBai9Xml.Text = File.ReadAllText(_xmlFilePath);
                    lblBai9Info.Text = $"✓ Đã đọc lại thành công {_dsXml.Tables["SinhVien"]?.Rows.Count} sinh viên từ tệp XML!";
                    lblStatus.Text = "Bài 9: ReadXml khôi phục dữ liệu thành công không cần CSDL.";
                }
            }
            catch (Exception ex)
            {
                txtBai9Xml.Text = "Lỗi đọc XML: " + ex.Message;
            }
        }

        private void BtnBai9_GhiXml_Click(object sender, EventArgs e)
        {
            ExportXmlWithSchema();
        }

        private void BtnBai9_XoaBoNho_Click(object sender, EventArgs e)
        {
            ClearInMemoryDataSet();
        }

        private void BtnBai9_DocXml_Click(object sender, EventArgs e)
        {
            ImportXmlWithSchema();
        }

        // =============================================================
        // BÀI 10: Hợp nhất dữ liệu bằng Merge
        // =============================================================
        public void LoadTabBai10()
        {
            _dal.CreateMergeSampleTables(out _dtMerge1, out _dtMerge2);
            dgvMergeNguon1.DataSource = _dtMerge1;
            dgvMergeNguon2.DataSource = _dtMerge2;
            PerformMerge();
        }

        public void PerformMerge()
        {
            if (_dtMerge1 == null || _dtMerge2 == null) return;

            // Tạo bản sao để thực hiện Merge
            DataTable dtResult = _dtMerge1.Copy();
            dtResult.TableName = "KetQuaSauMerge";

            // Thực hiện Merge: Nguồn 1 merge với Nguồn 2
            dtResult.Merge(_dtMerge2, preserveChanges: false, MissingSchemaAction.Add);

            dgvMergeKetQua.DataSource = dtResult;
            lblBai10Info.Text = $"✓ Hợp nhất thành công: Kết quả có {dtResult.Rows.Count} sinh viên (Đã cập nhật điểm mới cho SV002, SV003 và thêm mới SV004, SV005).";
            lblStatus.Text = $"Bài 10: Merge thành công tổng cộng {dtResult.Rows.Count} sinh viên.";
        }

        private void BtnBai10_HopNhat_Click(object sender, EventArgs e)
        {
            PerformMerge();
        }

        // Helper cho công cụ chụp ảnh tự động
        public void SwitchTab(int tabIndex)
        {
            if (tabIndex >= 0 && tabIndex < tabMain.TabPages.Count)
            {
                tabMain.SelectedIndex = tabIndex;
                Application.DoEvents();
            }
        }
    }
}
