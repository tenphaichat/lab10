using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lab10_DisconnectedData.GUI
{
    partial class frmMain
    {
        private IContainer components = null;

        // Header
        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Label lblHeaderSub;

        // Main TabControl
        public TabControl tabMain;

        // Tab 1: Bai 1 & 5
        private TabPage tabBai1_5;
        private Panel pnlBai1_5Top;
        private Button btnBai1_NapData;
        private Button btnBai5_LuuCSDL;
        private Button btnBai5_ThemDong;
        private Button btnBai5_XoaDong;
        private Label lblBai1_5Info;
        private DataGridView dgvBai1_5;

        // Tab 2: Bai 2 & 3
        private TabPage tabBai2_3;
        private Panel pnlBai2_3Master;
        private GroupBox grpKhoa;
        private DataGridView dgvKhoa;
        private GroupBox grpSinhVienTheoKhoa;
        private DataGridView dgvSinhVienTheoKhoa;
        private Panel pnlBai2_3Top;
        private Button btnBai2_NapDataSet;
        private Label lblBai2_3Desc;

        // Tab 3: Bai 4
        private TabPage tabBai4;
        private Panel pnlBai4Top;
        private Label lblBai4Khoa;
        private ComboBox cboBai4Khoa;
        private Label lblBai4Diem;
        private NumericUpDown numBai4MinDiem;
        private Label lblBai4Sort;
        private ComboBox cboBai4Sort;
        private Button btnBai4_LocDataView;
        private Button btnBai4_HuyLoc;
        private Label lblBai4Status;
        private DataGridView dgvBai4;

        // Tab 4: Bai 6
        private TabPage tabBai6;
        private Panel pnlBai6Top;
        private Button btnBai6_TaoTable;
        private Label lblBai6Desc;
        private DataGridView dgvBai6;

        // Tab 5: Bai 7 & 8
        private TabPage tabBai7_8;
        private Panel pnlBai7_8Top;
        private Button btnBai7_SuaMau;
        private Button btnBai7_ThemMau;
        private Button btnBai7_XoaMau;
        private Button btnBai7_KiemTraRowState;
        private Button btnBai8_AcceptChanges;
        private Button btnBai8_RejectChanges;
        private Label lblBai7_8Info;
        private DataGridView dgvBai7_8;
        private GroupBox grpRowStateLog;
        private ListBox lstRowStateLog;

        // Tab 6: Bai 9
        private TabPage tabBai9;
        private Panel pnlBai9Top;
        private Button btnBai9_GhiXml;
        private Button btnBai9_XoaBoNho;
        private Button btnBai9_DocXml;
        private Label lblBai9Info;
        private TextBox txtBai9Xml;
        private DataGridView dgvBai9Xml;

        // Tab 7: Bai 10
        private TabPage tabBai10;
        private Panel pnlBai10Top;
        private Button btnBai10_HopNhat;
        private Label lblBai10Info;
        private GroupBox grpMergeNguon1;
        private DataGridView dgvMergeNguon1;
        private GroupBox grpMergeNguon2;
        private DataGridView dgvMergeNguon2;
        private GroupBox grpMergeKetQua;
        private DataGridView dgvMergeKetQua;

        // StatusStrip
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblAuthor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblHeaderTitle = new Label();
            this.lblHeaderSub = new Label();

            this.tabMain = new TabControl();

            // Tab 1
            this.tabBai1_5 = new TabPage();
            this.pnlBai1_5Top = new Panel();
            this.btnBai1_NapData = new Button();
            this.btnBai5_LuuCSDL = new Button();
            this.btnBai5_ThemDong = new Button();
            this.btnBai5_XoaDong = new Button();
            this.lblBai1_5Info = new Label();
            this.dgvBai1_5 = new DataGridView();

            // Tab 2
            this.tabBai2_3 = new TabPage();
            this.pnlBai2_3Top = new Panel();
            this.btnBai2_NapDataSet = new Button();
            this.lblBai2_3Desc = new Label();
            this.pnlBai2_3Master = new Panel();
            this.grpKhoa = new GroupBox();
            this.dgvKhoa = new DataGridView();
            this.grpSinhVienTheoKhoa = new GroupBox();
            this.dgvSinhVienTheoKhoa = new DataGridView();

            // Tab 3
            this.tabBai4 = new TabPage();
            this.pnlBai4Top = new Panel();
            this.lblBai4Khoa = new Label();
            this.cboBai4Khoa = new ComboBox();
            this.lblBai4Diem = new Label();
            this.numBai4MinDiem = new NumericUpDown();
            this.lblBai4Sort = new Label();
            this.cboBai4Sort = new ComboBox();
            this.btnBai4_LocDataView = new Button();
            this.btnBai4_HuyLoc = new Button();
            this.lblBai4Status = new Label();
            this.dgvBai4 = new DataGridView();

            // Tab 4
            this.tabBai6 = new TabPage();
            this.pnlBai6Top = new Panel();
            this.btnBai6_TaoTable = new Button();
            this.lblBai6Desc = new Label();
            this.dgvBai6 = new DataGridView();

            // Tab 5
            this.tabBai7_8 = new TabPage();
            this.pnlBai7_8Top = new Panel();
            this.btnBai7_SuaMau = new Button();
            this.btnBai7_ThemMau = new Button();
            this.btnBai7_XoaMau = new Button();
            this.btnBai7_KiemTraRowState = new Button();
            this.btnBai8_AcceptChanges = new Button();
            this.btnBai8_RejectChanges = new Button();
            this.lblBai7_8Info = new Label();
            this.dgvBai7_8 = new DataGridView();
            this.grpRowStateLog = new GroupBox();
            this.lstRowStateLog = new ListBox();

            // Tab 6
            this.tabBai9 = new TabPage();
            this.pnlBai9Top = new Panel();
            this.btnBai9_GhiXml = new Button();
            this.btnBai9_XoaBoNho = new Button();
            this.btnBai9_DocXml = new Button();
            this.lblBai9Info = new Label();
            this.txtBai9Xml = new TextBox();
            this.dgvBai9Xml = new DataGridView();

            // Tab 7
            this.tabBai10 = new TabPage();
            this.pnlBai10Top = new Panel();
            this.btnBai10_HopNhat = new Button();
            this.lblBai10Info = new Label();
            this.grpMergeNguon1 = new GroupBox();
            this.dgvMergeNguon1 = new DataGridView();
            this.grpMergeNguon2 = new GroupBox();
            this.dgvMergeNguon2 = new DataGridView();
            this.grpMergeKetQua = new GroupBox();
            this.dgvMergeKetQua = new DataGridView();

            // StatusStrip
            this.statusStrip1 = new StatusStrip();
            this.lblStatus = new ToolStripStatusLabel();
            this.lblAuthor = new ToolStripStatusLabel();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = Color.FromArgb(235, 243, 252);
            this.pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(1184, 60);
            this.pnlHeader.TabIndex = 0;

            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = Color.FromArgb(16, 54, 110);
            this.lblHeaderTitle.Location = new Point(16, 8);
            this.lblHeaderTitle.Text = "LAB 10: DATAADAPTER, DATATABLE, DATASET VÀ DỮ LIỆU NGẮT KẾT NỐI";

            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblHeaderSub.Location = new Point(18, 33);
            this.lblHeaderSub.Text = "Học phần: Lập trình .NET (IT3212) | Sinh viên: Phan Văn Thắng - MSSV: 24002545 - Lớp: IT3212 - EAUT";

            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabBai1_5);
            this.tabMain.Controls.Add(this.tabBai2_3);
            this.tabMain.Controls.Add(this.tabBai4);
            this.tabMain.Controls.Add(this.tabBai6);
            this.tabMain.Controls.Add(this.tabBai7_8);
            this.tabMain.Controls.Add(this.tabBai9);
            this.tabMain.Controls.Add(this.tabBai10);
            this.tabMain.Dock = DockStyle.Fill;
            this.tabMain.Font = new Font("Segoe UI", 9F);
            this.tabMain.Location = new Point(0, 60);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new Size(1184, 600);
            this.tabMain.TabIndex = 1;

            // =========================================================
            // TAB 1: BÀI 1 & BÀI 5
            // =========================================================
            this.tabBai1_5.Controls.Add(this.dgvBai1_5);
            this.tabBai1_5.Controls.Add(this.pnlBai1_5Top);
            this.tabBai1_5.Location = new Point(4, 24);
            this.tabBai1_5.Name = "tabBai1_5";
            this.tabBai1_5.Padding = new Padding(6);
            this.tabBai1_5.Size = new Size(1176, 572);
            this.tabBai1_5.Text = "Bài 1 & 5: SqlDataAdapter & SqlCommandBuilder";
            this.tabBai1_5.UseVisualStyleBackColor = true;

            this.pnlBai1_5Top.Controls.Add(this.lblBai1_5Info);
            this.pnlBai1_5Top.Controls.Add(this.btnBai5_XoaDong);
            this.pnlBai1_5Top.Controls.Add(this.btnBai5_ThemDong);
            this.pnlBai1_5Top.Controls.Add(this.btnBai5_LuuCSDL);
            this.pnlBai1_5Top.Controls.Add(this.btnBai1_NapData);
            this.pnlBai1_5Top.Dock = DockStyle.Top;
            this.pnlBai1_5Top.Location = new Point(6, 6);
            this.pnlBai1_5Top.Name = "pnlBai1_5Top";
            this.pnlBai1_5Top.Size = new Size(1164, 46);
            this.pnlBai1_5Top.TabIndex = 0;

            this.btnBai1_NapData.Location = new Point(4, 8);
            this.btnBai1_NapData.Size = new Size(140, 30);
            this.btnBai1_NapData.Text = "🔄 Nạp dữ liệu (Bài 1)";
            this.btnBai1_NapData.UseVisualStyleBackColor = true;

            this.btnBai5_ThemDong.Location = new Point(152, 8);
            this.btnBai5_ThemDong.Size = new Size(125, 30);
            this.btnBai5_ThemDong.Text = "➕ Thêm sinh viên";
            this.btnBai5_ThemDong.UseVisualStyleBackColor = true;

            this.btnBai5_XoaDong.Location = new Point(285, 8);
            this.btnBai5_XoaDong.Size = new Size(120, 30);
            this.btnBai5_XoaDong.Text = "🗑 Xóa dòng chọn";
            this.btnBai5_XoaDong.UseVisualStyleBackColor = true;

            this.btnBai5_LuuCSDL.Location = new Point(413, 8);
            this.btnBai5_LuuCSDL.Size = new Size(170, 30);
            this.btnBai5_LuuCSDL.Text = "💾 Lưu về CSDL (Bài 5)";
            this.btnBai5_LuuCSDL.UseVisualStyleBackColor = true;

            this.lblBai1_5Info.AutoSize = true;
            this.lblBai1_5Info.ForeColor = Color.DarkGreen;
            this.lblBai1_5Info.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblBai1_5Info.Location = new Point(600, 15);
            this.lblBai1_5Info.Text = "💡 Có thể chỉnh sửa trực tiếp giá trị trên lưới, sau đó bấm 'Lưu về CSDL'.";

            this.dgvBai1_5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBai1_5.BackgroundColor = SystemColors.Window;
            this.dgvBai1_5.BorderStyle = BorderStyle.Fixed3D;
            this.dgvBai1_5.Dock = DockStyle.Fill;
            this.dgvBai1_5.Location = new Point(6, 52);
            this.dgvBai1_5.Name = "dgvBai1_5";
            this.dgvBai1_5.Size = new Size(1164, 514);
            this.dgvBai1_5.TabIndex = 1;

            // =========================================================
            // TAB 2: BÀI 2 & BÀI 3
            // =========================================================
            this.tabBai2_3.Controls.Add(this.pnlBai2_3Master);
            this.tabBai2_3.Controls.Add(this.pnlBai2_3Top);
            this.tabBai2_3.Location = new Point(4, 24);
            this.tabBai2_3.Name = "tabBai2_3";
            this.tabBai2_3.Padding = new Padding(6);
            this.tabBai2_3.Size = new Size(1176, 572);
            this.tabBai2_3.Text = "Bài 2 & 3: DataSet nhiều bảng & DataRelation";
            this.tabBai2_3.UseVisualStyleBackColor = true;

            this.pnlBai2_3Top.Controls.Add(this.lblBai2_3Desc);
            this.pnlBai2_3Top.Controls.Add(this.btnBai2_NapDataSet);
            this.pnlBai2_3Top.Dock = DockStyle.Top;
            this.pnlBai2_3Top.Location = new Point(6, 6);
            this.pnlBai2_3Top.Name = "pnlBai2_3Top";
            this.pnlBai2_3Top.Size = new Size(1164, 46);
            this.pnlBai2_3Top.TabIndex = 0;

            this.btnBai2_NapDataSet.Location = new Point(4, 8);
            this.btnBai2_NapDataSet.Size = new Size(210, 30);
            this.btnBai2_NapDataSet.Text = "📂 Nạp DataSet & Thiết lập Relation";
            this.btnBai2_NapDataSet.UseVisualStyleBackColor = true;

            this.lblBai2_3Desc.AutoSize = true;
            this.lblBai2_3Desc.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblBai2_3Desc.ForeColor = Color.DarkSlateBlue;
            this.lblBai2_3Desc.Location = new Point(230, 15);
            this.lblBai2_3Desc.Text = "📌 Chọn một Khoa bên trên, DataRelation (GetChildRows) sẽ tự động nạp các sinh viên trực thuộc vào lưới bên dưới.";

            this.pnlBai2_3Master.Controls.Add(this.grpSinhVienTheoKhoa);
            this.pnlBai2_3Master.Controls.Add(this.grpKhoa);
            this.pnlBai2_3Master.Dock = DockStyle.Fill;
            this.pnlBai2_3Master.Location = new Point(6, 52);
            this.pnlBai2_3Master.Name = "pnlBai2_3Master";
            this.pnlBai2_3Master.Size = new Size(1164, 514);
            this.pnlBai2_3Master.TabIndex = 1;

            this.grpKhoa.Controls.Add(this.dgvKhoa);
            this.grpKhoa.Dock = DockStyle.Top;
            this.grpKhoa.Location = new Point(0, 0);
            this.grpKhoa.Name = "grpKhoa";
            this.grpKhoa.Padding = new Padding(6);
            this.grpKhoa.Size = new Size(1164, 210);
            this.grpKhoa.TabIndex = 0;
            this.grpKhoa.TabStop = false;
            this.grpKhoa.Text = "Danh mục Khoa đào tạo (Master Table: ds.Tables[\"Khoa\"])";

            this.dgvKhoa.AllowUserToAddRows = false;
            this.dgvKhoa.AllowUserToDeleteRows = false;
            this.dgvKhoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoa.BackgroundColor = SystemColors.Window;
            this.dgvKhoa.BorderStyle = BorderStyle.Fixed3D;
            this.dgvKhoa.Dock = DockStyle.Fill;
            this.dgvKhoa.MultiSelect = false;
            this.dgvKhoa.ReadOnly = true;
            this.dgvKhoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoa.Size = new Size(1152, 180);
            this.dgvKhoa.TabIndex = 0;

            this.grpSinhVienTheoKhoa.Controls.Add(this.dgvSinhVienTheoKhoa);
            this.grpSinhVienTheoKhoa.Dock = DockStyle.Fill;
            this.grpSinhVienTheoKhoa.Location = new Point(0, 210);
            this.grpSinhVienTheoKhoa.Name = "grpSinhVienTheoKhoa";
            this.grpSinhVienTheoKhoa.Padding = new Padding(6);
            this.grpSinhVienTheoKhoa.Size = new Size(1164, 304);
            this.grpSinhVienTheoKhoa.TabIndex = 1;
            this.grpSinhVienTheoKhoa.TabStop = false;
            this.grpSinhVienTheoKhoa.Text = "Danh sách sinh viên trực thuộc Khoa được chọn (Detail Table: DataRelation.GetChildRows)";

            this.dgvSinhVienTheoKhoa.AllowUserToAddRows = false;
            this.dgvSinhVienTheoKhoa.AllowUserToDeleteRows = false;
            this.dgvSinhVienTheoKhoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVienTheoKhoa.BackgroundColor = SystemColors.Window;
            this.dgvSinhVienTheoKhoa.BorderStyle = BorderStyle.Fixed3D;
            this.dgvSinhVienTheoKhoa.Dock = DockStyle.Fill;
            this.dgvSinhVienTheoKhoa.ReadOnly = true;
            this.dgvSinhVienTheoKhoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVienTheoKhoa.Size = new Size(1152, 274);
            this.dgvSinhVienTheoKhoa.TabIndex = 0;

            // =========================================================
            // TAB 3: BÀI 4 (DataView)
            // =========================================================
            this.tabBai4.Controls.Add(this.dgvBai4);
            this.tabBai4.Controls.Add(this.pnlBai4Top);
            this.tabBai4.Location = new Point(4, 24);
            this.tabBai4.Name = "tabBai4";
            this.tabBai4.Padding = new Padding(6);
            this.tabBai4.Size = new Size(1176, 572);
            this.tabBai4.Text = "Bài 4: Lọc và Sắp xếp bằng DataView";
            this.tabBai4.UseVisualStyleBackColor = true;

            this.pnlBai4Top.Controls.Add(this.lblBai4Status);
            this.pnlBai4Top.Controls.Add(this.btnBai4_HuyLoc);
            this.pnlBai4Top.Controls.Add(this.btnBai4_LocDataView);
            this.pnlBai4Top.Controls.Add(this.cboBai4Sort);
            this.pnlBai4Top.Controls.Add(this.lblBai4Sort);
            this.pnlBai4Top.Controls.Add(this.numBai4MinDiem);
            this.pnlBai4Top.Controls.Add(this.lblBai4Diem);
            this.pnlBai4Top.Controls.Add(this.cboBai4Khoa);
            this.pnlBai4Top.Controls.Add(this.lblBai4Khoa);
            this.pnlBai4Top.Dock = DockStyle.Top;
            this.pnlBai4Top.Location = new Point(6, 6);
            this.pnlBai4Top.Name = "pnlBai4Top";
            this.pnlBai4Top.Size = new Size(1164, 52);
            this.pnlBai4Top.TabIndex = 0;

            this.lblBai4Khoa.AutoSize = true;
            this.lblBai4Khoa.Location = new Point(4, 17);
            this.lblBai4Khoa.Text = "Khoa:";

            this.cboBai4Khoa.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboBai4Khoa.Items.AddRange(new object[] { "-- Tất cả các khoa --", "CNTT", "OTO", "KT", "NN", "DDT" });
            this.cboBai4Khoa.SelectedIndex = 0;
            this.cboBai4Khoa.Location = new Point(48, 14);
            this.cboBai4Khoa.Size = new Size(140, 23);

            this.lblBai4Diem.AutoSize = true;
            this.lblBai4Diem.Location = new Point(198, 17);
            this.lblBai4Diem.Text = "Điểm tối thiểu:";

            this.numBai4MinDiem.DecimalPlaces = 1;
            this.numBai4MinDiem.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numBai4MinDiem.Location = new Point(285, 14);
            this.numBai4MinDiem.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numBai4MinDiem.Size = new Size(55, 23);
            this.numBai4MinDiem.Value = new decimal(new int[] { 70, 0, 0, 65536 }); // 7.0

            this.lblBai4Sort.AutoSize = true;
            this.lblBai4Sort.Location = new Point(350, 17);
            this.lblBai4Sort.Text = "Sắp xếp:";

            this.cboBai4Sort.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboBai4Sort.Items.AddRange(new object[] { 
                "Điểm TB giảm dần, Họ tên tăng dần", 
                "Họ tên tăng dần", 
                "Mã SV tăng dần",
                "Điểm TB tăng dần"
            });
            this.cboBai4Sort.SelectedIndex = 0;
            this.cboBai4Sort.Location = new Point(405, 14);
            this.cboBai4Sort.Size = new Size(220, 23);

            this.btnBai4_LocDataView.Location = new Point(635, 11);
            this.btnBai4_LocDataView.Size = new Size(140, 29);
            this.btnBai4_LocDataView.Text = "🔍 Lọc (DataView)";
            this.btnBai4_LocDataView.UseVisualStyleBackColor = true;

            this.btnBai4_HuyLoc.Location = new Point(782, 11);
            this.btnBai4_HuyLoc.Size = new Size(95, 29);
            this.btnBai4_HuyLoc.Text = "🔄 Hủy lọc";
            this.btnBai4_HuyLoc.UseVisualStyleBackColor = true;

            this.lblBai4Status.AutoSize = true;
            this.lblBai4Status.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblBai4Status.ForeColor = Color.DarkSlateBlue;
            this.lblBai4Status.Location = new Point(885, 18);
            this.lblBai4Status.Text = "RowFilter: Chưa lọc | Tổng số: 31";

            this.dgvBai4.AllowUserToAddRows = false;
            this.dgvBai4.AllowUserToDeleteRows = false;
            this.dgvBai4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBai4.BackgroundColor = SystemColors.Window;
            this.dgvBai4.BorderStyle = BorderStyle.Fixed3D;
            this.dgvBai4.Dock = DockStyle.Fill;
            this.dgvBai4.Location = new Point(6, 58);
            this.dgvBai4.Name = "dgvBai4";
            this.dgvBai4.ReadOnly = true;
            this.dgvBai4.Size = new Size(1164, 508);
            this.dgvBai4.TabIndex = 1;

            // =========================================================
            // TAB 4: BÀI 6 (Manual DataTable & Expression Column)
            // =========================================================
            this.tabBai6.Controls.Add(this.dgvBai6);
            this.tabBai6.Controls.Add(this.pnlBai6Top);
            this.tabBai6.Location = new Point(4, 24);
            this.tabBai6.Name = "tabBai6";
            this.tabBai6.Padding = new Padding(6);
            this.tabBai6.Size = new Size(1176, 572);
            this.tabBai6.Text = "Bài 6: Tạo DataTable thủ công & Cột biểu thức";
            this.tabBai6.UseVisualStyleBackColor = true;

            this.pnlBai6Top.Controls.Add(this.lblBai6Desc);
            this.pnlBai6Top.Controls.Add(this.btnBai6_TaoTable);
            this.pnlBai6Top.Dock = DockStyle.Top;
            this.pnlBai6Top.Location = new Point(6, 6);
            this.pnlBai6Top.Name = "pnlBai6Top";
            this.pnlBai6Top.Size = new Size(1164, 46);
            this.pnlBai6Top.TabIndex = 0;

            this.btnBai6_TaoTable.Location = new Point(4, 8);
            this.btnBai6_TaoTable.Size = new Size(220, 30);
            this.btnBai6_TaoTable.Text = "⚡ Tạo Bảng điểm (DataTable bộ nhớ)";
            this.btnBai6_TaoTable.UseVisualStyleBackColor = true;

            this.lblBai6Desc.AutoSize = true;
            this.lblBai6Desc.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblBai6Desc.ForeColor = Color.DarkGreen;
            this.lblBai6Desc.Location = new Point(235, 15);
            this.lblBai6Desc.Text = "📌 Cột 'DiemTB' được tính tự động bằng biểu thức: (DiemToan + DiemTin) / 2. Cột 'XepLoai' tự động phân loại.";

            this.dgvBai6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBai6.BackgroundColor = SystemColors.Window;
            this.dgvBai6.BorderStyle = BorderStyle.Fixed3D;
            this.dgvBai6.Dock = DockStyle.Fill;
            this.dgvBai6.Location = new Point(6, 52);
            this.dgvBai6.Name = "dgvBai6";
            this.dgvBai6.Size = new Size(1164, 514);
            this.dgvBai6.TabIndex = 1;

            // =========================================================
            // TAB 5: BÀI 7 & 8 (RowState, AcceptChanges & RejectChanges)
            // =========================================================
            this.tabBai7_8.Controls.Add(this.dgvBai7_8);
            this.tabBai7_8.Controls.Add(this.grpRowStateLog);
            this.tabBai7_8.Controls.Add(this.pnlBai7_8Top);
            this.tabBai7_8.Location = new Point(4, 24);
            this.tabBai7_8.Name = "tabBai7_8";
            this.tabBai7_8.Padding = new Padding(6);
            this.tabBai7_8.Size = new Size(1176, 572);
            this.tabBai7_8.Text = "Bài 7 & 8: RowState, AcceptChanges & RejectChanges";
            this.tabBai7_8.UseVisualStyleBackColor = true;

            this.pnlBai7_8Top.Controls.Add(this.lblBai7_8Info);
            this.pnlBai7_8Top.Controls.Add(this.btnBai8_RejectChanges);
            this.pnlBai7_8Top.Controls.Add(this.btnBai8_AcceptChanges);
            this.pnlBai7_8Top.Controls.Add(this.btnBai7_KiemTraRowState);
            this.pnlBai7_8Top.Controls.Add(this.btnBai7_XoaMau);
            this.pnlBai7_8Top.Controls.Add(this.btnBai7_ThemMau);
            this.pnlBai7_8Top.Controls.Add(this.btnBai7_SuaMau);
            this.pnlBai7_8Top.Dock = DockStyle.Top;
            this.pnlBai7_8Top.Location = new Point(6, 6);
            this.pnlBai7_8Top.Name = "pnlBai7_8Top";
            this.pnlBai7_8Top.Size = new Size(1164, 76);
            this.pnlBai7_8Top.TabIndex = 0;

            this.btnBai7_SuaMau.Location = new Point(4, 6);
            this.btnBai7_SuaMau.Size = new Size(115, 29);
            this.btnBai7_SuaMau.Text = "✏️ Sửa dòng 1";
            this.btnBai7_SuaMau.UseVisualStyleBackColor = true;

            this.btnBai7_ThemMau.Location = new Point(125, 6);
            this.btnBai7_ThemMau.Size = new Size(125, 29);
            this.btnBai7_ThemMau.Text = "➕ Thêm dòng mới";
            this.btnBai7_ThemMau.UseVisualStyleBackColor = true;

            this.btnBai7_XoaMau.Location = new Point(256, 6);
            this.btnBai7_XoaMau.Size = new Size(115, 29);
            this.btnBai7_XoaMau.Text = "🗑 Xóa dòng 2";
            this.btnBai7_XoaMau.UseVisualStyleBackColor = true;

            this.btnBai7_KiemTraRowState.Location = new Point(377, 6);
            this.btnBai7_KiemTraRowState.Size = new Size(195, 29);
            this.btnBai7_KiemTraRowState.Text = "🔍 Kiểm tra RowState (GetChanges)";
            this.btnBai7_KiemTraRowState.UseVisualStyleBackColor = true;

            this.btnBai8_AcceptChanges.Location = new Point(578, 6);
            this.btnBai8_AcceptChanges.Size = new Size(205, 29);
            this.btnBai8_AcceptChanges.Text = "✅ AcceptChanges (Chấp nhận)";
            this.btnBai8_AcceptChanges.UseVisualStyleBackColor = true;

            this.btnBai8_RejectChanges.Location = new Point(789, 6);
            this.btnBai8_RejectChanges.Size = new Size(185, 29);
            this.btnBai8_RejectChanges.Text = "↩️ RejectChanges (Hoàn tác)";
            this.btnBai8_RejectChanges.UseVisualStyleBackColor = true;

            this.lblBai7_8Info.AutoSize = true;
            this.lblBai7_8Info.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblBai7_8Info.ForeColor = Color.Crimson;
            this.lblBai7_8Info.Location = new Point(6, 46);
            this.lblBai7_8Info.Text = "⚠️ Chú ý: AcceptChanges chuyển tất cả RowState về Unchanged. Sau khi AcceptChanges, adapter.Update() sẽ KHÔNG thể cập nhật vào CSDL.";

            this.dgvBai7_8.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBai7_8.BackgroundColor = SystemColors.Window;
            this.dgvBai7_8.BorderStyle = BorderStyle.Fixed3D;
            this.dgvBai7_8.Dock = DockStyle.Fill;
            this.dgvBai7_8.Location = new Point(6, 82);
            this.dgvBai7_8.Name = "dgvBai7_8";
            this.dgvBai7_8.Size = new Size(1164, 332);
            this.dgvBai7_8.TabIndex = 1;

            this.grpRowStateLog.Controls.Add(this.lstRowStateLog);
            this.grpRowStateLog.Dock = DockStyle.Bottom;
            this.grpRowStateLog.Location = new Point(6, 414);
            this.grpRowStateLog.Name = "grpRowStateLog";
            this.grpRowStateLog.Padding = new Padding(6);
            this.grpRowStateLog.Size = new Size(1164, 152);
            this.grpRowStateLog.TabIndex = 2;
            this.grpRowStateLog.TabStop = false;
            this.grpRowStateLog.Text = "Bảng theo dõi trạng thái dòng (DataRow.RowState & DataTable.GetChanges())";

            this.lstRowStateLog.Dock = DockStyle.Fill;
            this.lstRowStateLog.Font = new Font("Consolas", 9.5F);
            this.lstRowStateLog.FormattingEnabled = true;
            this.lstRowStateLog.ItemHeight = 15;
            this.lstRowStateLog.Location = new Point(6, 22);
            this.lstRowStateLog.Name = "lstRowStateLog";
            this.lstRowStateLog.Size = new Size(1152, 124);
            this.lstRowStateLog.TabIndex = 0;

            // =========================================================
            // TAB 6: BÀI 9 (XML DataSet & Schema)
            // =========================================================
            this.tabBai9.Controls.Add(this.dgvBai9Xml);
            this.tabBai9.Controls.Add(this.txtBai9Xml);
            this.tabBai9.Controls.Add(this.pnlBai9Top);
            this.tabBai9.Location = new Point(4, 24);
            this.tabBai9.Name = "tabBai9";
            this.tabBai9.Padding = new Padding(6);
            this.tabBai9.Size = new Size(1176, 572);
            this.tabBai9.Text = "Bài 9: Lưu và Đọc DataSet XML";
            this.tabBai9.UseVisualStyleBackColor = true;

            this.pnlBai9Top.Controls.Add(this.lblBai9Info);
            this.pnlBai9Top.Controls.Add(this.btnBai9_DocXml);
            this.pnlBai9Top.Controls.Add(this.btnBai9_XoaBoNho);
            this.pnlBai9Top.Controls.Add(this.btnBai9_GhiXml);
            this.pnlBai9Top.Dock = DockStyle.Top;
            this.pnlBai9Top.Location = new Point(6, 6);
            this.pnlBai9Top.Name = "pnlBai9Top";
            this.pnlBai9Top.Size = new Size(1164, 46);
            this.pnlBai9Top.TabIndex = 0;

            this.btnBai9_GhiXml.Location = new Point(4, 8);
            this.btnBai9_GhiXml.Size = new Size(195, 30);
            this.btnBai9_GhiXml.Text = "💾 1. Ghi XML kèm Schema (WriteXml)";
            this.btnBai9_GhiXml.UseVisualStyleBackColor = true;

            this.btnBai9_XoaBoNho.Location = new Point(205, 8);
            this.btnBai9_XoaBoNho.Size = new Size(160, 30);
            this.btnBai9_XoaBoNho.Text = "🗑 2. Xóa trắng bộ nhớ";
            this.btnBai9_XoaBoNho.UseVisualStyleBackColor = true;

            this.btnBai9_DocXml.Location = new Point(371, 8);
            this.btnBai9_DocXml.Size = new Size(185, 30);
            this.btnBai9_DocXml.Text = "📂 3. Đọc lại từ XML (ReadXml)";
            this.btnBai9_DocXml.UseVisualStyleBackColor = true;

            this.lblBai9Info.AutoSize = true;
            this.lblBai9Info.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblBai9Info.ForeColor = Color.DarkSlateBlue;
            this.lblBai9Info.Location = new Point(565, 15);
            this.lblBai9Info.Text = "📌 Minh họa đọc/ghi XML ngắt kết nối hoàn toàn, không cần mở kết nối đến máy chủ SQL Server.";

            this.txtBai9Xml.Dock = DockStyle.Left;
            this.txtBai9Xml.Font = new Font("Consolas", 9F);
            this.txtBai9Xml.Location = new Point(6, 52);
            this.txtBai9Xml.Multiline = true;
            this.txtBai9Xml.Name = "txtBai9Xml";
            this.txtBai9Xml.ReadOnly = true;
            this.txtBai9Xml.ScrollBars = ScrollBars.Both;
            this.txtBai9Xml.Size = new Size(580, 514);
            this.txtBai9Xml.TabIndex = 1;

            this.dgvBai9Xml.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBai9Xml.BackgroundColor = SystemColors.Window;
            this.dgvBai9Xml.BorderStyle = BorderStyle.Fixed3D;
            this.dgvBai9Xml.Dock = DockStyle.Fill;
            this.dgvBai9Xml.Location = new Point(586, 52);
            this.dgvBai9Xml.Name = "dgvBai9Xml";
            this.dgvBai9Xml.ReadOnly = true;
            this.dgvBai9Xml.Size = new Size(584, 514);
            this.dgvBai9Xml.TabIndex = 2;

            // =========================================================
            // TAB 7: BÀI 10 (Hợp nhất dữ liệu bằng Merge)
            // =========================================================
            this.tabBai10.Controls.Add(this.grpMergeKetQua);
            this.tabBai10.Controls.Add(this.grpMergeNguon2);
            this.tabBai10.Controls.Add(this.grpMergeNguon1);
            this.tabBai10.Controls.Add(this.pnlBai10Top);
            this.tabBai10.Location = new Point(4, 24);
            this.tabBai10.Name = "tabBai10";
            this.tabBai10.Padding = new Padding(6);
            this.tabBai10.Size = new Size(1176, 572);
            this.tabBai10.Text = "Bài 10: Hợp nhất dữ liệu (Merge)";
            this.tabBai10.UseVisualStyleBackColor = true;

            this.pnlBai10Top.Controls.Add(this.lblBai10Info);
            this.pnlBai10Top.Controls.Add(this.btnBai10_HopNhat);
            this.pnlBai10Top.Dock = DockStyle.Top;
            this.pnlBai10Top.Location = new Point(6, 6);
            this.pnlBai10Top.Name = "pnlBai10Top";
            this.pnlBai10Top.Size = new Size(1164, 46);
            this.pnlBai10Top.TabIndex = 0;

            this.btnBai10_HopNhat.Location = new Point(4, 8);
            this.btnBai10_HopNhat.Size = new Size(220, 30);
            this.btnBai10_HopNhat.Text = "🔀 Thực hiện Hợp nhất (Merge)";
            this.btnBai10_HopNhat.UseVisualStyleBackColor = true;

            this.lblBai10Info.AutoSize = true;
            this.lblBai10Info.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblBai10Info.ForeColor = Color.DarkSlateBlue;
            this.lblBai10Info.Location = new Point(235, 15);
            this.lblBai10Info.Text = "📌 Bảng Nguồn 2 cập nhật lại điểm cho SV002 & SV003, đồng thời bổ sung thêm SV004 & SV005 vào Bảng Nguồn 1.";

            this.grpMergeNguon1.Controls.Add(this.dgvMergeNguon1);
            this.grpMergeNguon1.Dock = DockStyle.Left;
            this.grpMergeNguon1.Location = new Point(6, 52);
            this.grpMergeNguon1.Name = "grpMergeNguon1";
            this.grpMergeNguon1.Padding = new Padding(6);
            this.grpMergeNguon1.Size = new Size(380, 514);
            this.grpMergeNguon1.TabIndex = 1;
            this.grpMergeNguon1.TabStop = false;
            this.grpMergeNguon1.Text = "Nguồn 1: Danh sách chính quy ban đầu";

            this.dgvMergeNguon1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMergeNguon1.BackgroundColor = SystemColors.Window;
            this.dgvMergeNguon1.BorderStyle = BorderStyle.Fixed3D;
            this.dgvMergeNguon1.Dock = DockStyle.Fill;
            this.dgvMergeNguon1.ReadOnly = true;
            this.dgvMergeNguon1.Size = new Size(368, 485);
            this.dgvMergeNguon1.TabIndex = 0;

            this.grpMergeNguon2.Controls.Add(this.dgvMergeNguon2);
            this.grpMergeNguon2.Dock = DockStyle.Left;
            this.grpMergeNguon2.Location = new Point(386, 52);
            this.grpMergeNguon2.Name = "grpMergeNguon2";
            this.grpMergeNguon2.Padding = new Padding(6);
            this.grpMergeNguon2.Size = new Size(380, 514);
            this.grpMergeNguon2.TabIndex = 2;
            this.grpMergeNguon2.TabStop = false;
            this.grpMergeNguon2.Text = "Nguồn 2: Danh sách bổ sung / phúc khảo";

            this.dgvMergeNguon2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMergeNguon2.BackgroundColor = SystemColors.Window;
            this.dgvMergeNguon2.BorderStyle = BorderStyle.Fixed3D;
            this.dgvMergeNguon2.Dock = DockStyle.Fill;
            this.dgvMergeNguon2.ReadOnly = true;
            this.dgvMergeNguon2.Size = new Size(368, 485);
            this.dgvMergeNguon2.TabIndex = 0;

            this.grpMergeKetQua.Controls.Add(this.dgvMergeKetQua);
            this.grpMergeKetQua.Dock = DockStyle.Fill;
            this.grpMergeKetQua.Location = new Point(766, 52);
            this.grpMergeKetQua.Name = "grpMergeKetQua";
            this.grpMergeKetQua.Padding = new Padding(6);
            this.grpMergeKetQua.Size = new Size(404, 514);
            this.grpMergeKetQua.TabIndex = 3;
            this.grpMergeKetQua.TabStop = false;
            this.grpMergeKetQua.Text = "Kết quả sau khi Merge (Nguồn 1.Merge(Nguồn 2))";

            this.dgvMergeKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMergeKetQua.BackgroundColor = SystemColors.Window;
            this.dgvMergeKetQua.BorderStyle = BorderStyle.Fixed3D;
            this.dgvMergeKetQua.Dock = DockStyle.Fill;
            this.dgvMergeKetQua.ReadOnly = true;
            this.dgvMergeKetQua.Size = new Size(392, 485);
            this.dgvMergeKetQua.TabIndex = 0;

            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new ToolStripItem[] {
                this.lblStatus,
                this.lblAuthor
            });
            this.statusStrip1.Location = new Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new Size(1184, 24);
            this.statusStrip1.TabIndex = 2;

            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(800, 19);
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            this.lblStatus.Text = "Trạng thái: Sẵn sàng | Lab 10: Dữ liệu ngắt kết nối ADO.NET";

            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new Size(350, 19);
            this.lblAuthor.Text = "Phan Văn Thắng - MSSV: 24002545 - Lớp: IT3212 - EAUT";

            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1184, 684);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new Size(1050, 650);
            this.Name = "frmMain";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Lab 10 - DataAdapter, DataTable, DataSet và Dữ liệu ngắt kết nối";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabBai1_5.ResumeLayout(false);
            this.pnlBai1_5Top.ResumeLayout(false);
            this.pnlBai1_5Top.PerformLayout();
            ((ISupportInitialize)(this.dgvBai1_5)).EndInit();

            this.tabBai2_3.ResumeLayout(false);
            this.pnlBai2_3Top.ResumeLayout(false);
            this.pnlBai2_3Top.PerformLayout();
            this.pnlBai2_3Master.ResumeLayout(false);
            this.grpKhoa.ResumeLayout(false);
            ((ISupportInitialize)(this.dgvKhoa)).EndInit();
            this.grpSinhVienTheoKhoa.ResumeLayout(false);
            ((ISupportInitialize)(this.dgvSinhVienTheoKhoa)).EndInit();

            this.tabBai4.ResumeLayout(false);
            this.pnlBai4Top.ResumeLayout(false);
            this.pnlBai4Top.PerformLayout();
            ((ISupportInitialize)(this.numBai4MinDiem)).EndInit();
            ((ISupportInitialize)(this.dgvBai4)).EndInit();

            this.tabBai6.ResumeLayout(false);
            this.pnlBai6Top.ResumeLayout(false);
            this.pnlBai6Top.PerformLayout();
            ((ISupportInitialize)(this.dgvBai6)).EndInit();

            this.tabBai7_8.ResumeLayout(false);
            this.pnlBai7_8Top.ResumeLayout(false);
            this.pnlBai7_8Top.PerformLayout();
            ((ISupportInitialize)(this.dgvBai7_8)).EndInit();
            this.grpRowStateLog.ResumeLayout(false);

            this.tabBai9.ResumeLayout(false);
            this.tabBai9.PerformLayout();
            this.pnlBai9Top.ResumeLayout(false);
            this.pnlBai9Top.PerformLayout();
            ((ISupportInitialize)(this.dgvBai9Xml)).EndInit();

            this.tabBai10.ResumeLayout(false);
            this.pnlBai10Top.ResumeLayout(false);
            this.pnlBai10Top.PerformLayout();
            this.grpMergeNguon1.ResumeLayout(false);
            ((ISupportInitialize)(this.dgvMergeNguon1)).EndInit();
            this.grpMergeNguon2.ResumeLayout(false);
            ((ISupportInitialize)(this.dgvMergeNguon2)).EndInit();
            this.grpMergeKetQua.ResumeLayout(false);
            ((ISupportInitialize)(this.dgvMergeKetQua)).EndInit();

            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
