USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[VouchersVouchersDetailInsert]    Script Date: 17/11/2020 2:11:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[VouchersDetailUpdate] (
	@VouchersID varchar(50),
	@VouchersDetailID varchar(50),
	@NV varchar(50),
	@AccountID varchar(50),
	@CustomerID varchar(50),
	@AccountDetailID varchar(50),
	@Amount money,
	@CompanyID varchar(50),
	@CreateUser varchar(20),
	@Descriptions nvarchar(max)
)
AS	
	begin
		if(@NV = 'N')
		begin
			--------Ghi tk nợ
			update  VouchersDetail
			set
			VouchersID =@VouchersID,
			AccountID = @AccountID,
			AccountDetailID = @AccountDetailID,
			CustomerID =@CustomerID,
			DebitAmount = @Amount,
			CreditAmount = null,
			CompanyID = @CompanyID,
			UpdateUser = @CreateUser,
			UpdateDate = GETDATE(),
			Descriptions = @Descriptions
			where VouchersDetailID = @VouchersDetailID
		end
		else if(@NV = 'C')
		begin
			--------Ghi tk nợ
			update  VouchersDetail
			set
			VouchersID =@VouchersID,
			AccountID = @AccountID,
			AccountDetailID = @AccountDetailID,
			CustomerID =@CustomerID,
			DebitAmount = null,
			CreditAmount = @Amount,
			CompanyID = @CompanyID,
			UpdateUser = @CreateUser,
			UpdateDate = GETDATE(),
			Descriptions = @Descriptions
			where VouchersDetailID = @VouchersDetailID
		end
	end