USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[CustomerInsert]    Script Date: 11/8/2020 12:04:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter PROCEDURE [dbo].[VouchersInsert] (
	@VouchersID varchar(50),
	@Amount money,
	@Description nvarchar(max),
	@VouchersTypeID varchar(50),
	@Date datetime,
	@CompanyID varchar(50),
	@CreateUser varchar(20)
)
AS	
	INSERT INTO Vouchers(
		VouchersID,
		Description,
		Amount,
		VouchersTypeID,
		Date,
		CreateUser,
		CreateDate,
		CompanyID)
	VALUES(
		@VouchersID,
		@Description,
		@Amount,
		@VouchersTypeID,
		@Date,
		@CreateUser,
		GETDATE(),
		@CompanyID)