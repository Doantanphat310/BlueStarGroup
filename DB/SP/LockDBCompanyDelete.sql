USE [BlueStarGroup]
GO

Create Proc LockDBCompanyDelete
           @ClockDBID varchar(50),
           @CompanyID varchar(50),
           @CreateUser varchar(50),
           @IsDelete bit
as
begin
	UPDATE LockDBCompany
   SET 
		 CompanyID = @CompanyID
		,UpdateUser = @CreateUser
		,UpdateDate = getdate()
		,IsDelete = @IsDelete
 WHERE ClockDBID = @ClockDBID and CreateUser = @CreateUser and CompanyID = @CompanyID
end




