Create proc KichBanKetChuyentableSelect
@CompanyID varchar(50)
as
begin
	select * from KichBanketChuyentable
	where CompanyID = @CompanyID
end