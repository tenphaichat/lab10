-- ===================================================================
-- LAB 10: DATAADAPTER, DATATABLE, DATASET VÀ DỮ LIỆU NGẮT KẾT NỐI
-- Học phần: Lập trình .NET (IT3212) - EAUT
-- Sinh viên: Phan Văn Thắng - MSSV: 24002545 - Lớp: IT3212
-- CSDL: QLSinhVien
-- ===================================================================

USE QLSinhVien;
GO

-- 1. Đảm bảo các khoa tồn tại
IF NOT EXISTS (SELECT 1 FROM Khoa WHERE MaKhoa = 'CNTT')
    INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('CNTT', N'Công nghệ thông tin');
IF NOT EXISTS (SELECT 1 FROM Khoa WHERE MaKhoa = 'OTO')
    INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('OTO', N'Công nghệ kỹ thuật ô tô');
IF NOT EXISTS (SELECT 1 FROM Khoa WHERE MaKhoa = 'DDT')
    INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('DDT', N'Điện - Điện tử');
IF NOT EXISTS (SELECT 1 FROM Khoa WHERE MaKhoa = 'KT')
    INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('KT', N'Kinh tế');
IF NOT EXISTS (SELECT 1 FROM Khoa WHERE MaKhoa = 'NN')
    INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('NN', N'Ngôn ngữ Anh');
GO

-- 2. Đảm bảo sinh viên tác giả Phan Văn Thắng tồn tại
IF NOT EXISTS (SELECT 1 FROM SinhVien WHERE MaSV = '24002545')
BEGIN
    INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email)
    VALUES ('24002545', N'Phan Văn Thắng', '2006-03-26', 1, 'CNTT', 8.85, '24002545@eaut.edu.vn');
END
ELSE
BEGIN
    UPDATE SinhVien 
    SET HoTen = N'Phan Văn Thắng', NgaySinh = '2006-03-26', GioiTinh = 1, MaKhoa = 'CNTT', DiemTB = 8.85, Email = '24002545@eaut.edu.vn'
    WHERE MaSV = '24002545';
END
GO

SELECT COUNT(*) AS TongSoSinhVien FROM SinhVien;
SELECT COUNT(*) AS TongSoKhoa FROM Khoa;
GO
