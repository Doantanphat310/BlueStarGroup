create proc CloseGeneralLedgerSelectCompanyID
@CompanyID varchar(50)
as
begin
Select * from CloseGeneralLedger
where IsDelete is null and CompanyID = @CompanyID
end
