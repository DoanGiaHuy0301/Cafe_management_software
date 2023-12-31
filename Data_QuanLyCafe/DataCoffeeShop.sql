﻿CREATE DATABASE QuanLyQuanCafe
Go

--SanPham
--LoaiSanPham
--KhuyenMai
--ThongTinBan
--TaiKhoan
--NhanVien
--KhachHang
--KhachHangThanThiet
--HoaDon
--ChiTietHoaDon

Use QuanLyQuanCafe
Go

CREATE TABLE LoaiSanPham
(
	LoaiSanPhamID INT IDENTITY PRIMARY KEY,
	LoaiSanPham NVARCHAR(100)
)
Go

CREATE TABLE SanPham
(
	SanPhamID INT IDENTITY PRIMARY KEY,
	TenSanPham NVARCHAR(100) NOT NULL,
	DonViTinh NVARCHAR(20) NOT NULL,
	DonGia FLOAT NOT NULL,
	ID_LoaiSanPham INT NOT NULL,
	Size nchar(10) NOT NULL

	FOREIGN KEY (ID_LoaiSanPham) REFERENCES dbo.LoaiSanPham(LoaiSanPhamID)
)
Go

CREATE TABLE ThongTinBan
(
	BanID INT IDENTITY PRIMARY KEY,
	SoBan NVARCHAR NOT NULL,
	TrangThai NVARCHAR(100) DEFAULT N'Trống' --TRỐNG || CÓ NGƯỜI
)
Go


CREATE TABLE NhanVien
(
	NhanVienID INT IDENTITY PRIMARY KEY,
	HoVaTen NVARCHAR(50) NOT NULL,
	NgaySinh DATE NOT NULL,
	GioiTinh NVARCHAR(10) NOT NULL,
	SoDienThoai NVARCHAR(15) NOT NULL,
	NgayVaoLam DATE NOT NULL,
	ChucVu NVARCHAR(50) NOT NULL
)
Go

CREATE TABLE TaiKhoan 
(
	Username NVARCHAR(100) PRIMARY KEY,
	PassWord NVARCHAR(1000) NOT NULL,
	ID_NhanVien INT NOT NULL,
	ChucVu INT NOT NULL DEFAULT 0 --1: admin || 0: NhanVien

	FOREIGN KEY (ID_NhanVien) REFERENCES dbo.NhanVien(NhanVienID)
)
Go

CREATE TABLE KhachHang
(
	KhachHangID INT IDENTITY PRIMARY KEY,
	HoVaTen NVARCHAR(50) NOT NULL,
	SoDienThoai NVARCHAR(15) NOT NULL,
	DiemTichLuy INT NOT NULL
)
Go

CREATE TABLE KhachHangThanThiet
(
	KhachHangID INT IDENTITY PRIMARY KEY,
	MucGiamGia FLOAT NOT NULL,
	ID_KhachHang INT NOT NULL,

	FOREIGN KEY (ID_KhachHang) REFERENCES dbo.KhachHang(KhachHangID)
)
Go

CREATE TABLE HoaDon
(
	HoaDonID INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE NOT NULL,
	SoBanDaDung INT NOT NULL,
	ID_NhanVien INT NOT NULL,
	TrangThai INT NOT NULL DEFAULT 0 --Đã thanh toan || Chua thanh toán

	FOREIGN KEY (SoBanDaDung) REFERENCES dbo.ThongTinBan(BanID),
	FOREIGN KEY (ID_NhanVien) REFERENCES dbo.NhanVien(NhanVienID)
)
Go

CREATE TABLE ChiTietHoaDon
(
	ChiTietHoaDonID INT IDENTITY PRIMARY KEY,
	ID_HoaDon INT NOT NULL,
	ID_SanPham INT NOT NULL,
	TongSanPham INT NOT NULL DEFAULT 0

	FOREIGN KEY (ID_HoaDon) REFERENCES dbo.HoaDon(HoaDonID),
	FOREIGN KEY (ID_SanPham) REFERENCES dbo.SanPham(SanPhamID)
)
Go


INSERT INTO dbo.TaiKhoan (Username, PassWord, ID_NhanVien, ChuVu)
VALUES ('HUY', '123', '2', '0');
GO

INSERT INTO dbo.TaiKhoan (Username, PassWord, ID_NhanVien, ChuVu)
VALUES ('THANH', '456', '12', '1');
GO

INSERT INTO dbo.TaiKhoan (Username, PassWord, ID_NhanVien, ChuVu)
VALUES ('HIEU', '789', '13', '1');
GO

SELECT * FROM DBO.TaiKhoan
GO

CREATE PROC USP_GetTaiKhoanByUsername
@username nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.TaiKhoan WHERE Username = @username
END
GO

EXEC dbo.USP_GetTaiKhoanByUsername @username = N'HUY' 

GO 

CREATE PROC USP_Login
@username nvarchar(100), @password nvarchar(1000)
AS
BEGIN
	SELECT * FROM dbo.TaiKhoan WHERE Username = @username AND PassWord = @password
END
GO

EXEC USP_Login @username = 'huy2', @password = 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3'



DECLARE @i INT = 1

WHILE @i <= 20
BEGIN
	INSERT dbo.ThongTinBan (SoBan) VALUES (N'Bàn ' + CAST(@i AS nvarchar(50)))
	SET @i = @i + 1
END
GO

CREATE PROC USP_GetTable
AS SELECT * FROM dbo.ThongTinBan
go

EXEC dbo.USP_GetTable
Go




--Thêm bill
INSERT INTO dbo.HoaDon(DateCheckIn, DateCheckOut, SoBanDaDung, TrangThai)
VALUES ( GETDATE(), NULL, 26, 0);

INSERT INTO dbo.HoaDon(DateCheckIn, DateCheckOut, SoBanDaDung, TrangThai)
VALUES ( GETDATE(), NULL, 29, 0);

INSERT INTO dbo.HoaDon(DateCheckIn, DateCheckOut, SoBanDaDung, TrangThai)
VALUES ( GETDATE(), GETDATE(), 24, 1);

INSERT INTO dbo.HoaDon(DateCheckIn, DateCheckOut, SoBanDaDung, TrangThai)
VALUES ( GETDATE(), GETDATE(), 25, 1);

GO

--Thêm chi tiết hóa đơn
INSERT INTO dbo.ChiTietHoaDon(ID_HoaDon, ID_SanPham, TongSanPham)
VALUES (19, 10, 2);
INSERT INTO dbo.ChiTietHoaDon(ID_HoaDon, ID_SanPham, TongSanPham)
VALUES (19, 6, 1);
INSERT INTO dbo.ChiTietHoaDon(ID_HoaDon, ID_SanPham, TongSanPham)
VALUES (19, 2, 3);

INSERT INTO dbo.ChiTietHoaDon(ID_HoaDon, ID_SanPham, TongSanPham)
VALUES (22, 11, 2);
INSERT INTO dbo.ChiTietHoaDon(ID_HoaDon, ID_SanPham, TongSanPham)
VALUES (22, 8, 1);
INSERT INTO dbo.ChiTietHoaDon(ID_HoaDon, ID_SanPham, TongSanPham)
VALUES (22, 2, 3);

INSERT INTO dbo.ChiTietHoaDon(ID_HoaDon, ID_SanPham, TongSanPham)
VALUES (20, 10, 2);
INSERT INTO dbo.ChiTietHoaDon(ID_HoaDon, ID_SanPham, TongSanPham)
VALUES (20, 2, 1);

INSERT INTO dbo.ChiTietHoaDon(ID_HoaDon, ID_SanPham, TongSanPham)
VALUES (21, 10, 2);
INSERT INTO dbo.ChiTietHoaDon(ID_HoaDon, ID_SanPham, TongSanPham)
VALUES (21, 2, 1);
GO

--Select TenSanPham as N'Tên sản phẩm', DonViTinh as N'Đơn vị tính', sp.Size as N'Size', sp.DonGia as N'Đơn giá', cthd.TongSanPham as N'Số lượng sản phẩm', cthd.TongSanPham * sp.DonGia as N'Tổng tiền'
--from dbo.ChiTietHoaDon as cthd, dbo.HoaDon as hd, dbo.SanPham as sp
--where cthd.ID_HoaDon = hd.HoaDonID AND cthd.ID_SanPham = sp.SanPhamID AND hd.SoBanDaDung = 26 AND hd.TrangThai = 0

CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN
	INSERT INTO dbo.HoaDon(DateCheckIn, DateCheckOut, SoBanDaDung, TrangThai)
	VALUES ( GETDATE(), NULL, @idTable, 0);
END
GO

CREATE PROC USP_InsertBillInfo
@idBill INT, @idProduct INT, @count INT
AS
BEGIN
	
	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 1

	SELECT @isExitsBillInfo = ChiTietHoaDonID, @foodCount = TongSanPham 
	From dbo.ChiTietHoaDon 
	Where @idBill = ID_HoaDon AND @idProduct = ID_SanPham
	
	IF (@isExitsBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF (@newCount > 0)
			UPDATE dbo.ChiTietHoaDon SET TongSanPham = @foodCount + @count WHERE @idProduct = ID_SanPham
		ELSE
			DELETE dbo.ChiTietHoaDon WHERE @idBill = ID_HoaDon AND @idProduct = ID_SanPham
	END
	ELSE
	BEGIN
		INSERT INTO dbo.ChiTietHoaDon(ID_HoaDon, ID_SanPham, TongSanPham)
		VALUES (@idBill, @idProduct, @count);
	END	
END
GO

SELECT MAX(HoaDonID) FROM dbo.HoaDon

UPDATE dbo.HoaDon SET TrangThai = 1 WHERE HoaDonID = 1
GO

CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.ChiTietHoaDon FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT

	SELECT @idBill = ID_HoaDon FROM Inserted

	DECLARE @idTable INT

	SELECT @idTable = SobanDaDung  FROM dbo.HoaDon WHERE HoaDonID = @idBill AND TrangThai = 0
	
	DECLARE @count INT
	SELECT @count = COUNT(*) FROM dbo.ChiTietHoaDon WHERE ID_HoaDon = @idBill

	IF (@count > 0)
		UPDATE dbo.ThongTinBan SET TrangThai = N'Có người' WHERE BanID = @idTable
	ELSE
		UPDATE dbo.ThongTinBan SET TrangThai = N'Trống' WHERE BanID = @idTable
END
GO

CREATE TRIGGER UTG_UpdateBill
ON dbo.HoaDon FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT

	SELECT @idBill = HoaDonID FROM Inserted

	DECLARE @idTable INT

	SELECT @idTable = SobanDaDung  FROM dbo.HoaDon WHERE HoaDonID = @idBill

	DECLARE @count INT = 0

	SELECT @count = COUNT(*) FROM dbo.HoaDon as hd WHERE SoBanDaDung = @idTable AND hd.TrangThai = 0

	If (@count = 0)
		UPDATE dbo.ThongTinBan SET TrangThai = N'Trống' WHERE BanID = @idTable
END
GO

CREATE PROC USP_SwitchTable
@IDTable1 INT, @IDTable2 INT
AS
BEGIN
	DECLARE @idFirstBill INT
	DECLARE @idSecondBill INT

	DECLARE @idFirstTableEmty INT = 1
	DECLARE @idSecondTableEmty INT = 1

	SELECT @idSecondBill = HoaDonID FROM dbo.HoaDon WHERE SoBanDaDung = @IDTable2 AND TrangThai = '0'	
	SELECT @idFirstBill = HoaDonID FROM dbo.HoaDon WHERE SoBanDaDung = @IDTable1 AND TrangThai = '0'

	IF (@idFirstBill IS NULL) 
	BEGIN
		INSERT INTO dbo.HoaDon(DateCheckIn, DateCheckOut, SoBanDaDung, TrangThai)
		VALUES ( GETDATE(), NULL, @IDTable1, 0);

		SELECT @idFirstBill = MAX(HoaDonID) FROM dbo.HoaDon WHERE SoBanDaDung = @IDTable1 AND TrangThai = '0'

	END

	SELECT @idFirstTableEmty = COUNT(*) FROM dbo.ChiTietHoaDon WHERE ID_HoaDon = @idFirstBill

	IF (@idSecondBill IS NULL) 
	BEGIN
		INSERT INTO dbo.HoaDon(DateCheckIn, DateCheckOut, SoBanDaDung, TrangThai)
		VALUES ( GETDATE(), NULL, @IDTable2, 0);

		SELECT @idSecondBill = MAX(HoaDonID) FROM dbo.HoaDon WHERE SoBanDaDung = @IDTable1 AND TrangThai = '0'


	END
	SELECT @idSecondTableEmty = COUNT(*) FROM dbo.ChiTietHoaDon WHERE ID_HoaDon = @idSecondBill

	SELECT ChiTietHoaDonID INTO IDBillInfoTable FROM dbo.ChiTietHoaDon WHERE ID_HoaDon = @idSecondBill

	UPDATE dbo.ChiTietHoaDon SET ID_HoaDon = @idSecondBill WHERE ID_HoaDon = @idFirstBill

	UPDATE dbo.ChiTietHoaDon SET ID_HoaDon = @idFirstBill WHERE ChiTietHoaDonID IN (SELECT * FROM dbo.IDBillInfoTable)

	DROP TABLE IDBillInfoTable

	IF (@idFirstTableEmty = 0)
		UPDATE dbo.ThongTinBan SET TrangThai = N'Trống' WHERE BanID = @IDTable2
	IF (@idSecondTableEmty = 0)
		UPDATE dbo.ThongTinBan SET TrangThai = N'Trống' WHERE BanID = @IDTable1
END
GO


Select * from dbo.HoaDon
Select * from dbo.ChiTietHoaDon
GO

CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.ChiTietHoaDon FOR DELETE
AS
BEGIN
	DECLARE @idBillInfo INT
	DECLARE @idBill INT

	SELECT @idBillInfo = ChiTietHoaDonID, @idBill = deleted.ID_HoaDon FROM deleted

	DECLARE @idTable INT
	SELECT @idTable = SoBanDaDung FROM DBO.HoaDon WHERE @idBill = HoaDonID
	
	DECLARE @count INT = 0

	SELECT @count = COUNT(*) FROM dbo.ChiTietHoaDon as cthd, dbo.HoaDon as hd
	WHERE hd.HoaDonID = cthd.ID_HoaDon AND  hd.HoaDonID = @idBill AND hd.TrangThai = 0

	IF(@count = 0)
		UPDATE dbo.ThongTinBan SET TrangThai = N'Trống' WHERE @idTable = BanID
END
GO


CREATE PROC Update_PasswordAccountStaff
@username NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0

	SELECT @isRightPass = COUNT(*) FROM dbo.TaiKhoan WHERE Username = @username AND PassWord = @password

	IF(@isRightPass = 1) 
	BEGIN
		IF (@newPassword != null or @newPassword != '')
		BEGIN
			UPDATE dbo.TaiKhoan SET PassWord = @newPassword WHERE Username = @username
		END
	END
END
GO

SELECT * FROM ChiTietHoaDon
SELECT * FROM HoaDon
SELECT DateCheckOut as N'Month',  SUM(totalPrice) as N'Doanh Thu' FROM dbo.HoaDon WHERE TrangThai = 1 Group by DateCheckOut


SELECT MONTH(DateCheckOut) as 'Month', SUM(totalPrice) as 'Revenue' FROM dbo.HoaDon WHERE TrangThai = 1 AND YEAR(DateCheckOut) = 2023 Group by MONTH(DateCheckOut)
