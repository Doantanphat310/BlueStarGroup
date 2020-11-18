USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[VouchersVouchersDetailInsert]    Script Date: 17/11/2020 2:11:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

VouchersDetailInsert 'a','b','N','111',null,'c','100',null,'d'

Create PROCEDURE [dbo].[VouchersDetailInsert] (
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
			INSERT INTO VouchersDetail
			(VouchersID,VouchersDetailID,AccountID,GeneralLedgerID,CustomerID,DebitAmount,CompanyID,CreateDate,CreateUser)
			VALUES(@VouchersID,@VouchersDetailID,@AccountID,@GeneralLedgerID,@CustomerID,@Amount,@CompanyID,getdate(),@CreateUser)
		end
		else if(@NV = 'C')
		begin
			--------Ghi tk nợ
			INSERT INTO VouchersDetail
			(VouchersID,VouchersDetailID,AccountID,GeneralLedgerID,CustomerID,CreditAmount,CompanyID,CreateDate,CreateUser)
			VALUES(@VouchersID,@VouchersDetailID,@AccountID,@GeneralLedgerID,@CustomerID,@Amount,@CompanyID,getdate(),@CreateUser)
		end
	end