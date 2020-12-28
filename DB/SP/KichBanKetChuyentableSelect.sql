alter proc KichBanKetChuyentableSelect
@CompanyID varchar(50)
as
begin
	select GroupCode,KetChuyenDebitAccountID,KetChuyenCreditAccountID,CompanyID from KichBanketChuyentable
	where CompanyID = @CompanyID
end
