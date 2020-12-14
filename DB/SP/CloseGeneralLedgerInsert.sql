

alter proc CloseGeneralLedgerInsert
@CloseGeneralLedgerID varchar(50),@CloseGeneralLedgerDate datetime,@CloseGeneralLedgerAccountID varchar(50),@CloseGeneralLedgerStatus bit,@CreateUser varchar(50),@CompanyID varchar(50)
as
begin
insert into CloseGeneralLedger
(CloseGeneralLedgerID,
CloseGeneralLedgerDate,
CloseGeneralLedgerStatus,
CreateDate,
CreateUser,
CompanyID)
values(
@CloseGeneralLedgerID,
@CloseGeneralLedgerDate,
@CloseGeneralLedgerStatus,
getdate(),
@CreateUser,
@CompanyID)
end