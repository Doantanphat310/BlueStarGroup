USE [BlueStarGroup]
GO


Create Proc KichBanKetChuyentableInsert
@GroupCode varchar(50),
@KetChuyenDebitAccountID varchar(50),
@KetChuyenCreditAccountID varchar(50),
@CreateUser varchar(50),
@CompanyID varchar(50)
as
begin
Insert into KichBanKetChuyentable(
									GroupCode,
									KetChuyenDebitAccountID,
									KetChuyenCreditAccountID,
									CreateDate,
									CreateUser,
									CompanyID
									)
								values(
									@GroupCode,
									@KetChuyenDebitAccountID,
									@KetChuyenCreditAccountID,
									getdate(),
									@CreateUser,
									@CompanyID
									)
end


