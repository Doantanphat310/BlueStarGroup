DROP PROCEDURE IF EXISTS AccountsUpdate;
GO
CREATE PROCEDURE AccountsUpdate (
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
	UPDATE Accounts
	SET
		AccountName = @AccountName
		,AccountGroupID = @AccountGroupID
		,AccountLevel = @AccountLevel
		,ParentID = @ParentID
		,HachToan = @HachToan
		,DuNo = @DuNo
		,DuCo = @DuCo
		,ThongKe = @ThongKe
		,NgoaiTe = @NgoaiTe
		,TK152_156 = @TK152_156
		,VatTu = @VatTu
		,ThueVAT = @ThueVAT
		,HopDong = @HopDong
		,CongNo = @CongNo
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UpdateUser
	WHERE 
		AccountID = @AccountID
