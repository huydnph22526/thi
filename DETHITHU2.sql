--Câu 1 (1.5 điểm): Tạo cơ sở dữ liệu DANGKYHOC gồm 3 bảng.
CREATE DATABASE DKH
--SINHVIEN (MaSV, Ten,GioiTinh,NgaySinh,DiaChi)
IF OBJECT_ID('SINHVIEN') IS NOT NULL
DROP TABLE SINHVIEN 
GO 
CREATE TABLE SINHVIEN(
	MaSV VARCHAR(20) PRIMARY KEY NOT NULL,
	Ten NVARCHAR(30) NULL,
	GioiTinh NVARCHAR(20) NULL,
	NgaySinh DATE NULL,
	DiaChi NVARCHAR(20) NULL
)
--MONHOC (MaMH, TenMH, NganhHoc)
IF OBJECT_ID('MONHOC') IS NOT NULL
DROP TABLE MONHOC
GO 
CREATE TABLE MONHOC 
(
	MaMH VARCHAR(20) PRIMARY KEY NOT NULL,
	TenMH NVARCHAR(30) NULL,
	NganhHoc NVARCHAR(30) NULL
)
--DANGKY (MaSV, MaMH, NgayDK, HocKy)
IF OBJECT_ID('DANGKY') IS NOT NULL
DROP TABLE DANGKY
GO 
CREATE TABLE DANGKY(
	MaSV VARCHAR(20) NOT NULL,
	MaMH VARCHAR(20)  NOT NULL,
	NgayDK DATE NULL,
	HocKy INT NULL,
	PRIMARY KEY (MaSV,MaMH),
	FOREIGN KEY (MaSV) REFERENCES SINHVIEN,
	FOREIGN KEY (MaMH) REFERENCES MONHOC
)
--Câu 2 (3 điểm): Chèn thông tin vào các bảng
--Tạo Stored Procedure (SP) với các tham số đầu vào phù hợp.
--SP thứ nhất thực hiện chèn dữ liệu vào bảng SINHVIEN.
--SP thứ hai thực hiện chèn dữ liệu vào bảng MONHOC.
--SP thứ ba thực hiện chèn dữ liệu vào bảng DANGKY.
--Yêu cầu mỗi SP phải kiểm tra tham số đầu vào. Với các cột không chấp nhận thuộc tính Null.
--Với mỗi SP viết 3 lời gọi thành công.
IF OBJECT_ID('SP_SINHVIEN') IS NOT NULL
DROP PROC SP_SINHVIEN
GO 
CREATE PROC SP_SINHVIEN
@MaSV VARCHAR(20) ,
	@Ten NVARCHAR(30) ,
	@GioiTinh NVARCHAR(20) ,
	@NgaySinh DATE ,
	@DiaChi NVARCHAR(20)
AS IF @MaSV IS NULL OR @Ten IS NULL OR @GioiTinh IS NULL OR @NgaySinh IS NULL OR @DiaChi IS NULL 
PRINT N'VUI LÒNG NHẬP ĐẦY ĐỦ'
INSERT SINHVIEN VALUES(
@MaSV,@Ten,@GioiTinh,@NgaySinh,@DiaChi)
PRINT N'NHẬP THÀNH CÔNG'
EXEC SP_SINHVIEN 'PH001',N'ĐỖ NGỌC HUY', 'NAM', '08/05/2003',N'HÀ NỘI'
EXEC SP_SINHVIEN 'PH002',N'HÀ THỊ THU HẰNG', N'NỮ', '12/17/2004',N'HÒA BÌNH'
EXEC SP_SINHVIEN 'PH003',N'PHẠM KHƯƠNG DUY', 'NAM', '08/01/2003',N'THÁI BÌNH'
SELECT * FROM SINHVIEN
----
IF OBJECT_ID('SP_MONHOC') IS NOT NULL
DROP PROC SP_MONHOC
GO 
CREATE PROC SP_MONHOC
@MaMH VARCHAR(20),
	@TenMH NVARCHAR(30) ,
	@NganhHoc NVARCHAR(30) 
AS IF @MaMH IS NULL OR @TenMH IS NULL OR @NganhHoc IS NULL
PRINT N'VUI LÒNG NHẬP ĐẦY ĐỦ '
INSERT MONHOC VALUES(@MaMH,@TenMH,@NganhHoc)
PRINT N'NHẬP THÀNH CÔNG'
EXEC SP_MONHOC '001', N'ĐÁNH ĐÀN', N'NHẠC'
EXEC SP_MONHOC '002', N'KHIÊU VŨ', N'MÚA'
EXEC SP_MONHOC '003', N'HÁT', N'CA SĨ '
SELECT * FROM MONHOC
----
IF OBJECT_ID('SP_DANGKY') IS NOT NULL
DROP PROC SP_DANGKY
GO 
CREATE PROC SP_DANGKY
@MaSV VARCHAR(20) ,
	@MaMH VARCHAR(20),
	@NgayDK DATE ,
	@HocKy INT 
AS IF @MaSV IS NULL OR @MaMH IS NULL OR @NgayDK IS NULL OR @HocKy IS NULL
PRINT N'VUI LÒNG NHẬP ĐẦY ĐỦ '
INSERT DANGKY VALUES (@MaSV,@MaMH,@NgayDK,@HocKy)
PRINT N'NHẬP TAHNHF CÔNG'
EXEC SP_DANGKY 'PH001', '001','6/1/2022',1
EXEC SP_DANGKY 'PH002', '002','6/2/2022',2
EXEC SP_DANGKY 'PH003', '003','6/3/2022',3
SELECT * FROM DANGKY
--Câu 3 (2 điểm): Viết Hàm
--Viết hàm các tham số đầu vào tương ứng với các cột của bảng SinhVien . Hàm này trả về MaSV thỏa mãn các giá trị được truyền tham số.
IF OBJECT_ID('FUNC_SINHVIEN') IS NOT NULL
DROP FUNCTION FUNC_SINHVIEN
GO 
CREATE FUNCTION FUNC_SINHVIEN(
	@MaSV VARCHAR(20) ,
	@Ten NVARCHAR(30) ,
	@GioiTinh NVARCHAR(20) ,
	@NgaySinh DATE ,
	@DiaChi NVARCHAR(20)
)
RETURNS VARCHAR(20)
BEGIN
RETURN (SELECT MaSV FROM SINHVIEN WHERE @MaSV=MaSV AND @Ten= Ten AND @GioiTinh=GioiTinh AND @NgaySinh=NgaySinh AND @DiaChi=DiaChi)
END 
DECLARE @MaSV VARCHAR(20)
SET @MaSV= DBO.FUNC_SINHVIEN ('PH001',N'ĐỖ NGỌC HUY', 'NAM', '08/05/2003',N'HÀ NỘI')
SELECT @MaSV AS MASV
--Câu 4 (1.5 điểm): Tạo View 
--Tạo View lưu thông tin của  ngày đăng ký gần nhất, gồm các thông tin sau: MaSV, TenSV,Tuổi, DiaChi, MaMH, TenMH, NgayDK, HocKy và sắp xếp giảm dần theo ngày đăng ký
GO 
CREATE VIEW VIEW_NGAYDK
AS 
SELECT TOP 3 SINHVIEN.MaSV, Ten, (YEAR(GETDATE())-YEAR(NgaySinh)) AS N'TUỔI', DiaChi, MONHOC.MaMH, TenMH, NgayDK, HocKy
FROM SINHVIEN JOIN DANGKY ON SINHVIEN.MaSV= DANGKY.MaSV
			JOIN MONHOC ON DANGKY.MaMH = MONHOC.MaMH
GROUP BY  SINHVIEN.MaSV, Ten,NgaySinh, DiaChi, MONHOC.MaMH, TenMH, NgayDK, HocKy
ORDER BY NgayDK DESC
SELECT * FROM VIEW_NGAYDK
--Câu 5 (2 điểm): Viết thủ tục
--Viết một SP nhận một tham số đầu vào là NgayDK. SP này thực hiện thao tác xóa thông tin sinh viên và môn học tương ứng.
--Yêu cầu: Sử dụng giao dịch trong thân SP, để đảm bảo tính toàn vẹn dữ liệu khi một thao tác xóa thực hiện không thành công.
IF OBJECT_ID('SP_NGAYDK') IS NOT NULL
DROP PROC SP_NGAYDK
GO
 CREATE PROC SP_NGAYDK(
 @NgayDK DATE
 )
 AS 
 BEGIN TRY
 BEGIN TRAN
 DELETE FROM DANGKY WHERE NgayDK = @NgayDK
 PRINT N'XÓA THÀNH CÔNG'
 COMMIT TRAN
 END TRY
 BEGIN CATCH
 PRINT N'XÓA KHÔNG THÀNH CÔNG'
 ROLLBACK
 END CATCH

 EXEC  SP_NGAYDK '6/3/2022'
 SELECT * FROM DANGKY