
Create Proc KichBanKetChuyentableDelete
@GroupCode varchar(50),
@KetChuyenDebitAccountID varchar(50),
@KetChuyenCreditAccountID varchar(50),
@CreateUser varchar(50),
@CompanyID varchar(50)
as
begin
delete  KichBanKetChuyentable
 WHERE CompanyID = @CompanyID and CreateUser = @CreateUser 
		and KetChuyenDebitAccountID = @KetChuyenDebitAccountID 
		and KetChuyenCreditAccountID = @KetChuyenCreditAccountID
		and GroupCode = @GroupCode
end


