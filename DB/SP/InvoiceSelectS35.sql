alter PROCEDURE [dbo].[InvoiceSelectS35] (
	@StartDate Datetime,
	@EndDate Datetime,
	@CompanyID varchar(50)
)
AS	
	begin
		select * from Invoice 
		Where CompanyID = @CompanyID 
		and InvoiceDate >= @StartDate and InvoiceDate <= @EndDate
		and S35Type = 1
		and (IsDelete is Null)
	end
		
