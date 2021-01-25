USE [BlueStarGroup]
GO

alter Proc LockDBCompanyInsert
           @ClockDBID varchar(50),
           @CompanyID varchar(50),
           @ClockDBDate datetime,
           @ClockDBNote nvarchar(max),
           @ClockStatus bit,
           @CreateUser varchar(50)
as
begin
INSERT INTO [dbo].[LockDBCompany]
				(ClockDBID
				,CompanyID
				,ClockDBDate
				,ClockDBNote
				,ClockStatus
				,CreateUser
				,CreateDate)
     VALUES
              (@ClockDBID,
			   @CompanyID,
			   @ClockDBDate,
			   @ClockDBNote,
			   @ClockStatus,
			   @CreateUser ,
			   getdate())
end