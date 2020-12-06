DROP PROCEDURE IF EXISTS CompanyInsert;
GO
CREATE PROCEDURE CompanyInsert (
	@CompanyID varchar(20)
	,@CompanyName nvarchar(250)
	,@CompanySName varchar(50)
	,@Address nvarchar(MAX)
	,@MST varchar(20)
	,@District nvarchar(250)
	,@Province nvarchar(250)
	,@Phone varchar(20)
	,@Fax varchar(20)
	,@Email varchar(50)
	,@BankAccount varchar(50)
	,@BankName nvarchar(250)
	,@BankBranch nvarchar(250)
	,@Logo nvarchar(MAX)
	,@SoQuyetDinh varchar(50)
	,@MaSoHD varchar(50)
	,@NoiQLThue nvarchar(MAX)
	,@NHKhoBac nvarchar(MAX)
	,@TKThuThue varchar(50)
	,@LapBieu nvarchar(250)
	,@KTTruong nvarchar(250)
	,@KTVien nvarchar(250)
	,@LanhDao nvarchar(250)
	,@ThuQuy nvarchar(250)
	,@ChucDanhLanhDao nvarchar(250)
	,@ChuKyLapBieu nvarchar(MAX)
	,@ChuKyKTTruong nvarchar(MAX)
	,@ChuKyKeToanVien nvarchar(MAX)
	,@ChuKyLanhDao nvarchar(MAX)
	,@ChuKyThuQuy nvarchar(MAX)
    ,@UpdateUser varchar(20)
)
AS
	INSERT INTO Company(
		CompanyID
		,CompanyName
		,CompanySName
		,Address
		,MST
		,District
		,Province
		,Phone
		,Fax
		,Email
		,BankAccount
		,BankName
		,BankBranch
		,Logo
		,SoQuyetDinh
		,MaSoHD
		,NoiQLThue
		,NHKhoBac
		,TKThuThue
		,LapBieu
		,KTTruong
		,KTVien
		,LanhDao
		,ThuQuy
		,ChucDanhLanhDao
		,ChuKyLapBieu
		,ChuKyKTTruong
		,ChuKyKeToanVien
		,ChuKyLanhDao
		,ChuKyThuQuy
        ,CreateDate
        ,UpdateDate
        ,CreateUser
        ,UpdateUser)
	VALUES(
		@CompanyID
		,@CompanyName
		,@CompanySName
		,@Address
		,@MST
		,@District
		,@Province
		,@Phone
		,@Fax
		,@Email
		,@BankAccount
		,@BankName
		,@BankBranch
		,@Logo
		,@SoQuyetDinh
		,@MaSoHD
		,@NoiQLThue
		,@NHKhoBac
		,@TKThuThue
		,@LapBieu
		,@KTTruong
		,@KTVien
		,@LanhDao
		,@ThuQuy
		,@ChucDanhLanhDao
		,@ChuKyLapBieu
		,@ChuKyKTTruong
		,@ChuKyKeToanVien
		,@ChuKyLanhDao
		,@ChuKyThuQuy
        ,GETDATE()
        ,GETDATE()
        ,@UpdateUser
        ,@UpdateUser)
