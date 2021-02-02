USE [BlueStarGroup]
GO

alter Proc LockDBCompanyUpdate
           @ClockDBID varchar(50),
           @CompanyID varchar(50),
           @ClockDBDate datetime,
           @ClockDBNote nvarchar(max),
           @ClockStatus bit,
           @CreateUser varchar(50)
as
begin
	UPDATE LockDBCompany
   SET 
		CompanyID = @CompanyID
		,ClockDBDate = @ClockDBDate
		,ClockDBNote = @ClockDBNote
		,ClockStatus = @ClockStatus
		,UpdateUser = @CreateUser
		,UpdateDate = getdate()
 WHERE ClockDBID = @ClockDBID and CreateUser = @CreateUser and CompanyID = @CompanyID
end


