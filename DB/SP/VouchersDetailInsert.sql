USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[VouchersVouchersDetailInsert]    Script Date: 17/11/2020 2:11:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

VouchersDetailInsert 'a','b','N','111',null,'c','100',null,'d'

alter PROCEDURE [dbo].[VouchersDetailInsert] (
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
			INSERT INTO VouchersDetail
			(VouchersID,VouchersDetailID,AccountID,AccountDetailID,CustomerID,DebitAmount,CompanyID,CreateDate,CreateUser,Descriptions)
			VALUES(@VouchersID,@VouchersDetailID,@AccountID,@AccountDetailID,@CustomerID,@Amount,@CompanyID,getdate(),@CreateUser,@Descriptions)
		end
		else if(@NV = 'C')
		begin
			--------Ghi tk nợ
			INSERT INTO VouchersDetail
			(VouchersID,VouchersDetailID,AccountID,AccountDetailID,CustomerID,CreditAmount,CompanyID,CreateDate,CreateUser,Descriptions)
			VALUES(@VouchersID,@VouchersDetailID,@AccountID,@AccountDetailID,@CustomerID,@Amount,@CompanyID,getdate(),@CreateUser,@Descriptions)
		end
	end


	select * from VouchersDetail