USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[CustomerUpdate]    Script Date: 11/8/2020 12:08:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[VoucherUpdate] (
	@VouchersID nvarchar(250),
	@Amount money,
	@Description nvarchar(max),
	@CreateUser varchar(20)
)
AS
	UPDATE Vouchers
	SET
		Amount = @Amount,
		Description = @Description,
		UpdateDate = GETDATE(),
		UpdateUser = @CreateUser
	WHERE 
		VouchersID = @VouchersID
		AND IsDelete IS NULL