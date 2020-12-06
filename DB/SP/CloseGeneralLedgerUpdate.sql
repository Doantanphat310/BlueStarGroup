alter proc CloseGeneralLedgerUpdate
@CloseGeneralLedgerID varchar(50),@CloseGeneralLedgerStatus bit,@CreateUser varchar(50),@CompanyID varchar(50)
as
begin
update  CloseGeneralLedger
set CloseGeneralLedgerStatus = @CloseGeneralLedgerStatus,
UpdateUser = @CreateUser,
UpdateDate = getdate()
where @CloseGeneralLedgerID = @CloseGeneralLedgerID and CreateUser = @CreateUser and CompanyID = @CompanyID
end