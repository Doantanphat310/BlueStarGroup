USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[CustomerInsert]    Script Date: 11/8/2020 12:04:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

EXEC sp_rename 'Vouchers.ID', 'SEQ', 'COLUMN';

alter PROCEDURE [dbo].[VouchersInsert] (
	@Amount money,
	@Description nvarchar(max),
	@VouchersTypeID varchar(50),
	@VourchersTypeSumary nvarchar(20),
	@Date datetime,
	@CompanyID varchar(50),
	@CreateUser varchar(20)
)
AS	
	DECLARE @SEQ bigint;
	DECLARE @VouchersID varchar(50);
	SET @SEQ = (SELECT MAX(SEQ) + 1 FROM Vouchers);

	SET @VouchersID = 'VOU' + FORMAT(@SEQ, '0000000000');

	INSERT INTO Vouchers(
		VouchersID,
		Description,
		Amount,
		VouchersTypeID,
		VourchersTypeSumary,
		Date,
		CreateUser,
		CreateDate,
		CompanyID)
	VALUES(
		@VouchersID,
		@Description,
		@Amount,
		@VouchersTypeID,
		@VourchersTypeSumary,
		@Date,
		@CreateUser,
		GETDATE(),
		@CompanyID)