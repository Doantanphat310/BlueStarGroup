USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[VouchersVouchersDetailInsert]    Script Date: 17/11/2020 2:11:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[VouchersDetailUpdate] (
	@VouchersID varchar(50),
	@VouchersDetailID varchar(50),
	@NV varchar(50),
	@AccountID varchar(50),
	@CustomerID varchar(50),
	@GeneralLedgerID varchar(50),
	@Amount money,
	@CompanyID varchar(50),
	@CreateUser varchar(20)
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
			GeneralLedgerID = @GeneralLedgerID,
			CustomerID =@CustomerID,
			DebitAmount = @Amount,
			CreditAmount = null,
			CompanyID = @CompanyID,
			UpdateUser = @CreateUser,
			UpdateDate = GETDATE()
			where VouchersDetailID = @VouchersDetailID
		end
		else if(@NV = 'C')
		begin
			--------Ghi tk nợ
			update  VouchersDetail
			set
			VouchersID =@VouchersID,
			AccountID = @AccountID,
			GeneralLedgerID = @GeneralLedgerID,
			CustomerID =@CustomerID,
			DebitAmount = null,
			CreditAmount = @Amount,
			CompanyID = @CompanyID,
			UpdateUser = @CreateUser,
			UpdateDate = GETDATE()
			where VouchersDetailID = @VouchersDetailID
		end
	end