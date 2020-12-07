DROP PROCEDURE IF EXISTS AccountsInsert;
GO
CREATE PROCEDURE AccountsInsert (
	@AccountID varchar(30)
	,@AccountName nvarchar(250)
	,@AccountGroupID varchar(30)
	,@AccountLevel tinyint
	,@ParentID varchar(30)
	,@HachToan bit
	,@DuNo bit
	,@DuCo bit
	,@ThongKe bit
	,@NgoaiTe bit
	,@TK152_156 bit
	,@VatTu bit
	,@ThueVAT bit
	,@HopDong bit
	,@CongNo bit
    ,@UpdateUser varchar(20)
)
AS
	INSERT INTO Accounts(
		AccountID
		,AccountName
		,AccountGroupID
		,AccountLevel
		,ParentID
		,HachToan
		,DuNo
		,DuCo
		,ThongKe
		,NgoaiTe
		,TK152_156
		,VatTu
		,ThueVAT
		,HopDong
		,CongNo
        ,CreateDate
        ,UpdateDate
        ,CreateUser
        ,UpdateUser)
	VALUES(
		@AccountID
		,@AccountName
		,@AccountGroupID
		,@AccountLevel
		,@ParentID
		,@HachToan
		,@DuNo
		,@DuCo
		,@ThongKe
		,@NgoaiTe
		,@TK152_156
		,@VatTu
		,@ThueVAT
		,@HopDong
		,@CongNo
        ,GETDATE()
        ,GETDATE()
        ,@UpdateUser
        ,@UpdateUser)
