DROP PROCEDURE IF EXISTS CompanyUpdate;
GO
CREATE PROCEDURE CompanyUpdate (
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
	,@CurrencyUnit nvarchar(50)
	,@BankAccount varchar(50)
	,@BankName nvarchar(250)
	,@BankBranch nvarchar(250)
	,@Logo varchar(MAX)
	,@SoQuyetDinh varchar(50)
	,@InvoiceFormNo varchar(50)
	,@FormNo varchar(20)
	,@SerialNo varchar(20)
	,@NoiQLThue nvarchar(MAX)
	,@NHKhoBac nvarchar(MAX)
	,@TKThuThue varchar(50)
	,@LapBieu nvarchar(250)
	,@KTTruong nvarchar(250)
	,@KTVien nvarchar(250)
	,@LanhDao nvarchar(250)
	,@ThuQuy nvarchar(250)
	,@ChucDanhLanhDao nvarchar(250)
	,@ChuKyLapBieu varchar(MAX)
	,@ChuKyKTTruong varchar(MAX)
	,@ChuKyKeToanVien varchar(MAX)
	,@ChuKyLanhDao varchar(MAX)
	,@ChuKyThuQuy varchar(MAX)
    ,@UpdateUser varchar(20)
)
AS
	UPDATE Company
	SET
		CompanyName = @CompanyName
		,CompanySName = @CompanySName
		,Address = @Address
		,MST = @MST
		,District = @District
		,Province = @Province
		,Phone = @Phone
		,Fax = @Fax
		,Email = @Email
		,CurrencyUnit = @CurrencyUnit
		,BankAccount = @BankAccount
		,BankName = @BankName
		,BankBranch = @BankBranch
		,Logo = @Logo
		,SoQuyetDinh = @SoQuyetDinh
		,InvoiceFormNo = @InvoiceFormNo
		,FormNo = @FormNo
		,SerialNo = @SerialNo
		,NoiQLThue = @NoiQLThue
		,NHKhoBac = @NHKhoBac
		,TKThuThue = @TKThuThue
		,LapBieu = @LapBieu
		,KTTruong = @KTTruong
		,KTVien = @KTVien
		,LanhDao = @LanhDao
		,ThuQuy = @ThuQuy
		,ChucDanhLanhDao = @ChucDanhLanhDao
		,ChuKyLapBieu = @ChuKyLapBieu
		,ChuKyKTTruong = @ChuKyKTTruong
		,ChuKyKeToanVien = @ChuKyKeToanVien
		,ChuKyLanhDao = @ChuKyLanhDao
		,ChuKyThuQuy = @ChuKyThuQuy
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UpdateUser
	WHERE 
		CompanyID = @CompanyID
